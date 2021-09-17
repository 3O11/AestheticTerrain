﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            GL.BindTexture(TextureTarget.Texture2D, _textureID);

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