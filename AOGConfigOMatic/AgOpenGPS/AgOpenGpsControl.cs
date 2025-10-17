using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
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
            
            // Create download directory if it doesn't exist
            if (!Directory.Exists(_downloadPath))
            {
                try
                {
                    Directory.CreateDirectory(_downloadPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not create download directory: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
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
                var mainAsset = release.Assets?.FirstOrDefault(a => a.Name.EndsWith(".exe") || a.Name.EndsWith(".msi"));
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

                MessageBox.Show($"Latest release: {latestRelease.TagName}\nPublished: {latestRelease.PublishedAt:yyyy-MM-dd}\n\n{latestRelease.Body}", 
                    "Latest Release", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                }
            }
        }

        private async void btnDownloadInstaller_Click(object sender, EventArgs e)
        {
            await DownloadSelectedRelease("installer");
        }

        private async void btnDownloadPortable_Click(object sender, EventArgs e)
        {
            await DownloadSelectedRelease("portable");
        }

        private void btnLaunchAgOpenGPS_Click(object sender, EventArgs e)
        {
            // TODO: Implement launch functionality
            MessageBox.Show("Launch functionality will be implemented in Phase 2", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnOpenInstallFolder_Click(object sender, EventArgs e)
        {
            // TODO: Implement folder opening functionality  
            MessageBox.Show("Open install folder functionality will be implemented in Phase 2", "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            
            // Find appropriate asset
            var targetAsset = selectedRelease.Assets?.FirstOrDefault(a => 
                (assetType == "installer" && (a.Name.EndsWith(".msi") || a.Name.EndsWith(".exe"))) ||
                (assetType == "portable" && a.Name.Contains("portable")));

            if (targetAsset == null)
            {
                MessageBox.Show($"No {assetType} found for this release.", "Not Available", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                btnDownloadInstaller.Enabled = false;
                btnDownloadPortable.Enabled = false;
                progressBar.Visible = true;
                lblStatus.Text = $"Downloading {targetAsset.Name}...";

                var downloadPath = Path.Combine(_downloadPath, targetAsset.Name);
                await DownloadFile(targetAsset.DownloadUrl, downloadPath);

                lblStatus.Text = "Download completed!";
                MessageBox.Show($"Downloaded successfully to:\n{downloadPath}", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Download failed";
                MessageBox.Show($"Download failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDownloadInstaller.Enabled = true;
                btnDownloadPortable.Enabled = true;
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
    }

    // Data models for GitHub API
    public class AgOpenGpsRelease
    {
        [JsonProperty("tag_name")]
        public string TagName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("body")]
        public string Body { get; set; }

        [JsonProperty("prerelease")]
        public bool IsPrerelease { get; set; }

        [JsonProperty("assets")]
        public List<ReleaseAsset> Assets { get; set; }
    }

    public class ReleaseAsset
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("browser_download_url")]
        public string DownloadUrl { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("content_type")]
        public string ContentType { get; set; }
    }
}