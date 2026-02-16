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
            if (!spLUM982.IsOpen)
            {
                return;
            }

            try
            {
                rcvDataUM982 = "";
                rcvDataUM982 = spLUM982.ReadLine();
                SafeChatUM982(rcvDataUM982);
            }
            catch (Exception ex)
            {
                // Port was closed or other error during read
                SafeChatUM982Status($"Error in DataReceived: {ex.Message}");
            }
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
            lbCOMPortsUM982.Items.Clear();

            try
            {
                var portInfos = UsbSerialPortInfo.GetSerialPorts();

                foreach (var portInfo in portInfos)
                {
                    // For AiO devices, try to identify by interface first
                    if (portInfo.IsAioGpsConfigurator && portInfo.AioPortType == AioPortType.Unknown)
                    {
                        portInfo.AioPortType = AioPortIdentifier.IdentifyPortByInterface(portInfo.InterfaceNumber);
                    }

                    lbCOMPortsUM982.Items.Add(portInfo);
                }

                lbCOMPortsUM982.DisplayMember = "FriendlyName";
                lbCOMPortsUM982.ValueMember = "PortName";
            }
            catch (Exception ex)
            {
                // Fallback to basic port enumeration
                var basicPorts = SerialPort.GetPortNames();
                foreach (var port in basicPorts)
                {
                    var basicPortInfo = new UsbSerialPortInfo
                    {
                        PortName = port,
                        Description = port,
                        AioPortType = AioPortType.Unknown
                    };
                    lbCOMPortsUM982.Items.Add(basicPortInfo);
                }

                lbCOMPortsUM982.DisplayMember = "FriendlyName";
                lbCOMPortsUM982.ValueMember = "PortName";

                SafeChatUM982Status($"Error scanning UM982 ports: {ex.Message}");
            }
        }


        private void SafeChatUM982Status(string chat)
        {
            if (isClosing) { return; }
            if (txtUM982Status.InvokeRequired)
            {
                txtUM982Status.BeginInvoke(new MethodInvoker(delegate
                {
                    txtUM982Status.AppendText(chat + Environment.NewLine);
                }));
            }
            else
            {
                txtUM982Status.AppendText(chat + Environment.NewLine);
            }
        }

        private void SafeChatUM982(string chat)
        {
            if (isClosing) { return; }
            if (txtSerialChatUM982.InvokeRequired)
            {
                txtSerialChatUM982.BeginInvoke(new MethodInvoker(delegate
                {
                    txtSerialChatUM982.AppendText(chat + Environment.NewLine);
                }));
            }
            else
            {
                txtSerialChatUM982.AppendText(chat + Environment.NewLine);
            }
        }

        private void btnURefreshUM982_Click(object sender, EventArgs e)
        {
            ScanPortsUM982();
        }

        private void lbCOMPortsUM982_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbCOMPortsUM982.SelectedIndex > -1 && lbCOMPortsUM982.SelectedItem is UsbSerialPortInfo portInfo)
            {
                SelectedComPort = portInfo.PortName;
                btnConnectUM982.Enabled = true;

                // Show additional info for AiO devices
                if (portInfo.IsAioGpsConfigurator)
                {
                    var typeInfo = portInfo.AioPortType switch
                    {
                        AioPortType.Console => " (Console - Command/control interface)",
                        AioPortType.Gps1 => " (GPS1 - Bridge to Serial2)",
                        AioPortType.Gps2 => " (GPS2 - Bridge to Serial3)",
                        _ => " (AiO GPS Configurator)"
                    };

                    SafeChatUM982Status($"Selected AiO UM982 port: {portInfo.PortName}{typeInfo}");
                }
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
                    SafeChatUM982Status("Error opening serial port - make sure anything using it is closed!");
                    return;
                }
                btnConnectUM982.Text = "Disconnect";
                _serialPort.DataReceived += MySerialPort_DataReceived_UM982;
                isReadingData = true;

                // Check for UM982 at 115200 factory default. 
                SafeChatUM982Status("Checking for UM982 at 115200 bps ...");
                _serialPort.WriteLine("VERSION" + Environment.NewLine);
                Thread.Sleep(250);
                if (!rcvDataUM982.Contains("OK"))
                {
                    SafeChatUM982Status("Found UM982 at 115200 bps. Changing to 460800 bps.");
                    _serialPort.WriteLine("CONFIG COM1 460800" + Environment.NewLine);
                    Thread.Sleep(250);
                    _serialPort.WriteLine("CONFIG COM2 460800" + Environment.NewLine);
                    Thread.Sleep(250);
                    _serialPort.WriteLine("CONFIG COM3 460800" + Environment.NewLine);
                    Thread.Sleep(250);
                    _serialPort.DataReceived -= MySerialPort_DataReceived_UM982;
                    _serialPort.DiscardInBuffer();
                    _serialPort.DiscardOutBuffer();
                    _serialPort.Close();
                    _serialPort.BaudRate = 460800;
                    _serialPort.Open();
                    _serialPort.DataReceived += MySerialPort_DataReceived_UM982;
                }


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
                SafeChatUM982Status("Serial port is not open - please Connect");
                return;
            }
            ConfigureReceiverUM982();
        }

        private void ConfigureReceiverUM982()
        {
            if (string.IsNullOrEmpty(SelectedComPort) || !isReadingData)
            {
                return;
            }

            btnConfigUM982.Enabled = false;
            btnConnectUM982.Enabled = false;
            btnURefreshUM982.Enabled = false;

            // get receiver configuration file
            string configurationFilenameUM982;
            if (btnUMDual.Checked)
            {
                configurationFilenameUM982 = ".\\ConfigUM982D.txt";
            }
            else
            {
                configurationFilenameUM982 = ".\\ConfigUM982S.txt";
            }

            string[]? lines = null;

            try
            {
                lines = File.ReadAllLines(configurationFilenameUM982);
            }
            catch (Exception ex)
            {
                SafeChatUM982Status("Error configuring with " + configurationFilenameUM982 + " and error " + ex.Message.ToString());
            }
            isProgrammingUM982 = true;
            if (lines != null)
            {
                try
                {
                    _serialPort!.DataReceived += MySerialPort_DataReceived_UM982;

                    SafeChatUM982Status("Configuring..");

                    // Skip the first line of the file, that is the version
                    foreach (var line in lines.Skip(1))
                    {
                        SafeChatUM982(line);
                        _serialPort.WriteLine(line + Environment.NewLine);
                        Thread.Sleep(500);
                    }

                    SafeChatUM982Status("Configuring receiver done");
                }
                catch (Exception ex)
                {
                    SafeChatUM982Status("Error sending configuration to receiver" + Environment.NewLine + ex.ToString());
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
