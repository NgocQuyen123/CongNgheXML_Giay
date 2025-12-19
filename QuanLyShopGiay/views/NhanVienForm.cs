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
    public partial class NhanVienForm : Form
    {
        private TaiKhoan _taiKhoan;
        private List<ChiTietHoaDon> _dsCTHD = new List<ChiTietHoaDon>();


        public NhanVienForm(TaiKhoan taiKhoan)
        {
            InitializeComponent();
            _taiKhoan = taiKhoan;
        }

        //private void NhanVienForm_Load(object sender, EventArgs e)
        //{
           
        //}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void NhanVienForm_Load_1(object sender, EventArgs e)
        {
            if (_taiKhoan == null || _taiKhoan.NhanVien == null)
            {
                MessageBox.Show("Không xác định được nhân viên đăng nhập");
                this.Close();
                return;
            }

            txtMaNV.Text = _taiKhoan.MaNV.ToString();
            txtTenNV.Text = _taiKhoan.NhanVien.HoTen;

            txtMaNV.ReadOnly = true;
            txtTenNV.ReadOnly = true;

            LoadKhachHang();
            LoadGiay();
            SetupGrid();
        }

        void LoadKhachHang()
        {
            using (var db = new QLBanGiayContext())
            {
                cboKhachHang.DataSource = db.KhachHangs.ToList();
                cboKhachHang.DisplayMember = "HoTen";
                cboKhachHang.ValueMember = "MaKH";
            }
        }


        void LoadGiay()
        {
            using (var db = new QLBanGiayContext())
            {
                cboGiay.DataSource = db.Giays.ToList();
                cboGiay.DisplayMember = "TenGiay";
                cboGiay.ValueMember = "MaGiay";
            }
        }


        void SetupGrid()
        {
            dgvChiTietHoaDon.AutoGenerateColumns = true;
            dgvChiTietHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        private void btnLuuHoaDon_Click(object sender, EventArgs e)
        {
            if (_dsCTHD.Count == 0)
            {
                MessageBox.Show("Chưa có sản phẩm!");
                return;
            }

            using (var db = new QLBanGiayContext())
            {
                var hd = new HoaDon
                {
                    MaNV = _taiKhoan.MaNV,
                    MaKH = (int)cboKhachHang.SelectedValue,
                    NgayLap = DateTime.Now,
                    trangThai = 0 // chờ duyệt
                };

                db.HoaDons.Add(hd);
                db.SaveChanges();

                foreach (var ct in _dsCTHD)
                {
                    ct.MaHD = hd.MaHD;
                    db.ChiTietHoaDons.Add(ct);
                }

                db.SaveChanges();
            }

            MessageBox.Show("Lập hóa đơn thành công – chờ admin duyệt");
            this.Close();
        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ThemSanPhamVaoHoaDon();
                e.SuppressKeyPress = true;
            }
        }

        void ThemSanPhamVaoHoaDon()
        {
            if (cboGiay.SelectedValue == null)
            {
                MessageBox.Show("Chưa chọn sản phẩm!");
                return;
            }

            if (!int.TryParse(txtSoLuong.Text, out int soLuong) || soLuong <= 0)
            {
                MessageBox.Show("Số lượng không hợp lệ!");
                return;
            }

            if (!int.TryParse(txtSize.Text, out int size))
            {
                MessageBox.Show("Size không hợp lệ!");
                return;
            }

            int maGiay = (int)cboGiay.SelectedValue;

            // Thêm vào danh sách chi tiết hóa đơn
            var ct = new ChiTietHoaDon
            {
                MaGiay = maGiay,
                KichCo = size,
                SoLuongMua = soLuong
            };

            _dsCTHD.Add(ct);

            // Load lại grid hiển thị
            LoadGridHienThi();
            TinhTongTien();
            // Clear input
            txtSoLuong.Clear();
            txtSize.Clear();
            cboGiay.Focus();
        }

        void LoadGridHienThi()
        {
            using (var db = new QLBanGiayContext())
            {
                var ds = _dsCTHD.Select((ct, index) => new
                {
                    STT = index + 1,
                    TenGiay = db.Giays.First(g => g.MaGiay == ct.MaGiay).TenGiay,
                    Size = ct.KichCo,
                    SoLuong = ct.SoLuongMua
                }).ToList();

                dgvChiTietHoaDon.DataSource = null;
                dgvChiTietHoaDon.DataSource = ds;
            }
        }
        void TinhTongTien()
        {
            using (var db = new QLBanGiayContext())
            {
                decimal tong = 0;

                foreach (var ct in _dsCTHD)
                {
                    var giay = db.Giays.First(g => g.MaGiay == ct.MaGiay);
                    tong += giay.Gia * ct.SoLuongMua;
                }

                txtTongTien.Text = tong.ToString("N0"); // 1.000.000
            }
        }

    }
}
