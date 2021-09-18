using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void imageType_SelectedIndexChanged(object sender, EventArgs e) {
            // I am aware that this can cause problems in the future,
            // but as long as the order specified in the form
            // is the same as the order of values in the enum, there should be no problem.
            
        }

        private void cameraXValue_ValueChanged(object sender, EventArgs e) {
            var prevPos = _renderer.CameraPosition;
            _renderer.CameraPosition = new Vector3((float)cameraXValue.Value, prevPos.Y, prevPos.Z);
        }

        private void cameraYValue_ValueChanged(object sender, EventArgs e) {
            var prevPos = _renderer.CameraPosition;
            _renderer.CameraPosition = new Vector3((float)cameraXValue.Value, prevPos.Y, prevPos.Z);
        }

        private void cameraZValue_ValueChanged(object sender, EventArgs e) {
            var prevPos = _renderer.CameraPosition;
            _renderer.CameraPosition = new Vector3((float)cameraXValue.Value, prevPos.Y, prevPos.Z);
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
            previewImage.Image = _renderer.Render();
        }

        private void imageRenderButton_Click(object sender, EventArgs e) {

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
