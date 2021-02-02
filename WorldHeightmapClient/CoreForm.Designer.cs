
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
            this.dataTab = new System.Windows.Forms.TabControl();
            this.liveDataTab = new System.Windows.Forms.TabPage();
            this.elevationAPIKey = new System.Windows.Forms.Button();
            this.globalPosition = new System.Windows.Forms.GroupBox();
            this.longitudeLabel = new System.Windows.Forms.Label();
            this.longitudeIn = new System.Windows.Forms.TextBox();
            this.latitudeLabel = new System.Windows.Forms.Label();
            this.latitudeIn = new System.Windows.Forms.TextBox();
            this.heightSame = new System.Windows.Forms.CheckBox();
            this.mapWidth = new System.Windows.Forms.ComboBox();
            this.heighLabel = new System.Windows.Forms.Label();
            this.widthLabel = new System.Windows.Forms.Label();
            this.mapHeight = new System.Windows.Forms.ComboBox();
            this.savedDataTab = new System.Windows.Forms.TabPage();
            this.savedElevationBox = new System.Windows.Forms.ListBox();
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
            this.flattenMax = new System.Windows.Forms.NumericUpDown();
            this.minMapHeightLabel = new System.Windows.Forms.Label();
            this.flattenMin = new System.Windows.Forms.NumericUpDown();
            this.compressSettings = new System.Windows.Forms.GroupBox();
            this.compressPassesLabel = new System.Windows.Forms.Label();
            this.compressPasses = new System.Windows.Forms.NumericUpDown();
            this.squashGroup = new System.Windows.Forms.GroupBox();
            this.squishPercentLabel = new System.Windows.Forms.Label();
            this.squishPercent = new System.Windows.Forms.NumericUpDown();
            this.noSquash = new System.Windows.Forms.RadioButton();
            this.flattenSquash = new System.Windows.Forms.RadioButton();
            this.compressSquash = new System.Windows.Forms.RadioButton();
            this.waterTypeSelection = new System.Windows.Forms.GroupBox();
            this.automaticWater = new System.Windows.Forms.RadioButton();
            this.flattenWater = new System.Windows.Forms.RadioButton();
            this.generateButton = new System.Windows.Forms.Button();
            this.manualWaterBox = new System.Windows.Forms.GroupBox();
            this.abyssElevation = new System.Windows.Forms.NumericUpDown();
            this.depthElevationLabel = new System.Windows.Forms.Label();
            this.depthElevation = new System.Windows.Forms.NumericUpDown();
            this.abyssElevationLabel = new System.Windows.Forms.Label();
            this.waterElevationLabel = new System.Windows.Forms.Label();
            this.waterElevation = new System.Windows.Forms.NumericUpDown();
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
            this.settingsBox.SuspendLayout();
            this.dataTab.SuspendLayout();
            this.liveDataTab.SuspendLayout();
            this.globalPosition.SuspendLayout();
            this.savedDataTab.SuspendLayout();
            this.roundSettings.SuspendLayout();
            this.averageSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxVertexDifference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.averagePasses)).BeginInit();
            this.smoothingOptionsBox.SuspendLayout();
            this.flattenSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flattenMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flattenMin)).BeginInit();
            this.compressSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressPasses)).BeginInit();
            this.squashGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.squishPercent)).BeginInit();
            this.waterTypeSelection.SuspendLayout();
            this.manualWaterBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.abyssElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthElevation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterElevation)).BeginInit();
            this.operationHoldingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operationsPanel)).BeginInit();
            this.operationsPanel.Panel1.SuspendLayout();
            this.operationsPanel.Panel2.SuspendLayout();
            this.operationsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultSection)).BeginInit();
            this.resultSection.Panel1.SuspendLayout();
            this.resultSection.Panel2.SuspendLayout();
            this.resultSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resultDisplay)).BeginInit();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsBox
            // 
            this.settingsBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.settingsBox.Controls.Add(this.dataTab);
            this.settingsBox.Controls.Add(this.roundSettings);
            this.settingsBox.Controls.Add(this.averageSettings);
            this.settingsBox.Controls.Add(this.smoothingOptionsBox);
            this.settingsBox.Controls.Add(this.flattenSettings);
            this.settingsBox.Controls.Add(this.compressSettings);
            this.settingsBox.Controls.Add(this.squashGroup);
            this.settingsBox.Controls.Add(this.waterTypeSelection);
            this.settingsBox.Controls.Add(this.generateButton);
            this.settingsBox.Location = new System.Drawing.Point(14, 14);
            this.settingsBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.settingsBox.Name = "settingsBox";
            this.settingsBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.settingsBox.Size = new System.Drawing.Size(382, 618);
            this.settingsBox.TabIndex = 0;
            this.settingsBox.TabStop = false;
            this.settingsBox.Text = "Settings";
            // 
            // dataTab
            // 
            this.dataTab.Controls.Add(this.liveDataTab);
            this.dataTab.Controls.Add(this.savedDataTab);
            this.dataTab.Location = new System.Drawing.Point(6, 22);
            this.dataTab.Name = "dataTab";
            this.dataTab.SelectedIndex = 0;
            this.dataTab.Size = new System.Drawing.Size(369, 170);
            this.dataTab.TabIndex = 15;
            // 
            // liveDataTab
            // 
            this.liveDataTab.Controls.Add(this.elevationAPIKey);
            this.liveDataTab.Controls.Add(this.globalPosition);
            this.liveDataTab.Controls.Add(this.heightSame);
            this.liveDataTab.Controls.Add(this.mapWidth);
            this.liveDataTab.Controls.Add(this.heighLabel);
            this.liveDataTab.Controls.Add(this.widthLabel);
            this.liveDataTab.Controls.Add(this.mapHeight);
            this.liveDataTab.Location = new System.Drawing.Point(4, 24);
            this.liveDataTab.Name = "liveDataTab";
            this.liveDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.liveDataTab.Size = new System.Drawing.Size(361, 142);
            this.liveDataTab.TabIndex = 0;
            this.liveDataTab.Text = "Live Data";
            this.liveDataTab.UseVisualStyleBackColor = true;
            // 
            // elevationAPIKey
            // 
            this.elevationAPIKey.Location = new System.Drawing.Point(5, 83);
            this.elevationAPIKey.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.elevationAPIKey.Name = "elevationAPIKey";
            this.elevationAPIKey.Size = new System.Drawing.Size(165, 27);
            this.elevationAPIKey.TabIndex = 15;
            this.elevationAPIKey.Text = "Set Elevation API Key";
            this.elevationAPIKey.UseVisualStyleBackColor = true;
            this.elevationAPIKey.Click += new System.EventHandler(this.ElevationAPIKey_Click);
            // 
            // globalPosition
            // 
            this.globalPosition.Controls.Add(this.longitudeLabel);
            this.globalPosition.Controls.Add(this.longitudeIn);
            this.globalPosition.Controls.Add(this.latitudeLabel);
            this.globalPosition.Controls.Add(this.latitudeIn);
            this.globalPosition.Location = new System.Drawing.Point(4, 12);
            this.globalPosition.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.globalPosition.Name = "globalPosition";
            this.globalPosition.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.globalPosition.Size = new System.Drawing.Size(350, 63);
            this.globalPosition.TabIndex = 13;
            this.globalPosition.TabStop = false;
            this.globalPosition.Text = "Global Position";
            // 
            // longitudeLabel
            // 
            this.longitudeLabel.AutoSize = true;
            this.longitudeLabel.Location = new System.Drawing.Point(171, 29);
            this.longitudeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.longitudeLabel.Name = "longitudeLabel";
            this.longitudeLabel.Size = new System.Drawing.Size(61, 15);
            this.longitudeLabel.TabIndex = 3;
            this.longitudeLabel.Text = "Longitude";
            // 
            // longitudeIn
            // 
            this.longitudeIn.Location = new System.Drawing.Point(236, 25);
            this.longitudeIn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.longitudeIn.Name = "longitudeIn";
            this.longitudeIn.Size = new System.Drawing.Size(106, 23);
            this.longitudeIn.TabIndex = 2;
            // 
            // latitudeLabel
            // 
            this.latitudeLabel.AutoSize = true;
            this.latitudeLabel.Location = new System.Drawing.Point(6, 29);
            this.latitudeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.latitudeLabel.Name = "latitudeLabel";
            this.latitudeLabel.Size = new System.Drawing.Size(50, 15);
            this.latitudeLabel.TabIndex = 1;
            this.latitudeLabel.Text = "Latitude";
            // 
            // latitudeIn
            // 
            this.latitudeIn.Location = new System.Drawing.Point(65, 25);
            this.latitudeIn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.latitudeIn.Name = "latitudeIn";
            this.latitudeIn.Size = new System.Drawing.Size(106, 23);
            this.latitudeIn.TabIndex = 0;
            // 
            // heightSame
            // 
            this.heightSame.AutoSize = true;
            this.heightSame.Checked = true;
            this.heightSame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.heightSame.Location = new System.Drawing.Point(246, 88);
            this.heightSame.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.heightSame.Name = "heightSame";
            this.heightSame.Size = new System.Drawing.Size(104, 19);
            this.heightSame.TabIndex = 7;
            this.heightSame.Text = "Same as Width";
            this.heightSame.UseVisualStyleBackColor = true;
            this.heightSame.CheckedChanged += new System.EventHandler(this.HeightSame_CheckedChanged);
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
            this.mapWidth.Location = new System.Drawing.Point(51, 115);
            this.mapWidth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mapWidth.Name = "mapWidth";
            this.mapWidth.Size = new System.Drawing.Size(119, 23);
            this.mapWidth.TabIndex = 1;
            this.mapWidth.SelectedIndexChanged += new System.EventHandler(this.MapWidth_SelectedIndexChanged);
            // 
            // heighLabel
            // 
            this.heighLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.heighLabel.AutoSize = true;
            this.heighLabel.Location = new System.Drawing.Point(185, 110);
            this.heighLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.heighLabel.Name = "heighLabel";
            this.heighLabel.Size = new System.Drawing.Size(43, 15);
            this.heighLabel.TabIndex = 4;
            this.heighLabel.Text = "Height";
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(4, 110);
            this.widthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(39, 15);
            this.widthLabel.TabIndex = 2;
            this.widthLabel.Text = "Width";
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
            this.mapHeight.Location = new System.Drawing.Point(236, 115);
            this.mapHeight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mapHeight.Name = "mapHeight";
            this.mapHeight.Size = new System.Drawing.Size(114, 23);
            this.mapHeight.TabIndex = 3;
            // 
            // savedDataTab
            // 
            this.savedDataTab.Controls.Add(this.savedElevationBox);
            this.savedDataTab.Location = new System.Drawing.Point(4, 24);
            this.savedDataTab.Name = "savedDataTab";
            this.savedDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.savedDataTab.Size = new System.Drawing.Size(361, 142);
            this.savedDataTab.TabIndex = 1;
            this.savedDataTab.Text = "Saved Data";
            this.savedDataTab.UseVisualStyleBackColor = true;
            // 
            // savedElevationBox
            // 
            this.savedElevationBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.savedElevationBox.FormattingEnabled = true;
            this.savedElevationBox.ItemHeight = 15;
            this.savedElevationBox.Location = new System.Drawing.Point(3, 3);
            this.savedElevationBox.Name = "savedElevationBox";
            this.savedElevationBox.Size = new System.Drawing.Size(355, 136);
            this.savedElevationBox.TabIndex = 0;
            // 
            // roundSettings
            // 
            this.roundSettings.Controls.Add(this.roundToNearest);
            this.roundSettings.Controls.Add(this.roundToNearestLabel);
            this.roundSettings.Enabled = false;
            this.roundSettings.Location = new System.Drawing.Point(174, 516);
            this.roundSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.roundSettings.Name = "roundSettings";
            this.roundSettings.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.roundSettings.Size = new System.Drawing.Size(201, 60);
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
            this.roundToNearest.Location = new System.Drawing.Point(124, 25);
            this.roundToNearest.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.roundToNearest.Name = "roundToNearest";
            this.roundToNearest.Size = new System.Drawing.Size(65, 23);
            this.roundToNearest.TabIndex = 2;
            // 
            // roundToNearestLabel
            // 
            this.roundToNearestLabel.AutoSize = true;
            this.roundToNearestLabel.Location = new System.Drawing.Point(7, 29);
            this.roundToNearestLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.roundToNearestLabel.Name = "roundToNearestLabel";
            this.roundToNearestLabel.Size = new System.Drawing.Size(100, 15);
            this.roundToNearestLabel.TabIndex = 1;
            this.roundToNearestLabel.Text = "Round To Nearest";
            // 
            // averageSettings
            // 
            this.averageSettings.Controls.Add(this.averageSmoothCapLabel);
            this.averageSettings.Controls.Add(this.maxVertexDifference);
            this.averageSettings.Controls.Add(this.averagePassesLabel);
            this.averageSettings.Controls.Add(this.averagePasses);
            this.averageSettings.Location = new System.Drawing.Point(174, 424);
            this.averageSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.averageSettings.Name = "averageSettings";
            this.averageSettings.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.averageSettings.Size = new System.Drawing.Size(201, 85);
            this.averageSettings.TabIndex = 11;
            this.averageSettings.TabStop = false;
            this.averageSettings.Text = "Average Smoothing Settings";
            // 
            // averageSmoothCapLabel
            // 
            this.averageSmoothCapLabel.AutoSize = true;
            this.averageSmoothCapLabel.Location = new System.Drawing.Point(7, 60);
            this.averageSmoothCapLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.averageSmoothCapLabel.Name = "averageSmoothCapLabel";
            this.averageSmoothCapLabel.Size = new System.Drawing.Size(87, 15);
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
            this.maxVertexDifference.Location = new System.Drawing.Point(124, 58);
            this.maxVertexDifference.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.maxVertexDifference.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxVertexDifference.Name = "maxVertexDifference";
            this.maxVertexDifference.Size = new System.Drawing.Size(65, 23);
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
            this.averagePassesLabel.Location = new System.Drawing.Point(7, 29);
            this.averagePassesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.averagePassesLabel.Name = "averagePassesLabel";
            this.averagePassesLabel.Size = new System.Drawing.Size(41, 15);
            this.averagePassesLabel.TabIndex = 1;
            this.averagePassesLabel.Text = "Passes";
            // 
            // averagePasses
            // 
            this.averagePasses.Location = new System.Drawing.Point(124, 27);
            this.averagePasses.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.averagePasses.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.averagePasses.Name = "averagePasses";
            this.averagePasses.Size = new System.Drawing.Size(65, 23);
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
            this.smoothingOptionsBox.Location = new System.Drawing.Point(6, 424);
            this.smoothingOptionsBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.smoothingOptionsBox.Name = "smoothingOptionsBox";
            this.smoothingOptionsBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.smoothingOptionsBox.Size = new System.Drawing.Size(160, 152);
            this.smoothingOptionsBox.TabIndex = 12;
            this.smoothingOptionsBox.TabStop = false;
            this.smoothingOptionsBox.Text = "Smoothing";
            // 
            // noSmoothing
            // 
            this.noSmoothing.Location = new System.Drawing.Point(7, 98);
            this.noSmoothing.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.noSmoothing.Name = "noSmoothing";
            this.noSmoothing.Size = new System.Drawing.Size(148, 28);
            this.noSmoothing.TabIndex = 5;
            this.noSmoothing.Text = "None";
            this.noSmoothing.UseVisualStyleBackColor = true;
            // 
            // roundSmoothing
            // 
            this.roundSmoothing.Location = new System.Drawing.Point(8, 64);
            this.roundSmoothing.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.roundSmoothing.Name = "roundSmoothing";
            this.roundSmoothing.Size = new System.Drawing.Size(148, 28);
            this.roundSmoothing.TabIndex = 4;
            this.roundSmoothing.Text = "Round";
            this.roundSmoothing.UseVisualStyleBackColor = true;
            // 
            // averageSmoothing
            // 
            this.averageSmoothing.Checked = true;
            this.averageSmoothing.Location = new System.Drawing.Point(8, 30);
            this.averageSmoothing.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.averageSmoothing.Name = "averageSmoothing";
            this.averageSmoothing.Size = new System.Drawing.Size(148, 28);
            this.averageSmoothing.TabIndex = 3;
            this.averageSmoothing.TabStop = true;
            this.averageSmoothing.Text = "Average";
            this.averageSmoothing.UseVisualStyleBackColor = true;
            // 
            // flattenSettings
            // 
            this.flattenSettings.Controls.Add(this.maxMapHeightLabel);
            this.flattenSettings.Controls.Add(this.flattenMax);
            this.flattenSettings.Controls.Add(this.minMapHeightLabel);
            this.flattenSettings.Controls.Add(this.flattenMin);
            this.flattenSettings.Enabled = false;
            this.flattenSettings.Location = new System.Drawing.Point(174, 320);
            this.flattenSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flattenSettings.Name = "flattenSettings";
            this.flattenSettings.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flattenSettings.Size = new System.Drawing.Size(201, 97);
            this.flattenSettings.TabIndex = 11;
            this.flattenSettings.TabStop = false;
            this.flattenSettings.Text = "Flatten Settings";
            // 
            // maxMapHeightLabel
            // 
            this.maxMapHeightLabel.AutoSize = true;
            this.maxMapHeightLabel.Location = new System.Drawing.Point(7, 62);
            this.maxMapHeightLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.maxMapHeightLabel.Name = "maxMapHeightLabel";
            this.maxMapHeightLabel.Size = new System.Drawing.Size(96, 15);
            this.maxMapHeightLabel.TabIndex = 3;
            this.maxMapHeightLabel.Text = "Max Map Height";
            // 
            // flattenMax
            // 
            this.flattenMax.Location = new System.Drawing.Point(124, 60);
            this.flattenMax.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flattenMax.Name = "flattenMax";
            this.flattenMax.Size = new System.Drawing.Size(65, 23);
            this.flattenMax.TabIndex = 2;
            this.flattenMax.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // minMapHeightLabel
            // 
            this.minMapHeightLabel.AutoSize = true;
            this.minMapHeightLabel.Location = new System.Drawing.Point(7, 29);
            this.minMapHeightLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.minMapHeightLabel.Name = "minMapHeightLabel";
            this.minMapHeightLabel.Size = new System.Drawing.Size(94, 15);
            this.minMapHeightLabel.TabIndex = 1;
            this.minMapHeightLabel.Text = "Min Map Height";
            // 
            // flattenMin
            // 
            this.flattenMin.Location = new System.Drawing.Point(124, 27);
            this.flattenMin.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flattenMin.Name = "flattenMin";
            this.flattenMin.Size = new System.Drawing.Size(65, 23);
            this.flattenMin.TabIndex = 0;
            // 
            // compressSettings
            // 
            this.compressSettings.Controls.Add(this.compressPassesLabel);
            this.compressSettings.Controls.Add(this.compressPasses);
            this.compressSettings.Location = new System.Drawing.Point(174, 251);
            this.compressSettings.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.compressSettings.Name = "compressSettings";
            this.compressSettings.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.compressSettings.Size = new System.Drawing.Size(201, 62);
            this.compressSettings.TabIndex = 10;
            this.compressSettings.TabStop = false;
            this.compressSettings.Text = "Compress Settings";
            // 
            // compressPassesLabel
            // 
            this.compressPassesLabel.AutoSize = true;
            this.compressPassesLabel.Location = new System.Drawing.Point(7, 29);
            this.compressPassesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.compressPassesLabel.Name = "compressPassesLabel";
            this.compressPassesLabel.Size = new System.Drawing.Size(41, 15);
            this.compressPassesLabel.TabIndex = 1;
            this.compressPassesLabel.Text = "Passes";
            // 
            // compressPasses
            // 
            this.compressPasses.Location = new System.Drawing.Point(124, 27);
            this.compressPasses.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.compressPasses.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.compressPasses.Name = "compressPasses";
            this.compressPasses.Size = new System.Drawing.Size(65, 23);
            this.compressPasses.TabIndex = 0;
            this.compressPasses.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // squashGroup
            // 
            this.squashGroup.Controls.Add(this.squishPercentLabel);
            this.squashGroup.Controls.Add(this.squishPercent);
            this.squashGroup.Controls.Add(this.noSquash);
            this.squashGroup.Controls.Add(this.flattenSquash);
            this.squashGroup.Controls.Add(this.compressSquash);
            this.squashGroup.Location = new System.Drawing.Point(6, 251);
            this.squashGroup.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.squashGroup.Name = "squashGroup";
            this.squashGroup.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.squashGroup.Size = new System.Drawing.Size(161, 166);
            this.squashGroup.TabIndex = 9;
            this.squashGroup.TabStop = false;
            this.squashGroup.Text = "Squash Settings";
            // 
            // squishPercentLabel
            // 
            this.squishPercentLabel.AutoSize = true;
            this.squishPercentLabel.Location = new System.Drawing.Point(7, 139);
            this.squishPercentLabel.Name = "squishPercentLabel";
            this.squishPercentLabel.Size = new System.Drawing.Size(83, 15);
            this.squishPercentLabel.TabIndex = 4;
            this.squishPercentLabel.Text = "Squish Until %";
            // 
            // squishPercent
            // 
            this.squishPercent.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.squishPercent.Location = new System.Drawing.Point(106, 137);
            this.squishPercent.Name = "squishPercent";
            this.squishPercent.Size = new System.Drawing.Size(48, 23);
            this.squishPercent.TabIndex = 3;
            this.squishPercent.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // noSquash
            // 
            this.noSquash.Location = new System.Drawing.Point(8, 90);
            this.noSquash.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.noSquash.Name = "noSquash";
            this.noSquash.Size = new System.Drawing.Size(148, 28);
            this.noSquash.TabIndex = 2;
            this.noSquash.Text = "None";
            this.noSquash.UseVisualStyleBackColor = true;
            this.noSquash.CheckedChanged += new System.EventHandler(this.NoSquash_CheckedChanged);
            // 
            // flattenSquash
            // 
            this.flattenSquash.Location = new System.Drawing.Point(8, 56);
            this.flattenSquash.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flattenSquash.Name = "flattenSquash";
            this.flattenSquash.Size = new System.Drawing.Size(148, 28);
            this.flattenSquash.TabIndex = 1;
            this.flattenSquash.Text = "Flatten";
            this.flattenSquash.UseVisualStyleBackColor = true;
            this.flattenSquash.CheckedChanged += new System.EventHandler(this.FlattenSquash_CheckedChanged);
            // 
            // compressSquash
            // 
            this.compressSquash.Checked = true;
            this.compressSquash.Location = new System.Drawing.Point(8, 22);
            this.compressSquash.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.compressSquash.Name = "compressSquash";
            this.compressSquash.Size = new System.Drawing.Size(148, 28);
            this.compressSquash.TabIndex = 0;
            this.compressSquash.TabStop = true;
            this.compressSquash.Text = "Compress";
            this.compressSquash.UseVisualStyleBackColor = true;
            this.compressSquash.CheckedChanged += new System.EventHandler(this.CompressSquash_CheckedChanged);
            // 
            // waterTypeSelection
            // 
            this.waterTypeSelection.Controls.Add(this.automaticWater);
            this.waterTypeSelection.Controls.Add(this.flattenWater);
            this.waterTypeSelection.Location = new System.Drawing.Point(7, 198);
            this.waterTypeSelection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.waterTypeSelection.Name = "waterTypeSelection";
            this.waterTypeSelection.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.waterTypeSelection.Size = new System.Drawing.Size(368, 47);
            this.waterTypeSelection.TabIndex = 8;
            this.waterTypeSelection.TabStop = false;
            this.waterTypeSelection.Text = "Water";
            // 
            // automaticWater
            // 
            this.automaticWater.Checked = true;
            this.automaticWater.Location = new System.Drawing.Point(105, 21);
            this.automaticWater.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.automaticWater.Name = "automaticWater";
            this.automaticWater.Size = new System.Drawing.Size(93, 20);
            this.automaticWater.TabIndex = 1;
            this.automaticWater.TabStop = true;
            this.automaticWater.Text = "Automatic";
            this.automaticWater.UseVisualStyleBackColor = true;
            // 
            // flattenWater
            // 
            this.flattenWater.Location = new System.Drawing.Point(7, 21);
            this.flattenWater.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.flattenWater.Name = "flattenWater";
            this.flattenWater.Size = new System.Drawing.Size(75, 20);
            this.flattenWater.TabIndex = 0;
            this.flattenWater.Text = "Flatten";
            this.flattenWater.UseVisualStyleBackColor = true;
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.generateButton.Location = new System.Drawing.Point(6, 584);
            this.generateButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(369, 27);
            this.generateButton.TabIndex = 0;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.GenerateButton_ClickAsync);
            // 
            // manualWaterBox
            // 
            this.manualWaterBox.Controls.Add(this.abyssElevation);
            this.manualWaterBox.Controls.Add(this.depthElevationLabel);
            this.manualWaterBox.Controls.Add(this.depthElevation);
            this.manualWaterBox.Controls.Add(this.abyssElevationLabel);
            this.manualWaterBox.Controls.Add(this.waterElevationLabel);
            this.manualWaterBox.Controls.Add(this.waterElevation);
            this.manualWaterBox.Location = new System.Drawing.Point(16, 15);
            this.manualWaterBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.manualWaterBox.Name = "manualWaterBox";
            this.manualWaterBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.manualWaterBox.Size = new System.Drawing.Size(451, 105);
            this.manualWaterBox.TabIndex = 14;
            this.manualWaterBox.TabStop = false;
            this.manualWaterBox.Text = "Generated Automatic Water Values";
            // 
            // abyssElevation
            // 
            this.abyssElevation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.abyssElevation.DecimalPlaces = 2;
            this.abyssElevation.Location = new System.Drawing.Point(303, 76);
            this.abyssElevation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.abyssElevation.Name = "abyssElevation";
            this.abyssElevation.ReadOnly = true;
            this.abyssElevation.Size = new System.Drawing.Size(140, 23);
            this.abyssElevation.TabIndex = 5;
            // 
            // depthElevationLabel
            // 
            this.depthElevationLabel.AutoSize = true;
            this.depthElevationLabel.Location = new System.Drawing.Point(7, 52);
            this.depthElevationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.depthElevationLabel.Name = "depthElevationLabel";
            this.depthElevationLabel.Size = new System.Drawing.Size(90, 15);
            this.depthElevationLabel.TabIndex = 1;
            this.depthElevationLabel.Text = "Depth Elevation";
            // 
            // depthElevation
            // 
            this.depthElevation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.depthElevation.DecimalPlaces = 2;
            this.depthElevation.Location = new System.Drawing.Point(303, 50);
            this.depthElevation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.depthElevation.Name = "depthElevation";
            this.depthElevation.ReadOnly = true;
            this.depthElevation.Size = new System.Drawing.Size(140, 23);
            this.depthElevation.TabIndex = 4;
            // 
            // abyssElevationLabel
            // 
            this.abyssElevationLabel.AutoSize = true;
            this.abyssElevationLabel.Location = new System.Drawing.Point(7, 78);
            this.abyssElevationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.abyssElevationLabel.Name = "abyssElevationLabel";
            this.abyssElevationLabel.Size = new System.Drawing.Size(89, 15);
            this.abyssElevationLabel.TabIndex = 2;
            this.abyssElevationLabel.Text = "Abyss Elevation";
            // 
            // waterElevationLabel
            // 
            this.waterElevationLabel.AutoSize = true;
            this.waterElevationLabel.Location = new System.Drawing.Point(7, 25);
            this.waterElevationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.waterElevationLabel.Name = "waterElevationLabel";
            this.waterElevationLabel.Size = new System.Drawing.Size(89, 15);
            this.waterElevationLabel.TabIndex = 0;
            this.waterElevationLabel.Text = "Water Elevation";
            // 
            // waterElevation
            // 
            this.waterElevation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.waterElevation.DecimalPlaces = 2;
            this.waterElevation.Location = new System.Drawing.Point(303, 23);
            this.waterElevation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.waterElevation.Name = "waterElevation";
            this.waterElevation.ReadOnly = true;
            this.waterElevation.Size = new System.Drawing.Size(140, 23);
            this.waterElevation.TabIndex = 3;
            // 
            // operationHoldingPanel
            // 
            this.operationHoldingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.operationHoldingPanel.Controls.Add(this.operationsPanel);
            this.operationHoldingPanel.Location = new System.Drawing.Point(402, 14);
            this.operationHoldingPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.operationHoldingPanel.Name = "operationHoldingPanel";
            this.operationHoldingPanel.Size = new System.Drawing.Size(911, 618);
            this.operationHoldingPanel.TabIndex = 1;
            // 
            // operationsPanel
            // 
            this.operationsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.operationsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.operationsPanel.Location = new System.Drawing.Point(0, 0);
            this.operationsPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
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
            this.operationsPanel.Size = new System.Drawing.Size(911, 618);
            this.operationsPanel.SplitterDistance = 385;
            this.operationsPanel.SplitterWidth = 9;
            this.operationsPanel.TabIndex = 0;
            // 
            // resultSection
            // 
            this.resultSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultSection.Location = new System.Drawing.Point(0, 0);
            this.resultSection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.resultSection.Name = "resultSection";
            // 
            // resultSection.Panel1
            // 
            this.resultSection.Panel1.Controls.Add(this.resultDisplay);
            // 
            // resultSection.Panel2
            // 
            this.resultSection.Panel2.Controls.Add(this.manualWaterBox);
            this.resultSection.Size = new System.Drawing.Size(909, 383);
            this.resultSection.SplitterDistance = 429;
            this.resultSection.SplitterWidth = 9;
            this.resultSection.TabIndex = 0;
            // 
            // resultDisplay
            // 
            this.resultDisplay.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.resultDisplay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultDisplay.Location = new System.Drawing.Point(0, 0);
            this.resultDisplay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.resultDisplay.Name = "resultDisplay";
            this.resultDisplay.Size = new System.Drawing.Size(429, 383);
            this.resultDisplay.TabIndex = 0;
            this.resultDisplay.TabStop = false;
            // 
            // loggerView
            // 
            this.loggerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loggerView.HideSelection = false;
            this.loggerView.Location = new System.Drawing.Point(0, 0);
            this.loggerView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.loggerView.Name = "loggerView";
            this.loggerView.Size = new System.Drawing.Size(909, 222);
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
            this.statusBar.Location = new System.Drawing.Point(0, 636);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusBar.Size = new System.Drawing.Size(1321, 24);
            this.statusBar.TabIndex = 2;
            this.statusBar.Text = "statusStrip1";
            // 
            // opeartionStatusLabel
            // 
            this.opeartionStatusLabel.Name = "opeartionStatusLabel";
            this.opeartionStatusLabel.Size = new System.Drawing.Size(63, 19);
            this.opeartionStatusLabel.Text = "Operation:";
            // 
            // globalStatus
            // 
            this.globalStatus.Name = "globalStatus";
            this.globalStatus.Size = new System.Drawing.Size(117, 18);
            // 
            // groupStatusLabel
            // 
            this.groupStatusLabel.Name = "groupStatusLabel";
            this.groupStatusLabel.Size = new System.Drawing.Size(46, 19);
            this.groupStatusLabel.Text = "Group: ";
            // 
            // groupStatus
            // 
            this.groupStatus.Name = "groupStatus";
            this.groupStatus.Size = new System.Drawing.Size(117, 18);
            // 
            // CoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 660);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.operationHoldingPanel);
            this.Controls.Add(this.settingsBox);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "CoreForm";
            this.Text = "World Heightmap Generator for the FAF Map Editor";
            this.settingsBox.ResumeLayout(false);
            this.dataTab.ResumeLayout(false);
            this.liveDataTab.ResumeLayout(false);
            this.liveDataTab.PerformLayout();
            this.globalPosition.ResumeLayout(false);
            this.globalPosition.PerformLayout();
            this.savedDataTab.ResumeLayout(false);
            this.roundSettings.ResumeLayout(false);
            this.roundSettings.PerformLayout();
            this.averageSettings.ResumeLayout(false);
            this.averageSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxVertexDifference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.averagePasses)).EndInit();
            this.smoothingOptionsBox.ResumeLayout(false);
            this.flattenSettings.ResumeLayout(false);
            this.flattenSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flattenMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flattenMin)).EndInit();
            this.compressSettings.ResumeLayout(false);
            this.compressSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compressPasses)).EndInit();
            this.squashGroup.ResumeLayout(false);
            this.squashGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.squishPercent)).EndInit();
            this.waterTypeSelection.ResumeLayout(false);
            this.manualWaterBox.ResumeLayout(false);
            this.manualWaterBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.abyssElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.depthElevation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.waterElevation)).EndInit();
            this.operationHoldingPanel.ResumeLayout(false);
            this.operationsPanel.Panel1.ResumeLayout(false);
            this.operationsPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.operationsPanel)).EndInit();
            this.operationsPanel.ResumeLayout(false);
            this.resultSection.Panel1.ResumeLayout(false);
            this.resultSection.Panel2.ResumeLayout(false);
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
        private System.Windows.Forms.RadioButton flattenWater;
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
        private System.Windows.Forms.NumericUpDown flattenMax;
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
        private System.Windows.Forms.GroupBox globalPosition;
        private System.Windows.Forms.Label latitudeLabel;
        private System.Windows.Forms.TextBox latitudeIn;
        private System.Windows.Forms.Label longitudeLabel;
        private System.Windows.Forms.TextBox longitudeIn;
        private System.Windows.Forms.GroupBox manualWaterBox;
        private System.Windows.Forms.Button elevationAPIKey;
        private System.Windows.Forms.NumericUpDown flattenMin;
        private System.Windows.Forms.TabControl dataTab;
        private System.Windows.Forms.TabPage liveDataTab;
        private System.Windows.Forms.TabPage savedDataTab;
        private System.Windows.Forms.ListBox savedElevationBox;
        private System.Windows.Forms.NumericUpDown squishPercent;
        private System.Windows.Forms.Label squishPercentLabel;
    }
}

