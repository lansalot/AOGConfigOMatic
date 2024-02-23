using libTeensySharp;
using lunOptics.libTeensySharp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace TeensyFlasher
{
    public partial class frmMain : Form
    {
        private AutoResetEvent _waitForAckNak = new AutoResetEvent(false);
        private AutoResetEvent _waitForMonVer = new AutoResetEvent(false);
        private bool _ack = false;
        private string _monVerString = string.Empty;

        // 10 byte receive buffer for UBX and AOG messages. Only used to read the first few bytes.
        private byte[] _ubxParseBuffer = new byte[10];
        private int _ubxParseIndex = 0;
        private string SelectedComPort;
        private SerialPort _serialPort = null;
        private bool isReadingData = false;
        private string _FileName = ".\\Single.txt";
        private bool isProgrammingF9P = false;
        private bool isClosing = false;
        private int errorCount = 0;

        #region Teensy


        TeensyWatcher watcher;
        String localCSV = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Firmwares.csv");
        string localHexStub = AppDomain.CurrentDomain.BaseDirectory;
        string chosenFirmware = "";

        void LogMessage(string Text)
        {
            txtMessages.Text += Text + "\r\n";
            txtMessages.SelectionStart = txtMessages.Text.Length;
            txtMessages.ScrollToCaret();
        }
        void UpdateFirmwareBox()
        {
            // Read the CSV file and fill the listbox with the first column
            var lines = File.ReadAllLines(localCSV);
            var firstColumn = lines.Select(line => line.Split(',')[0]).ToList();
            lbFirmware.DataSource = firstColumn;
            lbFirmware.SelectedIndex = -1;
        }
        public frmMain()
        {
            InitializeComponent();
            watcher = new TeensyWatcher(SynchronizationContext.Current);
            watcher.ConnectedTeensies.CollectionChanged += ConnectedTeensiesChanged;
            foreach (var teensy in watcher.ConnectedTeensies)
            {
                lbTeensies.Items.Add(teensy);
            }
            if (lbTeensies.Items.Count > 0) lbTeensies.SelectedIndex = 0;
            if (File.Exists(localCSV))
            {
                UpdateFirmwareBox();
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
                if (lbFirmware.SelectedIndex > -1)
                {
                    btnProgram.Enabled = true;
                }
            }
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            btnProgram.Enabled = false;
            ScanPorts();
        }

        bool DownloadFile(string url, string localFile)
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
            string url = "https://raw.githubusercontent.com/lansalot/AOGConfigOMatic/main/Firmwares.csv";
            DownloadFile(url, localCSV);
            UpdateFirmwareBox();
        }

        private async void btnProgramTeensy_Click(object sender, EventArgs e)
        {
            string localHexFile = System.IO.Path.Combine(localHexStub, Path.GetFileName(chosenFirmware));
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
            var teensy = lbTeensies.SelectedItem as ITeensy;
            if (teensy != null)
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
        #endregion


        #region UBlox


        private void StopReadingData()
        {
            isReadingData = false;
            if (_serialPort == null)
            {
                return;
            }
            if (_serialPort.IsOpen)
            {
                _serialPort.DiscardInBuffer();
                _serialPort.DiscardOutBuffer();
                _serialPort.DataReceived -= MySerialPort_DataReceived;
                if (!isClosing)
                {
                    _serialPort.Close();
                }
            }
        }
        private void ScanPorts()
        {
            var ports = SerialPort.GetPortNames().ToList();
            lbCOMPorts.Items.Clear();
            foreach (var port in ports)
            {
                lbCOMPorts.Items.Add(port);
            }
        }
        private void btnURefresh_Click(object sender, EventArgs e)
        {
            ScanPorts();
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (isReadingData)
            {
                StopReadingData();
                btnConnect.Text = "Connect";
            }
            else
            {
                if (lbCOMPorts.SelectedIndex == -1)
                {
                    txtSerialChat.AppendText("Please select a COM port" + Environment.NewLine);
                    return;
                }
                _serialPort = new SerialPort(SelectedComPort, 460800, Parity.None, 8, StopBits.One);
                try
                {
                    _serialPort.Open();
                }
                catch
                {
                    safeChat("Error opening serial port - make sure anything using it (U-Center?) is closed!");
                    return;
                }
                btnConnect.Text = "Disconnect";
                _serialPort.DataReceived += MySerialPort_DataReceived;
                isReadingData = true;
                // B5 62 0A 04 00 00 0E 34
                byte[] ubxMsg = { 0xB5, 0x62, 0x0A, 0x04, 0x00, 0x00, 0x0E, 0x34 };
                _serialPort.Write(ubxMsg, 0, ubxMsg.Length);
            }
        }

        private void lbCOMPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCOMPorts.SelectedIndex > -1)
            {
                SelectedComPort = lbCOMPorts.SelectedItem.ToString();
                btnConnect.Enabled = true;
            }
            else
            {
                btnConnect.Enabled = false;
            }
        }

        private void safeChat(string chat)
        {
            if (isClosing) { return; }
            txtSerialChat.Invoke(new MethodInvoker(delegate
            {
                txtSerialChat.AppendText(chat + Environment.NewLine);
            }));
        }
        private void MySerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort spL = (SerialPort)sender;
            if (spL.IsOpen == false)
            {
                StopReadingData();
            }
            byte[]? buf = null;

            if (spL == null) { return; }
            int retries = 0;
            while (isProgrammingF9P && true) // in case a config change closes it, spin until we can re-open
            {
                try
                {
                    if (!spL.IsOpen)
                    {
                        safeChat(".");
                        spL.Open();
                        break;
                    }
                    else
                    {
                        break;
                    }
                }
                catch
                {
                    safeChat("Sleeping " + retries.ToString());
                }
                retries++;
                Thread.Sleep(100);
                if (retries > 10)
                {
                    safeChat("Failed to re-open serial port - retry " + retries.ToString());
                    break;
                }
            }
            if (!spL.IsOpen)
            {
                // sometimes the port closes, for some reason...
                safeChat("Serial port closed unexpectedly - please try again!");
                return;
            }
            buf = new byte[spL.BytesToRead];
            spL.Read(buf, 0, buf.Length);
            bool ubxMessage = false;

            for (var i = 0; i < buf.Length; i++)
            {
                var b = buf[i];

                if (b == 0x24 && !isProgrammingF9P)
                {  // $ is the start of a NMEA message
                    try
                    {
                        var nmea = Encoding.UTF8.GetString(buf, i, Array.IndexOf(buf, (byte)0x0a) - 1);
                        safeChat("NMEA: " + nmea);
                    }
                    catch { }
                }
                if (b == 0xB5)
                {
                    _ubxParseIndex = 0;
                }
                else if (b == 0x62 && _ubxParseIndex == 1 && _ubxParseBuffer[0] == 0xB5)
                {
                    ubxMessage = true;
                }

                if (_ubxParseIndex < _ubxParseBuffer.Length)
                {
                    _ubxParseBuffer[_ubxParseIndex] = b;
                    _ubxParseIndex++;
                }
                if (_ubxParseIndex >= _ubxParseBuffer.Length)
                {
                    _ubxParseIndex = 0;
                }

                // Check the Class and Message id, byte 2 and 3
                // 0x05 is ACK/NAK
                if (ubxMessage && _ubxParseBuffer[2] == 0x05)
                {
                    // 0x01 is ACK
                    if (_ubxParseBuffer[3] == 0x01)
                    {
                        _ack = true;
                        _waitForAckNak.Set();
                        ResetUbxBuffer();
                    }
                    // 0x00 is NAK
                    else if (_ubxParseBuffer[3] == 0x00)
                    {
                        errorCount++;
                        _ack = false;
                        _waitForAckNak.Set();
                        ResetUbxBuffer();
                    }
                    System.Diagnostics.Debug.WriteLine("Dumping buf with _ack state " + _ack.ToString());
                    System.Diagnostics.Debug.WriteLine(BitConverter.ToString(buf));
                    System.Diagnostics.Debug.WriteLine("Dumping _ubxParseBuffer");
                    System.Diagnostics.Debug.WriteLine(BitConverter.ToString(_ubxParseBuffer));
                }

                // Check the Class and Message id, byte 2 and 3
                // 0x0A 0x04 is MON-VER
                if (ubxMessage && _ubxParseBuffer[2] == 0x0A && _ubxParseBuffer[3] == 0x04)
                {
                    int length = buf[i + 1];
                    length |= buf[i + 2] << 8;

                    var verIndex = i + 3;
                    var payloadEnd = verIndex + length - 1;
                    var swVersionBytes = new byte[30];
                    var hwVersionBytes = new byte[10];

                    if (buf.Length >= (payloadEnd + 1))
                    {

                        Array.Copy(buf, verIndex, swVersionBytes, 0, swVersionBytes.Length);

                        var swVersion = Encoding.UTF8.GetString(swVersionBytes.TakeWhile(b => !b.Equals(0)).ToArray());

                        verIndex += swVersionBytes.Length;
                        Array.Copy(buf, verIndex, hwVersionBytes, 0, hwVersionBytes.Length);
                        var hwVersion = Encoding.UTF8.GetString(hwVersionBytes.TakeWhile(b => !b.Equals(0)).ToArray());

                        // Read extensions
                        verIndex += hwVersionBytes.Length;
                        var extensionBytes = new byte[30];
                        var extensions = string.Empty;

                        while (verIndex < payloadEnd)
                        {
                            Array.Copy(buf, verIndex, extensionBytes, 0, extensionBytes.Length);
                            var verExtension = Encoding.UTF8.GetString(extensionBytes.TakeWhile(b => !b.Equals(0)).ToArray());

                            if (!string.IsNullOrEmpty(extensions))
                            {
                                extensions += "\r\n";
                            }

                            extensions += verExtension;
                            verIndex += extensionBytes.Length;
                        }

                        _monVerString = "Software version:\r\n" + swVersion;
                        _monVerString += "\r\nHardware version:\r\n" + hwVersion;
                        _monVerString += "\r\nExtensions:\r\n" + extensions;
                        if (_monVerString.IndexOf("HPG 1.13").Equals(-1))
                        {
                            lblFirmwareWarning.Invoke(new MethodInvoker(delegate
                            {
                                lblFirmwareWarning.Text = "Incorrect fw version";
                                lblFirmwareWarning.ForeColor = Color.Red;
                            }));
                        }
                        else
                        {
                            lblFirmwareWarning.Invoke(new MethodInvoker(delegate
                            {
                                lblFirmwareWarning.Text = "Correct firmware version";
                                lblFirmwareWarning.ForeColor = Color.Green;
                            }));
                        }
                        // Signal waiting thread
                        _waitForMonVer.Set();
                        lblFirmware.Invoke(new MethodInvoker(delegate
                        {
                            lblFirmware.Text = _monVerString; // + Environment.NewLine);
                        }));
                        // Skip to the end of this message 
                        i = verIndex - 1;

                        // no ubxMessage yet
                        ubxMessage = false;
                        System.Diagnostics.Debug.WriteLine("Signaling thread for MON-VER");

                        //_waitForAckNak.Set();

                        ResetUbxBuffer();
                    }
                }
            }
        }

        public void ConfigureReceiver(string configurationFilename)
        {
            if (string.IsNullOrEmpty(SelectedComPort) || string.IsNullOrEmpty(configurationFilename) || !isReadingData)
            {
                return;
            }

            //if (_serialPort == null) // was I drunk?
            //{
            //    _serialPort.DataReceived -= MySerialPort_DataReceived;
            //}
            btnConfigF9P.Enabled = false;
            btnConnect.Enabled = false;
            btnF9PFlashFirmware.Enabled = false;
            btnURefresh.Enabled = false;
            string[] lines = null;

            try
            {
                // get receiver configuration file
                lines = File.ReadAllLines(configurationFilename);
            }
            catch (Exception ex)
            {
                var msg = ex.ToString();
                MessageBox.Show(msg, "Error configuring receiver");
            }
            isProgrammingF9P = true;
            if (lines != null)
            {
                try
                {
                    //_serialPort.DataReceived += MySerialPort_DataReceived; // we're already doing this

                    //byte[] monVer = new byte[] { 0xB5, 0x62, 0x0A, 0x04, 0x00, 0x00, 0x0E, 0x34 };
                    //_serialPort.Write(monVer, 0, monVer.Length);

                    //while (_serialPort.BytesToRead <= 0)
                    //{
                    //    Thread.Sleep(10);
                    //    _serialPort.Write(monVer, 0, monVer.Length);
                    //}

                    //var monBuf = new byte[_serialPort.BytesToRead];
                    //_serialPort.Read(monBuf, 0, monBuf.Length);

                    //System.Diagnostics.Debug.WriteLine($"Received bytes : {monBuf.Length}");
                    //System.Diagnostics.Debug.WriteLine(BitConverter.ToString(monBuf));

                    _serialPort.DataReceived += MySerialPort_DataReceived;

                    //Thread.Sleep(1000);

                    safeChat("Configuring:");

                    // Skip the first line of the file, that is the version
                    int progress = 1;
                    foreach (var line in lines.Skip(1))
                    {
                        pbConfiguration.Invoke(new MethodInvoker(delegate
                        {
                            pbConfiguration.Maximum = lines.Length - 1;
                            pbConfiguration.Value = progress;
                            progress++;
                        }));
                        if (!SendLine(line))
                        {
                            // Maybe the receiver baudrate has changed. So send passthrouhg again
                            // Send the passthrough command
                            // AW don't think we need this, we're not using AOG passthru anyway and PC USB doesn't care about baudrate
                            // _serialPort.Write(passthroughCmd, 0, passthroughCmd.Length);

                            if (_waitForAckNak.WaitOne(2000))
                            {
                                // This seems to just result in a NACK, but anyway
                                // Retry sending line
                                if (!SendLine(line))
                                {
                                    if (errorCount > 5)
                                    {
                                        safeChat("Too many errors, aborting");
                                        throw new Exception("Too many errors");
                                    }
                                }
                            }
                        }
                    }
                    pbConfiguration.Invoke(new MethodInvoker(delegate
                    {
                        pbConfiguration.Value = 0;
                    }));
                    safeChat("Configuring receiver done");
                }
                catch (Exception ex)
                {
                    safeChat("Error sending configuration to receiver" + Environment.NewLine + ex.ToString());
                }
                finally
                {
                    //_serialPort.DataReceived -= MySerialPort_DataReceived;
                    //_serialPort.Dispose();
                    //_serialPort = null;
                    isProgrammingF9P = false;
                    btnConfigF9P.Enabled = true;
                    btnConnect.Enabled = true;
                    btnF9PFlashFirmware.Enabled = true;
                    btnURefresh.Enabled = true;
                    errorCount = 0;
                    //StopReadingData();
                }
            }
        }

        private bool SendLine(string line)
        {
            // CFG-VALGET - 06 8A 0A 00 00 01 00 00 01 00 21 30 64 00 51 B9
            // Remove CFG-VALGET - 
            // Add B5 62 at the begin
            // Add Checksum at the end
            var stringBytes = line.Split(' ');
            var msgBytes = new byte[stringBytes.Length + 2];

            msgBytes[0] = 0xB5;
            msgBytes[1] = 0x62;
            msgBytes[2] = 0x06;
            msgBytes[3] = 0x8A;

            for (var i = 4; i < stringBytes.Length; i++)
            {
                msgBytes[i] = byte.Parse(stringBytes[i], NumberStyles.HexNumber);

                if (i == 7)
                {
                    msgBytes[i] = 0x01;
                }
            }
            msgBytes[7] = 5;
            UbxCalculateCheckSum(msgBytes);

            _ack = false;
            _serialPort.Write(msgBytes, 0, msgBytes.Length);
            _serialPort.Write(msgBytes, 0, msgBytes.Length);
            _serialPort.Write(msgBytes, 0, msgBytes.Length);
            _serialPort.Write(msgBytes, 0, msgBytes.Length);
            Thread.Sleep(1000);
            // Wait for ack or nak, should be within 1sec.
            if (_waitForAckNak.WaitOne(1000))
            {
                // Check ACK or NAK
                if (!_ack)
                {
                    //safeChat("NAK received");
                    return false;
                }
                //safeChat("AK received");
                return true;
            }
            else
            {
                safeChat("Timeout waiting for ACK on:");
                System.Diagnostics.Debug.WriteLine(BitConverter.ToString(msgBytes));
                return false;
            }
        }

        #endregion
        #region ubloxhelpers
        private void ResetUbxBuffer()
        {
            for (var i = 0; i < _ubxParseBuffer.Length; i++)
            {
                _ubxParseBuffer[i] = 0;
            }

            _ubxParseIndex = 0;
        }

        private void UbxCalculateCheckSum(byte[] msg)
        {
            byte ckA = 0;
            byte ckB = 0;

            for (int i = 2; i < msg.Length - 2; i++)
            {
                ckA = (byte)(ckA + msg[i]);
                ckB = (byte)(ckB + ckA);

                //System.Diagnostics.Debug.WriteLine($"Calculating : {i}");
            }

            msg[msg.Length - 2] = ckA;
            msg[msg.Length - 1] = ckB;
        }

        public static void PrintHexAndAscii(string input)
        {
            for (int i = 0; i < input.Length; i += 30)
            {
                string hexSection = "";
                string asciiSection = "";

                // Process each character in the section
                for (int j = i; j < i + 30 && j < input.Length; j++)
                {
                    // Convert each character to its hexadecimal representation
                    string hex = ((int)input[j]).ToString("X2");
                    hexSection += hex + " ";

                    // Convert non-printable characters to a dot for readability
                    char printableAscii = char.IsControl(input[j]) || input[j] > 127 ? '.' : input[j];
                    asciiSection += printableAscii;
                }

                // Print the sections
                Console.WriteLine($"{hexSection,-41} {asciiSection}");
            }
        }
        private static byte[] ConvertHexStringToByteArray(string hexString)
        {
            if (hexString.Length % 2 != 0)
            {
                throw new ArgumentException(String.Format(CultureInfo.InvariantCulture, "The binary key cannot have an odd number of digits: {0}", hexString));
            }

            byte[] data = new byte[hexString.Length / 2];
            for (int index = 0; index < data.Length; index++)
            {
                string byteValue = hexString.Substring(index * 2, 2);
                data[index] = byte.Parse(byteValue, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
            }

            return data;
        }
        #endregion

        private void tbPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnConnect.Enabled = false;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            isClosing = true;
            if (isReadingData)
            {
                _waitForAckNak.Dispose();
                _waitForMonVer.Dispose();
                StopReadingData();
            }
            base.OnFormClosing(e);
        }

        private void btnF9PFlashFirmware_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will flash the F9P with v1.13. It will take a while.\r\n\r\nDo not interrupt it!\r\n\r\nReady?", "Flash F9P", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            if (isReadingData)
            {
                StopReadingData();
                btnConnect.Text = "Connect";
            }

            var batchFile = Path.GetTempPath() + "flashf9p.bat";
            File.WriteAllText(batchFile, "ubxfwupdate -p \\\\.\\" + SelectedComPort + " -b 460800:9600:460800 --no-fis 1 -s 0 -t 0 -v 1 UBX113.bin");
            File.AppendAllText(batchFile, "\r\npause");

            txtSerialChat.AppendText("Flashing F9P firmware" + Environment.NewLine);
            var process = new Process();
            process.StartInfo.FileName = batchFile;
            process.StartInfo.UseShellExecute = false;
            process.Start();
            process.WaitForExit();
            txtSerialChat.AppendText("Flashing F9P firmware complete" + Environment.NewLine);
            txtSerialChat.AppendText("Now, hit configure to send the configuration!" + Environment.NewLine);
        }

        private void btnConfigF9P_Click(object sender, EventArgs e)
        {
            if (_serialPort == null || !_serialPort.IsOpen)
            {
                txtSerialChat.AppendText("Serial port is not open - please Connect" + Environment.NewLine);
                return;
            }
            if (lblFirmwareWarning.ForeColor == Color.Red)
            {
                MessageBox.Show("Firmware MUST be version 1.13. Please flash it first.", "Error!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSerialChat.AppendText("Firmware MUST be version 1.13. Please flash it first." + Environment.NewLine);
                return;
            }
            ConfigureReceiver(_FileName);
        }

        private void rbSingleF9P_CheckedChanged(object sender, EventArgs e)
        {
            if (rbSingleF9P.Checked)
            {
                _FileName = ".\\Single.txt";
            }
        }

        private void rbDualLocation_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDualLocation.Checked)
            {
                _FileName = ".\\DualPosition.txt";
            }
        }

        private void rbDualRelPos_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDualRelPos.Checked)
            {
                _FileName = ".\\DualRelPos.txt";
            }
        }

        private void lbFirmware_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines(localCSV);
            chosenFirmware = lines
                .Where(line => line.Split(',')[0] == (String)lbFirmware.SelectedValue)
                .Select(line => line.Split(',')[1])
                .FirstOrDefault();
            if (lbFirmware.SelectedIndex > -1 && lbTeensies.SelectedIndex > -1 && lbTeensies.Items.Count > 0)
            {
                btnProgram.Enabled = true;
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            ContextMenuStrip contexMenu = new ContextMenuStrip();
            contexMenu.Font = new Font("Microsoft Sans Serif", 14);
            //contexMenu.Items.Add("Video Tutorial");
            contexMenu.Items.Add("AOGConfig-O-Matic!");
            contexMenu.Items.Add("AgOpenGPS Tools");
            contexMenu.Items.Add("AgOpenGPS videos");
            contexMenu.Items.Add("AgOpenGPS");
            contexMenu.Items.Add("AgHardware");
            contexMenu.Items.Add("AOG Discourse");
            contexMenu.Show(Cursor.Position.X, Cursor.Position.Y);
            contexMenu.ItemClicked += new ToolStripItemClickedEventHandler(
                contexMenu_ItemClicked);
        }

        void contexMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            switch (item.Text)
            {
                case "Video Tutorial":
                    System.Diagnostics.Process.Start("https://www.youtube.com/user/lansing9r");
                    break;
                case "AgOpenGPS":
                    System.Diagnostics.Process.Start("https://github.com/farmerbriantee/AgOpenGPS");
                    break;
                case "AgHardware":
                    System.Diagnostics.Process.Start("https://github.com/AgHardware");
                    break;
                case "AgOpenGPS videos":
                    System.Diagnostics.Process.Start("https://www.youtube.com/user/lansing9r");
                    break;
                case "AOG Discourse":
                    System.Diagnostics.Process.Start("https://discourse.agopengps.com/");
                    break;
                case "AOGConfig-O-Matic!":
                    System.Diagnostics.Process.Start("https://github.com/lansalot/AOGConfigOMatic");
                    break;
                case "AgOpenGPS Tools":
                    System.Diagnostics.Process.Start("https://github.com/lansalot/AgOpenGPS-Tools");
                    break;
            }
        }
    }

}
