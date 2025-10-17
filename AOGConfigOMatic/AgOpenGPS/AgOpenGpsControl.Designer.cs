namespace AOGConfigOMatic.AgOpenGPS
{
    partial class AgOpenGpsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxReleases = new System.Windows.Forms.GroupBox();
            this.dataGridViewReleases = new System.Windows.Forms.DataGridView();
            this.colVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelReleaseControls = new System.Windows.Forms.Panel();
            this.btnCheckLatest = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chkIncludePreReleases = new System.Windows.Forms.CheckBox();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.btnDownloadZip = new System.Windows.Forms.Button();
            this.lblSelectedRelease = new System.Windows.Forms.Label();
            this.groupBoxDownloadPath = new System.Windows.Forms.GroupBox();
            this.btnBrowsePath = new System.Windows.Forms.Button();
            this.txtDownloadPath = new System.Windows.Forms.TextBox();
            this.lblDownloadTo = new System.Windows.Forms.Label();
            this.groupBoxLocalInstall = new System.Windows.Forms.GroupBox();
            this.chkStartWithWindows = new System.Windows.Forms.CheckBox();
            this.btnCreateDesktopShortcut = new System.Windows.Forms.Button();
            this.btnOpenInstallFolder = new System.Windows.Forms.Button();
            this.btnLaunchAgOpenGPS = new System.Windows.Forms.Button();
            this.lblInstallPath = new System.Windows.Forms.Label();
            this.lblInstalledVersion = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBoxReleases.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReleases)).BeginInit();
            this.panelReleaseControls.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.groupBoxDownloadPath.SuspendLayout();
            this.groupBoxLocalInstall.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxReleases
            // 
            this.groupBoxReleases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxReleases.Controls.Add(this.dataGridViewReleases);
            this.groupBoxReleases.Controls.Add(this.panelReleaseControls);
            this.groupBoxReleases.Location = new System.Drawing.Point(4, 4);
            this.groupBoxReleases.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxReleases.Name = "groupBoxReleases";
            this.groupBoxReleases.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxReleases.Size = new System.Drawing.Size(1059, 308);
            this.groupBoxReleases.TabIndex = 0;
            this.groupBoxReleases.TabStop = false;
            this.groupBoxReleases.Text = "Available Releases";
            // 
            // dataGridViewReleases
            // 
            this.dataGridViewReleases.AllowUserToAddRows = false;
            this.dataGridViewReleases.AllowUserToDeleteRows = false;
            this.dataGridViewReleases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewReleases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReleases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReleases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colVersion,
            this.colDate,
            this.colDescription,
            this.colSize});
            this.dataGridViewReleases.Location = new System.Drawing.Point(8, 62);
            this.dataGridViewReleases.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewReleases.MultiSelect = false;
            this.dataGridViewReleases.Name = "dataGridViewReleases";
            this.dataGridViewReleases.ReadOnly = true;
            this.dataGridViewReleases.RowHeadersWidth = 51;
            this.dataGridViewReleases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReleases.Size = new System.Drawing.Size(1043, 239);
            this.dataGridViewReleases.TabIndex = 1;
            this.dataGridViewReleases.SelectionChanged += new System.EventHandler(this.dataGridViewReleases_SelectionChanged);
            // 
            // colVersion
            // 
            this.colVersion.FillWeight = 80F;
            this.colVersion.HeaderText = "Version";
            this.colVersion.MinimumWidth = 6;
            this.colVersion.Name = "colVersion";
            this.colVersion.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.FillWeight = 80F;
            this.colDate.HeaderText = "Date";
            this.colDate.MinimumWidth = 6;
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.FillWeight = 200F;
            this.colDescription.HeaderText = "Description";
            this.colDescription.MinimumWidth = 6;
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colSize
            // 
            this.colSize.FillWeight = 60F;
            this.colSize.HeaderText = "Size";
            this.colSize.MinimumWidth = 6;
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            // 
            // panelReleaseControls
            // 
            this.panelReleaseControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelReleaseControls.Controls.Add(this.btnCheckLatest);
            this.panelReleaseControls.Controls.Add(this.btnRefresh);
            this.panelReleaseControls.Controls.Add(this.chkIncludePreReleases);
            this.panelReleaseControls.Location = new System.Drawing.Point(8, 23);
            this.panelReleaseControls.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelReleaseControls.Name = "panelReleaseControls";
            this.panelReleaseControls.Size = new System.Drawing.Size(1043, 31);
            this.panelReleaseControls.TabIndex = 0;
            // 
            // btnCheckLatest
            // 
            this.btnCheckLatest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckLatest.Location = new System.Drawing.Point(929, 1);
            this.btnCheckLatest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCheckLatest.Name = "btnCheckLatest";
            this.btnCheckLatest.Size = new System.Drawing.Size(113, 28);
            this.btnCheckLatest.TabIndex = 2;
            this.btnCheckLatest.Text = "Check Latest";
            this.btnCheckLatest.UseVisualStyleBackColor = true;
            this.btnCheckLatest.Click += new System.EventHandler(this.btnCheckLatest_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(821, 1);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 28);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chkIncludePreReleases
            // 
            this.chkIncludePreReleases.AutoSize = true;
            this.chkIncludePreReleases.Location = new System.Drawing.Point(4, 5);
            this.chkIncludePreReleases.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkIncludePreReleases.Name = "chkIncludePreReleases";
            this.chkIncludePreReleases.Size = new System.Drawing.Size(153, 20);
            this.chkIncludePreReleases.TabIndex = 0;
            this.chkIncludePreReleases.Text = "Include Pre-releases";
            this.chkIncludePreReleases.UseVisualStyleBackColor = true;
            this.chkIncludePreReleases.CheckedChanged += new System.EventHandler(this.chkIncludePreReleases_CheckedChanged);
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxActions.Controls.Add(this.btnDownloadZip);
            this.groupBoxActions.Controls.Add(this.lblSelectedRelease);
            this.groupBoxActions.Location = new System.Drawing.Point(4, 319);
            this.groupBoxActions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxActions.Size = new System.Drawing.Size(507, 98);
            this.groupBoxActions.TabIndex = 1;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Actions";
            // 
            // btnDownloadZip
            // 
            this.btnDownloadZip.Location = new System.Drawing.Point(20, 55);
            this.btnDownloadZip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDownloadZip.Name = "btnDownloadZip";
            this.btnDownloadZip.Size = new System.Drawing.Size(160, 28);
            this.btnDownloadZip.TabIndex = 1;
            this.btnDownloadZip.Text = "Download Zip";
            this.btnDownloadZip.UseVisualStyleBackColor = true;
            this.btnDownloadZip.Click += new System.EventHandler(this.btnDownloadZip_Click);
            // 
            // lblSelectedRelease
            // 
            this.lblSelectedRelease.AutoSize = true;
            this.lblSelectedRelease.Location = new System.Drawing.Point(16, 27);
            this.lblSelectedRelease.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectedRelease.Name = "lblSelectedRelease";
            this.lblSelectedRelease.Size = new System.Drawing.Size(105, 16);
            this.lblSelectedRelease.TabIndex = 0;
            this.lblSelectedRelease.Text = "Selected: (none)";
            // 
            // groupBoxDownloadPath
            // 
            this.groupBoxDownloadPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDownloadPath.Controls.Add(this.btnBrowsePath);
            this.groupBoxDownloadPath.Controls.Add(this.txtDownloadPath);
            this.groupBoxDownloadPath.Controls.Add(this.lblDownloadTo);
            this.groupBoxDownloadPath.Location = new System.Drawing.Point(519, 319);
            this.groupBoxDownloadPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxDownloadPath.Name = "groupBoxDownloadPath";
            this.groupBoxDownloadPath.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxDownloadPath.Size = new System.Drawing.Size(544, 98);
            this.groupBoxDownloadPath.TabIndex = 2;
            this.groupBoxDownloadPath.TabStop = false;
            this.groupBoxDownloadPath.Text = "Download Location";
            // 
            // btnBrowsePath
            // 
            this.btnBrowsePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowsePath.Location = new System.Drawing.Point(436, 53);
            this.btnBrowsePath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBrowsePath.Name = "btnBrowsePath";
            this.btnBrowsePath.Size = new System.Drawing.Size(100, 28);
            this.btnBrowsePath.TabIndex = 2;
            this.btnBrowsePath.Text = "Browse...";
            this.btnBrowsePath.UseVisualStyleBackColor = true;
            this.btnBrowsePath.Click += new System.EventHandler(this.btnBrowsePath_Click);
            // 
            // txtDownloadPath
            // 
            this.txtDownloadPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDownloadPath.Location = new System.Drawing.Point(20, 55);
            this.txtDownloadPath.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDownloadPath.Name = "txtDownloadPath";
            this.txtDownloadPath.ReadOnly = true;
            this.txtDownloadPath.Size = new System.Drawing.Size(407, 22);
            this.txtDownloadPath.TabIndex = 1;
            // 
            // lblDownloadTo
            // 
            this.lblDownloadTo.AutoSize = true;
            this.lblDownloadTo.Location = new System.Drawing.Point(16, 27);
            this.lblDownloadTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDownloadTo.Name = "lblDownloadTo";
            this.lblDownloadTo.Size = new System.Drawing.Size(85, 16);
            this.lblDownloadTo.TabIndex = 0;
            this.lblDownloadTo.Text = "Download to:";
            // 
            // groupBoxLocalInstall
            // 
            this.groupBoxLocalInstall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLocalInstall.Controls.Add(this.chkStartWithWindows);
            this.groupBoxLocalInstall.Controls.Add(this.btnCreateDesktopShortcut);
            this.groupBoxLocalInstall.Controls.Add(this.btnOpenInstallFolder);
            this.groupBoxLocalInstall.Controls.Add(this.btnLaunchAgOpenGPS);
            this.groupBoxLocalInstall.Controls.Add(this.lblInstallPath);
            this.groupBoxLocalInstall.Controls.Add(this.lblInstalledVersion);
            this.groupBoxLocalInstall.Location = new System.Drawing.Point(4, 425);
            this.groupBoxLocalInstall.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxLocalInstall.Name = "groupBoxLocalInstall";
            this.groupBoxLocalInstall.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxLocalInstall.Size = new System.Drawing.Size(1059, 148);
            this.groupBoxLocalInstall.TabIndex = 3;
            this.groupBoxLocalInstall.TabStop = false;
            this.groupBoxLocalInstall.Text = "Local Installation";
            // 
            // chkStartWithWindows
            // 
            this.chkStartWithWindows.AutoSize = true;
            this.chkStartWithWindows.Location = new System.Drawing.Point(20, 117);
            this.chkStartWithWindows.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkStartWithWindows.Name = "chkStartWithWindows";
            this.chkStartWithWindows.Size = new System.Drawing.Size(220, 20);
            this.chkStartWithWindows.TabIndex = 4;
            this.chkStartWithWindows.Text = "Start AgOpenGPS with Windows";
            this.chkStartWithWindows.UseVisualStyleBackColor = true;
            this.chkStartWithWindows.CheckedChanged += new System.EventHandler(this.chkStartWithWindows_CheckedChanged);
            // 
            // btnCreateDesktopShortcut
            // 
            this.btnCreateDesktopShortcut.Location = new System.Drawing.Point(400, 80);
            this.btnCreateDesktopShortcut.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreateDesktopShortcut.Name = "btnCreateDesktopShortcut";
            this.btnCreateDesktopShortcut.Size = new System.Drawing.Size(270, 28);
            this.btnCreateDesktopShortcut.TabIndex = 5;
            this.btnCreateDesktopShortcut.Text = "Create Desktop Shortcut";
            this.btnCreateDesktopShortcut.UseVisualStyleBackColor = true;
            this.btnCreateDesktopShortcut.Click += new System.EventHandler(this.btnCreateDesktopShortcut_Click);
            // 
            // btnOpenInstallFolder
            // 
            this.btnOpenInstallFolder.Location = new System.Drawing.Point(207, 80);
            this.btnOpenInstallFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnOpenInstallFolder.Name = "btnOpenInstallFolder";
            this.btnOpenInstallFolder.Size = new System.Drawing.Size(160, 28);
            this.btnOpenInstallFolder.TabIndex = 3;
            this.btnOpenInstallFolder.Text = "Open Install Folder";
            this.btnOpenInstallFolder.UseVisualStyleBackColor = true;
            this.btnOpenInstallFolder.Click += new System.EventHandler(this.btnOpenInstallFolder_Click);
            // 
            // btnLaunchAgOpenGPS
            // 
            this.btnLaunchAgOpenGPS.Enabled = false;
            this.btnLaunchAgOpenGPS.Location = new System.Drawing.Point(20, 80);
            this.btnLaunchAgOpenGPS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLaunchAgOpenGPS.Name = "btnLaunchAgOpenGPS";
            this.btnLaunchAgOpenGPS.Size = new System.Drawing.Size(160, 28);
            this.btnLaunchAgOpenGPS.TabIndex = 2;
            this.btnLaunchAgOpenGPS.Text = "Launch AgOpenGPS";
            this.btnLaunchAgOpenGPS.UseVisualStyleBackColor = true;
            this.btnLaunchAgOpenGPS.Click += new System.EventHandler(this.btnLaunchAgOpenGPS_Click);
            // 
            // lblInstallPath
            // 
            this.lblInstallPath.AutoSize = true;
            this.lblInstallPath.Location = new System.Drawing.Point(16, 52);
            this.lblInstallPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstallPath.Name = "lblInstallPath";
            this.lblInstallPath.Size = new System.Drawing.Size(159, 16);
            this.lblInstallPath.TabIndex = 1;
            this.lblInstallPath.Text = "Install Path: (not detected)";
            // 
            // lblInstalledVersion
            // 
            this.lblInstalledVersion.AutoSize = true;
            this.lblInstalledVersion.Location = new System.Drawing.Point(16, 27);
            this.lblInstalledVersion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInstalledVersion.Name = "lblInstalledVersion";
            this.lblInstalledVersion.Size = new System.Drawing.Size(172, 16);
            this.lblInstalledVersion.TabIndex = 0;
            this.lblInstalledVersion.Text = "Installed Version: (unknown)";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(4, 604);
            this.progressBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1059, 18);
            this.progressBar.TabIndex = 4;
            this.progressBar.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(4, 585);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(48, 16);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Ready";
            // 
            // AgOpenGpsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBoxLocalInstall);
            this.Controls.Add(this.groupBoxDownloadPath);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxReleases);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AgOpenGpsControl";
            this.Size = new System.Drawing.Size(1067, 628);
            this.groupBoxReleases.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReleases)).EndInit();
            this.panelReleaseControls.ResumeLayout(false);
            this.panelReleaseControls.PerformLayout();
            this.groupBoxActions.ResumeLayout(false);
            this.groupBoxActions.PerformLayout();
            this.groupBoxDownloadPath.ResumeLayout(false);
            this.groupBoxDownloadPath.PerformLayout();
            this.groupBoxLocalInstall.ResumeLayout(false);
            this.groupBoxLocalInstall.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxReleases;
        private System.Windows.Forms.DataGridView dataGridViewReleases;
        private System.Windows.Forms.Panel panelReleaseControls;
        private System.Windows.Forms.Button btnCheckLatest;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckBox chkIncludePreReleases;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.Button btnDownloadZip;
        private System.Windows.Forms.Label lblSelectedRelease;
        private System.Windows.Forms.GroupBox groupBoxDownloadPath;
        private System.Windows.Forms.Button btnBrowsePath;
        private System.Windows.Forms.TextBox txtDownloadPath;
        private System.Windows.Forms.Label lblDownloadTo;
        private System.Windows.Forms.GroupBox groupBoxLocalInstall;
        private System.Windows.Forms.Button btnOpenInstallFolder;
        private System.Windows.Forms.Button btnLaunchAgOpenGPS;
        private System.Windows.Forms.Label lblInstallPath;
        private System.Windows.Forms.Label lblInstalledVersion;
        private System.Windows.Forms.CheckBox chkStartWithWindows;
        private System.Windows.Forms.Button btnCreateDesktopShortcut;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
    }
}