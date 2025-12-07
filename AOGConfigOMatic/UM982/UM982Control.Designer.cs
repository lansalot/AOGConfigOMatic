namespace AOGConfigOMatic.UM982
{
    partial class UM982Control
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
            this.btnConfigUM982 = new System.Windows.Forms.Button();
            this.txtSerialChatUM982 = new System.Windows.Forms.TextBox();
            this.btnConnectUM982 = new System.Windows.Forms.Button();
            this.lbCOMPortsUM982 = new System.Windows.Forms.ListBox();
            this.btnURefreshUM982 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnUMDual = new System.Windows.Forms.RadioButton();
            this.btnUMSingle = new System.Windows.Forms.RadioButton();
            this.txtUM982Status = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnConfigUM982
            // 
            this.btnConfigUM982.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfigUM982.Location = new System.Drawing.Point(213, 107);
            this.btnConfigUM982.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.txtSerialChatUM982.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSerialChatUM982.Multiline = true;
            this.txtSerialChatUM982.Name = "txtSerialChatUM982";
            this.txtSerialChatUM982.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSerialChatUM982.Size = new System.Drawing.Size(692, 346);
            this.txtSerialChatUM982.TabIndex = 10;
            // 
            // btnConnectUM982
            // 
            this.btnConnectUM982.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnectUM982.Location = new System.Drawing.Point(213, 62);
            this.btnConnectUM982.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
            this.lbCOMPortsUM982.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbCOMPortsUM982.Name = "lbCOMPortsUM982";
            this.lbCOMPortsUM982.Size = new System.Drawing.Size(181, 124);
            this.lbCOMPortsUM982.TabIndex = 8;
            this.lbCOMPortsUM982.SelectedIndexChanged += new System.EventHandler(this.lbCOMPortsUM982_SelectedIndexChanged);
            // 
            // btnURefreshUM982
            // 
            this.btnURefreshUM982.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnURefreshUM982.Location = new System.Drawing.Point(213, 17);
            this.btnURefreshUM982.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnURefreshUM982.Name = "btnURefreshUM982";
            this.btnURefreshUM982.Size = new System.Drawing.Size(120, 41);
            this.btnURefreshUM982.TabIndex = 7;
            this.btnURefreshUM982.Text = "Rescan Ports";
            this.btnURefreshUM982.UseVisualStyleBackColor = true;
            this.btnURefreshUM982.Click += new System.EventHandler(this.btnURefreshUM982_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnUMDual);
            this.panel1.Controls.Add(this.btnUMSingle);
            this.panel1.Location = new System.Drawing.Point(361, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 85);
            this.panel1.TabIndex = 15;
            // 
            // btnUMDual
            // 
            this.btnUMDual.AutoSize = true;
            this.btnUMDual.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUMDual.Location = new System.Drawing.Point(10, 46);
            this.btnUMDual.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUMDual.Name = "btnUMDual";
            this.btnUMDual.Size = new System.Drawing.Size(80, 33);
            this.btnUMDual.TabIndex = 1;
            this.btnUMDual.Text = "Dual";
            this.btnUMDual.UseVisualStyleBackColor = true;
            // 
            // btnUMSingle
            // 
            this.btnUMSingle.AutoSize = true;
            this.btnUMSingle.Checked = true;
            this.btnUMSingle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUMSingle.Location = new System.Drawing.Point(10, 8);
            this.btnUMSingle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUMSingle.Name = "btnUMSingle";
            this.btnUMSingle.Size = new System.Drawing.Size(100, 33);
            this.btnUMSingle.TabIndex = 0;
            this.btnUMSingle.TabStop = true;
            this.btnUMSingle.Text = "Single";
            this.btnUMSingle.UseVisualStyleBackColor = true;
            // 
            // txtUM982Status
            // 
            this.txtUM982Status.Location = new System.Drawing.Point(361, 113);
            this.txtUM982Status.Multiline = true;
            this.txtUM982Status.Name = "txtUM982Status";
            this.txtUM982Status.Size = new System.Drawing.Size(344, 75);
            this.txtUM982Status.TabIndex = 16;
            // 
            // UM982Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtUM982Status);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnConfigUM982);
            this.Controls.Add(this.txtSerialChatUM982);
            this.Controls.Add(this.btnConnectUM982);
            this.Controls.Add(this.lbCOMPortsUM982);
            this.Controls.Add(this.btnURefreshUM982);
            this.Name = "UM982Control";
            this.Size = new System.Drawing.Size(720, 539);
            this.Load += new System.EventHandler(this.UM982Control_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfigUM982;
        private System.Windows.Forms.TextBox txtSerialChatUM982;
        private System.Windows.Forms.Button btnConnectUM982;
        private System.Windows.Forms.ListBox lbCOMPortsUM982;
        private System.Windows.Forms.Button btnURefreshUM982;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton btnUMDual;
        private System.Windows.Forms.RadioButton btnUMSingle;
        private System.Windows.Forms.TextBox txtUM982Status;
    }
}
