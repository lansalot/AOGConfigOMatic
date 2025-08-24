using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text.RegularExpressions;

namespace AOGConfigOMatic
{
    public class UsbSerialPortInfo
    {
        public string PortName { get; set; }
        public string Description { get; set; }
        public string VendorId { get; set; }
        public string ProductId { get; set; }
        public string InterfaceNumber { get; set; }
        public string DeviceInstanceId { get; set; }
        public AioPortType AioPortType { get; set; }
        
        public UsbSerialPortInfo()
        {
            PortName = string.Empty;
            Description = string.Empty;
            VendorId = string.Empty;
            ProductId = string.Empty;
            InterfaceNumber = string.Empty;
            DeviceInstanceId = string.Empty;
            AioPortType = AioPortType.Unknown;
        }
        
        public bool IsAioGpsConfigurator
        {
            get
            {
                return VendorId.Equals("16C0", StringComparison.OrdinalIgnoreCase) && 
                       ProductId.Equals("048C", StringComparison.OrdinalIgnoreCase);
            }
        }

        public string FriendlyName
        {
            get
            {
                if (IsAioGpsConfigurator)
                {
                    switch (AioPortType)
                    {
                        case AioPortType.Console:
                            return PortName + " - AiO Console";
                        case AioPortType.Gps1:
                            return PortName + " - AiO GPS1";
                        case AioPortType.Gps2:
                            return PortName + " - AiO GPS2";
                        default:
                            return PortName + " - AiO GPS Config";
                    }
                }
                return !string.IsNullOrEmpty(Description) ? PortName + " - " + Description : PortName;
            }
        }

        public static List<UsbSerialPortInfo> GetSerialPorts()
        {
            var result = new List<UsbSerialPortInfo>();
            
            try
            {
                // Query WMI for serial port information
                using (var searcher = new ManagementObjectSearcher(
                    "SELECT * FROM Win32_PnPEntity WHERE ClassGuid='{4d36e978-e325-11ce-bfc1-08002be10318}'"))
                using (var collection = searcher.Get())
                {
                    foreach (ManagementObject device in collection)
                    {
                        try
                        {
                            var name = device["Name"] != null ? device["Name"].ToString() : string.Empty;
                            var deviceId = device["DeviceID"] != null ? device["DeviceID"].ToString() : string.Empty;
                            
                            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(deviceId) || !name.Contains("COM"))
                                continue;

                            var portInfo = new UsbSerialPortInfo();
                            
                            // Extract COM port number
                            var comMatch = Regex.Match(name, @"COM(\d+)");
                            if (comMatch.Success)
                            {
                                portInfo.PortName = comMatch.Value;
                            }
                            
                            portInfo.Description = name;
                            portInfo.DeviceInstanceId = deviceId;
                            
                            // Parse USB VID/PID from device ID
                            var usbMatch = Regex.Match(deviceId, @"USB\\VID_([0-9A-F]{4})&PID_([0-9A-F]{4})", RegexOptions.IgnoreCase);
                            if (usbMatch.Success)
                            {
                                portInfo.VendorId = usbMatch.Groups[1].Value;
                                portInfo.ProductId = usbMatch.Groups[2].Value;
                                
                                // Extract interface number for multi-interface devices
                                var interfaceMatch = Regex.Match(deviceId, @"MI_(\d{2})", RegexOptions.IgnoreCase);
                                if (interfaceMatch.Success)
                                {
                                    portInfo.InterfaceNumber = interfaceMatch.Groups[1].Value;
                                    
                                    // Identify AiO GPS Configurator port types
                                    if (portInfo.IsAioGpsConfigurator)
                                    {
                                        switch (portInfo.InterfaceNumber)
                                        {
                                            case "00":
                                                portInfo.AioPortType = AioPortType.Console;
                                                break;
                                            case "02":
                                                portInfo.AioPortType = AioPortType.Gps1;
                                                break;
                                            case "04":
                                                portInfo.AioPortType = AioPortType.Gps2;
                                                break;
                                            default:
                                                portInfo.AioPortType = AioPortType.Unknown;
                                                break;
                                        }
                                    }
                                }
                            }
                            
                            if (!string.IsNullOrEmpty(portInfo.PortName))
                            {
                                result.Add(portInfo);
                            }
                        }
                        catch (Exception ex)
                        {
                            System.Diagnostics.Debug.WriteLine("Error processing device: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error querying serial ports: " + ex.Message);
                
                // Fallback to basic port enumeration
                var basicPorts = System.IO.Ports.SerialPort.GetPortNames();
                foreach (var port in basicPorts)
                {
                    result.Add(new UsbSerialPortInfo 
                    { 
                        PortName = port, 
                        Description = port,
                        AioPortType = AioPortType.Unknown
                    });
                }
            }
            
            return result.OrderBy(p => p.PortName).ToList();
        }
        
        public static List<UsbSerialPortInfo> GetAioGpsConfiguratorPorts()
        {
            var allPorts = GetSerialPorts();
            var aioPorts = new List<UsbSerialPortInfo>();
            foreach (var port in allPorts)
            {
                if (port.IsAioGpsConfigurator)
                {
                    aioPorts.Add(port);
                }
            }
            return aioPorts;
        }
    }

    public enum AioPortType
    {
        Unknown,
        Console,
        Gps1,
        Gps2
    }
}