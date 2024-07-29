using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MetroFramework.Forms;
using NAudio.CoreAudioApi;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;
using Newtonsoft.Json.Linq;
using System.Drawing;

namespace ILM
{
    public partial class main : MetroForm
    {
        private MMDeviceEnumerator deviceEnumerator;
        private MMDevice defaultDevice;
        private string apiUrl = "https://ilovemusic.de/typo3conf/ext/ep_channel/Scripts/playlist.php";
        private string versionUrl = "https://raw.githubusercontent.com/wiesty/ILM/master/VERSION";
        private string currentVersion = "2.0.0";
        private Dictionary<string, string> segmentNameMapping;
        private System.Timers.Timer songUpdateTimer;

        public main()
        {
            InitializeComponent();
            deviceEnumerator = new MMDeviceEnumerator();
            defaultDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            segmentNameMapping = new Dictionary<string, string>();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await LoadRadioStationsFromApi();
            comboBoxStations.DisplayMember = "Key";
            comboBoxStations.ValueMember = "Value";

            this.metroTrackBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBar1_Scroll);
            wmpPlayer.PlayStateChange += WmpPlayer_PlayStateChange;

            metroCheckBox1.CheckedChanged += new EventHandler(this.metroCheckBox1_CheckedChanged);
            currentPlaying.Click += new EventHandler(this.CurrentPlaying_Click);
            this.VersionLabel.Click += new EventHandler(this.VersionLabel_Click);

            songUpdateTimer = new System.Timers.Timer(45000);
            songUpdateTimer.Elapsed += async (s, ev) => await UpdateCurrentSongInfo();
            songUpdateTimer.Start();
        }
        
        private async Task LoadRadioStationsFromApi()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonResponse = await client.GetStringAsync(apiUrl);
                    var data = JObject.Parse(jsonResponse);

                    var stations = new List<object>();
                    foreach (var channel in data.Properties())
                    {
                        string segmentName = channel.Value["segmentname"].ToString();
                        if (!string.IsNullOrWhiteSpace(segmentName))
                        {
                            string displayName = $"I ♥ {segmentName.Replace("ilove", "")}";
                            string streamUrl = $"https://www.ilovemusic.de/{segmentName}.m3u";

                            segmentNameMapping[displayName] = segmentName;
                            stations.Add(new KeyValuePair<string, string>(displayName, streamUrl));

                            Console.WriteLine($"Found channel: {displayName} with URL: {streamUrl}");
                        }
                    }

                    InvokeOnUiThread(() =>
                    {
                        comboBoxStations.Items.AddRange(stations.ToArray());
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching radio channels: " + ex.Message);
            }
        }

        private async void buttonPlay_Click_1(object sender, EventArgs e)
        {
            if (buttonPlay.Text == "switch channel")
            {
                var selectedStation = GetSelectedStation();
                if (selectedStation.HasValue)
                {
                    wmpPlayer.URL = selectedStation.Value.Value;
                    wmpPlayer.Ctlcontrols.play();
                    await UpdateCurrentSongInfo();
                }
            }

            if (wmpPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                wmpPlayer.Ctlcontrols.stop();
                InvokeOnUiThread(() =>
                {
                    buttonPlay.Text = "Play";
                    currentPlaying.Text = "Stopped";
                    pictureBox1.Image = ILM.Properties.Resources.ilmlogo;
                });
            }
            else
            {
                var selectedStation = GetSelectedStation();
                if (selectedStation.HasValue)
                {
                    wmpPlayer.URL = selectedStation.Value.Value;
                    wmpPlayer.Ctlcontrols.play();
                    InvokeOnUiThread(() => buttonPlay.Text = "Stop");
                    await UpdateCurrentSongInfo();
                }
                else
                {
                    MessageBox.Show("Please select a radio station.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void WmpPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (wmpPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                InvokeOnUiThread(() => buttonPlay.Text = "Stop");
                await UpdateCurrentSongInfo();
            }
            else if (wmpPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                InvokeOnUiThread(() =>
                {
                    buttonPlay.Text = "Play";
                    currentPlaying.Text = "Stopped";
                    pictureBox1.Image = ILM.Properties.Resources.ilmlogo;
                });
            }
        }

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            wmpPlayer.settings.volume = metroTrackBar1.Value;
        }

        private void metroCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (metroCheckBox1.Checked)
            {
                SetApplicationVolume("ILM", 0.2f);
            }
            else if (!metroCheckBox1.Checked)
            {
                SetApplicationVolume("ILM", 1f);
            }
            
        }

