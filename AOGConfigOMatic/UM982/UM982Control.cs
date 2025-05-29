using System;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace AOGConfigOMatic.UM982
{
    public partial class UM982Control : UserControl
    {
        private string? SelectedComPort;
        private SerialPort? _serialPort = null;
        private bool isReadingData = false;
        private bool isClosing = false;

        private bool isProgrammingUM982 = false;
        private readonly string configurationFilenameUM982 = ".\\ConfigUM982.txt";
        private string rcvDataUM982 = string.Empty;

        public UM982Control()
        {
            InitializeComponent();
        }

        private void UM982Control_Load(object sender, EventArgs e)
        {
            btnConfigUM982.Enabled = false;
            ScanPortsUM982();
        }

        public void Close()
        {
            isClosing = true;
            if (isReadingData)
            {
                StopReadingDataUM982();
            }
        }

        private void MySerialPort_DataReceived_UM982(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort spLUM982 = (SerialPort)sender;
            rcvDataUM982 = "";
            rcvDataUM982 = spLUM982.ReadLine();
            SafeChatUM982(rcvDataUM982);
        }

        private void StopReadingDataUM982()
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
                _serialPort.DataReceived -= MySerialPort_DataReceived_UM982;
                if (!isClosing)
                {
                    _serialPort.Close();
                }
            }
        }

        private void ScanPortsUM982()
        {
            var ports = SerialPort.GetPortNames().ToList();
            lbCOMPortsUM982.Items.Clear();
            foreach (var port in ports)
            {
                lbCOMPortsUM982.Items.Add(port);
            }
        }

        private void SafeChatUM982(string chat)
        {
            if (isClosing) { return; }
            txtSerialChatUM982.Invoke(new MethodInvoker(delegate
            {
                txtSerialChatUM982.AppendText(chat + Environment.NewLine);
            }));
        }

        private void btnURefreshUM982_Click(object sender, EventArgs e)
        {
            ScanPortsUM982();
        }

        private void lbCOMPortsUM982_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCOMPortsUM982.SelectedIndex > -1)
            {
                SelectedComPort = lbCOMPortsUM982.SelectedItem.ToString();
                btnConnectUM982.Enabled = true;
            }
            else
            {
                btnConnectUM982.Enabled = false;
            }
        }

        private void btnConnectUM982_Click(object sender, EventArgs e)
        {
            if (isReadingData)
            {
                StopReadingDataUM982();
                btnConnectUM982.Text = "Connect";
            }
            else
            {
                if (lbCOMPortsUM982.SelectedIndex == -1)
                {
                    txtSerialChatUM982.AppendText("Please select a COM port" + Environment.NewLine);
                    return;
                }
                _serialPort = new SerialPort(SelectedComPort, 115200, Parity.None, 8, StopBits.One);
                try
                {
                    _serialPort.Open();
                }
                catch
                {
                    SafeChatUM982("Error opening serial port - make sure anything using it is closed!");
                    return;
                }
                btnConnectUM982.Text = "Disconnect";
                _serialPort.DataReceived += MySerialPort_DataReceived_UM982;
                isReadingData = true;

                // Check for UM982 at 115200 factory default. 
                txtSerialChatUM982.AppendText("Checking for UM982 at 115200 bps ..." + Environment.NewLine);
                _serialPort.WriteLine("VERSION" + Environment.NewLine);
                Thread.Sleep(250);
                if (rcvDataUM982.Contains("OK"))
                {
                    txtSerialChatUM982.AppendText("Found UM982 at 115200 bps. Changing to 460800 bps." + Environment.NewLine);
                    _serialPort.WriteLine("CONFIG COM1 460800" + Environment.NewLine);
                    Thread.Sleep(250);
                    _serialPort.WriteLine("CONFIG COM2 460800" + Environment.NewLine);
                    Thread.Sleep(250);
                    _serialPort.WriteLine("CONFIG COM3 460800" + Environment.NewLine);
                    Thread.Sleep(250);
                    txtSerialChatUM982.AppendText("Temporarily changed to 460800 bps." + Environment.NewLine);
                }
                _serialPort.BaudRate = 460800;

                // End factory defualt check

                txtSerialChatUM982.AppendText("Requesting UM982 version info ..." + Environment.NewLine);
                _serialPort.WriteLine("VERSION" + Environment.NewLine);
                Thread.Sleep(250);
                txtSerialChatUM982.AppendText("Requesting UM982 current mode ..." + Environment.NewLine);
                _serialPort.WriteLine("MODE" + Environment.NewLine);
                _serialPort.WriteLine("MODE" + Environment.NewLine);
                Thread.Sleep(250);
                txtSerialChatUM982.AppendText("Requesting UM982 current config ..." + Environment.NewLine);
                _serialPort.WriteLine("CONFIG" + Environment.NewLine);
                Thread.Sleep(250);
                txtSerialChatUM982.AppendText("Requesting UM982 current messages being sent ..." + Environment.NewLine);
                _serialPort.WriteLine("UNILOGLIST" + Environment.NewLine);
                Thread.Sleep(250);
                isReadingData = true;
                btnConfigUM982.Enabled = true;
            }
        }

        private void btnConfigUM982_Click(object sender, EventArgs e)
        {
            if (_serialPort == null || !_serialPort.IsOpen)
            {
                txtSerialChatUM982.AppendText("Serial port is not open - please Connect" + Environment.NewLine);
                return;
            }
            ConfigureReceiverUM982();
        }

        private void ConfigureReceiverUM982()
        {
            if (string.IsNullOrEmpty(SelectedComPort) || string.IsNullOrEmpty(configurationFilenameUM982) || !isReadingData)
            {
                return;
            }

            btnConfigUM982.Enabled = false;
            btnConnectUM982.Enabled = false;
            btnURefreshUM982.Enabled = false;
            string[]? lines = null;

            try
            {
                // get receiver configuration file
                lines = File.ReadAllLines(configurationFilenameUM982);
            }
            catch (Exception ex)
            {
                var msg = ex.ToString();
                MessageBox.Show(msg, "Error configuring receiver");
            }
            isProgrammingUM982 = true;
            if (lines != null)
            {
                try
                {
                    _serialPort!.DataReceived += MySerialPort_DataReceived_UM982;

                    SafeChatUM982("Configuring:");

                    // Skip the first line of the file, that is the version
                    foreach (var line in lines.Skip(1))
                    {
                        SafeChatUM982(line);
                        _serialPort.WriteLine(line + Environment.NewLine);
                        Thread.Sleep(500);
                    }

                    SafeChatUM982("Configuring receiver done");
                }
                catch (Exception ex)
                {
                    SafeChatUM982("Error sending configuration to receiver" + Environment.NewLine + ex.ToString());
                }
                finally
                {
                    isProgrammingUM982 = false;
                    btnConfigUM982.Enabled = true;
                    btnConnectUM982.Enabled = true;
                    btnURefreshUM982.Enabled = true;
                }
            }
        }
    }
}
