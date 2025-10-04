/*
 * MIT License
 *Copyright (c) 2021 易开元(EOM)

 *Permission is hereby granted, free of charge, to any person obtaining a copy
 *of this software and associated documentation files (the "Software"), to deal
 *in the Software without restriction, including without limitation the rights
 *to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 *copies of the Software, and to permit persons to whom the Software is
 *furnished to do so, subject to the following conditions:

 *The above copyright notice and this permission notice shall be included in all
 *copies or substantial portions of the Software.

 *THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 *IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 *FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 *AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 *LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 *OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 *SOFTWARE.
 *
 */
using AntdUI;
using EOM.TSHotelManagement.Common;
using EOM.TSHotelManagement.Common.Util;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace EOM.TSHotelManagement.FormUI
{
    public partial class FrmLoading : Window
    {
        private string CurrentVersion => ApplicationUtil.GetApplicationVersion().ToString();
        private string GithubRepoUrl => "https://api.github.com/repos/easy-open-meta/TopskyHotelManagerSystem/releases/latest";
        private string GiteeRepoUrl => "https://gitee.com/api/v5/repos/java-and-net/TopskyHotelManagerSystem/releases/latest";
        private string GithubProxyUrl => "https://ghproxy.oscode.top";
        private string AppDataPath => Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        private string FallbackUrl => "https://pan.gkhive.com/TSHotel";

        private ProgressBar progressBar;

        public FrmLoading()
        {
            InitializeComponent();
            progressBar = new ProgressBar
            {
                Minimum = 0,
                Maximum = 100,
                Dock = DockStyle.Top,
            };
            this.Controls.Add(progressBar);
        }

        private async void CheckForUpdate()
        {
            using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
            client.DefaultRequestHeaders.Add("User-Agent", await GetDefaultUserAgentAsync());
            try
            {
                var giteeResponse = await client.GetAsync(GiteeRepoUrl);
                if (giteeResponse.IsSuccessStatusCode)
                {
                    var giteeResult = await giteeResponse.Content.ReadAsStringAsync();
                    var giteeRelease = JsonConvert.DeserializeObject<GiteeRelease>(giteeResult);
                    HandleReleaseInfo<GiteeAsset>(giteeRelease.TagName, giteeRelease.Body, giteeRelease.Assets, isGitee: true);
                    return;
                }

                var githubResponse = await client.GetAsync(GithubRepoUrl);
                if (githubResponse.IsSuccessStatusCode)
                {
                    var githubResult = await githubResponse.Content.ReadAsStringAsync();
                    var githubRelease = JsonConvert.DeserializeObject<GitHubRelease>(githubResult);
                    HandleReleaseInfo<GitHubAsset>(githubRelease.TagName, githubRelease.Body, githubRelease.Assets, isGitee: false);
                    return;
                }
            }
            catch (Exception ex)
            {
                NotificationService.ShowError($"检查更新时发生错误: {ex.Message}");
                OpenFallbackUrl();
            }
            finally
            {
                progressBar.Visible = true;
            }
        }

        private void HandleReleaseInfo<TAsset>(
                string tagName,
                string releaseBody,
                List<TAsset> assets,
                bool isGitee) where TAsset : class
        {
            var version = tagName.Replace("v", string.Empty);
            rtbReleaseLog.Text = $"{releaseBody}";
            lbInternetSoftwareVersion.Text = version;
            lbInternetSoftwareVersion.Refresh();
            if (version.Equals(lblLocalSoftwareVersion.Text.Trim()))
            {
                progressBar.Value = 100;
                LoginInfo.SoftwareReleaseLog = $"{releaseBody}";
                NotificationService.ShowSuccess(LocalizationHelper.GetLocalizedString("The current version is already the latest, no need to update!", "当前已是最新版本，无需更新！"));
                lblTips.Text = LocalizationHelper.GetLocalizedString("The current version is already the latest, no need to update!", "当前已是最新版本，无需更新！");
                return;
            }

            string downloadUrl = string.Empty;
            if (isGitee)
            {
                dynamic executableAsset = assets.SingleOrDefault(a => ((dynamic)a).FileName?.EndsWith(".exe") == true);

                if (executableAsset == null) return;

                downloadUrl = executableAsset.DownloadUrl;
            }
            else
            {
                dynamic executableAsset = assets.SingleOrDefault(a => ((dynamic)a).Name?.EndsWith(".exe") == true);

                if (executableAsset == null) return;

                downloadUrl = $"{GithubProxyUrl}/{executableAsset.BrowserDownloadUrl}";
            }



            DownloadAndInstallUpdate(downloadUrl, "TS酒店管理系统.exe", new Progress<double>(ReportProgress), version);
            lblTips.Text = "安装包正在下载中，请稍等...";
        }

        private async Task<string> GetDefaultUserAgentAsync()
        {
            using var webBrowser = new WebBrowser();
            webBrowser.ScriptErrorsSuppressed = true;
            var tcs = new TaskCompletionSource<bool>();
            webBrowser.DocumentCompleted += (sender, e) => tcs.TrySetResult(true);

            webBrowser.Navigate(FallbackUrl);

            await tcs.Task;

            string? userAgent = webBrowser.Document?.InvokeScript("eval", new object[] { "navigator.userAgent;" })?.ToString();
            return userAgent ?? string.Empty;
        }

        private async Task<bool> DownloadAndInstallUpdate(string downloadUrl, string fileName, IProgress<double> progress, string tagName)
        {
            try
            {
                lblTips.Text = "正在选择保存路径...";
                fbdSavePath.UseDescriptionForTitle = true;
                fbdSavePath.Description = "请选择保存安装包的位置";
                fbdSavePath.RootFolder = Environment.SpecialFolder.Desktop;
                fbdSavePath.ShowNewFolderButton = true;

                if (fbdSavePath.ShowDialog() != DialogResult.OK)
                {
                    lblTips.Text = "下载已取消，将自动退出程序";
                    Thread.Sleep(2000);
                    ExitApplication();
                    return false;
                }

                string selectedPath = fbdSavePath.SelectedPath;

                string targetDirectory = Path.Combine(selectedPath ?? AppDataPath,
                    ApplicationUtil.GetApplicationCompanyName(),
                    ApplicationUtil.GetApplicationName(), tagName);

                if (!Path.Exists(targetDirectory))
                    Directory.CreateDirectory(targetDirectory);

                var tempFilePath = Path.Combine(targetDirectory, fileName);

                using var client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };
                var response = await client.GetAsync(downloadUrl, HttpCompletionOption.ResponseHeadersRead);
                var contentLength = response.Content.Headers.ContentLength;

                using var fileStream = new FileStream(tempFilePath, FileMode.Create, FileAccess.Write, FileShare.None);
                using var stream = await response.Content.ReadAsStreamAsync();

                var totalBytesRead = 0L;
                var buffer = new byte[8192];
                int bytesRead;

                lblTips.Text = "正在下载...";
                this.Refresh();

                while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await fileStream.WriteAsync(buffer, 0, bytesRead);
                    totalBytesRead += bytesRead;

                    if (contentLength.HasValue)
                    {
                        var progressPercentage = (double)totalBytesRead / contentLength.Value * 100;
                        progress.Report(progressPercentage);

                        lblTips.Text = $"下载中... {progressPercentage:F1}%";
                        this.Refresh();
                    }
                }

                Process.Start(new ProcessStartInfo
                {
                    FileName = "explorer.exe",
                    Arguments = $"/select, \"{tempFilePath}\"",
                    UseShellExecute = false,
                    CreateNoWindow = true
                });

                ExitApplication();
                return true;
            }
            catch (OperationCanceledException)
            {
                NotificationService.ShowError("网络连接超时，无法下载更新。");
                OpenFallbackUrl();
            }
            catch (Exception ex)
            {
                NotificationService.ShowError($"下载更新时发生错误: {ex.Message}");
                OpenFallbackUrl();
            }
            return false;
        }

        private void ReportProgress(double percentage)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<double>(ReportProgress), percentage);
            }
            else
            {
                progressBar.Value = (int)percentage;
            }
        }

        private void OpenFallbackUrl()
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = FallbackUrl,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                NotificationService.ShowError(LocalizationHelper.GetLocalizedString($"An error occurred while opening the browser: {ex.Message}", $"打开浏览器时发生错误: {ex.Message}"));
            }
        }

        private void FrmLoading_Load(object sender, EventArgs e)
        {
            if (RuntimeInformation.OSArchitecture != Architecture.X64)
            {
                lblTips.Text = LocalizationHelper.GetLocalizedString("Current Software only support x64 bit Architecture, running failure", "本应用仅支持x64位系统架构，运行失败");
                NotificationService.ShowError(LocalizationHelper.GetLocalizedString("Current Software only support x64 bit Architecture, running failure", "本应用不支持x64位系统架构，运行失败"));
                Thread.Sleep(2000);
                ExitApplication();
                return;
            }
            lblLocalSoftwareVersion.Text = CurrentVersion;
            CheckForUpdate();
        }

        public void threadPro()
        {
            System.Windows.Forms.MethodInvoker MethInvo = new System.Windows.Forms.MethodInvoker(ShowLoginForm);
            BeginInvoke(MethInvo);
        }

        public void ShowLoginForm()
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.ShowDialog(this);
            this.Close();
        }

        private void FrmLoading_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void ExitApplication()
        {
            Application.Exit();
        }

        public class GitHubRelease
        {
            [JsonProperty("tag_name")]
            public string TagName { get; set; }

            [JsonProperty("body")]
            public string Body { get; set; }

            [JsonProperty("assets")]
            public List<GitHubAsset> Assets { get; set; }
        }

        public class GitHubAsset
        {
            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("browser_download_url")]
            public string BrowserDownloadUrl { get; set; }
        }

        public class GiteeRelease
        {
            [JsonProperty("tag_name")]
            public string TagName { get; set; }

            [JsonProperty("name")]
            public string FileName { get; set; }

            [JsonProperty("body")]
            public string Body { get; set; }

            [JsonProperty("assets")]
            public List<GiteeAsset> Assets { get; set; }

            [JsonProperty("author")]
            public GiteeAuthor Author { get; set; }

            [JsonProperty("created_at")]
            public DateTime CreatedAt { get; set; }
        }

        public class GiteeAsset
        {
            [JsonProperty("browser_download_url")]
            public string DownloadUrl { get; set; }

            [JsonProperty("name")]
            public string FileName { get; set; }
        }

        public class GiteeAuthor
        {
            [JsonProperty("login")]
            public string Login { get; set; }

            [JsonProperty("avatar_url")]
            public string AvatarUrl { get; set; }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Task.Run(() => threadPro());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }
    }
}
