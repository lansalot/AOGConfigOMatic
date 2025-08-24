using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AOGConfigOMatic
{
    public static class AioDeviceHelper
    {
        /// <summary>
        /// Gets all available AiO GPS Configurator ports with identification
        /// </summary>
        public static List<UsbSerialPortInfo> GetAioConfiguratorPorts()
        {
            var allPorts = UsbSerialPortInfo.GetSerialPorts();
            var aioPorts = new List<UsbSerialPortInfo>();
            
            foreach (var port in allPorts)
            {
                if (port.IsAioGpsConfigurator)
                {
                    aioPorts.Add(port);
                }
            }
            
            // Identify ports by interface number (fast method)
            foreach (var port in aioPorts)
            {
                if (port.AioPortType == AioPortType.Unknown)
                {
                    port.AioPortType = AioPortIdentifier.IdentifyPortByInterface(port.InterfaceNumber);
                }
            }
            
            return aioPorts.OrderBy(p => (int)p.AioPortType).ToList();
        }
        
        /// <summary>
        /// Gets a specific type of AiO port
        /// </summary>
        public static UsbSerialPortInfo GetAioPort(AioPortType portType)
        {
            var aioPorts = GetAioConfiguratorPorts();
            foreach (var port in aioPorts)
            {
                if (port.AioPortType == portType)
                {
                    return port;
                }
            }
            return null;
        }
        
        /// <summary>
        /// Performs behavioral identification on all unknown AiO ports (slower, requires port access)
        /// </summary>
        public static async Task<List<UsbSerialPortInfo>> IdentifyAioPortsBehaviorAsync(CancellationToken cancellationToken)
        {
            var aioPorts = GetAioConfiguratorPorts();
            var unknownPorts = new List<UsbSerialPortInfo>();
            
            foreach (var port in aioPorts)
            {
                if (port.AioPortType == AioPortType.Unknown)
                {
                    unknownPorts.Add(port);
                }
            }
            
            foreach (var port in unknownPorts)
            {
                if (cancellationToken.IsCancellationRequested)
                    break;
                    
                try
                {
                    await AioPortIdentifier.IdentifyAioPortAsync(port, cancellationToken);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Failed to identify port " + port.PortName + ": " + ex.Message);
                }
            }
            
            return aioPorts.OrderBy(p => (int)p.AioPortType).ToList();
        }
        
        /// <summary>
        /// Checks if any AiO GPS Configurator devices are connected
        /// </summary>
        public static bool HasAioDevices()
        {
            var allPorts = UsbSerialPortInfo.GetSerialPorts();
            foreach (var port in allPorts)
            {
                if (port.IsAioGpsConfigurator)
                {
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// Gets a summary of connected AiO devices
        /// </summary>
        public static string GetAioDeviceSummary()
        {
            var aioPorts = GetAioConfiguratorPorts();
            
            if (aioPorts.Count == 0)
            {
                return "No AiO GPS Configurator devices found.";
            }
            
            var summary = "Found " + aioPorts.Count + " AiO GPS Configurator port(s):\n";
            foreach (var port in aioPorts)
            {
                summary += "  • " + port.FriendlyName + "\n";
            }
            
            return summary;
        }
    }
}