using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;
using System.Diagnostics;

namespace AestheticTerrain {
    class Renderer {
        public Renderer() {
            _camera = new Camera(new Vector3(0, 10, 0), 16.0f / 9.0f);
        }

        public Bitmap Render() {
            GL.ClearColor(Color.FromArgb(80, 120, 255));
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Texture terrainTexture = new Texture("Assets/03-terrainTile.jpeg");
            terrainTexture.Bind(0);

            Shader shader = new Shader("Assets/01-vert.glsl", "Assets/02-frag.glsl");
            shader.Bind();

            shader.SetUniformMat4f("u_View", _camera.GetViewMatrix());
            shader.SetUniformMat4f("u_Projection", _camera.GetProjectionMatrix());
            Matrix4 transform = Matrix4.CreateScale(5, 1, 5);
            shader.SetUniformMat4f("u_Model", transform);
            shader.SetUniform1i("u_Texture", 0);


            Mesh terrain = TerrainGenerator.GenerateTerrain(100, TerrainSeed, TerrainFrequency, TerrainMultiplier);
            terrain.Bind();
            GL.DrawElements(BeginMode.Triangles, terrain.GetIndexCount(), DrawElementsType.UnsignedInt, 0);
            GL.Flush();


            terrainTexture.Destroy();
            shader.Destroy();
            terrain.Destroy();

            // Return final product
            return createImage();
        }

        /// <summary>
        /// Initializes an invisible window which serves as the target for all OpenGL calls.
        /// Must be called before trying to call the Render() method!
        /// </summary>
        /// <param name="res"> The initial window resolution. </param>
        public void InitContext(int width, int height) {
            Width = width;
            Height = height;

            var gameWindowSettings = GameWindowSettings.Default;
            var nativeWindowSettings = new NativeWindowSettings() {
                Size = new Vector2i(Width, Height),
                Title = "Invisible."
            };

            _renderWindow = new GameWindow(gameWindowSettings, nativeWindowSettings);
            _renderWindow.IsVisible = false;

            GL.Enable(EnableCap.DebugOutput);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Enable(EnableCap.CullFace);
            GL.DepthMask(true);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);
            GL.Enable(EnableCap.Multisample);
        }

        /// <summary>
        /// Closes the invisible window, should be called when all the Render() calls are done and the renderer is
        /// not needed anymore.
        /// </summary>
        public void DestroyContext() {
            _renderWindow.Close();
            _renderWindow.Dispose();
        }

        Bitmap createBackground() {
            Bitmap background = new Bitmap(Width, Height);

            using (Graphics g = Graphics.FromImage(background)) {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.FillRectangle(Brushes.White, new Rectangle(0, 0, Width, Height));
            }

            return background;
        }

        Bitmap createImage() {
            var canvasSize = _renderWindow.Size;

            var bitmap = new Bitmap(canvasSize.X, canvasSize.Y, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            BitmapData mem = bitmap.LockBits(new Rectangle(0, 0, canvasSize.X, canvasSize.Y), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.PixelStore(PixelStoreParameter.PackRowLength, mem.Stride / 4);
            GL.ReadPixels(0, 0, canvasSize.X, canvasSize.Y, OpenTK.Graphics.OpenGL4.PixelFormat.Bgra, PixelType.UnsignedByte, mem.Scan0);
            bitmap.UnlockBits(mem);

            bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);

            return bitmap;
        }

        // Image Options
        int _width;
        public int Width {
            private get {
                return _width;
            }
            set {
                _width = value;
                _camera.AspectRatio = (float)_width / _height;
                if (_renderWindow != null)
                    _renderWindow.Size = new Vector2i(_width, _height);
            }
        }
        int _height;
        public int Height {
            private get {
                return _height;
            }
            set {
                _height = value;
                _camera.AspectRatio = (float)_width / _height;
                if (_renderWindow != null)
                    _renderWindow.Size = new Vector2i(_width, _height);
            }
        }
        public Vector3 CameraPosition {
            get => _camera.Position;
            set => _camera.Position = value;
        }
        public float CameraYaw {
            set => _camera.Yaw = value;
        }
        public float CameraPitch {
            set => _camera.Pitch = value;
        }
        public float CameraFov {
            set => _camera.Fov = value;
        }

        public int TerrainSeed { get; set; }
        public int TerrainMultiplier { get; set; }
        public int TerrainFrequency { get; set; }
        public Vector3i TerrainFrontColour { get; set; }
        public Vector3i TerrainBackColour { get; set; }
        public float TerrainLowerCutoff { get; set; }
        public float TerrainUpperCutoff { get; set; }
        public float TerrainFlattenCenterMult { get; set; }
        
        GameWindow _renderWindow;
        Camera _camera;
    }
}
