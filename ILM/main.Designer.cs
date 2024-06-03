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
            this.wmpPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.metroTrackBar1 = new MetroFramework.Controls.MetroTrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.wmpPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonPlay
            // 
            this.buttonPlay.Location = new System.Drawing.Point(23, 150);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Size = new System.Drawing.Size(182, 23);
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
            this.comboBoxStations.Size = new System.Drawing.Size(182, 29);
            this.comboBoxStations.Style = MetroFramework.MetroColorStyle.Black;
            this.comboBoxStations.TabIndex = 2;
            this.comboBoxStations.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.comboBoxStations.UseSelectable = true;
            this.comboBoxStations.SelectedIndexChanged += new System.EventHandler(this.comboBoxStations_SelectedIndexChanged);
            // 
            // wmpPlayer
            // 
            this.wmpPlayer.Enabled = true;
            this.wmpPlayer.Location = new System.Drawing.Point(354, 195);
            this.wmpPlayer.Name = "wmpPlayer";
            this.wmpPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("wmpPlayer.OcxState")));
            this.wmpPlayer.Size = new System.Drawing.Size(10, 10);
            this.wmpPlayer.TabIndex = 3;
            // 
            // metroTrackBar1
            // 
            this.metroTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.metroTrackBar1.Location = new System.Drawing.Point(23, 109);
            this.metroTrackBar1.Name = "metroTrackBar1";
            this.metroTrackBar1.Size = new System.Drawing.Size(182, 23);
            this.metroTrackBar1.TabIndex = 6;
            this.metroTrackBar1.Text = "metroTrackBar1";
            this.metroTrackBar1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTrackBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.metroTrackBar1_Scroll);
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 201);
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
            ((System.ComponentModel.ISupportInitialize)(this.wmpPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton buttonPlay;
        private MetroFramework.Controls.MetroComboBox comboBoxStations;
        private AxWMPLib.AxWindowsMediaPlayer wmpPlayer;
        private MetroFramework.Controls.MetroTrackBar metroTrackBar1;
    }
}

