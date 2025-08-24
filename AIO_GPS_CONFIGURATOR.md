# AiO GPS Configurator Support

AOGConfigOMatic now includes enhanced support for detecting and identifying AiO GPS Configurator devices (Teensy 4.1 with Triple Serial firmware).

## Overview

The AiO GPS Configurator presents as a single USB device with multiple CDC ACM serial interfaces:
- **VID**: 0x16C0 (Van Ooijen Technische Informatica)
- **PID**: 0x048C (Teensy Triple Serial)
- **Product Name**: "AiO GPS Config"
- **Manufacturer**: "AiO"

## Port Types

The device provides three distinct serial ports:

### Console Port (Interface 0 - MI_00)
- **Function**: Command/control interface
- **Identification**: Shows menu with "*** THIS IS THE CONSOLE PORT ***"
- **Usage**: Device configuration and control

### GPS1 Port (Interface 2 - MI_02)  
- **Function**: Bridge to Serial2 (Teensy pins 7,8)
- **Identification**: Shows "THIS IS GPS1 PORT" banner at startup
- **Periodic ID**: Sends `$PAIOC,PORT,GPS1*00` every 5 seconds
- **Usage**: Primary GPS device communication

### GPS2 Port (Interface 4 - MI_04)
- **Function**: Bridge to Serial3 (Teensy pins 15,14)  
- **Identification**: Shows "THIS IS GPS2 PORT" banner at startup
- **Periodic ID**: Sends `$PAIOC,PORT,GPS2*00` every 5 seconds
- **Usage**: Secondary GPS device communication (for dual setups)

## Implementation

### Key Classes

- **`UsbSerialPortInfo`**: Enhanced serial port information with USB device details
- **`AioPortIdentifier`**: Port identification by USB interface and behavioral analysis
- **`AioDeviceHelper`**: Utility methods for working with AiO devices

### Detection Methods

1. **USB Interface Detection** (Fast)
   - Parses Windows device instance path for MI_XX interface numbers
   - Maps interface numbers to port functions
   - No serial port access required

2. **Behavioral Detection** (Slower)
   - Opens serial port and analyzes responses
   - Looks for console menu, GPS port banners, and NMEA messages
   - Used as fallback when interface detection fails

### UI Integration

The UBlox and UM982 control panels now display enhanced port information:
- Standard ports: `COM3 - USB Serial Device`
- AiO ports: `COM15 - AiO Console`, `COM16 - AiO GPS1`, `COM17 - AiO GPS2`

## Usage Examples

```csharp
// Get all AiO GPS Configurator ports
var aioPorts = AioDeviceHelper.GetAioConfiguratorPorts();

// Get a specific port type
var consolePort = AioDeviceHelper.GetAioPort(AioPortType.Console);
var gps1Port = AioDeviceHelper.GetAioPort(AioPortType.Gps1);

// Check if AiO devices are connected
if (AioDeviceHelper.HasAioDevices())
{
    var summary = AioDeviceHelper.GetAioDeviceSummary();
    Console.WriteLine(summary);
}

// Get all serial ports with enhanced information
var allPorts = UsbSerialPortInfo.GetSerialPorts();
foreach (var port in allPorts)
{
    Console.WriteLine($"{port.FriendlyName} - {port.PortName}");
    if (port.IsAioGpsConfigurator)
    {
        Console.WriteLine($"  AiO Port Type: {port.AioPortType}");
        Console.WriteLine($"  Interface: MI_{port.InterfaceNumber}");
    }
}
```

## Testing

To test the AiO GPS Configurator support:

1. Connect an AiO GPS Configurator device via USB
2. Launch AOGConfigOMatic
3. Go to UBlox or UM982 tab
4. Click "Rescan Ports" 
5. Verify ports show as "AiO Console", "AiO GPS1", "AiO GPS2" instead of generic "USB Serial Device"
6. Select different ports and verify the correct COM port is used for connection

## Troubleshooting

### Ports show as generic "USB Serial Device"
- Windows may cache generic names instead of custom descriptors
- Try unplugging and reconnecting the device
- Check Device Manager for proper device enumeration

### Behavioral identification not working
- Ensure no other applications have the serial ports open
- Check that the AiO firmware is responding correctly
- Behavioral identification is disabled by default (requires port access)

### Build Issues
- Ensure System.Management reference is available for WMI queries
- .NET Framework 4.8 is required for proper USB device enumeration

## Integration Notes

The enhanced port detection is backward-compatible with existing functionality. If USB device enumeration fails, the system falls back to basic `SerialPort.GetPortNames()` behavior.

The detection code is designed to be non-intrusive and will not interfere with normal GPS device operation or configuration.