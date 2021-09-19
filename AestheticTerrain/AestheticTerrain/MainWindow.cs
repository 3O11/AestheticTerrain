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
    public partial class MainWindow : Form {
        public MainWindow() {
            InitializeComponent();
            this.Text = "AestheticTerrain";

            initTooltips();

            imageWidth.Value = 1280;
            imageHeight.Value = 720;
            cameraXValue.Value = -80;
            cameraYValue.Value = 5;
            cameraFov.Value = 70;
            cameraYaw.Value = 0;
            cameraPitch.Value = 0;
            noiseSeed.Value = 3011;
            noiseFrequency.Value = 15;
            noiseAmplitude.Value = 1;
            terrainScale.Value = 3;
            lowerCutoff.Value = -100;
            upperCutoff.Value = 100;
            frontColourButton.BackColor = Color.FromArgb(255, 60, 255);
            backColourButton.BackColor = Color.FromArgb(60, 255, 255);
            terrainEnabled.Checked = true;
            backgroundEnabled.Checked = true;
            quadraticMultiplierEnabled.Checked = true;
            quadraticMultiplierEnabled.Checked = false;

            logBox.Text = "Setting up default values and Initializing renderer.\n";

            _renderer.InitContext((int)imageWidth.Value, (int)imageHeight.Value);

            FormClosing += window_Closing;
        }

        private void prepareQuadratic() {
            if (quadraticMultiplierEnabled.Checked) {
                var quadratic = _terrainGenerator.FuncMultiplier;
                quadratic.xQuad = (float)xQuad.Value;
                quadratic.yQuad = (float)zQuad.Value;
                quadratic.xyLin = (float)xzLin.Value;
                quadratic.xLin = (float)xLin.Value;
                quadratic.yLin = (float)zLin.Value;
                quadratic.Const = (float)Const.Value;

                if (clampFunction.Checked) {
                    quadratic.Clamp = true;
                    quadratic.TopClamp = (float)upperClamp.Value;
                    quadratic.BottomClamp = (float)lowerClamp.Value;
                }
                else {
                    quadratic.Clamp = false;
                }
            }
            else {
                _terrainGenerator.FuncMultiplier = new Quadratic2D(0, 0, 1);
            }
        }

        // Image Options

        private void imageWidth_ValueChanged(object sender, EventArgs e) {
            _renderer.Width = (int)imageWidth.Value;
            _backgroundGenerator.Width = (int)imageWidth.Value;
        }

        private void imageHeight_ValueChanged(object sender, EventArgs e) {
            _renderer.Height = (int)imageHeight.Value;
            _backgroundGenerator.Height = (int)imageHeight.Value;
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

        private void sunPositionX_ValueChanged(object sender, EventArgs e) {

        }

        private void sunPositionY_ValueChanged(object sender, EventArgs e) {

        }

        private void sunRadius_ValueChanged(object sender, EventArgs e) {

        }

        private void sunGlowRadius_ValueChanged(object sender, EventArgs e) {

        }

        private void sunColour_Click(object sender, EventArgs e) {

        }

        private void sunGlowColour_Click(object sender, EventArgs e) {

        }

        private void starSeed_ValueChanged(object sender, EventArgs e) {

        }

        private void starCount_ValueChanged(object sender, EventArgs e) {

        }

        private void starRadius_ValueChanged(object sender, EventArgs e) {

        }

        private void starGlowRadius_ValueChanged(object sender, EventArgs e) {

        }

        private void starColour_Click(object sender, EventArgs e) {

        }

        private void starGlowColour_Click(object sender, EventArgs e) {

        }

        // Terrain Options

        private void noiseSeed_ValueChanged(object sender, EventArgs e) {
            _terrainGenerator.Seed = (int)noiseSeed.Value;
            _backgroundGenerator.Seed = (int)noiseSeed.Value;
        }

        private void noiseFrequency_ValueChanged(object sender, EventArgs e) {
            _terrainGenerator.Frequency = (int)noiseFrequency.Value;
        }

        private void noiseAmplitude_ValueChanged(object sender, EventArgs e) {
            _terrainGenerator.Multiplier = (int)noiseAmplitude.Value;
        }

        private void terrainScale_ValueChanged(object sender, EventArgs e) {
            _terrainGenerator.Scale = (float)terrainScale.Value;
        }

        private void frontColourButton_Click(object sender, EventArgs e) {
            frontColourButton.BackColor = ColourHelper.GetColourFromDialog();
        }

        private void frontColourButton_BackColorChanged(object sender, EventArgs e) {
            _terrainGenerator.FrontColour = ColourHelper.ConvertToVector(frontColourButton.BackColor);
        }

        private void backColourButton_Click(object sender, EventArgs e) {
            backColourButton.BackColor = ColourHelper.GetColourFromDialog();
        }

        private void backColourButton_BackColorChanged(object sender, EventArgs e) {
            _terrainGenerator.BackColour = ColourHelper.ConvertToVector(backColourButton.BackColor);
        }

        private void upperCutoff_ValueChanged(object sender, EventArgs e) {
            _terrainGenerator.UpperCutoff = (float)upperCutoff.Value;
        }

        private void lowerCutoff_ValueChanged(object sender, EventArgs e) {
            _terrainGenerator.LowerCutoff = (float)lowerCutoff.Value;
        }

        private void quadraticMultiplierEnabled_CheckedChanged(object sender, EventArgs e) {
            bool newState = quadraticMultiplierEnabled.Checked;
            xQuad.Enabled = newState;
            zQuad.Enabled = newState;
            xzLin.Enabled = newState;
            xLin.Enabled = newState;
            zLin.Enabled = newState;
            Const.Enabled = newState;
            clampFunction.Enabled = newState;
            upperClamp.Enabled = newState;
            lowerClamp.Enabled = newState;
        }

        private void clampFunction_CheckedChanged(object sender, EventArgs e) {
            bool newState = clampFunction.Checked;
            upperClamp.Enabled = newState;
            lowerClamp.Enabled = newState;
        }

        // General Options

        private void previewRenderButton_Click(object sender, EventArgs e) {
            prepareQuadratic();

            // The preview image can have very different size from the actual rendered image,
            // so we need to temporarily update the renderer with a different size to avoid problems.
            _renderer.Width = previewImage.Width;
            _renderer.Height = previewImage.Height;
            _backgroundGenerator.Width = previewImage.Width;
            _backgroundGenerator.Height = previewImage.Height;

            Mesh terrain = terrainEnabled.Checked ? _terrainGenerator.GenerateTerrain() : null;
            Bitmap background = backgroundEnabled.Checked ? _backgroundGenerator.GenerateBackground() : null;
            previewImage.Image = _renderer.Render(terrain, background);

            _renderer.Width = (int)imageWidth.Value;
            _renderer.Height = (int)imageHeight.Value;
            _backgroundGenerator.Width = (int)imageWidth.Value;
            _backgroundGenerator.Height = (int)imageHeight.Value;

            logBox.Text = "Preview rendered.\n";
        }

        private void imageRenderButton_Click(object sender, EventArgs e) {
            prepareQuadratic();

            if (!Paths.IsValidFilename(imageName.Text)) {
                logBox.Text = "The image name is not a valid filename, aborting operation!\n";
                return;
            }

            string imageDir = Paths.GetDir();
            if (imageDir == "") {
                logBox.Text = "The image folder is not selected, aborting operation!\n";
                return;
            }

            string imagePath = imageDir + "/" + imageName.Text;
            Mesh terrain = terrainEnabled.Checked ? _terrainGenerator.GenerateTerrain() : null;
            Bitmap background = backgroundEnabled.Checked ? _backgroundGenerator.GenerateBackground() : null;
            Bitmap renderedImage = _renderer.Render(terrain, background);

            switch (imageType.SelectedIndex) {
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

            logBox.Text = "The image was rendered and saved sucessfully!\n";

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
        TerrainGenerator _terrainGenerator = new TerrainGenerator();
        BackgroundGenerator _backgroundGenerator = new BackgroundGenerator();
    }
}
