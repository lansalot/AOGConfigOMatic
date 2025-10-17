using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AOGConfigOMatic
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void tbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            uBloxControl.TabChanged();
            agOpenGpsControl.TabChanged();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            uBloxControl.Close();
            um982Control.Close();
            agOpenGpsControl.Close();
            base.OnFormClosing(e);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            ContextMenuStrip contexMenu = new ContextMenuStrip();
            contexMenu.Font = new Font("Microsoft Sans Serif", 14);
            contexMenu.Items.Add("AOGConfig-O-Matic!");
            contexMenu.Items.Add("AgOpenGPS Tools");
            contexMenu.Items.Add("AgOpenGPS videos");
            contexMenu.Items.Add("AgOpenGPS");
            contexMenu.Items.Add("AgHardware");
            contexMenu.Items.Add("AOG Discourse");
            contexMenu.Items.Add("Donate to AOG!");
            contexMenu.Show(Cursor.Position.X, Cursor.Position.Y);
            contexMenu.ItemClicked += new ToolStripItemClickedEventHandler(
                contexMenu_ItemClicked);
        }

        void contexMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            switch (item.Text)
            {
                case "AgOpenGPS":
                    Process.Start("https://github.com/farmerbriantee/AgOpenGPS");
                    break;
                case "AgHardware":
                    Process.Start("https://github.com/AgHardware");
                    break;
                case "AgOpenGPS videos":
                    Process.Start("https://www.youtube.com/playlist?list=PL1N2N2XFHWW1fIDhb7koOa7hxH0LGppYc");
                    break;
                case "AOG Discourse":
                    Process.Start("https://discourse.agopengps.com/");
                    break;
                case "AOGConfig-O-Matic!":
                    Process.Start("https://github.com/lansalot/AOGConfigOMatic");
                    break;
                case "AgOpenGPS Tools":
                    Process.Start("https://github.com/lansalot/AgOpenGPS-Tools");
                    break;
                case "Donate to AOG!":
                    Process.Start("https://www.buymeacoffee.com/agopengps");
                    break;
            }
        }
    }
}
