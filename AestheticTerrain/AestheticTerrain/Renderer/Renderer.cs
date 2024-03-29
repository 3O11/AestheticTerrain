﻿using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace AestheticTerrain {
    class Renderer {
        public Renderer() {
            _camera = new Camera(new Vector3(0, 10, 0), 16.0f / 9.0f);
        }

        public Bitmap Render(Mesh terrain, Bitmap background) {
            GL.ClearColor(Color.FromArgb(80, 120, 255));
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            if (background != null) {
                _backgroundShader.Bind();

                Texture backgroundTex = new Texture(background);
                backgroundTex.Bind(0);
                _backgroundShader.SetUniform1i("u_Texture", 0);

                _backgroundMesh.Bind();

                GL.DrawElements(PrimitiveType.Triangles, _backgroundMesh.GetIndexCount(), DrawElementsType.UnsignedInt, 0);

                backgroundTex.Destroy();
                background.Dispose();
            }
            if (terrain != null) {
                _terrainTexture.Bind(0);
                _terrainShader.Bind();

                _terrainShader.SetUniformMat4f("u_View", _camera.GetViewMatrix());
                _terrainShader.SetUniformMat4f("u_Projection", _camera.GetProjectionMatrix());
                _terrainShader.SetUniformMat4f("u_Model", terrain.Transform);
                _terrainShader.SetUniform1i("u_Texture", 0);

                terrain.Bind();
                GL.DrawElements(BeginMode.Triangles, terrain.GetIndexCount(), DrawElementsType.UnsignedInt, 0);
                GL.Flush();

                terrain.Destroy();
            }

            // Return final product
            return createImage();
        }

        /// <summary>
        /// Initializes an invisible window which serves as the target for all OpenGL calls.
        /// Must be called before trying to call the Render() method!
        /// </summary>
        /// <param name="res"> The initial window resolution. </param>
        public void InitContext() {

            var gameWindowSettings = new GameWindowSettings();
            var nativeWindowSettings = new NativeWindowSettings() {
                Size = new Vector2i(Width, Height),
                Title = "Invisible."
            };
            nativeWindowSettings.NumberOfSamples = 16;

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

            _terrainShader = new Shader("Assets/01-vert.glsl", "Assets/02-frag.glsl");
            _terrainTexture = new Texture("Assets/03-terrainTile.jpeg");
            _backgroundShader = new Shader("Assets/04-vert.glsl", "Assets/05-frag.glsl");

            Vertex[] backgroundVertices = {
                new Vertex { Position = new Vector3( -1.0f, -1.0f,  1.0f ), TexCoords = new Vector2(0.0f, 0.0f) },
                new Vertex { Position = new Vector3(  1.0f, -1.0f,  1.0f ), TexCoords = new Vector2(1.0f, 0.0f) },
                new Vertex { Position = new Vector3(  1.0f,  1.0f,  1.0f ), TexCoords = new Vector2(1.0f, 1.0f) },
                new Vertex { Position = new Vector3( -1.0f,  1.0f,  1.0f ), TexCoords = new Vector2(0.0f, 1.0f) },
            };
            int[] backgroundIndices = { 0, 1, 2, 2, 3, 0 };
            _backgroundMesh = new Mesh(backgroundVertices, backgroundIndices);
            
        }

        public bool IsContextCreated() {
            return (_renderWindow != null);
        }

        /// <summary>
        /// Closes the invisible window, should be called when all the Render() calls are done and the renderer is
        /// not needed anymore.
        /// </summary>
        public void DestroyContext() {
            _terrainShader.Destroy();
            _terrainTexture.Destroy();
            _backgroundShader.Destroy();
            _backgroundMesh.Destroy();

            _renderWindow.Close();
            _renderWindow.Dispose();
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
            get {
                return _width;
            }
            set {
                _width = value;
                _camera.AspectRatio = (float)_width / _height;
                if (_renderWindow != null) {
                    _renderWindow.Size = new Vector2i(_width, _height);
                    GL.Viewport(0, 0, _width, _height);
                }  
            }
        }
        int _height;
        public int Height {
            get {
                return _height;
            }
            set {
                _height = value;
                _camera.AspectRatio = (float)_width / _height;
                if (_renderWindow != null) {
                    _renderWindow.Size = new Vector2i(_width, _height);
                    GL.Viewport(0, 0, _width, _height);
                }
            }
        }
        public Vector3 CameraPosition {
            get => _camera.Position;
            set => _camera.Position = value;
        }
        public float CameraYaw {
            get => _camera.Yaw;
            set => _camera.Yaw = value;
        }
        public float CameraPitch {
            get => _camera.Pitch;
            set => _camera.Pitch = value;
        }
        public float CameraFov {
            get => _camera.Fov;
            set => _camera.Fov = value;
        }
        
        GameWindow _renderWindow;
        Camera _camera;
        Texture _terrainTexture;
        Shader _terrainShader;
        Shader _backgroundShader;
        Mesh _backgroundMesh;
    }
}
