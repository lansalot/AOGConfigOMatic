using libTeensySharp;
using lunOptics.libTeensySharp;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace AOGConfigOMatic
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tbPages = new System.Windows.Forms.TabControl();
            this.tabGPS = new System.Windows.Forms.TabPage();
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
            this.tabTeensy = new System.Windows.Forms.TabPage();
            this.tabUM982 = new System.Windows.Forms.TabPage();
            this.btnHelp = new System.Windows.Forms.Button();
            this.teensyControl = new AOGConfigOMatic.Teensy.TeensyControl();
            this.um982Control = new AOGConfigOMatic.UM982.UM982Control();
            this.tbPages.SuspendLayout();
            this.tabGPS.SuspendLayout();
            this.pblF9PConfig.SuspendLayout();
            this.tabTeensy.SuspendLayout();
            this.tabUM982.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPages
            // 
            this.tbPages.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tbPages.Controls.Add(this.tabGPS);
            this.tbPages.Controls.Add(this.tabTeensy);
            this.tbPages.Controls.Add(this.tabUM982);
            this.tbPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPages.Location = new System.Drawing.Point(10, 11);
            this.tbPages.Name = "tbPages";
            this.tbPages.SelectedIndex = 0;
            this.tbPages.Size = new System.Drawing.Size(728, 584);
            this.tbPages.TabIndex = 11;
            this.tbPages.SelectedIndexChanged += new System.EventHandler(this.tbPages_SelectedIndexChanged);
            // 
            // tabGPS
            // 
            this.tabGPS.Controls.Add(this.pbConfiguration);
            this.tabGPS.Controls.Add(this.pblF9PConfig);
            this.tabGPS.Controls.Add(this.lblFirmwareWarning);
            this.tabGPS.Controls.Add(this.btnConfigF9P);
            this.tabGPS.Controls.Add(this.btnF9PFlashFirmware);
            this.tabGPS.Controls.Add(this.lblFirmware);
            this.tabGPS.Controls.Add(this.btnConnect);
            this.tabGPS.Controls.Add(this.lblCOMPorts);
            this.tabGPS.Controls.Add(this.txtSerialChat);
            this.tabGPS.Controls.Add(this.lbCOMPorts);
            this.tabGPS.Controls.Add(this.btnURefresh);
            this.tabGPS.Controls.Add(this.lblUblox);
            this.tabGPS.Location = new System.Drawing.Point(4, 41);
            this.tabGPS.Name = "tabGPS";
            this.tabGPS.Size = new System.Drawing.Size(720, 539);
            this.tabGPS.TabIndex = 1;
            this.tabGPS.Text = "Ublox";
            this.tabGPS.UseVisualStyleBackColor = true;
            // 
            // pbConfiguration
            // 
            this.pbConfiguration.Location = new System.Drawing.Point(20, 523);
            this.pbConfiguration.Margin = new System.Windows.Forms.Padding(2);
            this.pbConfiguration.Name = "pbConfiguration";
            this.pbConfiguration.Size = new System.Drawing.Size(678, 19);
            this.pbConfiguration.TabIndex = 13;
            // 
            // pblF9PConfig
            // 
            this.pblF9PConfig.Controls.Add(this.rbDualRelPos);
            this.pblF9PConfig.Controls.Add(this.rbDualLocation);
            this.pblF9PConfig.Controls.Add(this.rbSingleF9P);
            this.pblF9PConfig.Location = new System.Drawing.Point(171, 176);
            this.pblF9PConfig.Margin = new System.Windows.Forms.Padding(2);
            this.pblF9PConfig.Name = "pblF9PConfig";
            this.pblF9PConfig.Size = new System.Drawing.Size(250, 102);
            this.pblF9PConfig.TabIndex = 12;
            // 
            // rbDualRelPos
            // 
            this.rbDualRelPos.AutoSize = true;
            this.rbDualRelPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDualRelPos.Location = new System.Drawing.Point(10, 61);
            this.rbDualRelPos.Margin = new System.Windows.Forms.Padding(2);
            this.rbDualRelPos.Name = "rbDualRelPos";
            this.rbDualRelPos.Size = new System.Drawing.Size(165, 24);
            this.rbDualRelPos.TabIndex = 2;
            this.rbDualRelPos.Text = "Dual - Left - RelPos";
            this.rbDualRelPos.UseVisualStyleBackColor = true;
            this.rbDualRelPos.CheckedChanged += new System.EventHandler(this.rbDualRelPos_CheckedChanged);
            // 
            // rbDualLocation
            // 
            this.rbDualLocation.AutoSize = true;
            this.rbDualLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDualLocation.Location = new System.Drawing.Point(10, 32);
            this.rbDualLocation.Margin = new System.Windows.Forms.Padding(2);
            this.rbDualLocation.Name = "rbDualLocation";
            this.rbDualLocation.Size = new System.Drawing.Size(180, 24);
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
            this.rbSingleF9P.Location = new System.Drawing.Point(10, 2);
            this.rbSingleF9P.Margin = new System.Windows.Forms.Padding(2);
            this.rbSingleF9P.Name = "rbSingleF9P";
            this.rbSingleF9P.Size = new System.Drawing.Size(71, 24);
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
            this.lblFirmwareWarning.Location = new System.Drawing.Point(490, 46);
            this.lblFirmwareWarning.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFirmwareWarning.Name = "lblFirmwareWarning";
            this.lblFirmwareWarning.Size = new System.Drawing.Size(0, 17);
            this.lblFirmwareWarning.TabIndex = 11;
            // 
            // btnConfigF9P
            // 
            this.btnConfigF9P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigF9P.Location = new System.Drawing.Point(171, 114);
            this.btnConfigF9P.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfigF9P.Name = "btnConfigF9P";
            this.btnConfigF9P.Size = new System.Drawing.Size(120, 41);
            this.btnConfigF9P.TabIndex = 10;
            this.btnConfigF9P.Text = "Configure F9P";
            this.btnConfigF9P.UseVisualStyleBackColor = true;
            this.btnConfigF9P.Click += new System.EventHandler(this.btnConfigF9P_Click);
            // 
            // btnF9PFlashFirmware
            // 
            this.btnF9PFlashFirmware.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnF9PFlashFirmware.Location = new System.Drawing.Point(302, 114);
            this.btnF9PFlashFirmware.Margin = new System.Windows.Forms.Padding(2);
            this.btnF9PFlashFirmware.Name = "btnF9PFlashFirmware";
            this.btnF9PFlashFirmware.Size = new System.Drawing.Size(120, 41);
            this.btnF9PFlashFirmware.TabIndex = 9;
            this.btnF9PFlashFirmware.Text = "Flash firmware";
            this.btnF9PFlashFirmware.UseVisualStyleBackColor = true;
            this.btnF9PFlashFirmware.Click += new System.EventHandler(this.btnF9PFlashFirmware_Click);
            // 
            // lblFirmware
            // 
            this.lblFirmware.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirmware.Location = new System.Drawing.Point(490, 78);
            this.lblFirmware.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFirmware.Name = "lblFirmware";
            this.lblFirmware.Size = new System.Drawing.Size(230, 206);
            this.lblFirmware.TabIndex = 8;
            this.lblFirmware.Text = "Firmware";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(171, 62);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(120, 41);
            this.btnConnect.TabIndex = 6;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblCOMPorts
            // 
            this.lblCOMPorts.AutoSize = true;
            this.lblCOMPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCOMPorts.Location = new System.Drawing.Point(16, 114);
            this.lblCOMPorts.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCOMPorts.Name = "lblCOMPorts";
            this.lblCOMPorts.Size = new System.Drawing.Size(89, 20);
            this.lblCOMPorts.TabIndex = 5;
            this.lblCOMPorts.Text = "Serial ports";
            // 
            // txtSerialChat
            // 
            this.txtSerialChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialChat.Location = new System.Drawing.Point(20, 287);
            this.txtSerialChat.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerialChat.Multiline = true;
            this.txtSerialChat.Name = "txtSerialChat";
            this.txtSerialChat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSerialChat.Size = new System.Drawing.Size(680, 232);
            this.txtSerialChat.TabIndex = 4;
            // 
            // lbCOMPorts
            // 
            this.lbCOMPorts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCOMPorts.FormattingEnabled = true;
            this.lbCOMPorts.ItemHeight = 20;
            this.lbCOMPorts.Location = new System.Drawing.Point(20, 136);
            this.lbCOMPorts.Margin = new System.Windows.Forms.Padding(2);
            this.lbCOMPorts.Name = "lbCOMPorts";
            this.lbCOMPorts.Size = new System.Drawing.Size(121, 144);
            this.lbCOMPorts.TabIndex = 3;
            this.lbCOMPorts.SelectedIndexChanged += new System.EventHandler(this.lbCOMPorts_SelectedIndexChanged);
            // 
            // btnURefresh
            // 
            this.btnURefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnURefresh.Location = new System.Drawing.Point(20, 62);
            this.btnURefresh.Margin = new System.Windows.Forms.Padding(2);
            this.btnURefresh.Name = "btnURefresh";
            this.btnURefresh.Size = new System.Drawing.Size(120, 41);
            this.btnURefresh.TabIndex = 2;
            this.btnURefresh.Text = "Rescan Ports";
            this.btnURefresh.UseVisualStyleBackColor = true;
            this.btnURefresh.Click += new System.EventHandler(this.btnURefresh_Click);
            // 
            // lblUblox
            // 
            this.lblUblox.AutoSize = true;
            this.lblUblox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUblox.Location = new System.Drawing.Point(16, 17);
            this.lblUblox.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUblox.Name = "lblUblox";
            this.lblUblox.Size = new System.Drawing.Size(182, 24);
            this.lblUblox.TabIndex = 0;
            this.lblUblox.Text = "U-Blox Configuration";
            // 
            // tabTeensy
            // 
            this.tabTeensy.Controls.Add(this.teensyControl);
            this.tabTeensy.Location = new System.Drawing.Point(4, 41);
            this.tabTeensy.Name = "tabTeensy";
            this.tabTeensy.Padding = new System.Windows.Forms.Padding(3);
            this.tabTeensy.Size = new System.Drawing.Size(720, 539);
            this.tabTeensy.TabIndex = 0;
            this.tabTeensy.Text = "Teensy";
            this.tabTeensy.UseVisualStyleBackColor = true;
            // 
            // tabUM982
            // 
            this.tabUM982.Controls.Add(this.um982Control);
            this.tabUM982.Location = new System.Drawing.Point(4, 41);
            this.tabUM982.Name = "tabUM982";
            this.tabUM982.Padding = new System.Windows.Forms.Padding(3);
            this.tabUM982.Size = new System.Drawing.Size(720, 539);
            this.tabUM982.TabIndex = 2;
            this.tabUM982.Text = "UM982";
            this.tabUM982.UseVisualStyleBackColor = true;
            // 
            // btnHelp
            // 
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.ForeColor = System.Drawing.Color.Green;
            this.btnHelp.Location = new System.Drawing.Point(714, 2);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(2);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(37, 41);
            this.btnHelp.TabIndex = 15;
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // teensyControl
            // 
            this.teensyControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.teensyControl.Location = new System.Drawing.Point(0, 0);
            this.teensyControl.Margin = new System.Windows.Forms.Padding(7);
            this.teensyControl.Name = "teensyControl";
            this.teensyControl.Size = new System.Drawing.Size(720, 539);
            this.teensyControl.TabIndex = 14;
            // 
            // um982Control
            // 
            this.um982Control.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.um982Control.Location = new System.Drawing.Point(0, 0);
            this.um982Control.Margin = new System.Windows.Forms.Padding(7);
            this.um982Control.Name = "um982Control";
            this.um982Control.Size = new System.Drawing.Size(720, 539);
            this.um982Control.TabIndex = 12;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 608);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.tbPages);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.Text = "AOGConfig-O-Matic!";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tbPages.ResumeLayout(false);
            this.tabGPS.ResumeLayout(false);
            this.tabGPS.PerformLayout();
            this.pblF9PConfig.ResumeLayout(false);
            this.pblF9PConfig.PerformLayout();
            this.tabTeensy.ResumeLayout(false);
            this.tabUM982.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tbPages;
        private TabPage tabTeensy;
        private TabPage tabGPS;
        private Button btnURefresh;
        private Label lblUblox;
        private TextBox txtSerialChat;
        private ListBox lbCOMPorts;
        private Label lblCOMPorts;
        private Button btnConnect;
        private Label lblFirmware;
        private Button btnF9PFlashFirmware;
        private Button btnConfigF9P;
        private Label lblFirmwareWarning;
        private Panel pblF9PConfig;
        private RadioButton rbDualRelPos;
        private RadioButton rbDualLocation;
        private RadioButton rbSingleF9P;
        private ProgressBar pbConfiguration;
        private Button btnHelp;
        private TabPage tabUM982;
        private Teensy.TeensyControl teensyControl;
        private UM982.UM982Control um982Control;
    }
}

