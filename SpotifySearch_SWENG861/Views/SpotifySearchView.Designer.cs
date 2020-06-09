namespace SpotifySearch_SWENG861.Views
{
    partial class SpotifySearchView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpotifySearchView));
            this.flwSearchResultsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlSpotifySearch = new System.Windows.Forms.Panel();
            this.rtxtImportExportLocation = new System.Windows.Forms.RichTextBox();
            this.btnOptions = new System.Windows.Forms.Button();
            this.btnExportSearch = new System.Windows.Forms.Button();
            this.btnImportSearch = new System.Windows.Forms.Button();
            this.cbxMaxSearch = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rbtnArtistSearch = new System.Windows.Forms.RadioButton();
            this.rbtnSongSearch = new System.Windows.Forms.RadioButton();
            this.rtxtArtistSongEntry = new System.Windows.Forms.RichTextBox();
            this.lblSearchType = new System.Windows.Forms.Label();
            this.lblArtistSongEntry = new System.Windows.Forms.Label();
            this.lblMaxSearch = new System.Windows.Forms.Label();
            this.lblAppHeader = new System.Windows.Forms.Label();
            this.btnImportDirectory = new System.Windows.Forms.Button();
            this.lblImportExport = new System.Windows.Forms.Label();
            this.pnlSpotifySearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // flwSearchResultsFlowPanel
            // 
            this.flwSearchResultsFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flwSearchResultsFlowPanel.AutoScroll = true;
            this.flwSearchResultsFlowPanel.Location = new System.Drawing.Point(370, 0);
            this.flwSearchResultsFlowPanel.Name = "flwSearchResultsFlowPanel";
            this.flwSearchResultsFlowPanel.Size = new System.Drawing.Size(1123, 918);
            this.flwSearchResultsFlowPanel.TabIndex = 2;
            // 
            // pnlSpotifySearch
            // 
            this.pnlSpotifySearch.BackColor = System.Drawing.Color.Teal;
            this.pnlSpotifySearch.Controls.Add(this.lblImportExport);
            this.pnlSpotifySearch.Controls.Add(this.btnImportDirectory);
            this.pnlSpotifySearch.Controls.Add(this.rtxtImportExportLocation);
            this.pnlSpotifySearch.Controls.Add(this.btnOptions);
            this.pnlSpotifySearch.Controls.Add(this.btnExportSearch);
            this.pnlSpotifySearch.Controls.Add(this.btnImportSearch);
            this.pnlSpotifySearch.Controls.Add(this.cbxMaxSearch);
            this.pnlSpotifySearch.Controls.Add(this.btnSearch);
            this.pnlSpotifySearch.Controls.Add(this.rbtnArtistSearch);
            this.pnlSpotifySearch.Controls.Add(this.rbtnSongSearch);
            this.pnlSpotifySearch.Controls.Add(this.rtxtArtistSongEntry);
            this.pnlSpotifySearch.Controls.Add(this.lblSearchType);
            this.pnlSpotifySearch.Controls.Add(this.lblArtistSongEntry);
            this.pnlSpotifySearch.Controls.Add(this.lblMaxSearch);
            this.pnlSpotifySearch.Controls.Add(this.lblAppHeader);
            this.pnlSpotifySearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSpotifySearch.Location = new System.Drawing.Point(0, 0);
            this.pnlSpotifySearch.Name = "pnlSpotifySearch";
            this.pnlSpotifySearch.Size = new System.Drawing.Size(364, 918);
            this.pnlSpotifySearch.TabIndex = 3;
            // 
            // rtxtImportExportLocation
            // 
            this.rtxtImportExportLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtImportExportLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtImportExportLocation.Location = new System.Drawing.Point(12, 597);
            this.rtxtImportExportLocation.Name = "rtxtImportExportLocation";
            this.rtxtImportExportLocation.Size = new System.Drawing.Size(265, 59);
            this.rtxtImportExportLocation.TabIndex = 14;
            this.rtxtImportExportLocation.Text = "";
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptions.ForeColor = System.Drawing.Color.Black;
            this.btnOptions.Location = new System.Drawing.Point(184, 678);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(160, 110);
            this.btnOptions.TabIndex = 13;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOfflineMode_Click);
            // 
            // btnExportSearch
            // 
            this.btnExportSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportSearch.ForeColor = System.Drawing.Color.Black;
            this.btnExportSearch.Location = new System.Drawing.Point(12, 799);
            this.btnExportSearch.Name = "btnExportSearch";
            this.btnExportSearch.Size = new System.Drawing.Size(160, 110);
            this.btnExportSearch.TabIndex = 12;
            this.btnExportSearch.Text = "Export Search";
            this.btnExportSearch.UseVisualStyleBackColor = true;
            // 
            // btnImportSearch
            // 
            this.btnImportSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportSearch.ForeColor = System.Drawing.Color.Black;
            this.btnImportSearch.Location = new System.Drawing.Point(12, 678);
            this.btnImportSearch.Name = "btnImportSearch";
            this.btnImportSearch.Size = new System.Drawing.Size(160, 110);
            this.btnImportSearch.TabIndex = 11;
            this.btnImportSearch.Text = "Import Search";
            this.btnImportSearch.UseVisualStyleBackColor = true;
            // 
            // cbxMaxSearch
            // 
            this.cbxMaxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMaxSearch.FormattingEnabled = true;
            this.cbxMaxSearch.Location = new System.Drawing.Point(19, 482);
            this.cbxMaxSearch.Name = "cbxMaxSearch";
            this.cbxMaxSearch.Size = new System.Drawing.Size(182, 47);
            this.cbxMaxSearch.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(184, 799);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(160, 110);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "Spotify Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // rbtnArtistSearch
            // 
            this.rbtnArtistSearch.AutoSize = true;
            this.rbtnArtistSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnArtistSearch.ForeColor = System.Drawing.Color.White;
            this.rbtnArtistSearch.Location = new System.Drawing.Point(29, 208);
            this.rbtnArtistSearch.Name = "rbtnArtistSearch";
            this.rbtnArtistSearch.Size = new System.Drawing.Size(160, 29);
            this.rbtnArtistSearch.TabIndex = 9;
            this.rbtnArtistSearch.TabStop = true;
            this.rbtnArtistSearch.Text = "Artist Search";
            this.rbtnArtistSearch.UseVisualStyleBackColor = true;
            // 
            // rbtnSongSearch
            // 
            this.rbtnSongSearch.AutoSize = true;
            this.rbtnSongSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSongSearch.ForeColor = System.Drawing.Color.White;
            this.rbtnSongSearch.Location = new System.Drawing.Point(29, 243);
            this.rbtnSongSearch.Name = "rbtnSongSearch";
            this.rbtnSongSearch.Size = new System.Drawing.Size(161, 29);
            this.rbtnSongSearch.TabIndex = 8;
            this.rbtnSongSearch.TabStop = true;
            this.rbtnSongSearch.Text = "Song Search";
            this.rbtnSongSearch.UseVisualStyleBackColor = true;
            // 
            // rtxtArtistSongEntry
            // 
            this.rtxtArtistSongEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtArtistSongEntry.Location = new System.Drawing.Point(19, 346);
            this.rtxtArtistSongEntry.Name = "rtxtArtistSongEntry";
            this.rtxtArtistSongEntry.Size = new System.Drawing.Size(328, 59);
            this.rtxtArtistSongEntry.TabIndex = 6;
            this.rtxtArtistSongEntry.Text = "";
            this.rtxtArtistSongEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArtistSongEntry_KeyDown);
            // 
            // lblSearchType
            // 
            this.lblSearchType.AutoSize = true;
            this.lblSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchType.ForeColor = System.Drawing.Color.White;
            this.lblSearchType.Location = new System.Drawing.Point(14, 162);
            this.lblSearchType.Name = "lblSearchType";
            this.lblSearchType.Size = new System.Drawing.Size(158, 30);
            this.lblSearchType.TabIndex = 4;
            this.lblSearchType.Text = "Search Type";
            // 
            // lblArtistSongEntry
            // 
            this.lblArtistSongEntry.AutoSize = true;
            this.lblArtistSongEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArtistSongEntry.ForeColor = System.Drawing.Color.White;
            this.lblArtistSongEntry.Location = new System.Drawing.Point(14, 299);
            this.lblArtistSongEntry.Name = "lblArtistSongEntry";
            this.lblArtistSongEntry.Size = new System.Drawing.Size(205, 30);
            this.lblArtistSongEntry.TabIndex = 3;
            this.lblArtistSongEntry.Text = "Artist/Song Entry";
            // 
            // lblMaxSearch
            // 
            this.lblMaxSearch.AutoSize = true;
            this.lblMaxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxSearch.ForeColor = System.Drawing.Color.White;
            this.lblMaxSearch.Location = new System.Drawing.Point(14, 429);
            this.lblMaxSearch.Name = "lblMaxSearch";
            this.lblMaxSearch.Size = new System.Drawing.Size(293, 30);
            this.lblMaxSearch.TabIndex = 2;
            this.lblMaxSearch.Text = "Max Search #: (up to 50)";
            // 
            // lblAppHeader
            // 
            this.lblAppHeader.AutoSize = true;
            this.lblAppHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppHeader.ForeColor = System.Drawing.Color.White;
            this.lblAppHeader.Location = new System.Drawing.Point(12, 84);
            this.lblAppHeader.Name = "lblAppHeader";
            this.lblAppHeader.Size = new System.Drawing.Size(243, 39);
            this.lblAppHeader.TabIndex = 0;
            this.lblAppHeader.Text = "Spotify Search";
            // 
            // btnImportDirectory
            // 
            this.btnImportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportDirectory.ForeColor = System.Drawing.Color.Black;
            this.btnImportDirectory.Location = new System.Drawing.Point(286, 597);
            this.btnImportDirectory.Name = "btnImportDirectory";
            this.btnImportDirectory.Size = new System.Drawing.Size(61, 59);
            this.btnImportDirectory.TabIndex = 15;
            this.btnImportDirectory.Text = "...";
            this.btnImportDirectory.UseVisualStyleBackColor = true;
            // 
            // lblImportExport
            // 
            this.lblImportExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImportExport.AutoSize = true;
            this.lblImportExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImportExport.ForeColor = System.Drawing.Color.White;
            this.lblImportExport.Location = new System.Drawing.Point(11, 553);
            this.lblImportExport.Name = "lblImportExport";
            this.lblImportExport.Size = new System.Drawing.Size(290, 30);
            this.lblImportExport.TabIndex = 16;
            this.lblImportExport.Text = "Import / Export Directory";
            // 
            // SpotifySearchView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1505, 918);
            this.Controls.Add(this.pnlSpotifySearch);
            this.Controls.Add(this.flwSearchResultsFlowPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpotifySearchView";
            this.Text = "Spotify Search";
            this.Load += new System.EventHandler(this.SpotifySearchView_Load);
            this.pnlSpotifySearch.ResumeLayout(false);
            this.pnlSpotifySearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel flwSearchResultsFlowPanel;
        private System.Windows.Forms.Panel pnlSpotifySearch;
        private System.Windows.Forms.Label lblAppHeader;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RadioButton rbtnArtistSearch;
        private System.Windows.Forms.RadioButton rbtnSongSearch;
        private System.Windows.Forms.RichTextBox rtxtArtistSongEntry;
        private System.Windows.Forms.Label lblSearchType;
        private System.Windows.Forms.Label lblArtistSongEntry;
        private System.Windows.Forms.Label lblMaxSearch;
        private System.Windows.Forms.ComboBox cbxMaxSearch;
        private System.Windows.Forms.Button btnExportSearch;
        private System.Windows.Forms.Button btnImportSearch;
        private System.Windows.Forms.Button btnOptions;
        private System.Windows.Forms.RichTextBox rtxtImportExportLocation;
        private System.Windows.Forms.Button btnImportDirectory;
        private System.Windows.Forms.Label lblImportExport;
    }
}

