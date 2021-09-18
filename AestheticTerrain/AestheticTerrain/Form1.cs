using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Mathematics;

namespace AestheticTerrain {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();

            imageWidth.Value = 1280;
            imageHeight.Value = 720;
            cameraYValue.Value = 10;
            cameraFov.Value = 90;

            _renderer.InitContext((int)imageWidth.Value, (int)imageHeight.Value);

            FormClosing += window_Closing;
        }

        // Image Options

        private void imageWidth_ValueChanged(object sender, EventArgs e) {
            //_state.ImgResolution.Width = (int)imageWidth.Value;
        }

        private void imageHeight_ValueChanged(object sender, EventArgs e) {
            //_state.ImgResolution.Height = (int)imageHeight.Value;
        }

        private void cameraXValue_ValueChanged(object sender, EventArgs e) {
            var prevPos = _renderer.CameraPosition;
            _renderer.CameraPosition = new Vector3((float)cameraXValue.Value, prevPos.Y, prevPos.Z);
        }

        private void cameraYValue_ValueChanged(object sender, EventArgs e) {
            var prevPos = _renderer.CameraPosition;
            _renderer.CameraPosition = new Vector3(prevPos.X, (float)cameraYValue.Value, prevPos.Z);
        }

        private void cameraZValue_ValueChanged(object sender, EventArgs e) {
            var prevPos = _renderer.CameraPosition;
            _renderer.CameraPosition = new Vector3(prevPos.X, prevPos.Y, (float)cameraZValue.Value);
        }

        private void cameraYaw_ValueChanged(object sender, EventArgs e) {
            _renderer.CameraYaw = (float)cameraYaw.Value;
        }

        private void cameraPitch_ValueChanged(object sender, EventArgs e) {
            _renderer.CameraPitch = (float)cameraPitch.Value;
        }

        private void cameraFov_ValueChanged(object sender, EventArgs e) {
            _renderer.CameraFov = (float)cameraFov.Value;
        }

        // Background Options


        // Terrain Options


        // General Options

        private void previewRenderButton_Click(object sender, EventArgs e) {
            // The preview image can have very different size from the actual rendered image,
            // so we need to temporarily update the renderer with a different size to avoid problems.
            _renderer.Width = previewImage.Width;
            _renderer.Height = previewImage.Height;

            previewImage.Image = _renderer.Render();

            _renderer.Width = (int)imageWidth.Value;
            _renderer.Height = (int)imageHeight.Value;
        }

        private void imageRenderButton_Click(object sender, EventArgs e) {
            string imagePath = Paths.GetDir() + "/001-render";
            Image renderedImage = _renderer.Render();
            
            switch(imageType.SelectedIndex) {
                case 0:
                    imagePath += ".png";
                    renderedImage.Save(imagePath, ImageFormat.Png);
                    break;
                case 1:
                    imagePath += ".jpg";
                    renderedImage.Save(imagePath, ImageFormat.Jpeg);
                    break;
                case 2:
                    imagePath += ".bmp";
                    renderedImage.Save(imagePath, ImageFormat.Bmp);
                    break;
                default:
                    imagePath += ".png";
                    renderedImage.Save(imagePath, ImageFormat.Png);
                    break;
            }

            renderedImage.Dispose();
        }

        private void presetSaveButton_Click(object sender, EventArgs e) {

        }

        private void presetLoadButton_Click(object sender, EventArgs e) {

        }

        private void window_Closing(object sender, EventArgs e) {
            _renderer.DestroyContext();
        }

        // Members
        Renderer _renderer = new Renderer();
    }
}
