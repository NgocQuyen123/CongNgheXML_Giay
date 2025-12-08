using QuanLyShopGiay.context;
using QuanLyShopGiay.Models;
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
            LoadDanhSachHoaDon();
            LoadTaiKhoan();
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
                dgvGiay.Columns["TenGiay"].HeaderText = "Giày";
                dgvGiay.Columns["ThuongHieu"].HeaderText = "Thương Hiệu";
                dgvGiay.Columns["KichCo"].HeaderText = "Kích Cỡ";
                dgvGiay.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgvGiay.Columns["Gia"].HeaderText = "Giá Bán";
            }

        }

        private void btnTimKiemChiTietHoaDon_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemChiTietHoaDon.Text.Trim();

            using (var db = new QLBanGiayContext())
            {
                var ketQua = db.ChiTietHoaDons
                    .Where(ct =>
                        ct.MaCTHD.ToString() == keyword ||   
                        ct.MaHD.ToString() == keyword        
                    )
                    .Select(ct => new
                    {
                        ct.MaCTHD,
                        ct.MaHD,
                        TenGiay = ct.Giay.TenGiay,          
                        ct.KichCo,
                        ct.SoLuongMua,
                        TienGiay = ct.Giay.Gia,              
                        TongTien = ct.SoLuongMua * ct.Giay.Gia
                    })
                    .ToList();

                dgvTimKiemChiTietHoaDon.DataSource = ketQua;

                dgvTimKiemChiTietHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Đổi tên cột
                dgvTimKiemChiTietHoaDon.Columns["MaCTHD"].HeaderText = "Mã CTHD";
                dgvTimKiemChiTietHoaDon.Columns["MaHD"].HeaderText = "Mã Hóa Đơn";
                dgvTimKiemChiTietHoaDon.Columns["TenGiay"].HeaderText = "Giày";
                dgvTimKiemChiTietHoaDon.Columns["KichCo"].HeaderText = "Kích Cỡ";
                dgvTimKiemChiTietHoaDon.Columns["SoLuongMua"].HeaderText = "Số Lượng Mua";
                dgvTimKiemChiTietHoaDon.Columns["TienGiay"].HeaderText = "Giá Giày (VNĐ)";
                dgvTimKiemChiTietHoaDon.Columns["TongTien"].HeaderText = "Tổng Tiền (VNĐ)";
            }
        }

        private void btnTimKiemTaiKhoan_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemTaiKhoan.Text.Trim();

            using (var db = new QLBanGiayContext())
            {
                var ketQua = db.TaiKhoans
                    .Where(t =>
                        t.TenTaiKhoan.Contains(keyword) 
                    )
                    .Select(t => new
                    {
                        t.MaTK,
                        t.TenTaiKhoan,
                        t.QuyenHan,
                        TenNhanVien = t.NhanVien.HoTen,
                        t.MaNV
                    })
                    .ToList();

                dgvTimKiemTaiKhoan.DataSource = ketQua;

                dgvTimKiemTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvTimKiemTaiKhoan.Columns["MaTK"].HeaderText = "Mã Tài Khoản";
                dgvTimKiemTaiKhoan.Columns["TenTaiKhoan"].HeaderText = "Tài Khoản";
                dgvTimKiemTaiKhoan.Columns["QuyenHan"].HeaderText = "Quyền Hạn";
                dgvTimKiemTaiKhoan.Columns["TenNhanVien"].HeaderText = "Nhân Viên";
                dgvTimKiemTaiKhoan.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
            }
        }

        private void tabQlHoaDon_Click(object sender, EventArgs e)
        {
           
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabQlNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void tabTimKiemGiay_Click(object sender, EventArgs e)
        {

        }

        private void dgvGiay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        private void LoadDanhSachHoaDon()
        {
            using (var db = new QLBanGiayContext())
            {
                var dsHoaDon = db.HoaDons
                    .Select(hd => new
                    {
                        hd.MaHD,
                        hd.MaKH,
                        hd.MaNV,
                        hd.NgayLap
                    })
                    .ToList();

                dgvHoaDon.DataSource = dsHoaDon;

                dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvHoaDon.Columns["MaHD"].HeaderText = "Mã hóa đơn";
                dgvHoaDon.Columns["MaKH"].HeaderText = "Mã khách hàng";
                dgvHoaDon.Columns["MaNV"].HeaderText = "Mã nhân viên";
                dgvHoaDon.Columns["NgayLap"].HeaderText = "Ngày lập";
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }



        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maHD = txtHoaDon123.Text.Trim();
            string maKH = txtMaKH123.Text.Trim();
            string maNV = txtMaNV123.Text.Trim();
            string ngayLap = txtNgayLap123.Text.Trim();

            using (var db = new QLBanGiayContext())
            {
                var ketQua = db.HoaDons.AsQueryable();

                // Tìm theo MaHD
                if (!string.IsNullOrEmpty(maHD))
                    ketQua = ketQua.Where(hd => hd.MaHD.ToString().Contains(maHD));

                // Tìm theo MaKH
                if (!string.IsNullOrEmpty(maKH))
                    ketQua = ketQua.Where(hd => hd.MaKH.ToString().Contains(maKH));

                // Tìm theo MaNV
                if (!string.IsNullOrEmpty(maNV))
                    ketQua = ketQua.Where(hd => hd.MaNV.ToString().Contains(maNV));

                // Tìm theo NgayLap (YYYY-MM-DD)
                if (!string.IsNullOrEmpty(ngayLap))
                    ketQua = ketQua.Where(hd => hd.NgayLap.ToString().Contains(ngayLap));

                // Đổ dữ liệu ra grid
                var ds = ketQua
                    .Select(hd => new
                    {
                        hd.MaHD,
                        hd.MaKH,
                        hd.MaNV,
                        hd.NgayLap
                    })
                    .ToList();

                dgvHoaDon.DataSource = ds;

                dgvHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvHoaDon.Columns["MaHD"].HeaderText = "Mã hóa đơn";
                dgvHoaDon.Columns["MaKH"].HeaderText = "Mã khách hàng";
                dgvHoaDon.Columns["MaNV"].HeaderText = "Mã nhân viên";
                dgvHoaDon.Columns["NgayLap"].HeaderText = "Ngày lập";
            }
        }

        private void txtNgayLap123_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnTaoMoi123_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ textbox
            string maKH = txtMaKH123.Text.Trim();
            string maNV = txtMaNV123.Text.Trim();
            string ngayLap = txtNgayLap123.Text.Trim();

            // 2. Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(maKH) || string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(ngayLap))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã KH, Mã NV và Ngày Lập!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime date;
            if (!DateTime.TryParse(ngayLap, out date))
            {
                MessageBox.Show("Ngày lập không hợp lệ! (Định dạng: yyyy-MM-dd)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Thêm vào database
            using (var db = new QLBanGiayContext())
            {
                var hd = new HoaDon
                {
                    MaKH = int.Parse(maKH),
                    MaNV = int.Parse(maNV),
                    NgayLap = date
                };

                db.HoaDons.Add(hd);
                db.SaveChanges(); // Lưu vào SQL
            }

            // 4. Load lại danh sách
            LoadDanhSachHoaDon();

            // 5. Xóa trắng textbox
            txtHoaDon123.Clear();
            txtMaKH123.Clear();
            txtMaNV123.Clear();
            txtNgayLap123.Clear();

            MessageBox.Show("Thêm hóa đơn mới thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void tabQlTaiKhoan_Click(object sender, EventArgs e)
        {

        }
        private void LoadTaiKhoan()
        {
            using (var db = new QLBanGiayContext())
            {
                var data = db.TaiKhoans
                    .Select(tk => new
                    {
                        tk.MaTK,
                        tk.TenTaiKhoan,
                        tk.MatKhau,
                        tk.QuyenHan,
                        tk.MaNV
                    })
                    .ToList();

                dgvTaiKhoan.DataSource = data;

                dgvTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvTaiKhoan.Columns["MaTK"].HeaderText = "Mã tài khoản";
                dgvTaiKhoan.Columns["TenTaiKhoan"].HeaderText = "Tên tài khoản";
                dgvTaiKhoan.Columns["MatKhau"].HeaderText = "Mật khẩu";
                dgvTaiKhoan.Columns["QuyenHan"].HeaderText = "Quyền hạn";
                dgvTaiKhoan.Columns["MaNV"].HeaderText = "Mã nhân viên";
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTimKiemHoaDon_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemHoaDon.Text.Trim();

            using (var db = new QLBanGiayContext())
            {
                var ketQua = db.HoaDons
                    .Where(h => h.MaHD.ToString() == keyword)   // ⬅ Chỉ tìm đúng mã hóa đơn
                    .Select(h => new
                    {
                        h.MaHD,
                        TenKhachHang = h.KhachHang.HoTen,
                        TenNhanVien = h.NhanVien.HoTen,
                        h.NgayLap,

                        ThanhTien = h.ChiTietHoaDons
                                    .Sum(ct => ct.SoLuongMua * ct.Giay.Gia)
                    })
                    .ToList();

                dgvTimKiemHoaDon.DataSource = ketQua;

                dgvTimKiemHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvTimKiemHoaDon.Columns["MaHD"].HeaderText = "Mã Hóa Đơn";
                dgvTimKiemHoaDon.Columns["TenKhachHang"].HeaderText = "Khách Hàng";
                dgvTimKiemHoaDon.Columns["TenNhanVien"].HeaderText = "Nhân Viên";
                dgvTimKiemHoaDon.Columns["NgayLap"].HeaderText = "Ngày Lập";
                dgvTimKiemHoaDon.Columns["ThanhTien"].HeaderText = "Thành Tiền (VNĐ)";
            }
        }

        private void btnTimKiemNhanVien_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemNhanVien.Text.Trim();

            using (var db = new QLBanGiayContext())
            {
                var ketQua = db.NhanViens
                    .Where(nv => nv.HoTen.Contains(keyword))   // ⬅ Tìm gần đúng theo tên
                    .Select(nv => new
                    {
                        nv.MaNV,
                        nv.HoTen,
                        nv.DiaChi,
                        nv.SoDT
                    })
                    .ToList();

                dgvNhanVien.DataSource = ketQua;

                dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvNhanVien.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
                dgvNhanVien.Columns["HoTen"].HeaderText = "Họ Tên";
                dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
                dgvNhanVien.Columns["SoDT"].HeaderText = "Số Điện Thoại";
            }
        }
    }
}


