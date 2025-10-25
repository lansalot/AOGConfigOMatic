# AOGConfigOMatic Installer

This directory contains the Inno Setup script for creating the AOGConfigOMatic installer.

## Building the Installer Locally

### Prerequisites
- Inno Setup 6 (Download from: https://jrsoftware.org/isinfo.php)
- Visual Studio with MSBuild
- .NET Framework 4.8

### Steps

1. **Build the Release version:**
   ```powershell
   msbuild /m /p:Configuration=Release .\AOGConfigOMatic.sln
   ```

2. **Compile the installer:**
   ```powershell
   & "C:\Program Files (x86)\Inno Setup 6\ISCC.exe" setup.iss
   ```

3. **Find the installer:**
   The installer will be created in the `installer/` directory as:
   `AOGConfigOMatic-Setup-[version].exe`

## Automated Build

The GitHub Actions workflow automatically:
1. Builds the Release configuration
2. Updates the version number in `setup.iss`
3. Compiles the Inno Setup installer
4. Uploads both the ZIP file and installer to the GitHub Release

## Installer Features

The installer includes:
- ✅ Full application with all dependencies
- ✅ Firmwares folder with hierarchical structure
- ✅ Optional desktop shortcut
- ✅ Optional "Start with Windows" setting
- ✅ Proper uninstaller
- ✅ .NET Framework 4.8 requirement check
- ✅ Modern wizard interface

## Installation Options

During installation, users can choose:
- Installation directory (default: `C:\Program Files\AOGConfigOMatic`)
- Create desktop icon (unchecked by default)
- Start with Windows (unchecked by default)
- Launch application after installation

## Files Included

The installer packages:
- `AOGConfigOMatic.exe` - Main application
- All required DLLs (Newtonsoft.Json, libTeensySharp, etc.)
- Configuration files (*.txt, *.bin)
- `Firmwares/` folder with all subdirectories
- Application icon and resources
