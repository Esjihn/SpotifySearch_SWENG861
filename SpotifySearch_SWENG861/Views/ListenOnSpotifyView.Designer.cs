namespace SpotifySearch_SWENG861.Views
{
    partial class ListenOnSpotifyView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webListenOnSpotify = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webListenOnSpotify
            // 
            this.webListenOnSpotify.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webListenOnSpotify.Location = new System.Drawing.Point(0, 0);
            this.webListenOnSpotify.MinimumSize = new System.Drawing.Size(20, 20);
            this.webListenOnSpotify.Name = "webListenOnSpotify";
            this.webListenOnSpotify.Size = new System.Drawing.Size(667, 304);
            this.webListenOnSpotify.TabIndex = 0;
            // 
            // ListenOnSpotifyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(667, 304);
            this.Controls.Add(this.webListenOnSpotify);
            this.Name = "ListenOnSpotifyView";
            this.Text = "ListenOnSpotifyView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webListenOnSpotify;
    }
}