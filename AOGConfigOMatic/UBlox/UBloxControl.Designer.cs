namespace AOGConfigOMatic.UBlox
{
    partial class UBloxControl
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
            this.components = new System.ComponentModel.Container();
            this.pbConfiguration = new System.Windows.Forms.ProgressBar();
            this.pblF9PConfig = new System.Windows.Forms.Panel();
            this.rbDualRelPos = new System.Windows.Forms.RadioButton();
            this.rbDualLocation = new System.Windows.Forms.RadioButton();
            this.rbSingleF9P = new System.Windows.Forms.RadioButton();
            this.lblFirmwareWarning = new System.Windows.Forms.Label();
            this.btnConfigF9P = new System.Windows.Forms.Button();
            this.btnF9PFlashFirmware = new System.Windows.Forms.Button();
            this.lblFirmware = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblCOMPorts = new System.Windows.Forms.Label();
            this.txtSerialChat = new System.Windows.Forms.TextBox();
            this.lbCOMPorts = new System.Windows.Forms.ListBox();
            this.btnURefresh = new System.Windows.Forms.Button();
            this.lblUblox = new System.Windows.Forms.Label();
            this.tmrMessages = new System.Windows.Forms.Timer(this.components);
            this.pblF9PConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbConfiguration
            // 
            this.pbConfiguration.Location = new System.Drawing.Point(27, 644);
            this.pbConfiguration.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbConfiguration.Name = "pbConfiguration";
            this.pbConfiguration.Size = new System.Drawing.Size(904, 23);
            this.pbConfiguration.TabIndex = 13;
            // 
            // pblF9PConfig
            // 
            this.pblF9PConfig.Controls.Add(this.rbDualRelPos);
            this.pblF9PConfig.Controls.Add(this.rbDualLocation);
            this.pblF9PConfig.Controls.Add(this.rbSingleF9P);
            this.pblF9PConfig.Location = new System.Drawing.Point(308, 217);
            this.pblF9PConfig.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pblF9PConfig.Name = "pblF9PConfig";
            this.pblF9PConfig.Size = new System.Drawing.Size(333, 126);
            this.pblF9PConfig.TabIndex = 12;
            // 
            // rbDualRelPos
            // 
            this.rbDualRelPos.AutoSize = true;
            this.rbDualRelPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDualRelPos.Location = new System.Drawing.Point(13, 75);
            this.rbDualRelPos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbDualRelPos.Name = "rbDualRelPos";
            this.rbDualRelPos.Size = new System.Drawing.Size(201, 29);
            this.rbDualRelPos.TabIndex = 2;
            this.rbDualRelPos.Text = "Dual - Left - RelPos";
            this.rbDualRelPos.UseVisualStyleBackColor = true;
            this.rbDualRelPos.CheckedChanged += new System.EventHandler(this.rbDualRelPos_CheckedChanged);
            // 
            // rbDualLocation
            // 
            this.rbDualLocation.AutoSize = true;
            this.rbDualLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDualLocation.Location = new System.Drawing.Point(13, 39);
            this.rbDualLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbDualLocation.Name = "rbDualLocation";
            this.rbDualLocation.Size = new System.Drawing.Size(220, 29);
            this.rbDualLocation.TabIndex = 1;
            this.rbDualLocation.Text = "Dual - Right - Position";
            this.rbDualLocation.UseVisualStyleBackColor = true;
            this.rbDualLocation.CheckedChanged += new System.EventHandler(this.rbDualLocation_CheckedChanged);
            // 
            // rbSingleF9P
            // 
            this.rbSingleF9P.AutoSize = true;
            this.rbSingleF9P.Checked = true;
            this.rbSingleF9P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbSingleF9P.Location = new System.Drawing.Point(13, 2);
            this.rbSingleF9P.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbSingleF9P.Name = "rbSingleF9P";
            this.rbSingleF9P.Size = new System.Drawing.Size(88, 29);
            this.rbSingleF9P.TabIndex = 0;
            this.rbSingleF9P.TabStop = true;
            this.rbSingleF9P.Text = "Single";
            this.rbSingleF9P.UseVisualStyleBackColor = true;
            this.rbSingleF9P.CheckedChanged += new System.EventHandler(this.rbSingleF9P_CheckedChanged);
            // 
            // lblFirmwareWarning
            // 
            this.lblFirmwareWarning.AutoSize = true;
            this.lblFirmwareWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirmwareWarning.Location = new System.Drawing.Point(653, 57);
            this.lblFirmwareWarning.Name = "lblFirmwareWarning";
            this.lblFirmwareWarning.Size = new System.Drawing.Size(0, 20);
            this.lblFirmwareWarning.TabIndex = 11;
            // 
            // btnConfigF9P
            // 
            this.btnConfigF9P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigF9P.Location = new System.Drawing.Point(308, 140);
            this.btnConfigF9P.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfigF9P.Name = "btnConfigF9P";
            this.btnConfigF9P.Size = new System.Drawing.Size(160, 50);
            this.btnConfigF9P.TabIndex = 10;
            this.btnConfigF9P.Text = "Configure F9P";
            this.btnConfigF9P.UseVisualStyleBackColor = true;
            this.btnConfigF9P.Click += new System.EventHandler(this.btnConfigF9P_Click);
            // 
            // btnF9PFlashFirmware
            // 
            this.btnF9PFlashFirmware.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF9PFlashFirmware.Location = new System.Drawing.Point(483, 140);
            this.btnF9PFlashFirmware.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnF9PFlashFirmware.Name = "btnF9PFlashFirmware";
            this.btnF9PFlashFirmware.Size = new System.Drawing.Size(160, 50);
            this.btnF9PFlashFirmware.TabIndex = 9;
            this.btnF9PFlashFirmware.Text = "Flash firmware";
            this.btnF9PFlashFirmware.UseVisualStyleBackColor = true;
            this.btnF9PFlashFirmware.Click += new System.EventHandler(this.btnF9PFlashFirmware_Click);
            // 
            // lblFirmware
            // 
            this.lblFirmware.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirmware.Location = new System.Drawing.Point(653, 96);
            this.lblFirmware.Name = "lblFirmware";
            this.lblFirmware.Size = new System.Drawing.Size(307, 254);
            this.lblFirmware.TabIndex = 8;
            this.lblFirmware.Text = "Firmware";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(308, 76);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(160, 50);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblCOMPorts
            // 
            this.lblCOMPorts.AutoSize = true;
            this.lblCOMPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCOMPorts.Location = new System.Drawing.Point(21, 140);
            this.lblCOMPorts.Name = "lblCOMPorts";
            this.lblCOMPorts.Size = new System.Drawing.Size(110, 25);
            this.lblCOMPorts.TabIndex = 5;
            this.lblCOMPorts.Text = "Serial ports";
            // 
            // txtSerialChat
            // 
            this.txtSerialChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialChat.Location = new System.Drawing.Point(27, 353);
            this.txtSerialChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSerialChat.Multiline = true;
            this.txtSerialChat.Name = "txtSerialChat";
            this.txtSerialChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSerialChat.Size = new System.Drawing.Size(905, 285);
            this.txtSerialChat.TabIndex = 4;
            // 
            // lbCOMPorts
            // 
            this.lbCOMPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCOMPorts.FormattingEnabled = true;
            this.lbCOMPorts.ItemHeight = 25;
            this.lbCOMPorts.Location = new System.Drawing.Point(27, 167);
            this.lbCOMPorts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbCOMPorts.Name = "lbCOMPorts";
            this.lbCOMPorts.Size = new System.Drawing.Size(240, 154);
            this.lbCOMPorts.TabIndex = 3;
            this.lbCOMPorts.SelectedIndexChanged += new System.EventHandler(this.lbCOMPorts_SelectedIndexChanged);
            // 
            // btnURefresh
            // 
            this.btnURefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnURefresh.Location = new System.Drawing.Point(27, 76);
            this.btnURefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnURefresh.Name = "btnURefresh";
            this.btnURefresh.Size = new System.Drawing.Size(240, 50);
            this.btnURefresh.TabIndex = 2;
            this.btnURefresh.Text = "Rescan Ports";
            this.btnURefresh.UseVisualStyleBackColor = true;
            this.btnURefresh.Click += new System.EventHandler(this.btnURefresh_Click);
            // 
            // lblUblox
            // 
            this.lblUblox.AutoSize = true;
            this.lblUblox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUblox.Location = new System.Drawing.Point(21, 21);
            this.lblUblox.Name = "lblUblox";
            this.lblUblox.Size = new System.Drawing.Size(234, 29);
            this.lblUblox.TabIndex = 0;
            this.lblUblox.Text = "U-Blox Configuration";
            // 
            // tmrMessages
            // 
            this.tmrMessages.Interval = 3000;
            // 
            // UBloxControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbConfiguration);
            this.Controls.Add(this.pblF9PConfig);
            this.Controls.Add(this.lblFirmwareWarning);
            this.Controls.Add(this.btnConfigF9P);
            this.Controls.Add(this.btnF9PFlashFirmware);
            this.Controls.Add(this.lblFirmware);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lblCOMPorts);
            this.Controls.Add(this.txtSerialChat);
            this.Controls.Add(this.lbCOMPorts);
            this.Controls.Add(this.btnURefresh);
            this.Controls.Add(this.lblUblox);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UBloxControl";
            this.Size = new System.Drawing.Size(960, 663);
            this.Load += new System.EventHandler(this.UBloxControl_Load);
            this.pblF9PConfig.ResumeLayout(false);
            this.pblF9PConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbConfiguration;
        private System.Windows.Forms.Panel pblF9PConfig;
        private System.Windows.Forms.RadioButton rbDualRelPos;
        private System.Windows.Forms.RadioButton rbDualLocation;
        private System.Windows.Forms.RadioButton rbSingleF9P;
        private System.Windows.Forms.Label lblFirmwareWarning;
        private System.Windows.Forms.Button btnConfigF9P;
        private System.Windows.Forms.Button btnF9PFlashFirmware;
        private System.Windows.Forms.Label lblFirmware;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblCOMPorts;
        private System.Windows.Forms.TextBox txtSerialChat;
        private System.Windows.Forms.ListBox lbCOMPorts;
        private System.Windows.Forms.Button btnURefresh;
        private System.Windows.Forms.Label lblUblox;
        private System.Windows.Forms.Timer tmrMessages;
    }
}
