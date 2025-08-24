# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

AOGConfigOMatic is a Windows Forms application (.NET Framework 4.8) that simplifies flashing firmware to Teensy microcontrollers and configuring UBlox F9P/UM982 GPS devices for AgOpenGPS precision agriculture. The application provides a user-friendly interface to replace the complex TeensyDuino IDE and U-Center workflows.

## Architecture

### Core Structure
- **Main Form**: `frmMain.cs` - Primary UI with tabbed interface
- **User Controls**: Modular controls for different device types:
  - `Teensy/TeensyControl.cs` - Teensy microcontroller flashing
  - `UBlox/UBloxControl.cs` - UBlox F9P GPS configuration  
  - `UM982/UM982Control.cs` - UM982 GPS configuration

### Key Dependencies
- `lunOptics.libTeensySharp` (NuGet package) - Teensy programming library
- Built-in .NET Framework serial communication for GPS devices
- External executable: `ubxfwupdate.exe` for UBlox firmware updates

### Configuration Files
- `Firmwares.csv` - List of available firmware with download URLs
- `Single.txt`, `DualPosition.txt`, `DualRelPos.txt` - UBlox GPS configurations
- `ConfigUM982.txt`, `ConfigUM982D.txt`, `ConfigUM982S.txt` - UM982 GPS configurations
- `UBX113.bin` - UBlox firmware binary

## Build Commands

### Development Build
```bash
# Restore NuGet packages
nuget restore AOGConfigOMatic.sln -PackagesDirectory .\packages

# Build solution
msbuild /p:Configuration=Debug AOGConfigOMatic.sln
```

### Release Build
```bash
# Build for release
msbuild /p:Configuration=Release AOGConfigOMatic.sln

# Create distribution package
powershell Compress-Archive -Path AOGConfigOMatic\bin\Release\* -DestinationPath AOGConfigOMatic.zip -Force
```

### Version Management
```bash
# Update assembly versions (used by CI/CD)
powershell .\SetVersion.ps1 "1.2.3.4"
```

## Development Workflow

### Testing
- No automated test framework - testing is manual with actual hardware
- Test with physical Teensy and GPS devices connected via USB
- Verify firmware flashing and GPS configuration functionality

### CI/CD
- GitHub Actions workflow in `.github/workflows/main.yml`
- Automatic builds and releases on main branch pushes
- Semantic versioning based on commit messages (MAJOR:, MINOR: prefixes)
- Automated ZIP package creation for releases

### Hardware Requirements
- Windows development environment (uses Windows-specific libraries)
- Teensy microcontrollers for testing firmware flashing
- UBlox F9P or UM982 GPS devices for configuration testing

## Key Implementation Details

### Device Communication
- Serial port enumeration and management for GPS devices
- USB HID communication for Teensy programming via libTeensySharp
- Firmware downloading and caching from GitHub repositories

### File Management
- Runtime firmware downloading and local caching
- Configuration file deployment with build outputs
- Support for custom firmware files in application directory

### Error Handling
- Device detection and connection status monitoring  
- Firmware compatibility validation (UBlox requires v1.13)
- Progress tracking for long-running operations (firmware flashing, configuration)

## AiO GPS Configurator Support

### Enhanced Serial Port Detection
AOGConfigOMatic includes specialized support for AiO GPS Configurator devices:
- **USB Device Identification**: VID 0x16C0, PID 0x048C (Teensy Triple Serial)
- **Multi-Interface Detection**: Console (MI_00), GPS1 (MI_02), GPS2 (MI_04)
- **Behavioral Identification**: Port function detection via startup banners and NMEA messages

### Key AiO Classes
- `UsbSerialPortInfo` - Enhanced serial port enumeration with USB device details
- `AioPortIdentifier` - Port type identification (Console/GPS1/GPS2) 
- `AioDeviceHelper` - Utility methods for AiO device management

### Usage in Development
When working with AiO GPS Configurator features:
- Test with actual AiO hardware for port identification validation
- Use `AioDeviceHelper.GetAioDeviceSummary()` for device detection debugging
- Port detection gracefully falls back to basic enumeration if USB queries fail
- See `AIO_GPS_CONFIGURATOR.md` for detailed implementation documentation