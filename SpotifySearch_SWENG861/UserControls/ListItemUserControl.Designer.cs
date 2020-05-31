namespace SpotifySearch_SWENG861
{
    partial class UcSearchResultItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picListenOnSpotify = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.pnlListenOnSpotify = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblDoubleClick = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picListenOnSpotify)).BeginInit();
            this.pnlListenOnSpotify.SuspendLayout();
            this.SuspendLayout();
            // 
            // picListenOnSpotify
            // 
            this.picListenOnSpotify.Location = new System.Drawing.Point(22, 37);
            this.picListenOnSpotify.Name = "picListenOnSpotify";
            this.picListenOnSpotify.Size = new System.Drawing.Size(188, 152);
            this.picListenOnSpotify.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picListenOnSpotify.TabIndex = 0;
            this.picListenOnSpotify.TabStop = false;
            this.picListenOnSpotify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.picListenOnSpotify_MouseDoubleClick);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(245, 31);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(788, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Title";
            this.lblTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseClick);
            this.lblTitle.MouseEnter += new System.EventHandler(this.lblTitle_MouseEnter);
            this.lblTitle.MouseLeave += new System.EventHandler(this.lblTitle_MouseLeave);
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(273, 75);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(760, 132);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "Lorem ipsum - some text here";
            this.lblMessage.Click += new System.EventHandler(this.lblMessage_Click);
            this.lblMessage.MouseEnter += new System.EventHandler(this.lblMessage_MouseEnter);
            this.lblMessage.MouseLeave += new System.EventHandler(this.lblMessage_MouseLeave);
            // 
            // pnlListenOnSpotify
            // 
            this.pnlListenOnSpotify.BackColor = System.Drawing.Color.Teal;
            this.pnlListenOnSpotify.Controls.Add(this.lblDoubleClick);
            this.pnlListenOnSpotify.Controls.Add(this.picListenOnSpotify);
            this.pnlListenOnSpotify.Location = new System.Drawing.Point(3, 3);
            this.pnlListenOnSpotify.Name = "pnlListenOnSpotify";
            this.pnlListenOnSpotify.Size = new System.Drawing.Size(236, 220);
            this.pnlListenOnSpotify.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.DarkGray;
            this.panel2.Location = new System.Drawing.Point(-1, 214);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1048, 10);
            this.panel2.TabIndex = 4;
            // 
            // lblDoubleClick
            // 
            this.lblDoubleClick.AutoSize = true;
            this.lblDoubleClick.ForeColor = System.Drawing.Color.White;
            this.lblDoubleClick.Location = new System.Drawing.Point(10, 179);
            this.lblDoubleClick.Name = "lblDoubleClick";
            this.lblDoubleClick.Size = new System.Drawing.Size(214, 25);
            this.lblDoubleClick.TabIndex = 1;
            this.lblDoubleClick.Text = "Double Click To Listen!";
            this.lblDoubleClick.Click += new System.EventHandler(this.lblDoubleClick_Click);
            // 
            // UcSearchResultItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlListenOnSpotify);
            this.Name = "UcSearchResultItem";
            this.Size = new System.Drawing.Size(1047, 224);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListItem_MouseClick);
            this.MouseEnter += new System.EventHandler(this.ListItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ListItem_MouseLeave);
            ((System.ComponentModel.ISupportInitialize)(this.picListenOnSpotify)).EndInit();
            this.pnlListenOnSpotify.ResumeLayout(false);
            this.pnlListenOnSpotify.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picListenOnSpotify;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Panel pnlListenOnSpotify;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblDoubleClick;
    }
}
