# Teensy Firmware Management - Local Storage

## Overview
Changed the Teensy firmware management system from downloading firmwares from GitHub to using locally packaged firmware files that ship with the application.

## Changes Made

### 1. Removed GitHub Download Functionality
- **Removed**: Download from GitHub CSV and remote hex files
- **Removed**: `DownloadFile()` method
- **Removed**: Async download logic
- **Removed**: Unused using statements (`System.Net`, `System.Diagnostics.Eventing.Reader`)
- **Removed**: Unused fields (`localCSV`, `localHexStub`)

### 2. Simplified Firmware Loading
- **Modified**: `UpdateFirmwareBox()` now only scans local `Firmwares` folder
- **Modified**: `btnRefreshTeensy_Click()` simplified to just rescan local folders
- **Modified**: `btnProgramTeensy_Click()` simplified - only handles local file paths
- **Changed**: Button text from "Refresh list" to "Refresh"

### 3. Updated Build Configuration
- **Modified**: `AOGConfigOMatic.csproj` to include the `Firmwares` folder from repository root
- **Added**: Content item with pattern `..\Firmwares\**\*.*` that copies all firmware files to output directory
- **Result**: Firmwares folder is now packaged with every build (Debug/Release)

## Firmware Folder Structure
```
Firmwares/
├── All-In-One/
│   ├── AIO-2.5.hex
│   ├── AIO-4.1.hex
│   └── sample_aio.hex
├── CANBUS/
│   ├── CANBUS (CommonRail).hex
│   ├── CANBUS-AIO-Dual.hex
│   ├── CANBUS-All-In-One.hex
│   └── sample_canbus.hex
├── Experimental/
│   ├── AiO GPS Configurator.hex
│   ├── AIOv4-DHCP-Beta.hex
│   └── sample_experimental.hex
└── Keya/
    ├── Keya-NonRVC.hex
    ├── Keya.hex
    ├── sample_keya.hex
    └── Further/
        └── UM981_WASLESS.hex
```

## TreeView Display
The firmware list now displays as a hierarchical tree that mirrors the on-disk folder structure:
- **Folder nodes**: Display folder names, cannot be programmed
- **Firmware nodes**: Display .hex filenames, can be selected for programming
- **Nested folders**: Fully supported (e.g., Keya → Further)

## Benefits
1. **Offline Operation**: No internet connection required
2. **Version Control**: Firmware files tracked in Git repository
3. **Reliability**: No dependency on external GitHub API
4. **Simplicity**: Cleaner code, faster startup
5. **Distribution**: Firmwares automatically packaged with releases

## How to Add New Firmwares
1. Place .hex files in the appropriate subfolder under `Firmwares/` at repository root
2. Create new subfolders as needed for organization
3. Rebuild the project - files are automatically copied to output
4. Click "Refresh" button in the application to rescan

## Migration Notes
- Old `Firmwares.csv` file is no longer used
- Any downloaded firmwares in the old system will be ignored
- The application now looks only at the packaged `Firmwares` folder
- TreeView scanning is recursive, supporting unlimited nesting levels
