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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.tbPages = new System.Windows.Forms.TabControl();
            this.tabGPS = new System.Windows.Forms.TabPage();
            this.pbXbee = new System.Windows.Forms.PictureBox();
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
            this.tabUM982 = new System.Windows.Forms.TabPage();
            this.btnConfigUM982 = new System.Windows.Forms.Button();
            this.txtSerialChatUM982 = new System.Windows.Forms.TextBox();
            this.btnConnectUM982 = new System.Windows.Forms.Button();
            this.lbCOMPortsUM982 = new System.Windows.Forms.ListBox();
            this.btnURefreshUM982 = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.tmrMessages = new System.Windows.Forms.Timer(this.components);
            this.tbPages.SuspendLayout();
            this.tabGPS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbXbee)).BeginInit();
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
            this.tabGPS.Controls.Add(this.pbXbee);
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
            // pbXbee
            // 
            this.pbXbee.BackColor = System.Drawing.Color.Red;
            this.pbXbee.BackgroundImage = global::AOGConfigOMatic.Properties.Resources.xbee;
            this.pbXbee.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbXbee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbXbee.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbXbee.InitialImage")));
            this.pbXbee.Location = new System.Drawing.Point(302, 2);
            this.pbXbee.Margin = new System.Windows.Forms.Padding(2);
            this.pbXbee.Name = "pbXbee";
            this.pbXbee.Size = new System.Drawing.Size(165, 108);
            this.pbXbee.TabIndex = 14;
            this.pbXbee.TabStop = false;
            this.pbXbee.Click += new System.EventHandler(this.pbXbee_Click);
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
            this.lblFirmware.Location = new System.Drawing.Point(490, 63);
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
            this.tabTeensy.Controls.Add(this.lbTeensies);
            this.tabTeensy.Controls.Add(this.pbProgram);
            this.tabTeensy.Controls.Add(this.lblMessages);
            this.tabTeensy.Controls.Add(this.txtMessages);
            this.tabTeensy.Controls.Add(this.btnRefreshTeensy);
            this.tabTeensy.Controls.Add(this.btnProgram);
            this.tabTeensy.Controls.Add(this.label2);
            this.tabTeensy.Controls.Add(this.label1);
            this.tabTeensy.Controls.Add(this.lbFirmware);
            this.tabTeensy.Location = new System.Drawing.Point(4, 41);
            this.tabTeensy.Name = "tabTeensy";
            this.tabTeensy.Padding = new System.Windows.Forms.Padding(3);
            this.tabTeensy.Size = new System.Drawing.Size(720, 539);
            this.tabTeensy.TabIndex = 0;
            this.tabTeensy.Text = "Teensy";
            this.tabTeensy.UseVisualStyleBackColor = true;
            // 
            // lbTeensies
            // 
            this.lbTeensies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeensies.FormattingEnabled = true;
            this.lbTeensies.ItemHeight = 20;
            this.lbTeensies.Location = new System.Drawing.Point(100, 232);
            this.lbTeensies.Margin = new System.Windows.Forms.Padding(2);
            this.lbTeensies.Name = "lbTeensies";
            this.lbTeensies.Size = new System.Drawing.Size(357, 24);
            this.lbTeensies.TabIndex = 19;
            // 
            // pbProgram
            // 
            this.pbProgram.Location = new System.Drawing.Point(533, 285);
            this.pbProgram.Margin = new System.Windows.Forms.Padding(2);
            this.pbProgram.Name = "pbProgram";
            this.pbProgram.Size = new System.Drawing.Size(172, 19);
            this.pbProgram.TabIndex = 18;
            // 
            // lblMessages
            // 
            this.lblMessages.AutoSize = true;
            this.lblMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessages.Location = new System.Drawing.Point(10, 275);
            this.lblMessages.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMessages.Name = "lblMessages";
            this.lblMessages.Size = new System.Drawing.Size(124, 29);
            this.lblMessages.TabIndex = 17;
            this.lblMessages.Text = "Messages";
            // 
            // txtMessages
            // 
            this.txtMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessages.Location = new System.Drawing.Point(14, 310);
            this.txtMessages.Margin = new System.Windows.Forms.Padding(2);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessages.Size = new System.Drawing.Size(692, 160);
            this.txtMessages.TabIndex = 16;
            // 
            // btnRefreshTeensy
            // 
            this.btnRefreshTeensy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshTeensy.Location = new System.Drawing.Point(600, 15);
            this.btnRefreshTeensy.Margin = new System.Windows.Forms.Padding(2);
            this.btnRefreshTeensy.Name = "btnRefreshTeensy";
            this.btnRefreshTeensy.Size = new System.Drawing.Size(105, 42);
            this.btnRefreshTeensy.TabIndex = 15;
            this.btnRefreshTeensy.Text = "Refresh list";
            this.btnRefreshTeensy.UseVisualStyleBackColor = true;
            this.btnRefreshTeensy.Click += new System.EventHandler(this.btnRefreshTeensy_Click);
            // 
            // btnProgram
            // 
            this.btnProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgram.Location = new System.Drawing.Point(600, 229);
            this.btnProgram.Margin = new System.Windows.Forms.Padding(2);
            this.btnProgram.Name = "btnProgram";
            this.btnProgram.Size = new System.Drawing.Size(105, 37);
            this.btnProgram.TabIndex = 14;
            this.btnProgram.Text = "Program!";
            this.btnProgram.UseVisualStyleBackColor = true;
            this.btnProgram.Click += new System.EventHandler(this.btnProgramTeensy_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 237);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 36);
            this.label2.TabIndex = 13;
            this.label2.Text = "Teensy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(513, 29);
            this.label1.TabIndex = 12;
            this.label1.Text = "1. Select a local firmware or Refresh list if none";
            // 
            // lbFirmware
            // 
            this.lbFirmware.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFirmware.FormattingEnabled = true;
            this.lbFirmware.ItemHeight = 20;
            this.lbFirmware.Location = new System.Drawing.Point(16, 60);
            this.lbFirmware.Margin = new System.Windows.Forms.Padding(2);
            this.lbFirmware.Name = "lbFirmware";
            this.lbFirmware.Size = new System.Drawing.Size(690, 144);
            this.lbFirmware.TabIndex = 11;
            this.lbFirmware.SelectedIndexChanged += new System.EventHandler(this.lbFirmware_SelectedIndexChanged_1);
            // 
            // tabUM982
            // 
            this.tabUM982.Controls.Add(this.btnConfigUM982);
            this.tabUM982.Controls.Add(this.txtSerialChatUM982);
            this.tabUM982.Controls.Add(this.btnConnectUM982);
            this.tabUM982.Controls.Add(this.lbCOMPortsUM982);
            this.tabUM982.Controls.Add(this.btnURefreshUM982);
            this.tabUM982.Location = new System.Drawing.Point(4, 41);
            this.tabUM982.Name = "tabUM982";
            this.tabUM982.Padding = new System.Windows.Forms.Padding(3);
            this.tabUM982.Size = new System.Drawing.Size(720, 539);
            this.tabUM982.TabIndex = 2;
            this.tabUM982.Text = "UM982";
            this.tabUM982.UseVisualStyleBackColor = true;
            // 
            // btnConfigUM982
            // 
            this.btnConfigUM982.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigUM982.Location = new System.Drawing.Point(153, 107);
            this.btnConfigUM982.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfigUM982.Name = "btnConfigUM982";
            this.btnConfigUM982.Size = new System.Drawing.Size(120, 41);
            this.btnConfigUM982.TabIndex = 11;
            this.btnConfigUM982.Text = "Configure UM982";
            this.btnConfigUM982.UseVisualStyleBackColor = true;
            this.btnConfigUM982.Click += new System.EventHandler(this.btnConfigUM982_Click);
            // 
            // txtSerialChatUM982
            // 
            this.txtSerialChatUM982.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSerialChatUM982.Location = new System.Drawing.Point(14, 188);
            this.txtSerialChatUM982.Margin = new System.Windows.Forms.Padding(2);
            this.txtSerialChatUM982.Multiline = true;
            this.txtSerialChatUM982.Name = "txtSerialChatUM982";
            this.txtSerialChatUM982.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSerialChatUM982.Size = new System.Drawing.Size(692, 346);
            this.txtSerialChatUM982.TabIndex = 10;
            // 
            // btnConnectUM982
            // 
            this.btnConnectUM982.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectUM982.Location = new System.Drawing.Point(153, 62);
            this.btnConnectUM982.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnectUM982.Name = "btnConnectUM982";
            this.btnConnectUM982.Size = new System.Drawing.Size(120, 41);
            this.btnConnectUM982.TabIndex = 9;
            this.btnConnectUM982.Text = "Connect";
            this.btnConnectUM982.UseVisualStyleBackColor = true;
            this.btnConnectUM982.Click += new System.EventHandler(this.btnConnectUM982_Click);
            // 
            // lbCOMPortsUM982
            // 
            this.lbCOMPortsUM982.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCOMPortsUM982.FormattingEnabled = true;
            this.lbCOMPortsUM982.ItemHeight = 20;
            this.lbCOMPortsUM982.Location = new System.Drawing.Point(14, 17);
            this.lbCOMPortsUM982.Margin = new System.Windows.Forms.Padding(2);
            this.lbCOMPortsUM982.Name = "lbCOMPortsUM982";
            this.lbCOMPortsUM982.Size = new System.Drawing.Size(121, 124);
            this.lbCOMPortsUM982.TabIndex = 8;
            this.lbCOMPortsUM982.SelectedIndexChanged += new System.EventHandler(this.lbCOMPortsUM982_SelectedIndexChanged);
            // 
            // btnURefreshUM982
            // 
            this.btnURefreshUM982.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnURefreshUM982.Location = new System.Drawing.Point(153, 17);
            this.btnURefreshUM982.Margin = new System.Windows.Forms.Padding(2);
            this.btnURefreshUM982.Name = "btnURefreshUM982";
            this.btnURefreshUM982.Size = new System.Drawing.Size(120, 41);
            this.btnURefreshUM982.TabIndex = 7;
            this.btnURefreshUM982.Text = "Rescan Ports";
            this.btnURefreshUM982.UseVisualStyleBackColor = true;
            this.btnURefreshUM982.Click += new System.EventHandler(this.btnURefreshUM982_Click);
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
            // tmrMessages
            // 
            this.tmrMessages.Interval = 5000;
            this.tmrMessages.Tick += new System.EventHandler(this.tmrMessages_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 608);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.tbPages);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmMain";
            this.Text = "agOpenGPS Teensy Flasher";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tbPages.ResumeLayout(false);
            this.tabGPS.ResumeLayout(false);
            this.tabGPS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbXbee)).EndInit();
            this.pblF9PConfig.ResumeLayout(false);
            this.pblF9PConfig.PerformLayout();
            this.tabTeensy.ResumeLayout(false);
            this.tabTeensy.PerformLayout();
            this.tabUM982.ResumeLayout(false);
            this.tabUM982.PerformLayout();
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
        private Button btnHelp;
        private TabPage tabUM982;
        private Button btnConnectUM982;
        private ListBox lbCOMPortsUM982;
        private Button btnURefreshUM982;
        private TextBox txtSerialChatUM982;
        private Button btnConfigUM982;
        private PictureBox pbXbee;
        private System.Windows.Forms.Timer tmrMessages;
    }
}

