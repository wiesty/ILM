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
            this.wmpPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.version = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.wmpPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(31, 215);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(4);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(243, 28);
            this.buttonPlay.TabIndex = 0;
            this.buttonPlay.Text = "Play/Stop";
            this.buttonPlay.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonPlay.UseSelectable = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click_1);
            // 
            // comboBoxStations
            // 
            this.comboBoxStations.FormattingEnabled = true;
            this.comboBoxStations.ItemHeight = 24;
            this.comboBoxStations.Location = new System.Drawing.Point(31, 78);
            this.comboBoxStations.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxStations.Name = "comboBoxStations";
            this.comboBoxStations.Size = new System.Drawing.Size(241, 30);
            this.comboBoxStations.Style = MetroFramework.MetroColorStyle.Black;
            this.comboBoxStations.TabIndex = 2;
            this.comboBoxStations.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.comboBoxStations.UseSelectable = true;
            this.comboBoxStations.SelectedIndexChanged += new System.EventHandler(this.comboBoxStations_SelectedIndexChanged);
            // 
            // metroTrackBar1
            // 
            this.metroTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar1.Location = new System.Drawing.Point(31, 134);
            this.metroTrackBar1.Margin = new System.Windows.Forms.Padding(4);
            this.metroTrackBar1.Name = "metroTrackBar1";
            this.metroTrackBar1.Size = new System.Drawing.Size(243, 28);
            this.metroTrackBar1.TabIndex = 6;
            this.metroTrackBar1.Text = "metroTrackBar1";
            this.metroTrackBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTrackBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBar1_Scroll);
            // 
            // metroCheckBox1
            // 
            this.metroCheckBox1.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.metroCheckBox1.Location = new System.Drawing.Point(31, 169);
            this.metroCheckBox1.Name = "metroCheckBox1";
            this.metroCheckBox1.Size = new System.Drawing.Size(183, 29);
            this.metroCheckBox1.TabIndex = 7;
            this.metroCheckBox1.Text = "Volumefix";
            this.metroCheckBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroCheckBox1.UseSelectable = true;
            this.metroCheckBox1.CheckedChanged += new System.EventHandler(this.metroCheckBox1_CheckedChanged);
            // 
            // wmpPlayer
            // 
            this.wmpPlayer.Enabled = true;
            this.wmpPlayer.Location = new System.Drawing.Point(346, 20);
            this.wmpPlayer.Margin = new System.Windows.Forms.Padding(4);
            this.wmpPlayer.Name = "wmpPlayer";
            this.wmpPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpPlayer.OcxState")));
            this.wmpPlayer.Size = new System.Drawing.Size(10, 10);
            this.wmpPlayer.TabIndex = 3;
            // 
            // version
            // 
            this.version.Location = new System.Drawing.Point(31, 264);
            this.version.Name = "version";
            this.version.Size = new System.Drawing.Size(241, 20);
            this.version.TabIndex = 8;
            this.version.Text = "V. 2.0.0";
            this.version.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.version.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 299);
            this.Controls.Add(this.version);
            this.Controls.Add(this.metroCheckBox1);
            this.Controls.Add(this.metroTrackBar1);
            this.Controls.Add(this.wmpPlayer);
            this.Controls.Add(this.comboBoxStations);
            this.Controls.Add(this.buttonPlay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "main";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.White;
            this.Text = "ILM";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wmpPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton buttonPlay;
        private MetroFramework.Controls.MetroComboBox comboBoxStations;
        private AxWMPLib.AxWindowsMediaPlayer wmpPlayer;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar1;
        private MetroFramework.Controls.MetroCheckBox metroCheckBox1;
        private MetroFramework.Controls.MetroLabel version;
    }
}

