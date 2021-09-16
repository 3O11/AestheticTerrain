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
            _camera = new Camera(new Vector3(-1, 5, -1), 16.0f / 9.0f);
        }

        public Bitmap Render(State s) {
            GL.ClearColor(Color.FromArgb(s.BgSunColour.X, s.BgSunColour.Y, s.BgSunColour.Z));
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Shader shader = new Shader("Assets/01_vs_basic.glsl", "Assets/01_fs_basic.glsl");
            shader.Bind();

            shader.SetUniformMat4f("u_View", _camera.GetViewMatrix());
            shader.SetUniformMat4f("u_Projection", _camera.GetProjectionMatrix());
            shader.SetUniformMat4f("u_Model", Matrix4.Identity);
            //shader.SetUniformMat4f("u_View", Matrix4.Identity);
            //shader.SetUniformMat4f("u_Projection", Matrix4.Identity);

            Vertex[] triangle = {
                new Vertex() { Position = new Vector3( -0.5f,  0.5f,  0.0f)},
                new Vertex() { Position = new Vector3( -0.5f, -0.5f,  0.0f)},
                new Vertex() { Position = new Vector3(  0.5f, -0.5f,  0.0f)},
            };

            int[] indices = {
                0, 1, 2,
            };

            Mesh triangleMesh = new Mesh(triangle, indices);
            triangleMesh.Bind();
            GL.DrawElements(BeginMode.Triangles, triangleMesh.GetIndexCount(), DrawElementsType.UnsignedInt, 0);

            Mesh terrain = Mesh.GeneratePlane(10);
            terrain.Bind();
            GL.DrawElements(BeginMode.Triangles, terrain.GetIndexCount(), DrawElementsType.UnsignedInt, 0);

            GL.Flush();
            _renderWindow.SwapBuffers();

            // Return final product
            return createImage();
        }

        /// <summary>
        /// Initializes an invisible window which serves as the target for all OpenGL calls.
        /// Must be called before trying to call the Render() method!
        /// </summary>
        /// <param name="res"> The initial window resolution. </param>
        public void InitContext(Resolution res) {
            var gameWindowSettings = GameWindowSettings.Default;
            var nativeWindowSettings = new NativeWindowSettings() {
                Size = res.AsVector(),
                Title = "Invisible."
            };

            _renderWindow = new GameWindow(gameWindowSettings, nativeWindowSettings);
            //_renderWindow.IsVisible = false;

            GL.Enable(EnableCap.DebugOutput);
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            GL.Enable(EnableCap.CullFace);
            GL.DepthMask(true);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);

        }

        /// <summary>
        /// Closes the invisible window, should be called when all the Render() calls are done and the renderer is
        /// not needed anymore.
        /// </summary>
        public void DestroyContext() {
            _renderWindow.Close();
            _renderWindow.Dispose();
        }

        void updateCanvasSize(Resolution res) {
            _renderWindow.Size = res.AsVector();
        }

        //Bitmap generateBackground(State s) {

        //}

        Bitmap createBackground(State s) {
            Bitmap background = new Bitmap(s.ImgResolution.Width, s.ImgResolution.Height);

            using (Graphics g = Graphics.FromImage(background)) {
                g.SmoothingMode = SmoothingMode.AntiAlias;

                g.FillRectangle(Brushes.White, new Rectangle(0, 0, s.ImgResolution.Width, s.ImgResolution.Height));
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

        GameWindow _renderWindow;
        Camera _camera;
    }
}
