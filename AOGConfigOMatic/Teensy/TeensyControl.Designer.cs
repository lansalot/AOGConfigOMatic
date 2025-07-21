namespace AOGConfigOMatic.Teensy
{
    partial class TeensyControl
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
            this.lbTeensies = new System.Windows.Forms.ListBox();
            this.pbProgram = new System.Windows.Forms.ProgressBar();
            this.lblMessages = new System.Windows.Forms.Label();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.btnRefreshTeensy = new System.Windows.Forms.Button();
            this.btnProgram = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbFirmware = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbTeensies
            // 
            this.lbTeensies.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeensies.FormattingEnabled = true;
            this.lbTeensies.ItemHeight = 25;
            this.lbTeensies.Location = new System.Drawing.Point(133, 286);
            this.lbTeensies.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbTeensies.Name = "lbTeensies";
            this.lbTeensies.Size = new System.Drawing.Size(475, 29);
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
            this.lbFirmware.Size = new System.Drawing.Size(919, 179);
            this.lbFirmware.TabIndex = 11;
            this.lbFirmware.SelectedIndexChanged += new System.EventHandler(this.lbFirmware_SelectedIndexChanged_1);
            // 
            // TeensyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbTeensies);
            this.Controls.Add(this.pbProgram);
            this.Controls.Add(this.lblMessages);
            this.Controls.Add(this.txtMessages);
            this.Controls.Add(this.btnRefreshTeensy);
            this.Controls.Add(this.btnProgram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbFirmware);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TeensyControl";
            this.Size = new System.Drawing.Size(960, 663);
            this.Load += new System.EventHandler(this.TeensyControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbTeensies;
        private System.Windows.Forms.ProgressBar pbProgram;
        private System.Windows.Forms.Label lblMessages;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Button btnRefreshTeensy;
        private System.Windows.Forms.Button btnProgram;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbFirmware;
    }
}
