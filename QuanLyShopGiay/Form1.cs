using QuanLyShopGiay.views;
using System;
using System.Windows.Forms;

namespace QuanLyShopGiay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Code có thể để xử lý khi form1 được load
        }

        // Sự kiện khi nhấn vào nút button1
        private void button1_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng Login form
            Login loginForm = new Login();

            // Hiển thị form Login
            loginForm.Show();

            // Ẩn Form hiện tại (Form1)
            this.Hide();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            // Tạo đối tượng Main form
            Main mainForm = new Main();  // ✔ Đúng

            // Hiển thị form Main
            mainForm.Show();

            // Ẩn Form hiện tại (Form1)
            this.Hide();
        }

    }
}
