using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using libTeensySharp;
using lunOptics.libTeensySharp;

namespace AOGConfigOMatic.Teensy
{
    public partial class TeensyControl : UserControl
    {
        private readonly List<TeensyFirmwareItem> teensyFirmwareItems = new List<TeensyFirmwareItem>();

        private readonly TeensyWatcher watcher;
        private readonly string localCSV = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Firmwares.csv");
        private readonly string localHexStub = AppDomain.CurrentDomain.BaseDirectory;
        private string chosenFirmware = "";

        public TeensyControl()
        {
            InitializeComponent();
            watcher = new TeensyWatcher(SynchronizationContext.Current);
            watcher.ConnectedTeensies.CollectionChanged += ConnectedTeensiesChanged;
            foreach (var teensy in watcher.ConnectedTeensies)
            {
                lbTeensies.Items.Add(teensy);
            }
            if (lbTeensies.Items.Count > 0) lbTeensies.SelectedIndex = 0;
            UpdateFirmwareBox();
        }

        private void LogMessage(string Text)
        {
            txtMessages.Text += Text + "\r\n";
            txtMessages.SelectionStart = txtMessages.Text.Length;
            txtMessages.ScrollToCaret();
        }

        private void UpdateFirmwareBox()
        {
            lbFirmware.DataSource = null;
            teensyFirmwareItems.Clear();
            if (File.Exists(localCSV))
            {
                foreach (var line in File.ReadAllLines(localCSV))
                {
                    var parts = line.Split(',');
                    teensyFirmwareItems.Add(new TeensyFirmwareItem(parts[0], parts[1]));
                }
            }
            var hexFiles = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.hex");
            foreach (var hexFile in hexFiles)
            {
                if (!teensyFirmwareItems.Any(s => s.Location.IndexOf(Path.GetFileName(hexFile)) > -1))
                {
                    teensyFirmwareItems.Add(new TeensyFirmwareItem(Path.GetFileName(hexFile), Path.GetFileName(hexFile)));
                }
            }
            lbFirmware.DataSource = teensyFirmwareItems;
            lbFirmware.DisplayMember = "DisplayText";
            lbFirmware.ValueMember = "Location";
            lbFirmware.SelectedIndex = -1;
            lbFirmware.Refresh();
            // add any *.hex files in current folder to the list
        }

        private void ConnectedTeensiesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var teensy in e.NewItems)
                    {
                        lbTeensies.Items.Add(teensy);
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    foreach (var teensy in e.OldItems)
                    {
                        lbTeensies.Items.Remove(teensy);
                    }
                    break;
            }
            if (lbTeensies.SelectedIndex == -1 && lbTeensies.Items.Count > 0) lbTeensies.SelectedIndex = 0;
            if (lbTeensies.Items.Count == 0)
            {
                btnProgram.Enabled = false;
            }
            else
            {
                if (lbFirmware.SelectedIndex > -1)
                {
                    btnProgram.Enabled = true;
                }
            }
        }

        private void TeensyControl_Load(object sender, EventArgs e)
        {
            btnProgram.Enabled = false;
        }

        private bool DownloadFile(string url, string localFile)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(url, localFile);
                    LogMessage("Downloaded " + localFile);
                    return true;
                }
            }
            catch
            {
                LogMessage("Error downloading " + localFile);
                return false;
            }
        }

        private void btnRefreshTeensy_Click(object sender, EventArgs e)
        {
            string url = "https://raw.githubusercontent.com/lansalot/AOGConfigOMatic/main/AOGConfigOMatic/Firmwares.csv";
            DownloadFile(url, localCSV);
            UpdateFirmwareBox();
        }

        private async void btnProgramTeensy_Click(object sender, EventArgs e)
        {
            string localHexFile = Path.Combine(localHexStub, Path.GetFileName(chosenFirmware));
            if (!File.Exists(localHexFile))
            {
                LogMessage("Firmware file not found locally.. downloading");
                if (!DownloadFile(chosenFirmware, localHexFile)) return;
            }
            if ((lbTeensies.SelectedIndex == -1) | (lbTeensies.Items.Count == 0))
            {
                LogMessage("Sorry, no Teensies selected to program");
                return;
            }
            LogMessage("Programming!");
            if (lbTeensies.SelectedItem is ITeensy teensy)
            {
                var progress = new Progress<int>(v => pbProgram.Value = v);
                var result = await teensy.UploadAsync(localHexFile, progress);
                if (result.ToString() == "RebootError")
                {
                    LogMessage("Couldn't reboot Teensy - try pressing the white button on it to trigger download and press Program again");
                }
                else if (result.ToString() != "OK")
                {
                    LogMessage("Error: " + result.ToString());
                    LogMessage("Are you sure nothing else is using the Teensy?");
                    LogMessage("Close the Arduino IDE and try again, or unplug/reinsert the Teensy");
                }
                else
                {
                    LogMessage("Finished programming");
                }
                pbProgram.Value = 0;
            }
        }

        private void lbFirmware_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lbFirmware.SelectedIndex == -1)
            {
                btnProgram.Enabled = false;
                return;
            }
            else if (lbFirmware.SelectedIndex > -1 && lbTeensies.SelectedIndex > -1 && lbTeensies.Items.Count > 0)
            {
                chosenFirmware = ((TeensyFirmwareItem)lbFirmware.SelectedItem).Location;
                btnProgram.Enabled = true;
            }
        }
    }

    public class TeensyFirmwareItem
    {
        public string DisplayText { get; set; }
        public string Location { get; set; }

        // Constructor
        public TeensyFirmwareItem(string displayText, string location)
        {
            DisplayText = displayText;
            Location = location;
        }
    }
}
