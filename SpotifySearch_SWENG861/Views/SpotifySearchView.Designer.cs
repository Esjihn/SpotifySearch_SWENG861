﻿namespace SpotifySearch_SWENG861.Views
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
            this.lblExport = new System.Windows.Forms.Label();
            this.btnImportDirectory = new System.Windows.Forms.Button();
            this.rtxtExportLocation = new System.Windows.Forms.RichTextBox();
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
            this.fldrBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.fileBrowserDialog = new System.Windows.Forms.OpenFileDialog();
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
            this.flwSearchResultsFlowPanel.Margin = new System.Windows.Forms.Padding(4);
            this.flwSearchResultsFlowPanel.Name = "flwSearchResultsFlowPanel";
            this.flwSearchResultsFlowPanel.Size = new System.Drawing.Size(1131, 918);
            this.flwSearchResultsFlowPanel.TabIndex = 2;
            // 
            // pnlSpotifySearch
            // 
            this.pnlSpotifySearch.BackColor = System.Drawing.Color.Teal;
            this.pnlSpotifySearch.Controls.Add(this.lblExport);
            this.pnlSpotifySearch.Controls.Add(this.btnImportDirectory);
            this.pnlSpotifySearch.Controls.Add(this.rtxtExportLocation);
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
            this.pnlSpotifySearch.Margin = new System.Windows.Forms.Padding(4);
            this.pnlSpotifySearch.Name = "pnlSpotifySearch";
            this.pnlSpotifySearch.Size = new System.Drawing.Size(365, 918);
            this.pnlSpotifySearch.TabIndex = 3;
            // 
            // lblExport
            // 
            this.lblExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblExport.AutoSize = true;
            this.lblExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExport.ForeColor = System.Drawing.Color.White;
            this.lblExport.Location = new System.Drawing.Point(11, 554);
            this.lblExport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExport.Name = "lblExport";
            this.lblExport.Size = new System.Drawing.Size(197, 30);
            this.lblExport.TabIndex = 16;
            this.lblExport.Text = "Export Directory";
            // 
            // btnImportDirectory
            // 
            this.btnImportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportDirectory.ForeColor = System.Drawing.Color.Black;
            this.btnImportDirectory.Location = new System.Drawing.Point(286, 596);
            this.btnImportDirectory.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportDirectory.Name = "btnImportDirectory";
            this.btnImportDirectory.Size = new System.Drawing.Size(61, 59);
            this.btnImportDirectory.TabIndex = 15;
            this.btnImportDirectory.Text = "...";
            this.btnImportDirectory.UseVisualStyleBackColor = true;
            this.btnImportDirectory.Click += new System.EventHandler(this.btnImportDirectory_Click);
            // 
            // rtxtExportLocation
            // 
            this.rtxtExportLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtExportLocation.BackColor = System.Drawing.Color.Gray;
            this.rtxtExportLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtExportLocation.Location = new System.Drawing.Point(13, 596);
            this.rtxtExportLocation.Margin = new System.Windows.Forms.Padding(4);
            this.rtxtExportLocation.Multiline = false;
            this.rtxtExportLocation.Name = "rtxtExportLocation";
            this.rtxtExportLocation.Size = new System.Drawing.Size(264, 59);
            this.rtxtExportLocation.TabIndex = 14;
            this.rtxtExportLocation.Text = "";
            this.rtxtExportLocation.TextChanged += new System.EventHandler(this.rtxtImportExportLocation_TextChanged);
            // 
            // btnOptions
            // 
            this.btnOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOptions.ForeColor = System.Drawing.Color.Black;
            this.btnOptions.Location = new System.Drawing.Point(183, 678);
            this.btnOptions.Margin = new System.Windows.Forms.Padding(4);
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(160, 111);
            this.btnOptions.TabIndex = 13;
            this.btnOptions.Text = "Options";
            this.btnOptions.UseVisualStyleBackColor = true;
            this.btnOptions.Click += new System.EventHandler(this.btnOptions_Click);
            // 
            // btnExportSearch
            // 
            this.btnExportSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportSearch.ForeColor = System.Drawing.Color.Black;
            this.btnExportSearch.Location = new System.Drawing.Point(13, 799);
            this.btnExportSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportSearch.Name = "btnExportSearch";
            this.btnExportSearch.Size = new System.Drawing.Size(160, 111);
            this.btnExportSearch.TabIndex = 12;
            this.btnExportSearch.Text = "Export Search";
            this.btnExportSearch.UseVisualStyleBackColor = true;
            this.btnExportSearch.Click += new System.EventHandler(this.btnExportSearch_Click);
            // 
            // btnImportSearch
            // 
            this.btnImportSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportSearch.ForeColor = System.Drawing.Color.Black;
            this.btnImportSearch.Location = new System.Drawing.Point(13, 678);
            this.btnImportSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnImportSearch.Name = "btnImportSearch";
            this.btnImportSearch.Size = new System.Drawing.Size(160, 111);
            this.btnImportSearch.TabIndex = 11;
            this.btnImportSearch.Text = "Import Search";
            this.btnImportSearch.UseVisualStyleBackColor = true;
            this.btnImportSearch.Click += new System.EventHandler(this.btnImportSearch_Click);
            // 
            // cbxMaxSearch
            // 
            this.cbxMaxSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMaxSearch.FormattingEnabled = true;
            this.cbxMaxSearch.Location = new System.Drawing.Point(15, 482);
            this.cbxMaxSearch.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMaxSearch.Name = "cbxMaxSearch";
            this.cbxMaxSearch.Size = new System.Drawing.Size(182, 47);
            this.cbxMaxSearch.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.Black;
            this.btnSearch.Location = new System.Drawing.Point(183, 799);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(160, 111);
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
            this.rbtnArtistSearch.Location = new System.Drawing.Point(29, 209);
            this.rbtnArtistSearch.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnArtistSearch.Name = "rbtnArtistSearch";
            this.rbtnArtistSearch.Size = new System.Drawing.Size(160, 29);
            this.rbtnArtistSearch.TabIndex = 9;
            this.rbtnArtistSearch.TabStop = true;
            this.rbtnArtistSearch.Text = "Artist Search";
            this.rbtnArtistSearch.UseVisualStyleBackColor = true;
            this.rbtnArtistSearch.CheckedChanged += new System.EventHandler(this.rbtnArtistSearch_CheckedChanged);
            // 
            // rbtnSongSearch
            // 
            this.rbtnSongSearch.AutoSize = true;
            this.rbtnSongSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnSongSearch.ForeColor = System.Drawing.Color.White;
            this.rbtnSongSearch.Location = new System.Drawing.Point(29, 244);
            this.rbtnSongSearch.Margin = new System.Windows.Forms.Padding(4);
            this.rbtnSongSearch.Name = "rbtnSongSearch";
            this.rbtnSongSearch.Size = new System.Drawing.Size(161, 29);
            this.rbtnSongSearch.TabIndex = 8;
            this.rbtnSongSearch.TabStop = true;
            this.rbtnSongSearch.Text = "Song Search";
            this.rbtnSongSearch.UseVisualStyleBackColor = true;
            this.rbtnSongSearch.CheckedChanged += new System.EventHandler(this.rbtnSongSearch_CheckedChanged);
            // 
            // rtxtArtistSongEntry
            // 
            this.rtxtArtistSongEntry.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtArtistSongEntry.Location = new System.Drawing.Point(15, 345);
            this.rtxtArtistSongEntry.Margin = new System.Windows.Forms.Padding(4);
            this.rtxtArtistSongEntry.MaxLength = 27;
            this.rtxtArtistSongEntry.Name = "rtxtArtistSongEntry";
            this.rtxtArtistSongEntry.Size = new System.Drawing.Size(329, 59);
            this.rtxtArtistSongEntry.TabIndex = 6;
            this.rtxtArtistSongEntry.Text = "";
            this.rtxtArtistSongEntry.TextChanged += new System.EventHandler(this.rtxtArtistSongEntry_TextChanged);
            this.rtxtArtistSongEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtArtistSongEntry_KeyDown);
            this.rtxtArtistSongEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtxtArtistSongEntry_KeyPress);
            // 
            // lblSearchType
            // 
            this.lblSearchType.AutoSize = true;
            this.lblSearchType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchType.ForeColor = System.Drawing.Color.White;
            this.lblSearchType.Location = new System.Drawing.Point(15, 162);
            this.lblSearchType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.lblArtistSongEntry.Location = new System.Drawing.Point(9, 299);
            this.lblArtistSongEntry.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.lblMaxSearch.Location = new System.Drawing.Point(9, 428);
            this.lblMaxSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.lblAppHeader.Location = new System.Drawing.Point(13, 85);
            this.lblAppHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppHeader.Name = "lblAppHeader";
            this.lblAppHeader.Size = new System.Drawing.Size(243, 39);
            this.lblAppHeader.TabIndex = 0;
            this.lblAppHeader.Text = "Spotify Search";
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
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SpotifySearchView";
            this.Text = "Spotify Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SpotifySearchView_FormClosing);
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
        private System.Windows.Forms.RichTextBox rtxtExportLocation;
        private System.Windows.Forms.Button btnImportDirectory;
        private System.Windows.Forms.Label lblExport;
        private System.Windows.Forms.FolderBrowserDialog fldrBrowserDialog;
        private System.Windows.Forms.OpenFileDialog fileBrowserDialog;
    }
}

