using libTeensySharp;
using lunOptics.libTeensySharp;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace TeensyFlasher
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
            this.lbTeensies = new System.Windows.Forms.ListBox();
            this.pbProgram = new System.Windows.Forms.ProgressBar();
            this.lblMessages = new System.Windows.Forms.Label();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.btnRefreshTeensy = new System.Windows.Forms.Button();
            this.btnProgram = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbFirmware = new System.Windows.Forms.ListBox();
            this.tbPages.SuspendLayout();
            this.tabGPS.SuspendLayout();
            this.pblF9PConfig.SuspendLayout();
            this.tabTeensy.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPages
            // 
            this.tbPages.Controls.Add(this.tabGPS);
            this.tbPages.Controls.Add(this.tabTeensy);
            this.tbPages.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPages.Location = new System.Drawing.Point(13, 13);
            this.tbPages.Margin = new System.Windows.Forms.Padding(4);
            this.tbPages.Name = "tbPages";
            this.tbPages.SelectedIndex = 0;
            this.tbPages.Size = new System.Drawing.Size(971, 719);
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
            this.tabGPS.Location = new System.Drawing.Point(4, 45);
            this.tabGPS.Margin = new System.Windows.Forms.Padding(4);
            this.tabGPS.Name = "tabGPS";
            this.tabGPS.Size = new System.Drawing.Size(963, 670);
            this.tabGPS.TabIndex = 1;
            this.tabGPS.Text = "Ublox";
            this.tabGPS.UseVisualStyleBackColor = true;
            // 
            // pbConfiguration
            // 
            this.pbConfiguration.Location = new System.Drawing.Point(27, 644);
            this.pbConfiguration.Name = "pbConfiguration";
            this.pbConfiguration.Size = new System.Drawing.Size(904, 23);
            this.pbConfiguration.TabIndex = 13;
            // 
            // pblF9PConfig
            // 
            this.pblF9PConfig.Controls.Add(this.rbDualRelPos);
            this.pblF9PConfig.Controls.Add(this.rbDualLocation);
            this.pblF9PConfig.Controls.Add(this.rbSingleF9P);
            this.pblF9PConfig.Location = new System.Drawing.Point(228, 217);
            this.pblF9PConfig.Name = "pblF9PConfig";
            this.pblF9PConfig.Size = new System.Drawing.Size(334, 125);
            this.pblF9PConfig.TabIndex = 12;
            // 
            // rbDualRelPos
            // 
            this.rbDualRelPos.AutoSize = true;
            this.rbDualRelPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbDualRelPos.Location = new System.Drawing.Point(13, 75);
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
            this.rbSingleF9P.Location = new System.Drawing.Point(13, 3);
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
            this.lblFirmwareWarning.Location = new System.Drawing.Point(654, 57);
            this.lblFirmwareWarning.Name = "lblFirmwareWarning";
            this.lblFirmwareWarning.Size = new System.Drawing.Size(0, 20);
            this.lblFirmwareWarning.TabIndex = 11;
            // 
            // btnConfigF9P
            // 
            this.btnConfigF9P.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigF9P.Location = new System.Drawing.Point(228, 140);
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
            this.btnF9PFlashFirmware.Location = new System.Drawing.Point(402, 140);
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
            this.lblFirmware.Location = new System.Drawing.Point(654, 96);
            this.lblFirmware.Name = "lblFirmware";
            this.lblFirmware.Size = new System.Drawing.Size(306, 254);
            this.lblFirmware.TabIndex = 8;
            this.lblFirmware.Text = "Firmware";
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(228, 76);
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
            this.txtSerialChat.Location = new System.Drawing.Point(26, 353);
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
            this.lbCOMPorts.Location = new System.Drawing.Point(26, 168);
            this.lbCOMPorts.Name = "lbCOMPorts";
            this.lbCOMPorts.Size = new System.Drawing.Size(160, 179);
            this.lbCOMPorts.TabIndex = 3;
            this.lbCOMPorts.SelectedIndexChanged += new System.EventHandler(this.lbCOMPorts_SelectedIndexChanged);
            // 
            // btnURefresh
            // 
            this.btnURefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnURefresh.Location = new System.Drawing.Point(27, 76);
            this.btnURefresh.Name = "btnURefresh";
            this.btnURefresh.Size = new System.Drawing.Size(160, 50);
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
            // tabTeensy
            // 
            this.tabTeensy.Controls.Add(this.lbTeensies);
            this.tabTeensy.Controls.Add(this.pbProgram);
            this.tabTeensy.Controls.Add(this.lblMessages);
            this.tabTeensy.Controls.Add(this.txtMessages);
            this.tabTeensy.Controls.Add(this.btnRefreshTeensy);
            this.tabTeensy.Controls.Add(this.btnProgram);
            this.tabTeensy.Controls.Add(this.label2);
            this.tabTeensy.Controls.Add(this.label1);
            this.tabTeensy.Controls.Add(this.lbFirmware);
            this.tabTeensy.Location = new System.Drawing.Point(4, 45);
            this.tabTeensy.Margin = new System.Windows.Forms.Padding(4);
            this.tabTeensy.Name = "tabTeensy";
            this.tabTeensy.Padding = new System.Windows.Forms.Padding(4);
            this.tabTeensy.Size = new System.Drawing.Size(963, 670);
            this.tabTeensy.TabIndex = 0;
            this.tabTeensy.Text = "Teensy";
            this.tabTeensy.UseVisualStyleBackColor = true;
            // 
            // lbTeensies
            // 
            this.lbTeensies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeensies.FormattingEnabled = true;
            this.lbTeensies.ItemHeight = 25;
            this.lbTeensies.Location = new System.Drawing.Point(133, 286);
            this.lbTeensies.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbTeensies.Name = "lbTeensies";
            this.lbTeensies.Size = new System.Drawing.Size(475, 54);
            this.lbTeensies.TabIndex = 19;
            // 
            // pbProgram
            // 
            this.pbProgram.Location = new System.Drawing.Point(711, 351);
            this.pbProgram.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbProgram.Name = "pbProgram";
            this.pbProgram.Size = new System.Drawing.Size(229, 23);
            this.pbProgram.TabIndex = 18;
            // 
            // lblMessages
            // 
            this.lblMessages.AutoSize = true;
            this.lblMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessages.Location = new System.Drawing.Point(13, 338);
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Size = new System.Drawing.Size(150, 36);
            this.lblMessages.TabIndex = 17;
            this.lblMessages.Text = "Messages";
            // 
            // txtMessages
            // 
            this.txtMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessages.Location = new System.Drawing.Point(19, 382);
            this.txtMessages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(921, 196);
            this.txtMessages.TabIndex = 16;
            // 
            // btnRefreshTeensy
            // 
            this.btnRefreshTeensy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshTeensy.Location = new System.Drawing.Point(800, 18);
            this.btnRefreshTeensy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefreshTeensy.Name = "btnRefreshTeensy";
            this.btnRefreshTeensy.Size = new System.Drawing.Size(140, 52);
            this.btnRefreshTeensy.TabIndex = 15;
            this.btnRefreshTeensy.Text = "Refresh list";
            this.btnRefreshTeensy.UseVisualStyleBackColor = true;
            this.btnRefreshTeensy.Click += new System.EventHandler(this.btnRefreshTeensy_Click);
            // 
            // btnProgram
            // 
            this.btnProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgram.Location = new System.Drawing.Point(800, 282);
            this.btnProgram.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProgram.Name = "btnProgram";
            this.btnProgram.Size = new System.Drawing.Size(140, 46);
            this.btnProgram.TabIndex = 14;
            this.btnProgram.Text = "Program!";
            this.btnProgram.UseVisualStyleBackColor = true;
            this.btnProgram.Click += new System.EventHandler(this.btnProgramTeensy_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 44);
            this.label2.TabIndex = 13;
            this.label2.Text = "Teensy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(634, 36);
            this.label1.TabIndex = 12;
            this.label1.Text = "1. Select a local firmware or Refresh list if none";
            // 
            // lbFirmware
            // 
            this.lbFirmware.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFirmware.FormattingEnabled = true;
            this.lbFirmware.ItemHeight = 25;
            this.lbFirmware.Location = new System.Drawing.Point(21, 74);
            this.lbFirmware.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbFirmware.Name = "lbFirmware";
            this.lbFirmware.Size = new System.Drawing.Size(919, 204);
            this.lbFirmware.TabIndex = 11;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 748);
            this.Controls.Add(this.tbPages);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmMain";
            this.Text = "agOpenGPS Teensy Flasher";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tbPages.ResumeLayout(false);
            this.tabGPS.ResumeLayout(false);
            this.tabGPS.PerformLayout();
            this.pblF9PConfig.ResumeLayout(false);
            this.pblF9PConfig.PerformLayout();
            this.tabTeensy.ResumeLayout(false);
            this.tabTeensy.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tbPages;
        private TabPage tabTeensy;
        private TabPage tabGPS;
        private ListBox lbTeensies;
        private ProgressBar pbProgram;
        private Label lblMessages;
        private TextBox txtMessages;
        private Button btnRefreshTeensy;
        private Button btnProgram;
        private Label label2;
        private Label label1;
        private ListBox lbFirmware;
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
    }
}

