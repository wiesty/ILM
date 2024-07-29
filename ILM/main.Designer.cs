namespace ILM
{
    partial class main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.buttonPlay = new MetroFramework.Controls.MetroButton();
            this.comboBoxStations = new MetroFramework.Controls.MetroComboBox();
            this.metroTrackBar1 = new MetroFramework.Controls.MetroTrackBar();
            this.metroCheckBox1 = new MetroFramework.Controls.MetroCheckBox();
            this.VersionLabel = new MetroFramework.Controls.MetroLabel();
            this.currentPlaying = new MetroFramework.Controls.MetroLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.wmpPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(23, 179);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(242, 29);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play/Stop";
            this.buttonPlay.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonPlay.UseSelectable = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click_1);
            // 
            // comboBoxStations
            // 
            this.comboBoxStations.FormattingEnabled = true;
            this.comboBoxStations.ItemHeight = 23;
            this.comboBoxStations.Location = new System.Drawing.Point(23, 63);
            this.comboBoxStations.Name = "comboBoxStations";
            this.comboBoxStations.Size = new System.Drawing.Size(242, 29);
            this.comboBoxStations.Style = MetroFramework.MetroColorStyle.Black;
            this.comboBoxStations.TabIndex = 2;
            this.comboBoxStations.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.comboBoxStations.UseSelectable = true;
            this.comboBoxStations.SelectedIndexChanged += new System.EventHandler(this.comboBoxStations_SelectedIndexChanged);
            // 
            // metroTrackBar1
            // 
            this.metroTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar1.Location = new System.Drawing.Point(23, 137);
            this.metroTrackBar1.Name = "metroTrackBar1";
            this.metroTrackBar1.Size = new System.Drawing.Size(242, 23);
            this.metroTrackBar1.TabIndex = 6;
            this.metroTrackBar1.Text = "metroTrackBar1";
            this.metroTrackBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTrackBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBar1_Scroll);
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox1.Location = new System.Drawing.Point(288, 228);
            this.metroCheckBox1.Margin = new System.Windows.Forms.Padding(2);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(140, 24);
            this.metroCheckBox1.TabIndex = 7;
            this.metroCheckBox1.Text = "Background Mode";
            this.metroCheckBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBox1.UseSelectable = true;
            this.metroCheckBox1.CheckedChanged += new System.EventHandler(this.metroCheckBox1_CheckedChanged);
            // 
            // VersionLabel
            // 
            this.VersionLabel.Location = new System.Drawing.Point(23, 228);
            this.VersionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(82, 24);
            this.VersionLabel.TabIndex = 8;
            this.VersionLabel.Text = "V. 2.0.0";
            this.VersionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VersionLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // currentPlaying
            // 
            this.currentPlaying.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.currentPlaying.Location = new System.Drawing.Point(23, 108);
            this.currentPlaying.Margin = new System.Windows.Forms.Padding(0);
            this.currentPlaying.Name = "currentPlaying";
            this.currentPlaying.Size = new System.Drawing.Size(242, 23);
            this.currentPlaying.TabIndex = 9;
            this.currentPlaying.Text = "Please select a channel";
            this.currentPlaying.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.currentPlaying.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ILM.Properties.Resources.ilmlogo;
            this.pictureBox1.Location = new System.Drawing.Point(283, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(145, 145);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // wmpPlayer
            // 
            this.wmpPlayer.Enabled = true;
            this.wmpPlayer.Location = new System.Drawing.Point(23, 400);
            this.wmpPlayer.Name = "wmpPlayer";
            this.wmpPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpPlayer.OcxState")));
            this.wmpPlayer.Size = new System.Drawing.Size(10, 10);
            this.wmpPlayer.TabIndex = 3;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 268);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.currentPlaying);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.metroTrackBar1);
            this.Controls.Add(this.wmpPlayer);
            this.Controls.Add(this.comboBoxStations);
            this.Controls.Add(this.buttonPlay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "main";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "ILM";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wmpPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton buttonPlay;
        private MetroFramework.Controls.MetroComboBox comboBoxStations;
        private AxWMPLib.AxWindowsMediaPlayer wmpPlayer;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar1;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroLabel VersionLabel;
        private MetroFramework.Controls.MetroLabel currentPlaying;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

