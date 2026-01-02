using System;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AOGConfigOMatic
{
    public class AioPortIdentifier
    {
        private const int IDENTIFICATION_TIMEOUT_MS = 3000;
        private const int NMEA_WAIT_TIMEOUT_MS = 6000; // Wait for NMEA periodic messages
        
        public static async Task<AioPortType> IdentifyPortByBehaviorAsync(string portName, CancellationToken cancellationToken)
        {
            SerialPort? serialPort = null;
            try
            {
                serialPort = new SerialPort(portName, 115200, Parity.None, 8, StopBits.One);
                serialPort.ReadTimeout = 1000;
                serialPort.WriteTimeout = 1000;
                serialPort.DtrEnable = true;
                serialPort.RtsEnable = true;
                
                var receivedData = new StringBuilder();
                var dataReceived = false;
                
                serialPort.DataReceived += (sender, e) =>
                {
                    try
                    {
                        var sp = (SerialPort)sender;
                        var data = sp.ReadExisting();
                        lock (receivedData)
                        {
                            receivedData.Append(data);
                            dataReceived = true;
                        }
                    }
                    catch
                    {
                        // Ignore read errors during identification
                    }
                };
                
                serialPort.Open();
                
                // Send a character to trigger responses
                serialPort.Write("\r");
                
                // Wait for initial response
                var startTime = DateTime.Now;
                while (!dataReceived && (DateTime.Now - startTime).TotalMilliseconds < IDENTIFICATION_TIMEOUT_MS)
                {
                    if (cancellationToken.IsCancellationRequested)
                        return AioPortType.Unknown;
                        
                    await Task.Delay(100, cancellationToken);
                }
                
                string response;
                lock (receivedData)
                {
                    response = receivedData.ToString();
                }
                
                // Check for console port indicators
                if (response.Contains("*** THIS IS THE CONSOLE PORT ***") || 
                    response.Contains("CONSOLE") ||
                    (response.Contains("1)") && response.Contains("2)")) || // Menu items
                    response.Contains("AgOpenGPS") ||
                    response.Contains("Config"))
                {
                    return AioPortType.Console;
                }
                
                // Check for GPS port banners
                if (response.Contains("THIS IS GPS1 PORT"))
                {
                    return AioPortType.Gps1;
                }
                
                if (response.Contains("THIS IS GPS2 PORT"))
                {
                    return AioPortType.Gps2;
                }
                
                // Wait for periodic NMEA messages if no banner was found
                receivedData.Clear();
                dataReceived = false;
                
                startTime = DateTime.Now;
                while ((DateTime.Now - startTime).TotalMilliseconds < NMEA_WAIT_TIMEOUT_MS)
                {
                    if (cancellationToken.IsCancellationRequested)
                        return AioPortType.Unknown;
                        
                    await Task.Delay(500, cancellationToken);
                    
                    lock (receivedData)
                    {
                        var nmeaData = receivedData.ToString();
                        
                        // Check for periodic NMEA identification messages
                        if (nmeaData.Contains("$PAIOC,PORT,GPS1"))
                        {
                            return AioPortType.Gps1;
                        }
                        
                        if (nmeaData.Contains("$PAIOC,PORT,GPS2"))
                        {
                            return AioPortType.Gps2;
                        }
                    }
                }
                
                return AioPortType.Unknown;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error identifying port " + portName + ": " + ex.Message);
                return AioPortType.Unknown;
            }
            finally
            {
                try
                {
                    if (serialPort != null)
                    {
                        serialPort.Close();
                        serialPort.Dispose();
                    }
                }
                catch
                {
                    // Ignore cleanup errors
                }
            }
        }
        
        public static async Task<UsbSerialPortInfo> IdentifyAioPortAsync(UsbSerialPortInfo portInfo, CancellationToken cancellationToken)
        {
            if (!portInfo.IsAioGpsConfigurator || portInfo.AioPortType != AioPortType.Unknown)
            {
                return portInfo; // Already identified or not an AiO device
            }
            
            var identifiedType = await IdentifyPortByBehaviorAsync(portInfo.PortName, cancellationToken);
            portInfo.AioPortType = identifiedType;
            
            return portInfo;
        }
        
        /// <summary>
        /// Quick identification method for cases where behavioral identification isn't needed
        /// </summary>
        public static AioPortType IdentifyPortByInterface(string interfaceNumber)
        {
            switch (interfaceNumber)
            {
                case "00":
                    return AioPortType.Console;
                case "02":
                    return AioPortType.Gps1;
                case "04":
                    return AioPortType.Gps2;
                default:
                    return AioPortType.Unknown;
            }
        }
    }
}