        private void comboBoxStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (wmpPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                InvokeOnUiThread(() => buttonPlay.Text = "switch channel");
            }
            else
            {
                var selectedStation = GetSelectedStation();
                if (selectedStation.HasValue)
                {
                    InvokeOnUiThread(() => buttonPlay.Text = "Play");
                }
                else
                {
                    MessageBox.Show("Please select a radio station.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private KeyValuePair<string, string>? GetSelectedStation()
        {
            KeyValuePair<string, string>? selectedStation = null;
            InvokeOnUiThread(() =>
            {
                selectedStation = (KeyValuePair<string, string>?)comboBoxStations.SelectedItem;
            });
            return selectedStation;
        }

        private async Task<string> GetCurrentlyPlayingSongAsync(string segmentName)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string jsonResponse = await client.GetStringAsync(apiUrl);
                    var data = JObject.Parse(jsonResponse);
                    var channel = data.Properties().FirstOrDefault(p => p.Value["segmentname"].ToString() == segmentName);
                    if (channel != null)
                    {
                        var artist = channel.Value["artist"].ToString();
                        var title = channel.Value["title"].ToString();
                        var coverUrl = "https://ilovemusic.de" + channel.Value["cover"].ToString();
                        UpdateCoverImage(coverUrl);
                        Console.WriteLine($"Current song: {artist} - {title}");
                        return $"{artist} - {title}";
                    }
                    return "Unknown Song";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching song data: " + ex.Message);
                return "Unknown Song";
            }
        }

        private async Task UpdateCurrentSongInfo()
        {
            var selectedStation = GetSelectedStation();
            if (selectedStation.HasValue)
            {
                var songInfo = await GetCurrentlyPlayingSongAsync(segmentNameMapping[selectedStation.Value.Key]);
                InvokeOnUiThread(() =>
                {
                    currentPlaying.Text = songInfo;
                });
            }
            else
            {
                InvokeOnUiThread(() =>
                {
                    currentPlaying.Text = "Stopped";
                    pictureBox1.Image = ILM.Properties.Resources.ilmlogo;
                });
            }
        }

        private async void UpdateCoverImage(string coverUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var response = await client.GetAsync(coverUrl);
                    response.EnsureSuccessStatusCode();
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    {
                        var image = Image.FromStream(stream);
                        InvokeOnUiThread(() =>
                        {
                            pictureBox1.Image = image;
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                InvokeOnUiThread(() =>
                {
                    pictureBox1.Image = ILM.Properties.Resources.ilmlogo;
                });
                MessageBox.Show("Error fetching cover image: " + ex.Message);
            }
        }

        private void SetApplicationVolume(string exeName, float volume)
        {
            var process = Process.GetProcessesByName(exeName).FirstOrDefault();
            if (process != null)
            {
                var volumeManager = new AudioManager();
                volumeManager.SetApplicationVolume(process.Id, volume * 100); 
            }
        }

        private void InvokeOnUiThread(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(action);
            }
            else
            {
                action();
            }
        }

        private void CurrentPlaying_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentPlaying.Text) && currentPlaying.Text != "Stopped")
            {
                Clipboard.SetText(currentPlaying.Text);
                MessageBox.Show("Song info copied to clipboard.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void VersionLabel_Click(object sender, EventArgs e)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string onlineVersion = await client.GetStringAsync(versionUrl);
                    if (onlineVersion.Trim() != currentVersion)
                    {
                        var result = MessageBox.Show("A new version is available. Do you want to be redirected to github?", "New Version Available", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            Process.Start(new ProcessStartInfo
                            {
                                FileName = "https://github.com/wiesty/ILM/releases",
                                UseShellExecute = true
                            });
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are using the latest version.", "No New Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error checking for version: " + ex.Message);
            }
        }
    }

    public class AudioManager
    {
        public void SetApplicationVolume(int pid, float volume)
        {
            var deviceEnumerator = new MMDeviceEnumerator();
            var defaultDevice = deviceEnumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            var sessions = defaultDevice.AudioSessionManager.Sessions;

            for (int i = 0; i < sessions.Count; i++)
            {
                var session = sessions[i];
                if ((int)session.GetProcessID == pid)
                {
                    session.SimpleAudioVolume.Volume = volume / 100f;
                }
            }
        }
    }
}
