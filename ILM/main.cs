using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AxWMPLib;
using MetroFramework.Forms;

namespace ILM
{
    public partial class main : MetroForm
    {
        public main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadRadioStationsFromWebsite();
            comboBoxStations.DisplayMember = "Key";
            comboBoxStations.ValueMember = "Value";

            this.metroTrackBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBar1_Scroll);
            wmpPlayer.PlayStateChange += WmpPlayer_PlayStateChange;
        }

        private void LoadRadioStationsFromWebsite()
        {
            string url = "https://ilovemusic.de/streams/";
            WebClient client = new WebClient();
            try
            {
                string htmlCode = client.DownloadString(url);
                // Console.WriteLine(htmlCode);
                Dictionary<string, string> radioStations = ExtractRadioStations(htmlCode);
                // Console.WriteLine(radioStations);
                foreach (var station in radioStations)
                {
                    comboBoxStations.Items.Add(station);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fehler beim Herunterladen der Radiosender: " + ex.Message);
            }
        }

        private Dictionary<string, string> ExtractRadioStations(string htmlCode)
        {
            Dictionary<string, string> radioStations = new Dictionary<string, string>();

            string pattern = @"<a\s+href=""([^""]+\.m3u)""[^>]*>([^<]+)</a>";

            MatchCollection matches = Regex.Matches(htmlCode, pattern);

            foreach (Match match in matches)
            {
                string name = System.IO.Path.GetFileNameWithoutExtension(match.Groups[1].Value);
                name = name.Replace("ilove", "I ♥ ");
                string url = match.Groups[1].Value.Trim();
                radioStations[name] = url;
            }

            return radioStations;
        }



        private void buttonPlay_Click_1(object sender, EventArgs e)
        {
            if (buttonPlay.Text == "switch channel")
            {
                var selectedStation = (KeyValuePair<string, string>)comboBoxStations.SelectedItem;
                wmpPlayer.URL = selectedStation.Value;
                wmpPlayer.Ctlcontrols.play();
            }

            if (wmpPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying) 
            {
                wmpPlayer.Ctlcontrols.stop();
                buttonPlay.Text = "Play"; 
            }
            else 
            {
                if (comboBoxStations.SelectedItem != null)
                {
                    var selectedStation = (KeyValuePair<string, string>)comboBoxStations.SelectedItem;
                    wmpPlayer.URL = selectedStation.Value; 
                    wmpPlayer.Ctlcontrols.play(); 
                    buttonPlay.Text = "Stop";
                }
                else
                {
                    MessageBox.Show("Bitte wählen Sie einen Radiosender aus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void WmpPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            // Wenn der Player den Status "Wiedergabe" erreicht, ändere den Text des Buttons auf "Stop"
            if (wmpPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                buttonPlay.Text = "Stop";
            }
            // Wenn der Player aufhört zu spielen, ändere den Text des Buttons zurück auf "Play"
            else if (wmpPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                buttonPlay.Text = "Play";
            }
        }


        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            wmpPlayer.settings.volume = metroTrackBar1.Value;
        }

        private void comboBoxStations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (wmpPlayer.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                buttonPlay.Text = "switch channel";
            }
            else
            {
                if (comboBoxStations.SelectedItem != null)
                {
                    buttonPlay.Text = "Play";
                }
                else
                {
                    MessageBox.Show("Bitte wählen Sie einen Radiosender aus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
