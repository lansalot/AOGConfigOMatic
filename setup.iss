; AOGConfigOMatic Inno Setup Script
; This script will create an installer for the AOGConfigOMatic application

#define MyAppName "AOGConfigOMatic"
#define MyAppVersion "1.0.0.0"
#define MyAppPublisher "AOG Community"
#define MyAppURL "https://github.com/lansalot/AOGConfigOMatic"
#define MyAppExeName "AOGConfigOMatic.exe"
#define MyAppIcoName "AOGConfigOMatic.ico"

[Setup]
; NOTE: The value of AppId uniquely identifies this application. Do not use the same AppId value in installers for other applications.
; (To generate a new GUID, click Tools | Generate GUID inside the IDE.)
AppId={{2BE12002-7524-4552-9D32-1AC61BF78672}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
DefaultDirName={localappdata}\{#MyAppName}
DefaultGroupName={#MyAppName}
AllowNoIcons=yes
LicenseFile=LICENSE
OutputDir=installer
OutputBaseFilename=AOGConfigOMatic-Setup-{#MyAppVersion}
SetupIconFile=AOGConfigOMatic\{#MyAppIcoName}
Compression=lzma
SolidCompression=yes
WizardStyle=modern
ArchitecturesInstallIn64BitMode=x64compatible
PrivilegesRequired=lowest
PrivilegesRequiredOverridesAllowed=dialog

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "AOGConfigOMatic\bin\Release\{#MyAppExeName}"; DestDir: "{app}"; Flags: ignoreversion
Source: "AOGConfigOMatic\bin\Release\*.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "AOGConfigOMatic\bin\Release\*.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "AOGConfigOMatic\bin\Release\*.txt"; DestDir: "{app}"; Flags: ignoreversion
Source: "AOGConfigOMatic\bin\Release\*.bin"; DestDir: "{app}"; Flags: ignoreversion
Source: "AOGConfigOMatic\bin\Release\*.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "AOGConfigOMatic\bin\Release\Firmwares\*"; DestDir: "{app}\Firmwares"; Flags: ignoreversion recursesubdirs createallsubdirs
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

[Icons]
Name: "{group}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"
Name: "{group}\{cm:UninstallProgram,{#MyAppName}}"; Filename: "{uninstallexe}"
Name: "{autodesktop}\{#MyAppName}"; Filename: "{app}\{#MyAppExeName}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#MyAppExeName}"; Description: "{cm:LaunchProgram,{#MyAppName}}"; Flags: nowait postinstall skipifsilent

[Code]
// Check for .NET Framework 4.8
function IsDotNetInstalled(): Boolean;
var
  Exists: Boolean;
  Release: Cardinal;
begin
  Exists := RegQueryDWordValue(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full', 'Release', Release);
  Result := Exists and (Release >= 528040);
end;

function InitializeSetup(): Boolean;
begin
  Result := True;
  if not IsDotNetInstalled() then
  begin
    MsgBox('.NET Framework 4.8 or later is required to run this application.'#13#13
           'Please install .NET Framework 4.8 from:'#13
           'https://dotnet.microsoft.com/download/dotnet-framework/net48', mbError, MB_OK);
    Result := False;
  end;
end;
