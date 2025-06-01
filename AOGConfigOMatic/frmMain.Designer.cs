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
            this.uBloxControl = new AOGConfigOMatic.UBlox.UBloxControl();
            this.tabTeensy = new System.Windows.Forms.TabPage();
            this.teensyControl = new AOGConfigOMatic.Teensy.TeensyControl();
            this.tabUM982 = new System.Windows.Forms.TabPage();
            this.um982Control = new AOGConfigOMatic.UM982.UM982Control();
            this.btnHelp = new System.Windows.Forms.Button();
            this.tbPages.SuspendLayout();
            this.tabGPS.SuspendLayout();
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
            this.tabGPS.Controls.Add(this.uBloxControl);
            this.tabGPS.Location = new System.Drawing.Point(4, 41);
            this.tabGPS.Name = "tabGPS";
            this.tabGPS.Size = new System.Drawing.Size(720, 539);
            this.tabGPS.TabIndex = 1;
            this.tabGPS.Text = "Ublox";
            this.tabGPS.UseVisualStyleBackColor = true;
            // 
            // uBloxControl
            // 
            this.uBloxControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.uBloxControl.Location = new System.Drawing.Point(0, 0);
            this.uBloxControl.Margin = new System.Windows.Forms.Padding(7);
            this.uBloxControl.Name = "uBloxControl";
            this.uBloxControl.Size = new System.Drawing.Size(720, 539);
            this.uBloxControl.TabIndex = 14;
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
            // teensyControl
            // 
            this.teensyControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.teensyControl.Location = new System.Drawing.Point(0, 0);
            this.teensyControl.Margin = new System.Windows.Forms.Padding(7);
            this.teensyControl.Name = "teensyControl";
            this.teensyControl.Size = new System.Drawing.Size(720, 539);
            this.teensyControl.TabIndex = 14;
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
            // um982Control
            // 
            this.um982Control.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.um982Control.Location = new System.Drawing.Point(0, 0);
            this.um982Control.Margin = new System.Windows.Forms.Padding(7);
            this.um982Control.Name = "um982Control";
            this.um982Control.Size = new System.Drawing.Size(720, 539);
            this.um982Control.TabIndex = 12;
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
            this.tbPages.ResumeLayout(false);
            this.tabGPS.ResumeLayout(false);
            this.tabTeensy.ResumeLayout(false);
            this.tabUM982.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tbPages;
        private TabPage tabTeensy;
        private TabPage tabGPS;
        private Button btnHelp;
        private TabPage tabUM982;
        private Teensy.TeensyControl teensyControl;
        private UM982.UM982Control um982Control;
        private UBlox.UBloxControl uBloxControl;
    }
}

