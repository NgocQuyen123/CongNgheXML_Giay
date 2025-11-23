using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuanLyShopGiay.views
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            SetDefaultBackgroundImage();
            this.Shown += new EventHandler(Login_Shown);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            SetPlaceholder(text_username, "Username");
            SetPlaceholder(text_password, "Password");
        }

        private void SetDefaultBackgroundImage()
        {
            string imagePath = @"img\background_img.jpg";

            try
            {
                this.BackgroundImage = Image.FromFile(imagePath);
                this.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể tải ảnh hình nền: " + ex.Message);
            }
        }

        private void bg_login_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int borderRadius = 30; 
            Rectangle rect = new Rectangle(0, 0, bg_login.Width, bg_login.Height);

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90); 
                path.AddArc(bg_login.Width - borderRadius - 1, 0, borderRadius, borderRadius, 270, 90); 
                path.AddArc(bg_login.Width - borderRadius - 1, bg_login.Height - borderRadius - 1, borderRadius, borderRadius, 0, 90); 
                path.AddArc(0, bg_login.Height - borderRadius - 1, borderRadius, borderRadius, 90, 90);
                path.CloseFigure(); 

                bg_login.Region = new Region(path);

                using (SolidBrush brush = new SolidBrush(bg_login.BackColor))
                {
                    g.FillPath(brush, path);
                }

                using (Pen pen = new Pen(Color.Gray)) 
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;  
            textBox.Enter += (sender, e) => RemovePlaceholder(sender as TextBox, placeholder);
            textBox.Leave += (sender, e) => SetPlaceholderIfEmpty(sender as TextBox, placeholder);
        }

        private void RemovePlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black; 
            }
        }

        private void SetPlaceholderIfEmpty(TextBox textBox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray; 
            }
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

    }
}
