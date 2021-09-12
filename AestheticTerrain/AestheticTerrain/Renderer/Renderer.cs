using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace AestheticTerrain {
    class Renderer {
        public Renderer() {

        }

        public Bitmap Render(State s) {
            // Create GL context
            GameWindow win = new GameWindow(GameWindowSettings.Default, new NativeWindowSettings() { Size = s.ImgResolution.AsVector(), Title = "Invisible." });
            win.IsVisible = false;
            win.MakeCurrent();

            // Draw Background
            GL.ClearColor(Color.FromArgb(s.BgSunColour.X, s.BgSunColour.Y, s.BgSunColour.Z));
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // Draw Mesh

            // Move rendered frame into bitmap
            GL.Flush();
            var bitmap = new Bitmap(s.ImgResolution.Width, s.ImgResolution.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            BitmapData mem = bitmap.LockBits(new Rectangle(0, 0, s.ImgResolution.Width, s.ImgResolution.Height), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.PixelStore(PixelStoreParameter.PackRowLength, mem.Stride / 4);
            GL.ReadPixels(0, 0, s.ImgResolution.Width, s.ImgResolution.Height, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, mem.Scan0);
            bitmap.UnlockBits(mem);

            // Destroy GL context

            // Return final product
            return bitmap;
        }
    }
}
