namespace SpotifySearch_SWENG861.Views
{
    partial class AdditionalMetaDataView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdditionalMetaDataView));
            this.rtxtMetaData = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtxtMetaData
            // 
            this.rtxtMetaData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtMetaData.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtMetaData.Location = new System.Drawing.Point(0, 0);
            this.rtxtMetaData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtxtMetaData.Name = "rtxtMetaData";
            this.rtxtMetaData.Size = new System.Drawing.Size(1731, 882);
            this.rtxtMetaData.TabIndex = 0;
            this.rtxtMetaData.Text = "";
            // 
            // AdditionalMetaDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1731, 882);
            this.Controls.Add(this.rtxtMetaData);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdditionalMetaDataView";
            this.Text = "Artist / Track Meta data";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtMetaData;
    }
}