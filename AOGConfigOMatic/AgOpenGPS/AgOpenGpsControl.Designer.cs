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
            this.groupBoxReleases.Location = new System.Drawing.Point(3, 3);
            this.groupBoxReleases.Name = "groupBoxReleases";
            this.groupBoxReleases.Size = new System.Drawing.Size(794, 250);
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
            this.dataGridViewReleases.Location = new System.Drawing.Point(6, 50);
            this.dataGridViewReleases.MultiSelect = false;
            this.dataGridViewReleases.Name = "dataGridViewReleases";
            this.dataGridViewReleases.ReadOnly = true;
            this.dataGridViewReleases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReleases.Size = new System.Drawing.Size(782, 194);
            this.dataGridViewReleases.TabIndex = 1;
            this.dataGridViewReleases.SelectionChanged += new System.EventHandler(this.dataGridViewReleases_SelectionChanged);
            // 
            // colVersion
            // 
            this.colVersion.FillWeight = 80F;
            this.colVersion.HeaderText = "Version";
            this.colVersion.Name = "colVersion";
            this.colVersion.ReadOnly = true;
            // 
            // colDate
            // 
            this.colDate.FillWeight = 80F;
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            // 
            // colDescription
            // 
            this.colDescription.FillWeight = 200F;
            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.ReadOnly = true;
            // 
            // colSize
            // 
            this.colSize.FillWeight = 60F;
            this.colSize.HeaderText = "Size";
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
            this.panelReleaseControls.Location = new System.Drawing.Point(6, 19);
            this.panelReleaseControls.Name = "panelReleaseControls";
            this.panelReleaseControls.Size = new System.Drawing.Size(782, 25);
            this.panelReleaseControls.TabIndex = 0;
            // 
            // btnCheckLatest
            // 
            this.btnCheckLatest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckLatest.Location = new System.Drawing.Point(697, 1);
            this.btnCheckLatest.Name = "btnCheckLatest";
            this.btnCheckLatest.Size = new System.Drawing.Size(85, 23);
            this.btnCheckLatest.TabIndex = 2;
            this.btnCheckLatest.Text = "Check Latest";
            this.btnCheckLatest.UseVisualStyleBackColor = true;
            this.btnCheckLatest.Click += new System.EventHandler(this.btnCheckLatest_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(616, 1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chkIncludePreReleases
            // 
            this.chkIncludePreReleases.AutoSize = true;
            this.chkIncludePreReleases.Location = new System.Drawing.Point(3, 4);
            this.chkIncludePreReleases.Name = "chkIncludePreReleases";
            this.chkIncludePreReleases.Size = new System.Drawing.Size(129, 17);
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
            this.groupBoxActions.Location = new System.Drawing.Point(3, 259);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(380, 80);
            this.groupBoxActions.TabIndex = 1;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Actions";
            // 
            // btnDownloadZip
            // 
            this.btnDownloadZip.Location = new System.Drawing.Point(15, 45);
            this.btnDownloadZip.Name = "btnDownloadZip";
            this.btnDownloadZip.Size = new System.Drawing.Size(120, 23);
            this.btnDownloadZip.TabIndex = 1;
            this.btnDownloadZip.Text = "Download Zip";
            this.btnDownloadZip.UseVisualStyleBackColor = true;
            this.btnDownloadZip.Click += new System.EventHandler(this.btnDownloadZip_Click);
            // 
            // lblSelectedRelease
            // 
            this.lblSelectedRelease.AutoSize = true;
            this.lblSelectedRelease.Location = new System.Drawing.Point(12, 22);
            this.lblSelectedRelease.Name = "lblSelectedRelease";
            this.lblSelectedRelease.Size = new System.Drawing.Size(89, 13);
            this.lblSelectedRelease.TabIndex = 0;
            this.lblSelectedRelease.Text = "Selected: (none)";
            // 
            // groupBoxDownloadPath
            // 
            this.groupBoxDownloadPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxDownloadPath.Controls.Add(this.btnBrowsePath);
            this.groupBoxDownloadPath.Controls.Add(this.txtDownloadPath);
            this.groupBoxDownloadPath.Controls.Add(this.lblDownloadTo);
            this.groupBoxDownloadPath.Location = new System.Drawing.Point(389, 259);
            this.groupBoxDownloadPath.Name = "groupBoxDownloadPath";
            this.groupBoxDownloadPath.Size = new System.Drawing.Size(408, 80);
            this.groupBoxDownloadPath.TabIndex = 2;
            this.groupBoxDownloadPath.TabStop = false;
            this.groupBoxDownloadPath.Text = "Download Location";
            // 
            // btnBrowsePath
            // 
            this.btnBrowsePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowsePath.Location = new System.Drawing.Point(327, 43);
            this.btnBrowsePath.Name = "btnBrowsePath";
            this.btnBrowsePath.Size = new System.Drawing.Size(75, 23);
            this.btnBrowsePath.TabIndex = 2;
            this.btnBrowsePath.Text = "Browse...";
            this.btnBrowsePath.UseVisualStyleBackColor = true;
            this.btnBrowsePath.Click += new System.EventHandler(this.btnBrowsePath_Click);
            // 
            // txtDownloadPath
            // 
            this.txtDownloadPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDownloadPath.Location = new System.Drawing.Point(15, 45);
            this.txtDownloadPath.Name = "txtDownloadPath";
            this.txtDownloadPath.ReadOnly = true;
            this.txtDownloadPath.Size = new System.Drawing.Size(306, 20);
            this.txtDownloadPath.TabIndex = 1;
            // 
            // lblDownloadTo
            // 
            this.lblDownloadTo.AutoSize = true;
            this.lblDownloadTo.Location = new System.Drawing.Point(12, 22);
            this.lblDownloadTo.Name = "lblDownloadTo";
            this.lblDownloadTo.Size = new System.Drawing.Size(70, 13);
            this.lblDownloadTo.TabIndex = 0;
            this.lblDownloadTo.Text = "Download to:";
            // 
            // groupBoxLocalInstall
            // 
            this.groupBoxLocalInstall.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxLocalInstall.Controls.Add(this.btnOpenInstallFolder);
            this.groupBoxLocalInstall.Controls.Add(this.btnLaunchAgOpenGPS);
            this.groupBoxLocalInstall.Controls.Add(this.lblInstallPath);
            this.groupBoxLocalInstall.Controls.Add(this.lblInstalledVersion);
            this.groupBoxLocalInstall.Location = new System.Drawing.Point(3, 345);
            this.groupBoxLocalInstall.Name = "groupBoxLocalInstall";
            this.groupBoxLocalInstall.Size = new System.Drawing.Size(794, 100);
            this.groupBoxLocalInstall.TabIndex = 3;
            this.groupBoxLocalInstall.TabStop = false;
            this.groupBoxLocalInstall.Text = "Local Installation";
            // 
            // btnOpenInstallFolder
            // 
            this.btnOpenInstallFolder.Location = new System.Drawing.Point(155, 65);
            this.btnOpenInstallFolder.Name = "btnOpenInstallFolder";
            this.btnOpenInstallFolder.Size = new System.Drawing.Size(120, 23);
            this.btnOpenInstallFolder.TabIndex = 3;
            this.btnOpenInstallFolder.Text = "Open Install Folder";
            this.btnOpenInstallFolder.UseVisualStyleBackColor = true;
            this.btnOpenInstallFolder.Click += new System.EventHandler(this.btnOpenInstallFolder_Click);
            // 
            // btnLaunchAgOpenGPS
            // 
            this.btnLaunchAgOpenGPS.Enabled = false;
            this.btnLaunchAgOpenGPS.Location = new System.Drawing.Point(15, 65);
            this.btnLaunchAgOpenGPS.Name = "btnLaunchAgOpenGPS";
            this.btnLaunchAgOpenGPS.Size = new System.Drawing.Size(120, 23);
            this.btnLaunchAgOpenGPS.TabIndex = 2;
            this.btnLaunchAgOpenGPS.Text = "Launch AgOpenGPS";
            this.btnLaunchAgOpenGPS.UseVisualStyleBackColor = true;
            this.btnLaunchAgOpenGPS.Click += new System.EventHandler(this.btnLaunchAgOpenGPS_Click);
            // 
            // lblInstallPath
            // 
            this.lblInstallPath.AutoSize = true;
            this.lblInstallPath.Location = new System.Drawing.Point(12, 42);
            this.lblInstallPath.Name = "lblInstallPath";
            this.lblInstallPath.Size = new System.Drawing.Size(133, 13);
            this.lblInstallPath.TabIndex = 1;
            this.lblInstallPath.Text = "Install Path: (not detected)";
            // 
            // lblInstalledVersion
            // 
            this.lblInstalledVersion.AutoSize = true;
            this.lblInstalledVersion.Location = new System.Drawing.Point(12, 22);
            this.lblInstalledVersion.Name = "lblInstalledVersion";
            this.lblInstalledVersion.Size = new System.Drawing.Size(142, 13);
            this.lblInstalledVersion.TabIndex = 0;
            this.lblInstalledVersion.Text = "Installed Version: (unknown)";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(3, 471);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(794, 15);
            this.progressBar.TabIndex = 4;
            this.progressBar.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(3, 455);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Ready";
            // 
            // AgOpenGpsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.groupBoxLocalInstall);
            this.Controls.Add(this.groupBoxDownloadPath);
            this.Controls.Add(this.groupBoxActions);
            this.Controls.Add(this.groupBoxReleases);
            this.Name = "AgOpenGpsControl";
            this.Size = new System.Drawing.Size(800, 490);
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
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVersion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSize;
    }
}