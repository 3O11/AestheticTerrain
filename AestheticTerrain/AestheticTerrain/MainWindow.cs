﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using OpenTK.Mathematics;

namespace AestheticTerrain {
    public partial class MainWindow : Form {
        public MainWindow() {
            InitializeComponent();
            this.Text = "AestheticTerrain";
            this.Icon = new Icon("Assets/06-icon.ico");

            loadFormStateFromFile("Assets/07-terrainState.ats");

            logBox.Text = "Setting up default values and Initializing renderer.\n";

            _renderer.Width = 1280;
            _renderer.Height = 720;
            _renderer.InitContext();

            FormClosing += window_Closing;
        }

        private void loadFormStateFromFile(string filepath) {
            if (_renderer.IsContextCreated()) _renderer.DestroyContext();

            Serializer.Deserialize(
                filepath,
                out ImageMetadata metadata,
                out _renderer,
                out _terrainGenerator,
                out _backgroundGenerator
            );

            _renderer.InitContext();

            imageName.Text = metadata.ImageName;
            imageType.SelectedIndex = metadata.ImageTypeIndex;

            syncFormWithState();
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

        private void syncFormWithState() {
            // Image values

            //imageName.Text = "01-out";
            //imageType.SelectedIndex = 0;

            // Renderer
            imageWidth.Value = _renderer.Width;
            imageHeight.Value = _renderer.Height;
            cameraXValue.Value = (decimal)_renderer.CameraPosition.X;
            cameraYValue.Value = (decimal)_renderer.CameraPosition.Y;
            cameraZValue.Value = (decimal)_renderer.CameraPosition.Z;
            cameraYaw.Value = (decimal)_renderer.CameraYaw;
            cameraPitch.Value = (decimal)_renderer.CameraPitch;
            cameraFov.Value = (decimal)_renderer.CameraFov;
            terrainEnabled.Checked = true;
            backgroundEnabled.Checked = true;

            // Terrain values
            noiseSeed.Value = _terrainGenerator.NoiseSeed;
            noiseFrequency.Value = _terrainGenerator.Frequency;
            noiseAmplitude.Value = _terrainGenerator.Multiplier;
            terrainScale.Value = (decimal)_terrainGenerator.Scale;
            lowerCutoff.Value = (decimal)_terrainGenerator.LowerCutoff;
            upperCutoff.Value = (decimal)_terrainGenerator.UpperCutoff;
            frontColourButton.BackColor = _terrainGenerator.FrontColour;
            backColourButton.BackColor = _terrainGenerator.BackColour;
            quadraticMultiplierEnabled.Checked = true;
            xQuad.Value = (decimal)_terrainGenerator.FuncMultiplier.xQuad;
            zQuad.Value = (decimal)_terrainGenerator.FuncMultiplier.yQuad;
            xzLin.Value = (decimal)_terrainGenerator.FuncMultiplier.xyLin;
            xLin.Value = (decimal)_terrainGenerator.FuncMultiplier.xLin;
            zLin.Value = (decimal)_terrainGenerator.FuncMultiplier.yLin;
            Const.Value = (decimal)_terrainGenerator.FuncMultiplier.Const;
            clampFunction.Checked = false;
            upperClamp.Enabled = false;
            upperClamp.Value = (decimal)_terrainGenerator.FuncMultiplier.TopClamp;
            lowerClamp.Enabled = false;
            lowerClamp.Value = (decimal)_terrainGenerator.FuncMultiplier.BottomClamp;

            //Bagkcgound options
            sunPositionX.Value = (decimal)_backgroundGenerator.SunPosition.X;
            sunPositionY.Value = (decimal)_backgroundGenerator.SunPosition.Y;
            sunRadius.Value = _backgroundGenerator.SunRadius;
            sunGlowRadius.Value = _backgroundGenerator.SunGlowRadius;
            sunColour.BackColor = _backgroundGenerator.SunColour;
            sunGlowColour.BackColor = _backgroundGenerator.SunGlowColour;
            starSeed.Value = _backgroundGenerator.StarSeed;
            starCount.Value = _backgroundGenerator.StarCount;
            minStarDistance.Value = (decimal)_backgroundGenerator.MinStarDistance;
            starRadius.Value = _backgroundGenerator.StarRadius;
            starGlowRadius.Value = _backgroundGenerator.StarGlowRadius;
            starColour.BackColor = _backgroundGenerator.StarColour;
            starGlowColour.BackColor = _backgroundGenerator.StarGlowColour;
            topBackgroundColour.BackColor = _backgroundGenerator.TopColour;
            bottomBackgroundColour.BackColor = _backgroundGenerator.BottomColour;
        }

        // Image Options

        private void imageWidth_ValueChanged(object sender, EventArgs e) {
            _renderer.Width = (int)imageWidth.Value;
            _backgroundGenerator.BackgroundWidth = (int)imageWidth.Value;
        }

        private void imageHeight_ValueChanged(object sender, EventArgs e) {
            _renderer.Height = (int)imageHeight.Value;
            _backgroundGenerator.BackgroundHeight = (int)imageHeight.Value;
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
            _backgroundGenerator.SunPosition = new Vector2((float)sunPositionX.Value, _backgroundGenerator.SunPosition.Y);
        }

        private void sunPositionY_ValueChanged(object sender, EventArgs e) {
            _backgroundGenerator.SunPosition = new Vector2(_backgroundGenerator.SunPosition.X, (float)sunPositionY.Value);
        }

        private void sunRadius_ValueChanged(object sender, EventArgs e) {
            _backgroundGenerator.SunRadius = (int)sunRadius.Value;
        }

        private void sunGlowRadius_ValueChanged(object sender, EventArgs e) {
            _backgroundGenerator.SunGlowRadius = (int)sunGlowRadius.Value;
        }

        private void sunColour_Click(object sender, EventArgs e) {
            sunColour.BackColor = Utils.GetColourFromDialog();
        }

        private void sunColour_BackColorChanged(object sender, EventArgs e) {
            _backgroundGenerator.SunColour = sunColour.BackColor;
        }

        private void sunGlowColour_Click(object sender, EventArgs e) {
            sunGlowColour.BackColor = Utils.GetColourFromDialog();
        }

        private void sunGlowColour_BackColorChanged(object sender, EventArgs e) {
            _backgroundGenerator.SunGlowColour = sunGlowColour.BackColor;
        }

        private void starSeed_ValueChanged(object sender, EventArgs e) {
            _backgroundGenerator.StarSeed = (int)starSeed.Value;
        }

        private void starCount_ValueChanged(object sender, EventArgs e) {
            _backgroundGenerator.StarCount = (int)starCount.Value;
        }

        private void minStarDistance_ValueChanged(object sender, EventArgs e) {
            _backgroundGenerator.MinStarDistance = (float)minStarDistance.Value;
        }

        private void starRadius_ValueChanged(object sender, EventArgs e) {
            _backgroundGenerator.StarRadius = (int)starRadius.Value;
        }

        private void starGlowRadius_ValueChanged(object sender, EventArgs e) {
            _backgroundGenerator.StarGlowRadius = (int)starGlowRadius.Value;
        }

        private void starColour_Click(object sender, EventArgs e) {
            starColour.BackColor = Utils.GetColourFromDialog();
        }

        private void starColour_BackColorChanged(object sender, EventArgs e) {
            _backgroundGenerator.StarColour = starColour.BackColor;
        }

        private void starGlowColour_Click(object sender, EventArgs e) {
            starGlowColour.BackColor = Utils.GetColourFromDialog();
        }

        private void starGlowColour_BackColorChanged(object sender, EventArgs e) {
            _backgroundGenerator.StarGlowColour = starGlowColour.BackColor;
        }

        private void topBackgroundColour_Click(object sender, EventArgs e) {
            topBackgroundColour.BackColor = Utils.GetColourFromDialog();
        }

        private void topBackgroundColour_BackColorChanged(object sender, EventArgs e) {
            _backgroundGenerator.TopColour = topBackgroundColour.BackColor;
        }

        private void bottomBackgroundColour_Click(object sender, EventArgs e) {
            bottomBackgroundColour.BackColor = Utils.GetColourFromDialog();
        }

        private void bottomBackgroundColour_BackColorChanged(object sender, EventArgs e) {
            _backgroundGenerator.BottomColour = bottomBackgroundColour.BackColor;
        }

        // Terrain Options

        private void noiseSeed_ValueChanged(object sender, EventArgs e) {
            _terrainGenerator.NoiseSeed = (int)noiseSeed.Value;
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
            frontColourButton.BackColor = Utils.GetColourFromDialog();
        }

        private void frontColourButton_BackColorChanged(object sender, EventArgs e) {
            _terrainGenerator.FrontColour = frontColourButton.BackColor;
        }

        private void backColourButton_Click(object sender, EventArgs e) {
            backColourButton.BackColor = Utils.GetColourFromDialog();
        }

        private void backColourButton_BackColorChanged(object sender, EventArgs e) {
            _terrainGenerator.BackColour = backColourButton.BackColor;
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
            _backgroundGenerator.BackgroundWidth = previewImage.Width;
            _backgroundGenerator.BackgroundHeight = previewImage.Height;

            Mesh terrain = terrainEnabled.Checked ? _terrainGenerator.GenerateTerrain() : null;
            Bitmap background = backgroundEnabled.Checked ? _backgroundGenerator.GenerateBackground() : null;
            previewImage.Image = _renderer.Render(terrain, background);

            _renderer.Width = (int)imageWidth.Value;
            _renderer.Height = (int)imageHeight.Value;
            _backgroundGenerator.BackgroundWidth = (int)imageWidth.Value;
            _backgroundGenerator.BackgroundHeight = (int)imageHeight.Value;

            logBox.Text = "Preview rendered.\n";
        }

        private void imageRenderButton_Click(object sender, EventArgs e) {
            prepareQuadratic();

            if (!Utils.IsValidFilename(imageName.Text)) {
                logBox.Text = "The image name is not a valid filename, aborting operation!\n";
                return;
            }

            string imageDir = Utils.GetDir();
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
            Serializer.Serialize(
                Serializer.GetSavepathFromDialog(),
                new ImageMetadata() { ImageName = imageName.Text, ImageTypeIndex = imageType.SelectedIndex }, 
                _renderer,
                _terrainGenerator,
                _backgroundGenerator
            );
        }

        private void presetLoadButton_Click(object sender, EventArgs e) {
            loadFormStateFromFile(Serializer.GetOpenpathFromDialog());
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
