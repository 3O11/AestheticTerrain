using System.Drawing;
using System.Drawing.Imaging;
using OpenTK.Graphics.OpenGL4;


namespace AestheticTerrain {
    class Texture {
        public Texture(string filepath) {
            Bitmap texture = new Bitmap(filepath);
            BitmapData rawTexture = texture.LockBits(
                new Rectangle(0, 0, texture.Width, texture.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb
            );

            _textureID = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2DMultisample, _textureID);
            GL.TexStorage2DMultisample(
                TextureTargetMultisample2d.Texture2DMultisample,
                8,
                SizedInternalFormat.Rgba8,
                texture.Width,
                texture.Height,
                false
            );

            GL.TexImage2D(
                TextureTarget.Texture2D,
                0,
                PixelInternalFormat.Rgba,
                texture.Width,
                texture.Height,
                0,
                OpenTK.Graphics.OpenGL4.PixelFormat.Bgra,
                PixelType.UnsignedByte,
                rawTexture.Scan0
            );

            GL.TexParameterI(
                TextureTarget.Texture2D,
                TextureParameterName.TextureMinFilter,
                new int[] {
                    (int)TextureMagFilter.Linear,
                    (int)TextureMinFilter.Linear,
                    (int)TextureWrapMode.Repeat,
                }
            );

            GL.BindTexture(TextureTarget.Texture2D, 0);

            texture.UnlockBits(rawTexture);
            texture.Dispose();
        }

        public Texture(Bitmap image) {
            BitmapData rawTexture = image.LockBits(
                new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb
            );

            _textureID = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, _textureID);

            GL.TexImage2D(
                TextureTarget.Texture2D,
                0,
                PixelInternalFormat.Rgba,
                image.Width,
                image.Height,
                0,
                OpenTK.Graphics.OpenGL4.PixelFormat.Bgra,
                PixelType.UnsignedByte,
                rawTexture.Scan0
            );

            GL.TexParameterI(
                TextureTarget.Texture2D,
                TextureParameterName.TextureMinFilter,
                new int[] {
                    (int)TextureMagFilter.Linear,
                    (int)TextureMinFilter.Linear,
                    (int)TextureWrapMode.Repeat,
                }
            );

            GL.BindTexture(TextureTarget.Texture2D, 0);

            image.UnlockBits(rawTexture);
        }

        public void Bind(int slot) {
            GL.ActiveTexture((TextureUnit)((int)TextureUnit.Texture0 + slot));
            GL.BindTexture(TextureTarget.Texture2D, _textureID);
        }

        public void Destroy() {
            GL.DeleteTexture(_textureID);
        }

        int _textureID;
    }
}
