
namespace WorldHeightmapClient
{
    partial class CoreForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.settingsBox = new System.Windows.Forms.GroupBox();
            this.manualWaterBox = new System.Windows.Forms.GroupBox();
            this.abyssElevation = new System.Windows.Forms.NumericUpDown();
            this.depthElevationLabel = new System.Windows.Forms.Label();
            this.depthElevation = new System.Windows.Forms.NumericUpDown();
            this.abyssElevationLabel = new System.Windows.Forms.Label();
            this.waterElevationLabel = new System.Windows.Forms.Label();
            this.waterElevation = new System.Windows.Forms.NumericUpDown();
            this.globalPosition = new System.Windows.Forms.GroupBox();
            this.longitudeLabel = new System.Windows.Forms.Label();
            this.longitudeIn = new System.Windows.Forms.TextBox();
            this.latitudeLabel = new System.Windows.Forms.Label();
            this.latitudeIn = new System.Windows.Forms.TextBox();
            this.roundSettings = new System.Windows.Forms.GroupBox();
            this.roundToNearest = new System.Windows.Forms.ComboBox();
            this.roundToNearestLabel = new System.Windows.Forms.Label();
            this.averageSettings = new System.Windows.Forms.GroupBox();
            this.averageSmoothCapLabel = new System.Windows.Forms.Label();
            this.maxVertexDifference = new System.Windows.Forms.NumericUpDown();
            this.averagePassesLabel = new System.Windows.Forms.Label();
            this.averagePasses = new System.Windows.Forms.NumericUpDown();
            this.smoothingOptionsBox = new System.Windows.Forms.GroupBox();
            this.noSmoothing = new System.Windows.Forms.RadioButton();
            this.roundSmoothing = new System.Windows.Forms.RadioButton();
            this.averageSmoothing = new System.Windows.Forms.RadioButton();
            this.flattenSettings = new System.Windows.Forms.GroupBox();
            this.maxMapHeightLabel = new System.Windows.Forms.Label();
            this.maxMapHeight = new System.Windows.Forms.NumericUpDown();
            this.minMapHeightLabel = new System.Windows.Forms.Label();
            this.minMapHeight = new System.Windows.Forms.NumericUpDown();
            this.compressSettings = new System.Windows.Forms.GroupBox();
            this.compressPassesLabel = new System.Windows.Forms.Label();
            this.compressPasses = new System.Windows.Forms.NumericUpDown();
            this.squashGroup = new System.Windows.Forms.GroupBox();
            this.noSquash = new System.Windows.Forms.RadioButton();
            this.flattenSquash = new System.Windows.Forms.RadioButton();
            this.compressSquash = new System.Windows.Forms.RadioButton();
            this.waterTypeSelection = new System.Windows.Forms.GroupBox();
            this.noWater = new System.Windows.Forms.RadioButton();
            this.automaticWater = new System.Windows.Forms.RadioButton();
            this.manualWater = new System.Windows.Forms.RadioButton();
            this.heightSame = new System.Windows.Forms.CheckBox();
            this.heighLabel = new System.Windows.Forms.Label();
            this.mapHeight = new System.Windows.Forms.ComboBox();
            this.widthLabel = new System.Windows.Forms.Label();
            this.mapWidth = new System.Windows.Forms.ComboBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.operationHoldingPanel = new System.Windows.Forms.Panel();
            this.operationsPanel = new System.Windows.Forms.SplitContainer();
            this.resultSection = new System.Windows.Forms.SplitContainer();
            this.resultDisplay = new System.Windows.Forms.PictureBox();
            this.loggerView = new System.Windows.Forms.ListView();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.opeartionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.globalStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.groupStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.elevationAPIKey = new System.Windows.Forms.Button();
            this.settingsBox.SuspendLayout();
            this.manualWaterBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.abyssElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterElevation)).BeginInit();
            this.globalPosition.SuspendLayout();
            this.roundSettings.SuspendLayout();
            this.averageSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxVertexDifference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.averagePasses)).BeginInit();
            this.smoothingOptionsBox.SuspendLayout();
            this.flattenSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxMapHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minMapHeight)).BeginInit();
            this.compressSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressPasses)).BeginInit();
            this.squashGroup.SuspendLayout();
            this.waterTypeSelection.SuspendLayout();
            this.operationHoldingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operationsPanel)).BeginInit();
            this.operationsPanel.Panel1.SuspendLayout();
            this.operationsPanel.Panel2.SuspendLayout();
            this.operationsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultSection)).BeginInit();
            this.resultSection.Panel1.SuspendLayout();
            this.resultSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDisplay)).BeginInit();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsBox
            // 
            this.settingsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.settingsBox.Controls.Add(this.elevationAPIKey);
            this.settingsBox.Controls.Add(this.manualWaterBox);
            this.settingsBox.Controls.Add(this.globalPosition);
            this.settingsBox.Controls.Add(this.roundSettings);
            this.settingsBox.Controls.Add(this.averageSettings);
            this.settingsBox.Controls.Add(this.smoothingOptionsBox);
            this.settingsBox.Controls.Add(this.flattenSettings);
            this.settingsBox.Controls.Add(this.compressSettings);
            this.settingsBox.Controls.Add(this.squashGroup);
            this.settingsBox.Controls.Add(this.waterTypeSelection);
            this.settingsBox.Controls.Add(this.heightSame);
            this.settingsBox.Controls.Add(this.heighLabel);
            this.settingsBox.Controls.Add(this.mapHeight);
            this.settingsBox.Controls.Add(this.widthLabel);
            this.settingsBox.Controls.Add(this.mapWidth);
            this.settingsBox.Controls.Add(this.generateButton);
            this.settingsBox.Location = new System.Drawing.Point(12, 12);
            this.settingsBox.Name = "settingsBox";
            this.settingsBox.Size = new System.Drawing.Size(327, 596);
            this.settingsBox.TabIndex = 0;
            this.settingsBox.TabStop = false;
            this.settingsBox.Text = "Settings";
            // 
            // manualWaterBox
            // 
            this.manualWaterBox.Controls.Add(this.abyssElevation);
            this.manualWaterBox.Controls.Add(this.depthElevationLabel);
            this.manualWaterBox.Controls.Add(this.depthElevation);
            this.manualWaterBox.Controls.Add(this.abyssElevationLabel);
            this.manualWaterBox.Controls.Add(this.waterElevationLabel);
            this.manualWaterBox.Controls.Add(this.waterElevation);
            this.manualWaterBox.Enabled = false;
            this.manualWaterBox.Location = new System.Drawing.Point(7, 183);
            this.manualWaterBox.Name = "manualWaterBox";
            this.manualWaterBox.Size = new System.Drawing.Size(313, 91);
            this.manualWaterBox.TabIndex = 14;
            this.manualWaterBox.TabStop = false;
            this.manualWaterBox.Text = "Manual Water Options";
            // 
            // abyssElevation
            // 
            this.abyssElevation.DecimalPlaces = 2;
            this.abyssElevation.Location = new System.Drawing.Point(186, 66);
            this.abyssElevation.Name = "abyssElevation";
            this.abyssElevation.Size = new System.Drawing.Size(120, 20);
            this.abyssElevation.TabIndex = 5;
            // 
            // depthElevationLabel
            // 
            this.depthElevationLabel.AutoSize = true;
            this.depthElevationLabel.Location = new System.Drawing.Point(6, 45);
            this.depthElevationLabel.Name = "depthElevationLabel";
            this.depthElevationLabel.Size = new System.Drawing.Size(83, 13);
            this.depthElevationLabel.TabIndex = 1;
            this.depthElevationLabel.Text = "Depth Elevation";
            // 
            // depthElevation
            // 
            this.depthElevation.DecimalPlaces = 2;
            this.depthElevation.Location = new System.Drawing.Point(186, 43);
            this.depthElevation.Name = "depthElevation";
            this.depthElevation.Size = new System.Drawing.Size(120, 20);
            this.depthElevation.TabIndex = 4;
            // 
            // abyssElevationLabel
            // 
            this.abyssElevationLabel.AutoSize = true;
            this.abyssElevationLabel.Location = new System.Drawing.Point(6, 68);
            this.abyssElevationLabel.Name = "abyssElevationLabel";
            this.abyssElevationLabel.Size = new System.Drawing.Size(82, 13);
            this.abyssElevationLabel.TabIndex = 2;
            this.abyssElevationLabel.Text = "Abyss Elevation";
            // 
            // waterElevationLabel
            // 
            this.waterElevationLabel.AutoSize = true;
            this.waterElevationLabel.Location = new System.Drawing.Point(6, 22);
            this.waterElevationLabel.Name = "waterElevationLabel";
            this.waterElevationLabel.Size = new System.Drawing.Size(83, 13);
            this.waterElevationLabel.TabIndex = 0;
            this.waterElevationLabel.Text = "Water Elevation";
            // 
            // waterElevation
            // 
            this.waterElevation.DecimalPlaces = 2;
            this.waterElevation.Location = new System.Drawing.Point(186, 20);
            this.waterElevation.Name = "waterElevation";
            this.waterElevation.Size = new System.Drawing.Size(120, 20);
            this.waterElevation.TabIndex = 3;
            // 
            // globalPosition
            // 
            this.globalPosition.Controls.Add(this.longitudeLabel);
            this.globalPosition.Controls.Add(this.longitudeIn);
            this.globalPosition.Controls.Add(this.latitudeLabel);
            this.globalPosition.Controls.Add(this.latitudeIn);
            this.globalPosition.Location = new System.Drawing.Point(6, 19);
            this.globalPosition.Name = "globalPosition";
            this.globalPosition.Size = new System.Drawing.Size(315, 55);
            this.globalPosition.TabIndex = 13;
            this.globalPosition.TabStop = false;
            this.globalPosition.Text = "Global Position";
            // 
            // longitudeLabel
            // 
            this.longitudeLabel.AutoSize = true;
            this.longitudeLabel.Location = new System.Drawing.Point(159, 25);
            this.longitudeLabel.Name = "longitudeLabel";
            this.longitudeLabel.Size = new System.Drawing.Size(54, 13);
            this.longitudeLabel.TabIndex = 3;
            this.longitudeLabel.Text = "Longitude";
            // 
            // longitudeIn
            // 
            this.longitudeIn.Location = new System.Drawing.Point(215, 22);
            this.longitudeIn.Name = "longitudeIn";
            this.longitudeIn.Size = new System.Drawing.Size(97, 20);
            this.longitudeIn.TabIndex = 2;
            // 
            // latitudeLabel
            // 
            this.latitudeLabel.AutoSize = true;
            this.latitudeLabel.Location = new System.Drawing.Point(5, 25);
            this.latitudeLabel.Name = "latitudeLabel";
            this.latitudeLabel.Size = new System.Drawing.Size(45, 13);
            this.latitudeLabel.TabIndex = 1;
            this.latitudeLabel.Text = "Latitude";
            // 
            // latitudeIn
            // 
            this.latitudeIn.Location = new System.Drawing.Point(56, 22);
            this.latitudeIn.Name = "latitudeIn";
            this.latitudeIn.Size = new System.Drawing.Size(97, 20);
            this.latitudeIn.TabIndex = 0;
            // 
            // roundSettings
            // 
            this.roundSettings.Controls.Add(this.roundToNearest);
            this.roundSettings.Controls.Add(this.roundToNearestLabel);
            this.roundSettings.Enabled = false;
            this.roundSettings.Location = new System.Drawing.Point(149, 510);
            this.roundSettings.Name = "roundSettings";
            this.roundSettings.Size = new System.Drawing.Size(172, 52);
            this.roundSettings.TabIndex = 12;
            this.roundSettings.TabStop = false;
            this.roundSettings.Text = "Round Smoothing Settings";
            // 
            // roundToNearest
            // 
            this.roundToNearest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roundToNearest.FormattingEnabled = true;
            this.roundToNearest.Items.AddRange(new object[] {
            ".25",
            ".5",
            "1"});
            this.roundToNearest.Location = new System.Drawing.Point(106, 22);
            this.roundToNearest.Name = "roundToNearest";
            this.roundToNearest.Size = new System.Drawing.Size(56, 21);
            this.roundToNearest.TabIndex = 2;
            // 
            // roundToNearestLabel
            // 
            this.roundToNearestLabel.AutoSize = true;
            this.roundToNearestLabel.Location = new System.Drawing.Point(6, 25);
            this.roundToNearestLabel.Name = "roundToNearestLabel";
            this.roundToNearestLabel.Size = new System.Drawing.Size(95, 13);
            this.roundToNearestLabel.TabIndex = 1;
            this.roundToNearestLabel.Text = "Round To Nearest";
            // 
            // averageSettings
            // 
            this.averageSettings.Controls.Add(this.averageSmoothCapLabel);
            this.averageSettings.Controls.Add(this.maxVertexDifference);
            this.averageSettings.Controls.Add(this.averagePassesLabel);
            this.averageSettings.Controls.Add(this.averagePasses);
            this.averageSettings.Location = new System.Drawing.Point(149, 430);
            this.averageSettings.Name = "averageSettings";
            this.averageSettings.Size = new System.Drawing.Size(172, 74);
            this.averageSettings.TabIndex = 11;
            this.averageSettings.TabStop = false;
            this.averageSettings.Text = "Average Smoothing Settings";
            // 
            // averageSmoothCapLabel
            // 
            this.averageSmoothCapLabel.AutoSize = true;
            this.averageSmoothCapLabel.Location = new System.Drawing.Point(6, 52);
            this.averageSmoothCapLabel.Name = "averageSmoothCapLabel";
            this.averageSmoothCapLabel.Size = new System.Drawing.Size(79, 13);
            this.averageSmoothCapLabel.TabIndex = 3;
            this.averageSmoothCapLabel.Text = "Max Difference";
            // 
            // maxVertexDifference
            // 
            this.maxVertexDifference.DecimalPlaces = 4;
            this.maxVertexDifference.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.maxVertexDifference.Location = new System.Drawing.Point(106, 50);
            this.maxVertexDifference.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxVertexDifference.Name = "maxVertexDifference";
            this.maxVertexDifference.Size = new System.Drawing.Size(56, 20);
            this.maxVertexDifference.TabIndex = 2;
            this.maxVertexDifference.Value = new decimal(new int[] {
            35,
            0,
            0,
            262144});
            // 
            // averagePassesLabel
            // 
            this.averagePassesLabel.AutoSize = true;
            this.averagePassesLabel.Location = new System.Drawing.Point(6, 25);
            this.averagePassesLabel.Name = "averagePassesLabel";
            this.averagePassesLabel.Size = new System.Drawing.Size(41, 13);
            this.averagePassesLabel.TabIndex = 1;
            this.averagePassesLabel.Text = "Passes";
            // 
            // averagePasses
            // 
            this.averagePasses.Location = new System.Drawing.Point(106, 23);
            this.averagePasses.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.averagePasses.Name = "averagePasses";
            this.averagePasses.Size = new System.Drawing.Size(56, 20);
            this.averagePasses.TabIndex = 0;
            this.averagePasses.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // smoothingOptionsBox
            // 
            this.smoothingOptionsBox.Controls.Add(this.noSmoothing);
            this.smoothingOptionsBox.Controls.Add(this.roundSmoothing);
            this.smoothingOptionsBox.Controls.Add(this.averageSmoothing);
            this.smoothingOptionsBox.Location = new System.Drawing.Point(9, 430);
            this.smoothingOptionsBox.Name = "smoothingOptionsBox";
            this.smoothingOptionsBox.Size = new System.Drawing.Size(134, 132);
            this.smoothingOptionsBox.TabIndex = 12;
            this.smoothingOptionsBox.TabStop = false;
            this.smoothingOptionsBox.Text = "Smoothing";
            // 
            // noSmoothing
            // 
            this.noSmoothing.Location = new System.Drawing.Point(5, 86);
            this.noSmoothing.Name = "noSmoothing";
            this.noSmoothing.Size = new System.Drawing.Size(127, 24);
            this.noSmoothing.TabIndex = 5;
            this.noSmoothing.Text = "None";
            this.noSmoothing.UseVisualStyleBackColor = true;
            // 
            // roundSmoothing
            // 
            this.roundSmoothing.Location = new System.Drawing.Point(6, 56);
            this.roundSmoothing.Name = "roundSmoothing";
            this.roundSmoothing.Size = new System.Drawing.Size(127, 24);
            this.roundSmoothing.TabIndex = 4;
            this.roundSmoothing.Text = "Round";
            this.roundSmoothing.UseVisualStyleBackColor = true;
            // 
            // averageSmoothing
            // 
            this.averageSmoothing.Checked = true;
            this.averageSmoothing.Location = new System.Drawing.Point(6, 26);
            this.averageSmoothing.Name = "averageSmoothing";
            this.averageSmoothing.Size = new System.Drawing.Size(127, 24);
            this.averageSmoothing.TabIndex = 3;
            this.averageSmoothing.TabStop = true;
            this.averageSmoothing.Text = "Average";
            this.averageSmoothing.UseVisualStyleBackColor = true;
            // 
            // flattenSettings
            // 
            this.flattenSettings.Controls.Add(this.maxMapHeightLabel);
            this.flattenSettings.Controls.Add(this.maxMapHeight);
            this.flattenSettings.Controls.Add(this.minMapHeightLabel);
            this.flattenSettings.Controls.Add(this.minMapHeight);
            this.flattenSettings.Enabled = false;
            this.flattenSettings.Location = new System.Drawing.Point(149, 340);
            this.flattenSettings.Name = "flattenSettings";
            this.flattenSettings.Size = new System.Drawing.Size(172, 84);
            this.flattenSettings.TabIndex = 11;
            this.flattenSettings.TabStop = false;
            this.flattenSettings.Text = "Flatten Settings";
            // 
            // maxMapHeightLabel
            // 
            this.maxMapHeightLabel.AutoSize = true;
            this.maxMapHeightLabel.Location = new System.Drawing.Point(6, 54);
            this.maxMapHeightLabel.Name = "maxMapHeightLabel";
            this.maxMapHeightLabel.Size = new System.Drawing.Size(85, 13);
            this.maxMapHeightLabel.TabIndex = 3;
            this.maxMapHeightLabel.Text = "Max Map Height";
            // 
            // maxMapHeight
            // 
            this.maxMapHeight.Location = new System.Drawing.Point(106, 52);
            this.maxMapHeight.Name = "maxMapHeight";
            this.maxMapHeight.Size = new System.Drawing.Size(56, 20);
            this.maxMapHeight.TabIndex = 2;
            this.maxMapHeight.Value = new decimal(new int[] {
            55,
            0,
            0,
            0});
            // 
            // minMapHeightLabel
            // 
            this.minMapHeightLabel.AutoSize = true;
            this.minMapHeightLabel.Location = new System.Drawing.Point(6, 25);
            this.minMapHeightLabel.Name = "minMapHeightLabel";
            this.minMapHeightLabel.Size = new System.Drawing.Size(82, 13);
            this.minMapHeightLabel.TabIndex = 1;
            this.minMapHeightLabel.Text = "Min Map Height";
            // 
            // minMapHeight
            // 
            this.minMapHeight.Location = new System.Drawing.Point(106, 23);
            this.minMapHeight.Name = "minMapHeight";
            this.minMapHeight.Size = new System.Drawing.Size(56, 20);
            this.minMapHeight.TabIndex = 0;
            this.minMapHeight.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // compressSettings
            // 
            this.compressSettings.Controls.Add(this.compressPassesLabel);
            this.compressSettings.Controls.Add(this.compressPasses);
            this.compressSettings.Location = new System.Drawing.Point(149, 280);
            this.compressSettings.Name = "compressSettings";
            this.compressSettings.Size = new System.Drawing.Size(172, 54);
            this.compressSettings.TabIndex = 10;
            this.compressSettings.TabStop = false;
            this.compressSettings.Text = "Compress Settings";
            // 
            // compressPassesLabel
            // 
            this.compressPassesLabel.AutoSize = true;
            this.compressPassesLabel.Location = new System.Drawing.Point(6, 25);
            this.compressPassesLabel.Name = "compressPassesLabel";
            this.compressPassesLabel.Size = new System.Drawing.Size(41, 13);
            this.compressPassesLabel.TabIndex = 1;
            this.compressPassesLabel.Text = "Passes";
            // 
            // compressPasses
            // 
            this.compressPasses.Location = new System.Drawing.Point(106, 23);
            this.compressPasses.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.compressPasses.Name = "compressPasses";
            this.compressPasses.Size = new System.Drawing.Size(56, 20);
            this.compressPasses.TabIndex = 0;
            this.compressPasses.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // squashGroup
            // 
            this.squashGroup.Controls.Add(this.noSquash);
            this.squashGroup.Controls.Add(this.flattenSquash);
            this.squashGroup.Controls.Add(this.compressSquash);
            this.squashGroup.Location = new System.Drawing.Point(5, 280);
            this.squashGroup.Name = "squashGroup";
            this.squashGroup.Size = new System.Drawing.Size(138, 144);
            this.squashGroup.TabIndex = 9;
            this.squashGroup.TabStop = false;
            this.squashGroup.Text = "Squash Type";
            // 
            // noSquash
            // 
            this.noSquash.Location = new System.Drawing.Point(6, 79);
            this.noSquash.Name = "noSquash";
            this.noSquash.Size = new System.Drawing.Size(127, 24);
            this.noSquash.TabIndex = 2;
            this.noSquash.Text = "None";
            this.noSquash.UseVisualStyleBackColor = true;
            // 
            // flattenSquash
            // 
            this.flattenSquash.Location = new System.Drawing.Point(7, 49);
            this.flattenSquash.Name = "flattenSquash";
            this.flattenSquash.Size = new System.Drawing.Size(127, 24);
            this.flattenSquash.TabIndex = 1;
            this.flattenSquash.Text = "Flatten";
            this.flattenSquash.UseVisualStyleBackColor = true;
            // 
            // compressSquash
            // 
            this.compressSquash.Checked = true;
            this.compressSquash.Location = new System.Drawing.Point(7, 19);
            this.compressSquash.Name = "compressSquash";
            this.compressSquash.Size = new System.Drawing.Size(127, 24);
            this.compressSquash.TabIndex = 0;
            this.compressSquash.TabStop = true;
            this.compressSquash.Text = "Compress";
            this.compressSquash.UseVisualStyleBackColor = true;
            // 
            // waterTypeSelection
            // 
            this.waterTypeSelection.Controls.Add(this.noWater);
            this.waterTypeSelection.Controls.Add(this.automaticWater);
            this.waterTypeSelection.Controls.Add(this.manualWater);
            this.waterTypeSelection.Location = new System.Drawing.Point(6, 135);
            this.waterTypeSelection.Name = "waterTypeSelection";
            this.waterTypeSelection.Size = new System.Drawing.Size(315, 41);
            this.waterTypeSelection.TabIndex = 8;
            this.waterTypeSelection.TabStop = false;
            this.waterTypeSelection.Text = "Water";
            // 
            // noWater
            // 
            this.noWater.Location = new System.Drawing.Point(191, 18);
            this.noWater.Name = "noWater";
            this.noWater.Size = new System.Drawing.Size(80, 17);
            this.noWater.TabIndex = 2;
            this.noWater.Text = "None";
            this.noWater.UseVisualStyleBackColor = true;
            this.noWater.CheckedChanged += new System.EventHandler(this.NoWater_CheckedChanged);
            // 
            // automaticWater
            // 
            this.automaticWater.Checked = true;
            this.automaticWater.Location = new System.Drawing.Point(90, 18);
            this.automaticWater.Name = "automaticWater";
            this.automaticWater.Size = new System.Drawing.Size(80, 17);
            this.automaticWater.TabIndex = 1;
            this.automaticWater.TabStop = true;
            this.automaticWater.Text = "Automatic";
            this.automaticWater.UseVisualStyleBackColor = true;
            this.automaticWater.CheckedChanged += new System.EventHandler(this.AutomaticWater_CheckedChanged);
            // 
            // manualWater
            // 
            this.manualWater.Location = new System.Drawing.Point(6, 18);
            this.manualWater.Name = "manualWater";
            this.manualWater.Size = new System.Drawing.Size(64, 17);
            this.manualWater.TabIndex = 0;
            this.manualWater.Text = "Manual";
            this.manualWater.UseVisualStyleBackColor = true;
            this.manualWater.CheckedChanged += new System.EventHandler(this.ManualWater_CheckedChanged);
            // 
            // heightSame
            // 
            this.heightSame.AutoSize = true;
            this.heightSame.Checked = true;
            this.heightSame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.heightSame.Location = new System.Drawing.Point(225, 83);
            this.heightSame.Name = "heightSame";
            this.heightSame.Size = new System.Drawing.Size(98, 17);
            this.heightSame.TabIndex = 7;
            this.heightSame.Text = "Same as Width";
            this.heightSame.UseVisualStyleBackColor = true;
            // 
            // heighLabel
            // 
            this.heighLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.heighLabel.AutoSize = true;
            this.heighLabel.Location = new System.Drawing.Point(181, 111);
            this.heighLabel.Name = "heighLabel";
            this.heighLabel.Size = new System.Drawing.Size(38, 13);
            this.heighLabel.TabIndex = 4;
            this.heighLabel.Text = "Height";
            // 
            // mapHeight
            // 
            this.mapHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapHeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapHeight.Enabled = false;
            this.mapHeight.FormattingEnabled = true;
            this.mapHeight.Items.AddRange(new object[] {
            "1.25 km (64px)",
            "2.5 km (128px)",
            "5 km (256px)",
            "10 km (512px)",
            "20 km (1024px)",
            "40 km (2048px)",
            "80 km (4096px)"});
            this.mapHeight.Location = new System.Drawing.Point(221, 108);
            this.mapHeight.Name = "mapHeight";
            this.mapHeight.Size = new System.Drawing.Size(103, 21);
            this.mapHeight.TabIndex = 3;
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(6, 111);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(35, 13);
            this.widthLabel.TabIndex = 2;
            this.widthLabel.Text = "Width";
            // 
            // mapWidth
            // 
            this.mapWidth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mapWidth.FormattingEnabled = true;
            this.mapWidth.Items.AddRange(new object[] {
            "1.25 km (64px)",
            "2.5 km (128px)",
            "5 km (256px)",
            "10 km (512px)",
            "20 km (1024px)",
            "40 km (2048px)",
            "80 km (4096px)"});
            this.mapWidth.Location = new System.Drawing.Point(46, 108);
            this.mapWidth.Name = "mapWidth";
            this.mapWidth.Size = new System.Drawing.Size(103, 21);
            this.mapWidth.TabIndex = 1;
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.generateButton.Location = new System.Drawing.Point(6, 567);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(315, 23);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            // 
            // operationHoldingPanel
            // 
            this.operationHoldingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.operationHoldingPanel.Controls.Add(this.operationsPanel);
            this.operationHoldingPanel.Location = new System.Drawing.Point(345, 12);
            this.operationHoldingPanel.Name = "operationHoldingPanel";
            this.operationHoldingPanel.Size = new System.Drawing.Size(781, 596);
            this.operationHoldingPanel.TabIndex = 1;
            // 
            // operationsPanel
            // 
            this.operationsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.operationsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationsPanel.Location = new System.Drawing.Point(0, 0);
            this.operationsPanel.Name = "operationsPanel";
            this.operationsPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // operationsPanel.Panel1
            // 
            this.operationsPanel.Panel1.Controls.Add(this.resultSection);
            // 
            // operationsPanel.Panel2
            // 
            this.operationsPanel.Panel2.Controls.Add(this.loggerView);
            this.operationsPanel.Size = new System.Drawing.Size(781, 596);
            this.operationsPanel.SplitterDistance = 372;
            this.operationsPanel.SplitterWidth = 8;
            this.operationsPanel.TabIndex = 0;
            // 
            // resultSection
            // 
            this.resultSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultSection.Location = new System.Drawing.Point(0, 0);
            this.resultSection.Name = "resultSection";
            // 
            // resultSection.Panel1
            // 
            this.resultSection.Panel1.Controls.Add(this.resultDisplay);
            this.resultSection.Size = new System.Drawing.Size(779, 370);
            this.resultSection.SplitterDistance = 368;
            this.resultSection.SplitterWidth = 8;
            this.resultSection.TabIndex = 0;
            // 
            // resultDisplay
            // 
            this.resultDisplay.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.resultDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultDisplay.Location = new System.Drawing.Point(0, 0);
            this.resultDisplay.Name = "resultDisplay";
            this.resultDisplay.Size = new System.Drawing.Size(368, 370);
            this.resultDisplay.TabIndex = 0;
            this.resultDisplay.TabStop = false;
            // 
            // loggerView
            // 
            this.loggerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loggerView.HideSelection = false;
            this.loggerView.Location = new System.Drawing.Point(0, 0);
            this.loggerView.Name = "loggerView";
            this.loggerView.Size = new System.Drawing.Size(779, 214);
            this.loggerView.TabIndex = 0;
            this.loggerView.UseCompatibleStateImageBehavior = false;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opeartionStatusLabel,
            this.globalStatus,
            this.groupStatusLabel,
            this.groupStatus});
            this.statusBar.Location = new System.Drawing.Point(0, 611);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1132, 22);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // opeartionStatusLabel
            // 
            this.opeartionStatusLabel.Name = "opeartionStatusLabel";
            this.opeartionStatusLabel.Size = new System.Drawing.Size(63, 17);
            this.opeartionStatusLabel.Text = "Operation:";
            // 
            // globalStatus
            // 
            this.globalStatus.Name = "globalStatus";
            this.globalStatus.Size = new System.Drawing.Size(100, 16);
            // 
            // groupStatusLabel
            // 
            this.groupStatusLabel.Name = "groupStatusLabel";
            this.groupStatusLabel.Size = new System.Drawing.Size(46, 17);
            this.groupStatusLabel.Text = "Group: ";
            // 
            // groupStatus
            // 
            this.groupStatus.Name = "groupStatus";
            this.groupStatus.Size = new System.Drawing.Size(100, 16);
            // 
            // elevationAPIKey
            // 
            this.elevationAPIKey.Location = new System.Drawing.Point(7, 81);
            this.elevationAPIKey.Name = "elevationAPIKey";
            this.elevationAPIKey.Size = new System.Drawing.Size(212, 23);
            this.elevationAPIKey.TabIndex = 15;
            this.elevationAPIKey.Text = "Set Elevation API Key";
            this.elevationAPIKey.UseVisualStyleBackColor = true;
            this.elevationAPIKey.Click += new System.EventHandler(this.ElevationAPIKey_Click);
            // 
            // CoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 633);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.operationHoldingPanel);
            this.Controls.Add(this.settingsBox);
            this.Name = "CoreForm";
            this.Text = "World Heightmap Generator for the FAF Map Editor";
            this.settingsBox.ResumeLayout(false);
            this.settingsBox.PerformLayout();
            this.manualWaterBox.ResumeLayout(false);
            this.manualWaterBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.abyssElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterElevation)).EndInit();
            this.globalPosition.ResumeLayout(false);
            this.globalPosition.PerformLayout();
            this.roundSettings.ResumeLayout(false);
            this.roundSettings.PerformLayout();
            this.averageSettings.ResumeLayout(false);
            this.averageSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxVertexDifference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.averagePasses)).EndInit();
            this.smoothingOptionsBox.ResumeLayout(false);
            this.flattenSettings.ResumeLayout(false);
            this.flattenSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxMapHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minMapHeight)).EndInit();
            this.compressSettings.ResumeLayout(false);
            this.compressSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressPasses)).EndInit();
            this.squashGroup.ResumeLayout(false);
            this.waterTypeSelection.ResumeLayout(false);
            this.operationHoldingPanel.ResumeLayout(false);
            this.operationsPanel.Panel1.ResumeLayout(false);
            this.operationsPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.operationsPanel)).EndInit();
            this.operationsPanel.ResumeLayout(false);
            this.resultSection.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultSection)).EndInit();
            this.resultSection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resultDisplay)).EndInit();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox settingsBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Panel operationHoldingPanel;
        private System.Windows.Forms.SplitContainer operationsPanel;
        private System.Windows.Forms.ComboBox mapWidth;
        private System.Windows.Forms.ListView loggerView;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.SplitContainer resultSection;
        private System.Windows.Forms.PictureBox resultDisplay;
        private System.Windows.Forms.ToolStripStatusLabel opeartionStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar globalStatus;
        private System.Windows.Forms.ToolStripStatusLabel groupStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar groupStatus;
        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heighLabel;
        private System.Windows.Forms.ComboBox mapHeight;
        private System.Windows.Forms.CheckBox heightSame;
        private System.Windows.Forms.Label waterElevationLabel;
        private System.Windows.Forms.Label abyssElevationLabel;
        private System.Windows.Forms.Label depthElevationLabel;
        private System.Windows.Forms.NumericUpDown waterElevation;
        private System.Windows.Forms.NumericUpDown abyssElevation;
        private System.Windows.Forms.NumericUpDown depthElevation;
        private System.Windows.Forms.GroupBox waterTypeSelection;
        private System.Windows.Forms.RadioButton manualWater;
        private System.Windows.Forms.RadioButton automaticWater;
        private System.Windows.Forms.GroupBox squashGroup;
        private System.Windows.Forms.RadioButton compressSquash;
        private System.Windows.Forms.RadioButton flattenSquash;
        private System.Windows.Forms.RadioButton noSquash;
        private System.Windows.Forms.GroupBox compressSettings;
        private System.Windows.Forms.NumericUpDown compressPasses;
        private System.Windows.Forms.Label compressPassesLabel;
        private System.Windows.Forms.GroupBox flattenSettings;
        private System.Windows.Forms.Label minMapHeightLabel;
        private System.Windows.Forms.NumericUpDown minMapHeight;
        private System.Windows.Forms.Label maxMapHeightLabel;
        private System.Windows.Forms.NumericUpDown maxMapHeight;
        private System.Windows.Forms.GroupBox smoothingOptionsBox;
        private System.Windows.Forms.RadioButton noSmoothing;
        private System.Windows.Forms.RadioButton roundSmoothing;
        private System.Windows.Forms.RadioButton averageSmoothing;
        private System.Windows.Forms.GroupBox averageSettings;
        private System.Windows.Forms.Label averagePassesLabel;
        private System.Windows.Forms.NumericUpDown averagePasses;
        private System.Windows.Forms.GroupBox roundSettings;
        private System.Windows.Forms.Label roundToNearestLabel;
        private System.Windows.Forms.Label averageSmoothCapLabel;
        private System.Windows.Forms.NumericUpDown maxVertexDifference;
        private System.Windows.Forms.ComboBox roundToNearest;
        private System.Windows.Forms.RadioButton noWater;
        private System.Windows.Forms.GroupBox globalPosition;
        private System.Windows.Forms.Label latitudeLabel;
        private System.Windows.Forms.TextBox latitudeIn;
        private System.Windows.Forms.Label longitudeLabel;
        private System.Windows.Forms.TextBox longitudeIn;
        private System.Windows.Forms.GroupBox manualWaterBox;
        private System.Windows.Forms.Button elevationAPIKey;
    }
}

