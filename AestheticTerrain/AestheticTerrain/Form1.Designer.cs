﻿
namespace AestheticTerrain {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.topMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.options = new System.Windows.Forms.TabControl();
            this.imageOptions = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cameraFov = new System.Windows.Forms.NumericUpDown();
            this.fovLabel = new System.Windows.Forms.Label();
            this.cameraPitch = new System.Windows.Forms.NumericUpDown();
            this.cameraPitchLabel = new System.Windows.Forms.Label();
            this.cameraYaw = new System.Windows.Forms.NumericUpDown();
            this.cameraYawLabel = new System.Windows.Forms.Label();
            this.cameraZ = new System.Windows.Forms.Label();
            this.cameraYValue = new System.Windows.Forms.NumericUpDown();
            this.cameraZValue = new System.Windows.Forms.NumericUpDown();
            this.cameraY = new System.Windows.Forms.Label();
            this.cameraXValue = new System.Windows.Forms.NumericUpDown();
            this.cameraX = new System.Windows.Forms.Label();
            this.cameraPosition = new System.Windows.Forms.Label();
            this.generalImageOptions = new System.Windows.Forms.Label();
            this.cameraSettings = new System.Windows.Forms.Label();
            this.imageType = new System.Windows.Forms.ComboBox();
            this.imageTypeLabel = new System.Windows.Forms.Label();
            this.imageHeight = new System.Windows.Forms.NumericUpDown();
            this.imageWidth = new System.Windows.Forms.NumericUpDown();
            this.heightLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.resolutionLabel = new System.Windows.Forms.Label();
            this.terrainOptions = new System.Windows.Forms.TabPage();
            this.backgroundOptions = new System.Windows.Forms.TabPage();
            this.presetSaveButton = new System.Windows.Forms.Button();
            this.presetLoadButton = new System.Windows.Forms.Button();
            this.previewRenderButton = new System.Windows.Forms.Button();
            this.previewImage = new System.Windows.Forms.PictureBox();
            this.imageRenderButton = new System.Windows.Forms.Button();
            this.topMenu.SuspendLayout();
            this.options.SuspendLayout();
            this.imageOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraFov)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPitch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraYValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraZValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraXValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewImage)).BeginInit();
            this.SuspendLayout();
            // 
            // topMenu
            // 
            this.topMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.topMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.topMenu.Location = new System.Drawing.Point(0, 0);
            this.topMenu.Name = "topMenu";
            this.topMenu.Size = new System.Drawing.Size(1692, 28);
            this.topMenu.TabIndex = 0;
            this.topMenu.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.toolStripSeparator,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
            this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newToolStripMenuItem.Text = "&New";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
            this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(178, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
            this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveToolStripMenuItem.Text = "&Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(178, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
            this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.printToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
            this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(178, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.toolStripSeparator5,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.contentsToolStripMenuItem.Text = "&Contents";
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.indexToolStripMenuItem.Text = "&Index";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.searchToolStripMenuItem.Text = "&Search";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(147, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(150, 26);
            this.aboutToolStripMenuItem.Text = "&About...";
            // 
            // options
            // 
            this.options.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.options.Controls.Add(this.imageOptions);
            this.options.Controls.Add(this.terrainOptions);
            this.options.Controls.Add(this.backgroundOptions);
            this.options.Location = new System.Drawing.Point(1303, 31);
            this.options.Name = "options";
            this.options.SelectedIndex = 0;
            this.options.Size = new System.Drawing.Size(389, 724);
            this.options.TabIndex = 1;
            // 
            // imageOptions
            // 
            this.imageOptions.Controls.Add(this.label1);
            this.imageOptions.Controls.Add(this.cameraFov);
            this.imageOptions.Controls.Add(this.fovLabel);
            this.imageOptions.Controls.Add(this.cameraPitch);
            this.imageOptions.Controls.Add(this.cameraPitchLabel);
            this.imageOptions.Controls.Add(this.cameraYaw);
            this.imageOptions.Controls.Add(this.cameraYawLabel);
            this.imageOptions.Controls.Add(this.cameraZ);
            this.imageOptions.Controls.Add(this.cameraYValue);
            this.imageOptions.Controls.Add(this.cameraZValue);
            this.imageOptions.Controls.Add(this.cameraY);
            this.imageOptions.Controls.Add(this.cameraXValue);
            this.imageOptions.Controls.Add(this.cameraX);
            this.imageOptions.Controls.Add(this.cameraPosition);
            this.imageOptions.Controls.Add(this.generalImageOptions);
            this.imageOptions.Controls.Add(this.cameraSettings);
            this.imageOptions.Controls.Add(this.imageType);
            this.imageOptions.Controls.Add(this.imageTypeLabel);
            this.imageOptions.Controls.Add(this.imageHeight);
            this.imageOptions.Controls.Add(this.imageWidth);
            this.imageOptions.Controls.Add(this.heightLabel);
            this.imageOptions.Controls.Add(this.widthLabel);
            this.imageOptions.Controls.Add(this.resolutionLabel);
            this.imageOptions.Location = new System.Drawing.Point(4, 29);
            this.imageOptions.Name = "imageOptions";
            this.imageOptions.Padding = new System.Windows.Forms.Padding(3);
            this.imageOptions.Size = new System.Drawing.Size(381, 691);
            this.imageOptions.TabIndex = 0;
            this.imageOptions.Text = "Image Options";
            this.imageOptions.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 383);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 22;
            // 
            // cameraFov
            // 
            this.cameraFov.Location = new System.Drawing.Point(80, 340);
            this.cameraFov.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.cameraFov.Name = "cameraFov";
            this.cameraFov.Size = new System.Drawing.Size(75, 27);
            this.cameraFov.TabIndex = 21;
            this.cameraFov.ValueChanged += new System.EventHandler(this.cameraFov_ValueChanged);
            // 
            // fovLabel
            // 
            this.fovLabel.AutoSize = true;
            this.fovLabel.Location = new System.Drawing.Point(13, 342);
            this.fovLabel.Name = "fovLabel";
            this.fovLabel.Size = new System.Drawing.Size(37, 20);
            this.fovLabel.TabIndex = 20;
            this.fovLabel.Text = "FoV:";
            // 
            // cameraPitch
            // 
            this.cameraPitch.Location = new System.Drawing.Point(80, 307);
            this.cameraPitch.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.cameraPitch.Minimum = new decimal(new int[] {
            90,
            0,
            0,
            -2147483648});
            this.cameraPitch.Name = "cameraPitch";
            this.cameraPitch.Size = new System.Drawing.Size(75, 27);
            this.cameraPitch.TabIndex = 19;
            this.cameraPitch.ValueChanged += new System.EventHandler(this.cameraPitch_ValueChanged);
            // 
            // cameraPitchLabel
            // 
            this.cameraPitchLabel.AutoSize = true;
            this.cameraPitchLabel.Location = new System.Drawing.Point(13, 309);
            this.cameraPitchLabel.Name = "cameraPitchLabel";
            this.cameraPitchLabel.Size = new System.Drawing.Size(44, 20);
            this.cameraPitchLabel.TabIndex = 18;
            this.cameraPitchLabel.Text = "Pitch:";
            // 
            // cameraYaw
            // 
            this.cameraYaw.Location = new System.Drawing.Point(80, 274);
            this.cameraYaw.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.cameraYaw.Minimum = new decimal(new int[] {
            16384,
            0,
            0,
            -2147483648});
            this.cameraYaw.Name = "cameraYaw";
            this.cameraYaw.Size = new System.Drawing.Size(75, 27);
            this.cameraYaw.TabIndex = 17;
            this.cameraYaw.ValueChanged += new System.EventHandler(this.cameraYaw_ValueChanged);
            // 
            // cameraYawLabel
            // 
            this.cameraYawLabel.AutoSize = true;
            this.cameraYawLabel.Location = new System.Drawing.Point(13, 276);
            this.cameraYawLabel.Name = "cameraYawLabel";
            this.cameraYawLabel.Size = new System.Drawing.Size(38, 20);
            this.cameraYawLabel.TabIndex = 16;
            this.cameraYawLabel.Text = "Yaw:";
            // 
            // cameraZ
            // 
            this.cameraZ.AutoSize = true;
            this.cameraZ.Location = new System.Drawing.Point(242, 231);
            this.cameraZ.Name = "cameraZ";
            this.cameraZ.Size = new System.Drawing.Size(21, 20);
            this.cameraZ.TabIndex = 15;
            this.cameraZ.Text = "Z:";
            // 
            // cameraYValue
            // 
            this.cameraYValue.DecimalPlaces = 2;
            this.cameraYValue.Location = new System.Drawing.Point(161, 229);
            this.cameraYValue.Name = "cameraYValue";
            this.cameraYValue.Size = new System.Drawing.Size(75, 27);
            this.cameraYValue.TabIndex = 14;
            this.cameraYValue.ValueChanged += new System.EventHandler(this.cameraYValue_ValueChanged);
            // 
            // cameraZValue
            // 
            this.cameraZValue.DecimalPlaces = 2;
            this.cameraZValue.Location = new System.Drawing.Point(269, 229);
            this.cameraZValue.Name = "cameraZValue";
            this.cameraZValue.Size = new System.Drawing.Size(75, 27);
            this.cameraZValue.TabIndex = 13;
            this.cameraZValue.ValueChanged += new System.EventHandler(this.cameraZValue_ValueChanged);
            // 
            // cameraY
            // 
            this.cameraY.AutoSize = true;
            this.cameraY.Location = new System.Drawing.Point(135, 231);
            this.cameraY.Name = "cameraY";
            this.cameraY.Size = new System.Drawing.Size(20, 20);
            this.cameraY.TabIndex = 12;
            this.cameraY.Text = "Y:";
            // 
            // cameraXValue
            // 
            this.cameraXValue.DecimalPlaces = 2;
            this.cameraXValue.Location = new System.Drawing.Point(54, 229);
            this.cameraXValue.Name = "cameraXValue";
            this.cameraXValue.Size = new System.Drawing.Size(75, 27);
            this.cameraXValue.TabIndex = 11;
            this.cameraXValue.ValueChanged += new System.EventHandler(this.cameraXValue_ValueChanged);
            // 
            // cameraX
            // 
            this.cameraX.AutoSize = true;
            this.cameraX.Location = new System.Drawing.Point(27, 231);
            this.cameraX.Name = "cameraX";
            this.cameraX.Size = new System.Drawing.Size(21, 20);
            this.cameraX.TabIndex = 10;
            this.cameraX.Text = "X:";
            // 
            // cameraPosition
            // 
            this.cameraPosition.AutoSize = true;
            this.cameraPosition.Location = new System.Drawing.Point(13, 205);
            this.cameraPosition.Name = "cameraPosition";
            this.cameraPosition.Size = new System.Drawing.Size(61, 20);
            this.cameraPosition.TabIndex = 9;
            this.cameraPosition.Text = "Position";
            // 
            // generalImageOptions
            // 
            this.generalImageOptions.AutoSize = true;
            this.generalImageOptions.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.generalImageOptions.Location = new System.Drawing.Point(4, 4);
            this.generalImageOptions.Name = "generalImageOptions";
            this.generalImageOptions.Size = new System.Drawing.Size(194, 23);
            this.generalImageOptions.TabIndex = 8;
            this.generalImageOptions.Text = "General Image Options";
            // 
            // cameraSettings
            // 
            this.cameraSettings.AutoSize = true;
            this.cameraSettings.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.cameraSettings.Location = new System.Drawing.Point(4, 178);
            this.cameraSettings.Name = "cameraSettings";
            this.cameraSettings.Size = new System.Drawing.Size(142, 23);
            this.cameraSettings.TabIndex = 7;
            this.cameraSettings.Text = "Camera Settings";
            // 
            // imageType
            // 
            this.imageType.FormattingEnabled = true;
            this.imageType.Items.AddRange(new object[] {
            "PNG",
            "JPEG",
            "BMP"});
            this.imageType.Location = new System.Drawing.Point(108, 134);
            this.imageType.Name = "imageType";
            this.imageType.Size = new System.Drawing.Size(151, 28);
            this.imageType.TabIndex = 6;
            this.imageType.Text = "PNG";
            this.imageType.SelectedIndexChanged += new System.EventHandler(this.imageType_SelectedIndexChanged);
            // 
            // imageTypeLabel
            // 
            this.imageTypeLabel.AutoSize = true;
            this.imageTypeLabel.Location = new System.Drawing.Point(13, 137);
            this.imageTypeLabel.Name = "imageTypeLabel";
            this.imageTypeLabel.Size = new System.Drawing.Size(89, 20);
            this.imageTypeLabel.TabIndex = 5;
            this.imageTypeLabel.Text = "Image Type:";
            // 
            // imageHeight
            // 
            this.imageHeight.Location = new System.Drawing.Point(89, 92);
            this.imageHeight.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.imageHeight.Name = "imageHeight";
            this.imageHeight.Size = new System.Drawing.Size(86, 27);
            this.imageHeight.TabIndex = 4;
            this.imageHeight.ValueChanged += new System.EventHandler(this.imageHeight_ValueChanged);
            // 
            // imageWidth
            // 
            this.imageWidth.Location = new System.Drawing.Point(89, 59);
            this.imageWidth.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
            this.imageWidth.Name = "imageWidth";
            this.imageWidth.Size = new System.Drawing.Size(86, 27);
            this.imageWidth.TabIndex = 3;
            this.imageWidth.ValueChanged += new System.EventHandler(this.imageWidth_ValueChanged);
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(26, 94);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(57, 20);
            this.heightLabel.TabIndex = 2;
            this.heightLabel.Text = "Height:";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(26, 61);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(52, 20);
            this.widthLabel.TabIndex = 1;
            this.widthLabel.Text = "Width:";
            // 
            // resolutionLabel
            // 
            this.resolutionLabel.AutoSize = true;
            this.resolutionLabel.Location = new System.Drawing.Point(13, 36);
            this.resolutionLabel.Name = "resolutionLabel";
            this.resolutionLabel.Size = new System.Drawing.Size(79, 20);
            this.resolutionLabel.TabIndex = 0;
            this.resolutionLabel.Text = "Resolution";
            // 
            // terrainOptions
            // 
            this.terrainOptions.Location = new System.Drawing.Point(4, 29);
            this.terrainOptions.Name = "terrainOptions";
            this.terrainOptions.Padding = new System.Windows.Forms.Padding(3);
            this.terrainOptions.Size = new System.Drawing.Size(381, 691);
            this.terrainOptions.TabIndex = 1;
            this.terrainOptions.Text = "Terrain Options";
            this.terrainOptions.UseVisualStyleBackColor = true;
            // 
            // backgroundOptions
            // 
            this.backgroundOptions.Location = new System.Drawing.Point(4, 29);
            this.backgroundOptions.Name = "backgroundOptions";
            this.backgroundOptions.Padding = new System.Windows.Forms.Padding(3);
            this.backgroundOptions.Size = new System.Drawing.Size(381, 691);
            this.backgroundOptions.TabIndex = 2;
            this.backgroundOptions.Text = "Background Options";
            this.backgroundOptions.UseVisualStyleBackColor = true;
            // 
            // presetSaveButton
            // 
            this.presetSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.presetSaveButton.Location = new System.Drawing.Point(1594, 761);
            this.presetSaveButton.Name = "presetSaveButton";
            this.presetSaveButton.Size = new System.Drawing.Size(94, 29);
            this.presetSaveButton.TabIndex = 2;
            this.presetSaveButton.Text = "Save Preset";
            this.presetSaveButton.UseVisualStyleBackColor = true;
            this.presetSaveButton.Click += new System.EventHandler(this.presetSaveButton_Click);
            // 
            // presetLoadButton
            // 
            this.presetLoadButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.presetLoadButton.Location = new System.Drawing.Point(1594, 796);
            this.presetLoadButton.Name = "presetLoadButton";
            this.presetLoadButton.Size = new System.Drawing.Size(94, 29);
            this.presetLoadButton.TabIndex = 3;
            this.presetLoadButton.Text = "Load Preset";
            this.presetLoadButton.UseVisualStyleBackColor = true;
            this.presetLoadButton.Click += new System.EventHandler(this.presetLoadButton_Click);
            // 
            // previewRenderButton
            // 
            this.previewRenderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.previewRenderButton.Location = new System.Drawing.Point(1303, 761);
            this.previewRenderButton.Name = "previewRenderButton";
            this.previewRenderButton.Size = new System.Drawing.Size(144, 29);
            this.previewRenderButton.TabIndex = 4;
            this.previewRenderButton.Text = "Render Preview";
            this.previewRenderButton.UseVisualStyleBackColor = true;
            this.previewRenderButton.Click += new System.EventHandler(this.previewRenderButton_Click);
            // 
            // previewImage
            // 
            this.previewImage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.previewImage.Location = new System.Drawing.Point(13, 31);
            this.previewImage.Name = "previewImage";
            this.previewImage.Size = new System.Drawing.Size(1280, 720);
            this.previewImage.TabIndex = 5;
            this.previewImage.TabStop = false;
            // 
            // imageRenderButton
            // 
            this.imageRenderButton.Location = new System.Drawing.Point(1303, 796);
            this.imageRenderButton.Name = "imageRenderButton";
            this.imageRenderButton.Size = new System.Drawing.Size(144, 29);
            this.imageRenderButton.TabIndex = 6;
            this.imageRenderButton.Text = "Render Image";
            this.imageRenderButton.UseVisualStyleBackColor = true;
            this.imageRenderButton.Click += new System.EventHandler(this.imageRenderButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1692, 886);
            this.Controls.Add(this.imageRenderButton);
            this.Controls.Add(this.previewImage);
            this.Controls.Add(this.previewRenderButton);
            this.Controls.Add(this.presetLoadButton);
            this.Controls.Add(this.presetSaveButton);
            this.Controls.Add(this.options);
            this.Controls.Add(this.topMenu);
            this.MainMenuStrip = this.topMenu;
            this.Name = "Form1";
            this.Text = "Form1";
            this.topMenu.ResumeLayout(false);
            this.topMenu.PerformLayout();
            this.options.ResumeLayout(false);
            this.imageOptions.ResumeLayout(false);
            this.imageOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraFov)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraPitch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraYValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraZValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cameraXValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.previewImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip topMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TabControl options;
        private System.Windows.Forms.TabPage imageOptions;
        private System.Windows.Forms.TabPage terrainOptions;
        private System.Windows.Forms.TabPage backgroundOptions;
        private System.Windows.Forms.Button presetSaveButton;
        private System.Windows.Forms.Button presetLoadButton;
        private System.Windows.Forms.Button previewRenderButton;
        private System.Windows.Forms.NumericUpDown imageHeight;
        private System.Windows.Forms.NumericUpDown imageWidth;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label resolutionLabel;
        private System.Windows.Forms.Label imageTypeLabel;
        private System.Windows.Forms.PictureBox previewImage;
        private System.Windows.Forms.ComboBox imageType;
        private System.Windows.Forms.Button imageRenderButton;
        private System.Windows.Forms.Label cameraY;
        private System.Windows.Forms.NumericUpDown cameraXValue;
        private System.Windows.Forms.Label cameraX;
        private System.Windows.Forms.Label cameraPosition;
        private System.Windows.Forms.Label generalImageOptions;
        private System.Windows.Forms.Label cameraSettings;
        private System.Windows.Forms.Label cameraZ;
        private System.Windows.Forms.NumericUpDown cameraYValue;
        private System.Windows.Forms.NumericUpDown cameraZValue;
        private System.Windows.Forms.NumericUpDown cameraPitch;
        private System.Windows.Forms.Label cameraPitchLabel;
        private System.Windows.Forms.NumericUpDown cameraYaw;
        private System.Windows.Forms.Label cameraYawLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown cameraFov;
        private System.Windows.Forms.Label fovLabel;
    }
}

