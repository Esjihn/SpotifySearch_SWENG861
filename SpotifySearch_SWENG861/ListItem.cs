using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SpotifySearch_SWENG861
{
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();
        }

        #region Properties

        [Category("Custom Props")]
        public string Title
        {
            get
            {
                return this.lblTitle.Text;
            }
            set
            {
                if (value != null)
                    this.lblTitle.Text = value;
            }
        }

        [Category("Custom Props")]
        public Color IconBackGround
        {
            get
            {
                return this.panel1.BackColor;
            }
            set
            {
                if (value != null)
                    this.panel1.BackColor = value;
            }
        }

        [Category("Custom Props")]
        public string Message 
        {
            get
            {
                return this.lblMessage.Text;
            }
            set
            {
                if (value != null) 
                    this.lblMessage.Text = value;
            }
        }

        [Category("Custom Props")]
        public Image Icon
        {
            get
            {
                return this.pictureBox1.Image;
            }
            set
            {
                if (value != null)
                    this.pictureBox1.Image = value;
            }
        }

        #endregion

        private void ListItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void ListItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void lblTitle_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void lblTitle_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void lblMessage_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Silver;
        }

        private void lblMessage_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void ListItem_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("More data here");
        }

        private void lblTitle_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("More data here");
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {
            MessageBox.Show("More data here");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            WebBrowser wb = new WebBrowser();
            //Form2 form2 = new Form2();
            //form2.WebBrowser.Url = new Uri("https://www.google.com");
            //form2.Show();
        }
    }
}
