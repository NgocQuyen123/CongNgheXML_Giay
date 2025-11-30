using QuanLyShopGiay.context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyShopGiay.views
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void mnuBaoCaoThongKe_Click(object sender, EventArgs e)
        {

        }

        private void mnuQLNhanSu_Click(object sender, EventArgs e)
        {

        }

        private void chuyểnĐổiDữLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnTimKiemGiay_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemGiay.Text.Trim();

            using (var db = new QLBanGiayContext())
            {
                var ketQua = db.Giays
                               .Where(g => g.TenGiay.Contains(keyword))
                               .Select(g => new
                               {
                                   g.MaGiay,
                                   g.TenGiay,
                                   g.ThuongHieu,
                                   g.KichCo,
                                   g.SoLuong,
                                   g.Gia
                               })
                               .ToList();

                dgvGiay.DataSource = ketQua;

                dgvGiay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // 🔥 Đổi tên tiêu đề cột sang tiếng Việt
                dgvGiay.Columns["MaGiay"].HeaderText = "Mã Giày";
                dgvGiay.Columns["TenGiay"].HeaderText = "Tên Giày";
                dgvGiay.Columns["ThuongHieu"].HeaderText = "Thương Hiệu";
                dgvGiay.Columns["KichCo"].HeaderText = "Kích Cỡ";
                dgvGiay.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgvGiay.Columns["Gia"].HeaderText = "Giá Bán";
            }

        }

        private void btnTimKiemChiTietHoaDon_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiemTaiKhoan_Click(object sender, EventArgs e)
        {

        }
    }
}
