using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace AOGConfigOMatic.AgOpenGPS
{
    public partial class AgOpenGpsControl : UserControl
    {
        private readonly HttpClient _httpClient;
        private readonly List<AgOpenGpsRelease> _releases = new List<AgOpenGpsRelease>();
        private string _downloadPath = @"C:\AgOpenGPS";
        private bool _includePreReleases = false;

        public AgOpenGpsControl()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "AOGConfigOMatic");
            
            // Load settings
            LoadSettings();
            
            // Initialize UI
            InitializeUI();
        }

        private void LoadSettings()
        {
            try
            {
                _downloadPath = System.Configuration.ConfigurationManager.AppSettings["AgOpenGPS_DownloadPath"] ?? @"C:\AgOpenGPS";
                _includePreReleases = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["AgOpenGPS_IncludePreReleases"] ?? "false");
            }
            catch
            {
                // Use defaults if config reading fails
                _downloadPath = @"C:\AgOpenGPS";
                _includePreReleases = false;
            }
        }

        private void InitializeUI()
        {
            txtDownloadPath.Text = _downloadPath;
            chkIncludePreReleases.Checked = _includePreReleases;
            
            // Ensure download directory exists
            EnsureDownloadDirectoryExists();
            
            // Update local installation info
            UpdateLocalInstallationInfo();
        }

        private bool EnsureDownloadDirectoryExists()
        {
            if (string.IsNullOrWhiteSpace(_downloadPath))
            {
                MessageBox.Show("Download path is not set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!Directory.Exists(_downloadPath))
            {
                try
                {
                    Directory.CreateDirectory(_downloadPath);
                    lblStatus.Text = $"Created directory: {_downloadPath}";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not create download directory '{_downloadPath}': {ex.Message}", 
                        "Directory Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            
            return true;
        }

        public async Task RefreshReleases()
        {
            try
            {
                btnRefresh.Enabled = false;
                btnCheckLatest.Enabled = false;
                progressBar.Visible = true;
                lblStatus.Text = "Fetching releases...";

                await FetchReleasesFromGitHub();
                PopulateReleasesGrid();

                lblStatus.Text = $"Found {_releases.Count} releases";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error fetching releases";
                MessageBox.Show($"Error fetching releases: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRefresh.Enabled = true;
                btnCheckLatest.Enabled = true;
                progressBar.Visible = false;
            }
        }

        private async Task FetchReleasesFromGitHub()
        {
            const string apiUrl = "https://api.github.com/repos/AgOpenGPS-Official/AgOpenGPS/releases";
            
            var response = await _httpClient.GetStringAsync(apiUrl);
            var allReleases = JsonConvert.DeserializeObject<List<AgOpenGpsRelease>>(response);

            _releases.Clear();
            
            // Filter releases based on user preferences and take last 10
            var filteredReleases = allReleases
                .Where(r => _includePreReleases || !r.IsPrerelease)
                .Take(10)
                .ToList();

            _releases.AddRange(filteredReleases);
        }

        private void PopulateReleasesGrid()
        {
            dataGridViewReleases.Rows.Clear();

            foreach (var release in _releases)
            {
                var versionText = release.IsPrerelease ? $"{release.TagName}β" : release.TagName;
                var mainAsset = release.Assets?.FirstOrDefault(a => 
                    a.Name.StartsWith("agopengps", StringComparison.OrdinalIgnoreCase) && 
                    a.Name.EndsWith(".zip", StringComparison.OrdinalIgnoreCase));
                var sizeText = mainAsset != null ? FormatFileSize(mainAsset.Size) : "N/A";

                dataGridViewReleases.Rows.Add(
                    versionText,
                    release.PublishedAt.ToString("yyyy-MM-dd"),
                    TruncateDescription(release.Body ?? release.Name),
                    sizeText
                );
            }
        }

        private string FormatFileSize(long bytes)
        {
            if (bytes >= 1073741824) return $"{bytes / 1073741824.0:F1} GB";
            if (bytes >= 1048576) return $"{bytes / 1048576.0:F1} MB";
            if (bytes >= 1024) return $"{bytes / 1024.0:F1} KB";
            return $"{bytes} B";
        }

        private string TruncateDescription(string description)
        {
            if (string.IsNullOrEmpty(description)) return "";
            
            // Remove markdown and limit length
            var cleaned = description.Replace("#", "").Replace("*", "").Replace("\r\n", " ").Replace("\n", " ");
            return cleaned.Length > 50 ? cleaned.Substring(0, 47) + "..." : cleaned;
        }

        public void TabChanged()
        {
            // Called when tab becomes active - refresh if needed
            if (_releases.Count == 0)
            {
                _ = RefreshReleases();
            }
        }

        public void Close()
        {
            // Cleanup when form is closing
            _httpClient?.Dispose();
        }

        // Event handlers
        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await RefreshReleases();
        }

        private async void btnCheckLatest_Click(object sender, EventArgs e)
        {
            try
            {
                const string latestUrl = "https://api.github.com/repos/AgOpenGPS-Official/AgOpenGPS/releases/latest";
                var response = await _httpClient.GetStringAsync(latestUrl);
                var latestRelease = JsonConvert.DeserializeObject<AgOpenGpsRelease>(response);
                if (latestRelease == null) return;
                try
                {
                    if (!string.IsNullOrEmpty(latestRelease.HTMLUrl))
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(latestRelease.HTMLUrl)
                        {
                            UseShellExecute = true
                        });
                    }
                }
                catch (Exception openEx)
                {
                    lblStatus.Text = $"Could not open browser: {openEx.Message}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking latest release: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkIncludePreReleases_CheckedChanged(object sender, EventArgs e)
        {
            _includePreReleases = chkIncludePreReleases.Checked;
            // Save setting and refresh if we have releases loaded
            if (_releases.Count > 0)
            {
                _ = RefreshReleases();
            }
        }

        private void btnBrowsePath_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.SelectedPath = _downloadPath;
                folderDialog.Description = "Select AgOpenGPS download/install directory";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    _downloadPath = folderDialog.SelectedPath;
                    txtDownloadPath.Text = _downloadPath;
                    UpdateLocalInstallationInfo();
                }
            }
        }

        private async void btnDownloadZip_Click(object sender, EventArgs e)
        {
            await DownloadSelectedRelease("zip");
        }

        private void btnLaunchAgOpenGPS_Click(object sender, EventArgs e)
        {
            try
            {
                // Search for agopengps.exe recursively in the download path
                string? agOpenGpsExe = null;
                
                if (Directory.Exists(_downloadPath))
                {
                    try
                    {
                        var exeFiles = Directory.GetFiles(_downloadPath, "agopengps.exe", SearchOption.AllDirectories);
                        if (exeFiles.Length > 0)
                        {
                            agOpenGpsExe = exeFiles[0]; // Use the first one found
                        }
                    }
                    catch
                    {
                        // Ignore search errors
                    }
                }
                
                if (!string.IsNullOrEmpty(agOpenGpsExe) && File.Exists(agOpenGpsExe))
                {
                    System.Diagnostics.Process.Start(agOpenGpsExe);
                }
                else
                {
                    MessageBox.Show("agopengps.exe not found in the installation directory.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not launch AgOpenGPS: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOpenInstallFolder_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(_downloadPath))
                {
                    System.Diagnostics.Process.Start("explorer.exe", _downloadPath);
                }
                else
                {
                    MessageBox.Show("Installation directory does not exist.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not open folder: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateLocalInstallationInfo()
        {
            // Search for agopengps.exe recursively in the download path
            string? agOpenGpsExe = null;
            
            if (Directory.Exists(_downloadPath))
            {
                try
                {
                    // Search for agopengps.exe in the download directory and subdirectories
                    var exeFiles = Directory.GetFiles(_downloadPath, "agopengps.exe", SearchOption.AllDirectories);
                    if (exeFiles.Length > 0)
                    {
                        agOpenGpsExe = exeFiles[0]; // Use the first one found
                    }
                }
                catch
                {
                    // Ignore search errors
                }
            }
            
            if (!string.IsNullOrEmpty(agOpenGpsExe) && File.Exists(agOpenGpsExe))
            {
                try
                {
                    var versionInfo = System.Diagnostics.FileVersionInfo.GetVersionInfo(agOpenGpsExe);
                    lblInstalledVersion.Text = $"Installed Version: {versionInfo.FileVersion ?? "Unknown"}";
                    lblInstallPath.Text = $"Install Path: {Path.GetDirectoryName(agOpenGpsExe)}";
                    btnLaunchAgOpenGPS.Enabled = true;
                    btnOpenInstallFolder.Enabled = true;
                }
                catch
                {
                    lblInstalledVersion.Text = "Installed Version: (detected, version unknown)";
                    lblInstallPath.Text = $"Install Path: {Path.GetDirectoryName(agOpenGpsExe)}";
                    btnLaunchAgOpenGPS.Enabled = true;
                    btnOpenInstallFolder.Enabled = true;
                }
            }
            else
            {
                lblInstalledVersion.Text = "Installed Version: (not detected)";
                lblInstallPath.Text = $"Install Path: {_downloadPath}";
                btnLaunchAgOpenGPS.Enabled = false;
                btnOpenInstallFolder.Enabled = Directory.Exists(_downloadPath);
            }
            
            // Update startup checkbox state
            UpdateStartupCheckboxState();
        }


        private void UpdateStartupCheckboxState()
        {
            try
            {
                string keyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                string valueName = "AgOpenGPS";

                using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyName, false))
                {
                    var value = key?.GetValue(valueName);
                    chkStartWithWindows.Checked = value != null;
                }
            }
            catch
            {
                // If we can't read registry, assume it's not set
                chkStartWithWindows.Checked = false;
            }
        }

        private void chkStartWithWindows_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string keyName = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
                string valueName = "AgOpenGPS";
                
                using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(keyName, true))
                {
                    if (chkStartWithWindows.Checked)
                    {
                        // Find AgOpenGPS executable to add to startup
                        string? agOpenGpsExe = null;
                        if (Directory.Exists(_downloadPath))
                        {
                            var exeFiles = Directory.GetFiles(_downloadPath, "agopengps.exe", SearchOption.AllDirectories);
                            if (exeFiles.Length > 0)
                            {
                                agOpenGpsExe = exeFiles[0];
                            }
                        }
                        
                        if (!string.IsNullOrEmpty(agOpenGpsExe) && File.Exists(agOpenGpsExe))
                        {
                            key?.SetValue(valueName, $"\"{agOpenGpsExe}\"");
                            lblStatus.Text = "AgOpenGPS added to Windows startup";
                        }
                        else
                        {
                            chkStartWithWindows.Checked = false;
                        }
                    }
                    else
                    {
                        // Remove from startup
                        key?.DeleteValue(valueName, false);
                        lblStatus.Text = "AgOpenGPS removed from Windows startup";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not modify startup settings: {ex.Message}", 
                    "Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Revert checkbox state if operation failed
                chkStartWithWindows.Checked = !chkStartWithWindows.Checked;
            }
        }

        private void btnCreateDesktopShortcut_Click(object sender, EventArgs e)
        {
            try
            {
                // Find AgOpenGPS executable
                string? agOpenGpsExe = null;
                if (Directory.Exists(_downloadPath))
                {
                    var exeFiles = Directory.GetFiles(_downloadPath, "agopengps.exe", SearchOption.AllDirectories);
                    if (exeFiles.Length > 0)
                    {
                        agOpenGpsExe = exeFiles[0];
                    }
                }
                
                if (string.IsNullOrEmpty(agOpenGpsExe) || !File.Exists(agOpenGpsExe))
                {
                    return;
                }

                // Create desktop shortcut
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string shortcutPath = Path.Combine(desktopPath, "AgOpenGPS.lnk");
                
                // Use WScript.Shell COM object to create shortcut (without dynamic)
                Type shellType = Type.GetTypeFromProgID("WScript.Shell");
                object shell = Activator.CreateInstance(shellType);
                object shortcut = shellType.InvokeMember("CreateShortcut", System.Reflection.BindingFlags.InvokeMethod, 
                    null, shell, new object[] { shortcutPath });
                
                // Set shortcut properties
                Type shortcutType = shortcut.GetType();
                shortcutType.InvokeMember("TargetPath", System.Reflection.BindingFlags.SetProperty, null, shortcut, new object?[] { agOpenGpsExe });
                shortcutType.InvokeMember("WorkingDirectory", System.Reflection.BindingFlags.SetProperty, null, shortcut, new object[] { Path.GetDirectoryName(agOpenGpsExe) });
                shortcutType.InvokeMember("Description", System.Reflection.BindingFlags.SetProperty, null, shortcut, new object[] { "AgOpenGPS - Precision Agriculture Application" });
                shortcutType.InvokeMember("Save", System.Reflection.BindingFlags.InvokeMethod, null, shortcut, null);
                
                lblStatus.Text = "Desktop shortcut created successfully";
                MessageBox.Show($"Desktop shortcut created successfully at:\n{shortcutPath}", 
                    "Shortcut Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not create desktop shortcut: {ex.Message}", 
                    "Shortcut Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewReleases_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewReleases.SelectedRows.Count > 0)
            {
                var selectedIndex = dataGridViewReleases.SelectedRows[0].Index;
                if (selectedIndex < _releases.Count)
                {
                    var selectedRelease = _releases[selectedIndex];
                    lblSelectedRelease.Text = $"Selected: {selectedRelease.TagName}";
                }
            }
            else
            {
                lblSelectedRelease.Text = "Selected: (none)";
            }
        }

        private async Task DownloadSelectedRelease(string assetType)
        {
            if (dataGridViewReleases.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a release to download.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedIndex = dataGridViewReleases.SelectedRows[0].Index;
            if (selectedIndex >= _releases.Count) return;

            var selectedRelease = _releases[selectedIndex];
            
            // Find AgOpenGPS zip file (agopengps*.zip)
            var targetAsset = selectedRelease.Assets?.FirstOrDefault(a => 
                a.Name.StartsWith("agopengps", StringComparison.OrdinalIgnoreCase) && 
                a.Name.EndsWith(".zip", StringComparison.OrdinalIgnoreCase));

            if (targetAsset == null)
            {
                MessageBox.Show("No AgOpenGPS zip file found for this release.", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Ensure download directory exists before attempting download
                if (!EnsureDownloadDirectoryExists())
                {
                    return; // Exit if directory creation failed
                }

                btnDownloadZip.Enabled = false;
                progressBar.Visible = true;
                lblStatus.Text = $"Downloading {targetAsset.Name}...";

                var downloadPath = Path.Combine(_downloadPath, targetAsset.Name);
                await DownloadFile(targetAsset.DownloadUrl, downloadPath);

                lblStatus.Text = "Extracting files...";
                progressBar.Style = ProgressBarStyle.Marquee;
                
                // Extract the zip file and handle subfolder structure
                await ExtractZipFile(downloadPath, _downloadPath, selectedRelease.TagName);

                lblStatus.Text = "Installation completed!";
                
                // Update local installation info after extraction
                UpdateLocalInstallationInfo();
                
                MessageBox.Show($"AgOpenGPS {selectedRelease.TagName} has been successfully installed to:\n{_downloadPath}", 
                    "Installation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Optionally delete the zip file after extraction
                try
                {
                    File.Delete(downloadPath);
                }
                catch
                {
                    // Ignore if we can't delete the zip file
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Download failed";
                MessageBox.Show($"Download failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDownloadZip.Enabled = true;
                progressBar.Style = ProgressBarStyle.Blocks;
                progressBar.Visible = false;
            }
        }

        private async Task DownloadFile(string url, string filePath)
        {
            using (var response = await _httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                var totalBytes = response.Content.Headers.ContentLength ?? 0;
                using (var contentStream = await response.Content.ReadAsStreamAsync())
                using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
                {
                    var buffer = new byte[8192];
                    var totalBytesRead = 0L;
                    int bytesRead;

                    while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await fileStream.WriteAsync(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;

                        if (totalBytes > 0)
                        {
                            var percentage = (int)((totalBytesRead * 100) / totalBytes);
                            progressBar.Value = Math.Min(percentage, 100);
                        }
                    }
                }
            }
        }

        private async Task ExtractZipFile(string zipFilePath, string extractToPath, string versionTag)
        {
            await Task.Run(() =>
            {
                using (var archive = ZipFile.OpenRead(zipFilePath))
                {
                    // Check if there's a common root folder in the zip
                    var rootFolders = archive.Entries
                        .Where(e => !string.IsNullOrEmpty(e.FullName) && e.FullName.Contains("/"))
                        .Select(e => e.FullName.Split('/')[0])
                        .Distinct()
                        .ToList();

                    // If there's only one root folder, we'll extract its contents directly to the target
                    var hasRootFolder = rootFolders.Count == 1 && 
                                       archive.Entries.All(e => string.IsNullOrEmpty(e.FullName) || 
                                                               e.FullName.StartsWith(rootFolders[0] + "/") || 
                                                               e.FullName == rootFolders[0]);

                    foreach (var entry in archive.Entries)
                    {
                        if (string.IsNullOrEmpty(entry.FullName)) continue;

                        string relativePath;
                        
                        if (hasRootFolder && entry.FullName.StartsWith(rootFolders[0] + "/"))
                        {
                            // Remove the root folder from the path
                            relativePath = entry.FullName.Substring(rootFolders[0].Length + 1);
                        }
                        else if (hasRootFolder && entry.FullName == rootFolders[0])
                        {
                            // Skip the root folder entry itself
                            continue;
                        }
                        else
                        {
                            relativePath = entry.FullName;
                        }

                        if (string.IsNullOrEmpty(relativePath)) continue;

                        var destinationPath = Path.Combine(extractToPath, relativePath);
                        var destinationDir = Path.GetDirectoryName(destinationPath);

                        if (!string.IsNullOrEmpty(destinationDir) && !Directory.Exists(destinationDir))
                        {
                            Directory.CreateDirectory(destinationDir);
                        }

                        // Only extract files, not directories
                        if (!entry.FullName.EndsWith("/") && !string.IsNullOrEmpty(entry.Name))
                        {
                            entry.ExtractToFile(destinationPath, overwrite: true);
                        }
                    }
                }
            });
        }
    }

    // Data models for GitHub API
    public class AgOpenGpsRelease
    {

        [JsonProperty("html_url")]
        public string HTMLUrl { get; set; } = null!;

        [JsonProperty("tag_name")]
        public string TagName { get; set; } = null!;

        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; } = null!;

        [JsonProperty("prerelease")]
        public bool IsPrerelease { get; set; }

        [JsonProperty("assets")]
        public List<ReleaseAsset> Assets { get; set; } = new List<ReleaseAsset>();
    }

    public class ReleaseAsset
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("browser_download_url")]
        public string DownloadUrl { get; set; } = null!;

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; } = null!;
    }
}