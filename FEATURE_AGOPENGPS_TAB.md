# Feature Addition: AgOpenGPS Tab

## Overview

This document outlines the addition of a new "AgOpenGPS" tab to the AOGConfigOMatic application. This tab will provide users with the ability to download and manage AgOpenGPS releases directly from within the application.

## Background

AOGConfigOMatic currently provides tabs for:
- GPS (U-blox configuration)
- Teensy (firmware flashing)
- UM982 (GPS configuration)

Adding an AgOpenGPS tab will enhance the application's utility by providing a centralized location for users to access and manage AgOpenGPS software, complementing the existing hardware configuration capabilities.

## Feature Requirements

### Core Functionality

1. **Version List Display**
   - Fetch and display available AgOpenGPS releases from the official GitHub repository (located at https://github.com/AgOpenGPS-Official/AgOpenGPS/releases)
   - Show release version numbers, release dates, and descriptions, for last 10 releases
   - Display both stable releases and pre-releases (with appropriate labeling)
   - Provide filtering options (stable only, include pre-releases)

2. **Download Capabilities**
   - Download selected AgOpenGPS release packages - these are the agopengps*.zip file only, there is no "installer"
   - Show download progress with progress bar
   - Only offer the agopengps*.zip from each release
   - No architecture detection required

3. **Local Version Management**
   - allow user to select a default installation location, or display currently installed AgOpenGPS version (if detectable)
   - allow ability to create a folder for agopengps, suggest c:\agopengps as default
   - Show download history and cached releases
   - Option to launch installed AgOpenGPS directly from the tab


### User Interface Design

#### Layout Structure
```
┌─ AgOpenGPS Tab ───────────────────────────────────────────┐
│ ┌─ Available Releases ──────────────────────────────────┐ │
│ │ [ ] Include Pre-releases    [Refresh] [Check Latest]  │ │
│ │                                                       │ │
│ │ Version  │ Date       │ Description          │ Size   │ │
│ │ ─────────┼────────────┼─────────────────────┼───────  │ │
│ │ v5.7.3   │ 2024-10-15 │ Stable release      │ 125MB   │ │
│ │ v5.7.2   │ 2024-09-20 │ Bug fixes           │ 123MB   │ │
│ │ v5.8.0β  │ 2024-10-10 │ Beta features       │ 128MB   │ │
│ └───────────────────────────────────────────────────────┘ │
│                                                           │
│ ┌─ Actions ─────────────────────────────────────────────┐ │
│ │ Selected: v5.7.3                                      │ │
│ │ [Download Installer] [Download Portable]              │ │
│ │ Download to: [C:\Downloads\AgOpenGPS] [Browse...]     │ │
│ │                                                       │ │
│ │ Progress: [████████████████████] 100%                 │ │
│ └───────────────────────────────────────────────────────┘ │
│                                                           │
│ ┌─ Local Installation ──────────────────────────────────┐ │
│ │ Installed Version: v5.7.2                             │ │
│ │ Install Path: C:\Program Files\AgOpenGPS\             │ │
│ │ [Launch AgOpenGPS] [Open Install Folder]              │ │
│ └───────────────────────────────────────────────────────┘ │
└───────────────────────────────────────────────────────────┘
```

### Technical Implementation

#### New Components Required

1. **AgOpenGpsControl User Control**
   - Path: `AOGConfigOMatic/AgOpenGPS/AgOpenGpsControl.cs`
   - Similar structure to existing controls (TeensyControl, UBloxControl, UM982Control)
   - Handles all AgOpenGPS-related functionality

2. **GitHub API Integration**
   - Service class for GitHub API communication
   - Endpoints:
     - `GET /repos/farmerbriantee/AgOpenGPS/releases` - List releases
     - `GET /repos/farmerbriantee/AgOpenGPS/releases/latest` - Latest release
   - Rate limiting handling (GitHub API allows 60 requests/hour for unauthenticated)

3. **Download Manager**
   - Asynchronous download with progress reporting
   - Resume capability for interrupted downloads
   - Hash verification for downloaded files (if provided by releases)

4. **Registry/File System Integration**
   - Detection of installed AgOpenGPS versions
   - Common installation paths checking:
     - c:\agopengps
     - `C:\Program Files\AgOpenGPS\`
     - `C:\Program Files (x86)\AgOpenGPS\`
     - User profile directories
     - Portable installations

5. **Ability to set agOpenGPS to run on windows startup**
   - checkbox to enable it to start on windows-startup, or disable

#### Data Models

```csharp
public class AgOpenGpsRelease
{
    public string TagName { get; set; }
    public string Name { get; set; }
    public DateTime PublishedAt { get; set; }
    public string Body { get; set; }
    public bool IsPrerelease { get; set; }
    public List<ReleaseAsset> Assets { get; set; }
}

public class ReleaseAsset
{
    public string Name { get; set; }
    public string DownloadUrl { get; set; }
    public long Size { get; set; }
    public string ContentType { get; set; }
}
```

#### Configuration Storage

Extend the existing `App.config` to include:
```xml
<appSettings>
    <!-- Existing settings -->
    <add key="AgOpenGPS_DownloadPath" value="" />
    <add key="AgOpenGPS_InstallPath" value="" />
    <add key="AgOpenGPS_IncludePreReleases" value="false" />
    <add key="AgOpenGPS_AutoCheckUpdates" value="true" />
</appSettings>
```

### Implementation Phases

#### Phase 1: Basic Infrastructure
- [x] Create AgOpenGpsControl user control
- [x] Add new tab to main form
- [x] Implement GitHub API service class
- [x] Create basic UI layout

#### Phase 2: Core Functionality
- [ ] Implement release list fetching and display
- [ ] Add download functionality with progress tracking
- [ ] Implement local version detection
- [ ] Add configuration persistence

#### Phase 3: Enhanced Features
- [ ] Add auto-update checking
- [ ] Implement download resumption
- [ ] Add file hash verification
- [ ] Improve error handling and user feedback

#### Phase 4: Polish and Testing
- [ ] Add comprehensive error handling
- [ ] Implement offline mode graceful degradation
- [ ] Add unit tests for core functionality
- [ ] User interface refinements

### Dependencies

#### New NuGet Packages Required
- `Newtonsoft.Json` (for JSON deserialization of GitHub API responses)
- `System.Net.Http` (for HTTP client functionality)
- Potentially `Microsoft.Win32.Registry` (for registry-based version detection)

#### External Dependencies
- Internet connection for GitHub API access
- GitHub API availability (consider fallback options)

### Error Handling Scenarios

1. **Network Connectivity Issues**
   - No internet connection
   - GitHub API unavailable
   - Download interruptions

2. **File System Issues**
   - Insufficient disk space
   - Permission denied for download location
   - Corrupted downloads

3. **API Rate Limiting**
   - GitHub API rate limit exceeded
   - Graceful degradation with caching

### Security Considerations

1. **Download Verification**
   - Verify downloads come from official GitHub releases
   - Check file hashes when available
   - Warn users about unofficial sources

2. **File System Security**
   - Validate download paths to prevent directory traversal
   - Ensure proper permissions for download locations
   - Scan downloaded files with Windows Defender (if available)

### Future Enhancements

1. **Version Comparison**
   - Highlight newer versions than currently installed
   - Show changelog differences between versions

2. **Automatic Updates**
   - Optional background checking for new releases
   - Notification system for available updates

3. **Multiple Installation Management**
   - Support for multiple AgOpenGPS installations
   - Version switching capabilities

4. **Integration with Other Tabs**
   - Cross-reference compatible firmware versions
   - Suggest optimal configurations based on AgOpenGPS version

### Testing Strategy

#### Unit Tests
- GitHub API service methods
- Version parsing and comparison
- Download manager functionality
- Configuration persistence

#### Integration Tests
- Full download workflow
- UI interaction scenarios
- Error handling paths

#### User Acceptance Testing
- Real-world usage scenarios
- Performance with large releases
- Network interruption handling

### Documentation Updates

#### User Documentation
- Update main README.md with new tab information
- Create usage guide for AgOpenGPS tab
- Add troubleshooting section

#### Developer Documentation
- API documentation for new components
- Code examples for extending functionality
- Architecture diagrams showing integration points

## Conclusion

The addition of an AgOpenGPS tab will significantly enhance the AOGConfigOMatic application by providing users with a complete solution for managing both hardware configuration and software installation. This feature aligns with the application's goal of simplifying the AgOpenGPS ecosystem management for end users.

The phased implementation approach ensures that core functionality can be delivered quickly while allowing for iterative improvements and enhanced features in subsequent releases.