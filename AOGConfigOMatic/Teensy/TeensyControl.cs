using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
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
            tvFirmware.Nodes.Clear();
            teensyFirmwareItems.Clear();

            // Scan for hex files in Firmwares folder (packaged with application)
            string firmwaresPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Firmwares");
            if (Directory.Exists(firmwaresPath))
            {
                // Scan subdirectories and build tree structure
                ScanDirectoryForHexFiles(firmwaresPath, tvFirmware.Nodes);
            }
            else
            {
                LogMessage("Firmwares folder not found at: " + firmwaresPath);
            }
            
            tvFirmware.ExpandAll();
        }

        private void ScanDirectoryForHexFiles(string directoryPath, TreeNodeCollection parentNodes)
        {
            try
            {
                // Get all subdirectories
                var subDirs = Directory.GetDirectories(directoryPath);
                
                foreach (var subDir in subDirs)
                {
                    string folderName = Path.GetFileName(subDir);
                    TreeNode folderNode = new TreeNode(folderName);
                    folderNode.Tag = null; // Folder node, not a firmware file
                    
                    // Get all hex files in this directory
                    var hexFiles = Directory.GetFiles(subDir, "*.hex");
                    
                    foreach (var hexFile in hexFiles)
                    {
                        string fileName = Path.GetFileName(hexFile).Replace(".hex", "");
                        // Only add if not already in the list
                        if (!teensyFirmwareItems.Any(s => s.Location.Equals(hexFile, StringComparison.OrdinalIgnoreCase)))
                        {
                            var firmwareItem = new TeensyFirmwareItem(fileName, hexFile);
                            teensyFirmwareItems.Add(firmwareItem);
                            
                            TreeNode fileNode = new TreeNode(fileName);
                            fileNode.Tag = firmwareItem;
                            folderNode.Nodes.Add(fileNode);
                        }
                    }
                    
                    // Recursively scan subdirectories
                    ScanDirectoryForHexFiles(subDir, folderNode.Nodes);
                    
                    // Only add folder node if it has children
                    if (folderNode.Nodes.Count > 0)
                    {
                        parentNodes.Add(folderNode);
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage($"Error scanning directory {directoryPath}: {ex.Message}");
            }
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
                // Check if a firmware file is selected (not just a folder)
                if (tvFirmware.SelectedNode != null && tvFirmware.SelectedNode.Tag is TeensyFirmwareItem)
                {
                    btnProgram.Enabled = true;
                }
            }
        }

        private void TeensyControl_Load(object sender, EventArgs e)
        {
            btnProgram.Enabled = false;
        }



        private void btnRefreshTeensy_Click(object sender, EventArgs e)
        {
            LogMessage("Rescanning Firmwares folder...");
            UpdateFirmwareBox();
            LogMessage("Firmware list refreshed");
        }

        private async void btnProgramTeensy_Click(object sender, EventArgs e)
        {
            string localHexFile = chosenFirmware;
            
            // Verify the file exists
            if (!File.Exists(localHexFile))
            {
                LogMessage("Error: Firmware file not found: " + localHexFile);
                return;
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

        private void tvFirmware_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Tag == null)
            {
                // Selected a folder node, not a firmware file
                btnProgram.Enabled = false;
                chosenFirmware = "";
                return;
            }
            
            if (e.Node.Tag is TeensyFirmwareItem firmwareItem)
            {
                chosenFirmware = firmwareItem.Location;
                
                if (lbTeensies.SelectedIndex > -1 && lbTeensies.Items.Count > 0)
                {
                    btnProgram.Enabled = true;
                }
                else
                {
                    btnProgram.Enabled = false;
                }
            }
            else
            {
                btnProgram.Enabled = false;
                chosenFirmware = "";
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
