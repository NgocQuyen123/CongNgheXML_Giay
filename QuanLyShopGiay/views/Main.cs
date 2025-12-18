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
using System.IO;
using System.Xml;
using System.Data.Entity;
using System.Data.Entity;
using System.Windows.Forms.DataVisualization.Charting;


namespace QuanLyShopGiay.views
{
    public partial class Main : Form
    {
        /// <summary>
        /// </summary>
        private bool hasShownXmlNoticeNV = false;
        private readonly object xmlLock = new object();
        private string NhanVienXmlPath => Path.Combine(Application.StartupPath, "NhanVien.xml");
        private string GiayXmlPath => Path.Combine(Application.StartupPath, "Giay.xml");
        private string HoaDonXmlPath => Path.Combine(Application.StartupPath, "HoaDon.xml");
        private string TaiKhoanXmlPath => Path.Combine(Application.StartupPath, "TaiKhoan.xml");
        QLBanGiayContext db = new QLBanGiayContext();
        private void LoadGridFromXml(string filePath, DataGridView dgv)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show($"File {Path.GetFileName(filePath)} không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataSet ds = new DataSet();
            ds.ReadXml(filePath);

            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trong file XML.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgv.DataSource = ds.Tables[0];
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dgv.Columns.Contains("MaTK"))
            {
                dgv.Columns["MaTK"].HeaderText = "Mã Tài Khoản";
                dgv.Columns["TenTaiKhoan"].HeaderText = "Tên Tài Khoản";
                dgv.Columns["MatKhau"].HeaderText = "Mật Khẩu";
                dgv.Columns["QuyenHan"].HeaderText = "Quyền hạn";
                dgv.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
                return;
            }
            if (dgv.Columns.Contains("MaHD"))
            {
                dgv.Columns["MaHD"].HeaderText = "Mã Hóa Đơn";
                dgv.Columns["MaKH"].HeaderText = "Mã Khách Hàng";
                dgv.Columns["MaNV"].HeaderText = "Mã Nhân Viên";
                dgv.Columns["NgayLap"].HeaderText = "Ngày Lập";
                return;
            }

            if (dgv.Columns.Contains("MaGiay"))
            {
                dgv.Columns["MaGiay"].HeaderText = "Mã Giày";
                dgv.Columns["TenGiay"].HeaderText = "Tên Giày";
                dgv.Columns["ThuongHieu"].HeaderText = "Thương Hiệu";
                dgv.Columns["KichCo"].HeaderText = "Kích Cỡ";
                dgv.Columns["SoLuong"].HeaderText = "Số Lượng";
                dgv.Columns["Gia"].HeaderText = "Giá Bán";
                return;
            }

            // Đổi tiêu đề cột nếu có
            if (dgv.Columns.Contains("MaNV")) { 
                dgv.Columns["MaNV"].HeaderText = "Mã Nhân Viên"; 
                dgv.Columns["HoTen"].HeaderText = "Họ Tên";
                dgv.Columns["DiaChi"].HeaderText = "Địa Chỉ"; 
                dgv.Columns["SoDT"].HeaderText = "Số ĐT";
                return;
            }

        }
        private void RegenerateNhanVienXml()
        {
            lock (xmlLock)
            {
                using (var db = new QLBanGiayContext())
                {
                    var nvList = db.NhanViens
                                   .Select(n => new { n.MaNV, n.HoTen, n.DiaChi, n.SoDT })
                                   .ToList();

                    DataTable dtNV = new DataTable("NhanVien");
                    dtNV.Columns.Add("MaNV");
                    dtNV.Columns.Add("HoTen");
                    dtNV.Columns.Add("DiaChi");
                    dtNV.Columns.Add("SoDT");

                    foreach (var n in nvList)
                        dtNV.Rows.Add(n.MaNV, n.HoTen, n.DiaChi, n.SoDT);

                    DataSet ds = new DataSet("NewDataSet");
                    ds.Tables.Add(dtNV);
                    ds.WriteXml(NhanVienXmlPath, XmlWriteMode.WriteSchema);
                }
            }
        }
        private void RegenerateGiayXml()
        {
            lock (xmlLock)
            {
                using (var db = new QLBanGiayContext())
                {
                    var giayList = db.Giays
                                      .Select(g => new { g.MaGiay, g.TenGiay, g.ThuongHieu, g.KichCo, g.SoLuong, g.Gia })
                                      .ToList();

                    DataTable dtGiay = new DataTable("Giay");
                    dtGiay.Columns.Add("MaGiay");
                    dtGiay.Columns.Add("TenGiay");
                    dtGiay.Columns.Add("ThuongHieu");
                    dtGiay.Columns.Add("KichCo");
                    dtGiay.Columns.Add("SoLuong");
                    dtGiay.Columns.Add("Gia");

                    foreach (var g in giayList)
                        dtGiay.Rows.Add(g.MaGiay, g.TenGiay, g.ThuongHieu, g.KichCo, g.SoLuong, g.Gia);

                    DataSet ds = new DataSet("NewDataSet");
                    ds.Tables.Add(dtGiay);
                    ds.WriteXml(GiayXmlPath, XmlWriteMode.WriteSchema);
                }
            }
        }
        private void RegenerateHoaDonXml()
        {
            lock (xmlLock)
            {
                using (var db = new QLBanGiayContext())
                {
                    var hoaDonList = db.HoaDons
                        .Select(hd => new
                        {
                            hd.MaHD,
                            hd.MaKH,
                            hd.MaNV,
                            hd.NgayLap
                        })
                        .ToList();

                    DataTable dtHD = new DataTable("HoaDon");
                    dtHD.Columns.Add("MaHD");
                    dtHD.Columns.Add("MaKH");
                    dtHD.Columns.Add("MaNV");
                    dtHD.Columns.Add("NgayLap");

                    foreach (var hd in hoaDonList)
                        dtHD.Rows.Add(hd.MaHD, hd.MaKH, hd.MaNV, hd.NgayLap);

                    DataSet ds = new DataSet("NewDataSet");
                    ds.Tables.Add(dtHD);
                    ds.WriteXml(HoaDonXmlPath, XmlWriteMode.WriteSchema);
                }
            }
        }
        private void RegenerateTaiKhoanXml()
        {
            lock (xmlLock)
            {
                using (var db = new QLBanGiayContext())
                {
                    // Lấy danh sách tài khoản
                    var taiKhoanList = db.TaiKhoans
                                         .Select(tk => new { tk.MaTK, tk.TenTaiKhoan, tk.MatKhau, tk.QuyenHan, tk.MaNV })
                                         .ToList();

                    // Tạo DataTable
                    DataTable dtTaiKhoan = new DataTable("TaiKhoan");
                    dtTaiKhoan.Columns.Add("MaTK");
                    dtTaiKhoan.Columns.Add("TenTaiKhoan");
                    dtTaiKhoan.Columns.Add("MatKhau");
                    dtTaiKhoan.Columns.Add("QuyenHan");
                    dtTaiKhoan.Columns.Add("MaNV");

                    // Đổ dữ liệu vào DataTable
                    foreach (var tk in taiKhoanList)
                    {
                        dtTaiKhoan.Rows.Add(tk.MaTK, tk.TenTaiKhoan, tk.MatKhau, tk.QuyenHan, tk.MaNV);
                    }

                    // Tạo DataSet và ghi XML
                    DataSet ds = new DataSet("NewDataSet");
                    ds.Tables.Add(dtTaiKhoan);
                    ds.WriteXml(TaiKhoanXmlPath, XmlWriteMode.WriteSchema);
                }
            }
        }



        private void LoadDanhSachNhanVien()
        {
            if (!File.Exists(NhanVienXmlPath))
            {
                dtgNhanVien.DataSource = null;

                if (!hasShownXmlNoticeNV)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        MessageBox.Show(
                            "Vui lòng ấn nút 'Tạo XML' để tạo file XML và hiển thị dữ liệu. \n" +
                            "Tương tự cho các tab khác",
                            "Thông báo",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }));

                    hasShownXmlNoticeNV = true;
                }
                return;
            }

            LoadGridFromXml(NhanVienXmlPath, dtgNhanVien);
        }

        private void LoadDanhSachGiay()
        {
            if (!File.Exists(GiayXmlPath))
            {
                dtgGiay.DataSource = null;
                return;
            }

            LoadGridFromXml(GiayXmlPath, dtgGiay);
        }

        //end test XML
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
            // ===== KHÓA ID =====
            txtMaNV.ReadOnly = true;
            txtMaGiay.ReadOnly = true;

            //LoadDanhSachHoaDon();
            LoadTaiKhoan();
            LoadDanhSachNhanVien();
            //LoadDanhSachGiay();
        }

        

        private void btnTimKiemGiay_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemGiay.Text.Trim();

            if (!File.Exists(GiayXmlPath))
            {
                MessageBox.Show("File XML Giày không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataSet ds = new DataSet();
            ds.ReadXml(GiayXmlPath);

            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("File XML không có dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dt = ds.Tables[0];

            // Lọc dữ liệu bằng LINQ to DataTable
            var ketQua = dt.AsEnumerable()
                           .Where(row => row.Field<string>("TenGiay") != null &&
                                         row.Field<string>("TenGiay").ToLower().Contains(keyword.ToLower()))
                           .CopyToDataTable();

            dgvGiay.DataSource = ketQua;
            dgvGiay.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đổi tên tiêu đề cột
            if (dgvGiay.Columns.Contains("MaGiay")) dgvGiay.Columns["MaGiay"].HeaderText = "Mã Giày";
            if (dgvGiay.Columns.Contains("TenGiay")) dgvGiay.Columns["TenGiay"].HeaderText = "Giày";
            if (dgvGiay.Columns.Contains("ThuongHieu")) dgvGiay.Columns["ThuongHieu"].HeaderText = "Thương Hiệu";
            if (dgvGiay.Columns.Contains("KichCo")) dgvGiay.Columns["KichCo"].HeaderText = "Kích Cỡ";
            if (dgvGiay.Columns.Contains("SoLuong")) dgvGiay.Columns["SoLuong"].HeaderText = "Số Lượng";
            if (dgvGiay.Columns.Contains("Gia")) dgvGiay.Columns["Gia"].HeaderText = "Giá Bán";

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

            if (!File.Exists(TaiKhoanXmlPath))
            {
                MessageBox.Show("File XML Tài Khoản không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet ds = new DataSet();
            ds.ReadXml(TaiKhoanXmlPath);
            DataTable dtTaiKhoan = ds.Tables[0];

            DataTable ketQua;

            try
            {
                // Tìm kiếm gần đúng theo TenTaiKhoan (không phân biệt hoa thường)
                ketQua = dtTaiKhoan.AsEnumerable()
                                   .Where(r => r.Field<string>("TenTaiKhoan")
                                                 .IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                                   .CopyToDataTable();
            }
            catch
            {
                // Trường hợp không tìm thấy dòng nào
                ketQua = dtTaiKhoan.Clone(); // Tạo DataTable rỗng cùng cấu trúc
            }

            // Load vào DataGridView
            dgvTimKiemTaiKhoan.DataSource = ketQua;
            dgvTimKiemTaiKhoan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đổi tiêu đề cột
            if (dgvTimKiemTaiKhoan.Columns.Contains("MaTK"))
                dgvTimKiemTaiKhoan.Columns["MaTK"].HeaderText = "Mã Tài Khoản";
            if (dgvTimKiemTaiKhoan.Columns.Contains("TenTaiKhoan"))
                dgvTimKiemTaiKhoan.Columns["TenTaiKhoan"].HeaderText = "Tài Khoản";
            if (dgvTimKiemTaiKhoan.Columns.Contains("QuyenHan"))
                dgvTimKiemTaiKhoan.Columns["QuyenHan"].HeaderText = "Quyền Hạn";
            if (dgvTimKiemTaiKhoan.Columns.Contains("MaNV"))
                dgvTimKiemTaiKhoan.Columns["MaNV"].HeaderText = "Mã Nhân Viên";

            // Lấy tên nhân viên từ XML Nhân Viên
            if (File.Exists(NhanVienXmlPath) && dgvTimKiemTaiKhoan.Columns.Contains("MaNV"))
            {
                DataSet dsNV = new DataSet();
                dsNV.ReadXml(NhanVienXmlPath);
                DataTable dtNV = dsNV.Tables[0];

                // Thêm cột TenNhanVien nếu chưa có
                if (!ketQua.Columns.Contains("TenNhanVien"))
                    ketQua.Columns.Add("TenNhanVien");

                foreach (DataRow row in ketQua.Rows)
                {
                    string maNV = row["MaNV"].ToString();
                    var nvRow = dtNV.AsEnumerable().FirstOrDefault(r => r.Field<string>("MaNV") == maNV);
                    row["TenNhanVien"] = nvRow != null ? nvRow.Field<string>("HoTen") : "";
                }

                dgvTimKiemTaiKhoan.Columns["TenNhanVien"].HeaderText = "Nhân Viên";
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
            if (!File.Exists(HoaDonXmlPath))
            {
                dgvHoaDon.DataSource = null;
                return;
            }

            LoadGridFromXml(HoaDonXmlPath, dgvHoaDon);
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
            RegenerateHoaDonXml();
            LoadDanhSachHoaDon();
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
            if (string.IsNullOrWhiteSpace(txtMaTK345.Text))
            {
                MessageBox.Show("Vui lòng nhập mã tài khoản!",
                                "Thiếu dữ liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMaTK345.Text.Trim(), out int maTK))
            {
                MessageBox.Show("Mã tài khoản không hợp lệ!",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // 2. Load XML Tài Khoản
            if (!File.Exists(TaiKhoanXmlPath))
            {
                MessageBox.Show("File XML Tài Khoản không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet ds = new DataSet();
            ds.ReadXml(TaiKhoanXmlPath);
            DataTable dt = ds.Tables[0];

            // 3. Tìm tài khoản cần sửa
            var row = dt.AsEnumerable().FirstOrDefault(r => r.Field<string>("MaTK") == maTK.ToString());
            if (row == null)
            {
                MessageBox.Show("Tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Sửa từng trường nếu có nhập
            if (!string.IsNullOrWhiteSpace(txtTK345.Text))
                row["TenTaiKhoan"] = txtTK345.Text.Trim();

            if (!string.IsNullOrWhiteSpace(txtMK345.Text))
                row["MatKhau"] = txtMK345.Text.Trim();

            if (!string.IsNullOrWhiteSpace(txtQuyen345.Text))
                row["QuyenHan"] = txtQuyen345.Text.Trim();

            if (!string.IsNullOrWhiteSpace(txtMaNV345.Text))
            {
                if (!int.TryParse(txtMaNV345.Text.Trim(), out int maNV))
                {
                    MessageBox.Show("Mã nhân viên không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra tồn tại nhân viên trong XML
                DataSet dsNV = new DataSet();
                if (!File.Exists(NhanVienXmlPath))
                {
                    MessageBox.Show("File XML Nhân Viên không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                dsNV.ReadXml(NhanVienXmlPath);
                DataTable dtNV = dsNV.Tables[0];

                bool tonTaiNV = dtNV.AsEnumerable().Any(r => r.Field<string>("MaNV") == maNV.ToString());
                if (!tonTaiNV)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại trong XML!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                row["MaNV"] = maNV;
            }

            // 5. Lưu XML
            ds.WriteXml(TaiKhoanXmlPath, XmlWriteMode.WriteSchema);

            // 6. Load lại DataGridView
            LoadTaiKhoan();
            ClearTextBoxes(tabQlTaiKhoan);

            MessageBox.Show("Sửa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void tabQlTaiKhoan_Click(object sender, EventArgs e)
        {

        }
        private void LoadTaiKhoan()
        {
            if (!File.Exists(TaiKhoanXmlPath))
            {
                dgvHoaDon.DataSource = null;
                return;
            }

            LoadGridFromXml(TaiKhoanXmlPath, dgvTaiKhoan345);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnTimKiemHoaDon_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemHoaDon.Text.Trim();

            if (!File.Exists(HoaDonXmlPath))
            {
                MessageBox.Show("File XML hóa đơn không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataSet ds = new DataSet();
            ds.ReadXml(HoaDonXmlPath);

            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trong file XML.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dt = ds.Tables[0];

            // Tìm các dòng theo keyword
            DataTable ketQua;
            try
            {
                ketQua = dt.AsEnumerable()
                           .Where(row => row.Field<string>("MaHD") != null &&
                                         row.Field<string>("MaHD").Equals(keyword, StringComparison.OrdinalIgnoreCase))
                           .CopyToDataTable();
            }
            catch
            {
                // Trường hợp không có dòng nào thỏa mãn
                ketQua = dt.Clone(); // tạo table rỗng cùng cấu trúc
            }

            dgvTimKiemHoaDon.DataSource = ketQua;
            dgvTimKiemHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đổi tiêu đề cột
            if (dgvTimKiemHoaDon.Columns.Contains("MaHD"))
                dgvTimKiemHoaDon.Columns["MaHD"].HeaderText = "Mã Hóa Đơn";

            if (dgvTimKiemHoaDon.Columns.Contains("MaKH"))
                dgvTimKiemHoaDon.Columns["MaKH"].HeaderText = "Mã Khách Hàng";

            if (dgvTimKiemHoaDon.Columns.Contains("MaNV"))
                dgvTimKiemHoaDon.Columns["MaNV"].HeaderText = "Mã Nhân Viên";

            if (dgvTimKiemHoaDon.Columns.Contains("NgayLap"))
                dgvTimKiemHoaDon.Columns["NgayLap"].HeaderText = "Ngày Lập";

            if (dgvTimKiemHoaDon.Columns.Contains("ThanhTien"))
                dgvTimKiemHoaDon.Columns["ThanhTien"].HeaderText = "Thành Tiền (VNĐ)";
        }

        private void btnTimKiemNhanVien_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiemNhanVien.Text.Trim();

            if (!File.Exists(NhanVienXmlPath))
            {
                MessageBox.Show("File XML Nhân Viên không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataSet ds = new DataSet();
            ds.ReadXml(NhanVienXmlPath);

            if (ds.Tables.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu trong file XML.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dt = ds.Tables[0];

            DataTable ketQua;
            try
            {
                ketQua = dt.AsEnumerable()
                           .Where(row =>
                               row.Field<string>("HoTen") != null &&
                               row.Field<string>("HoTen").IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0
                           )
                           .CopyToDataTable();
            }
            catch
            {
                // Nếu không có kết quả, tạo DataTable rỗng
                ketQua = dt.Clone();
            }

            dgvNhanVien.DataSource = ketQua;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đổi tên cột
            if (dgvNhanVien.Columns.Contains("MaNV"))
                dgvNhanVien.Columns["MaNV"].HeaderText = "Mã Nhân Viên";

            if (dgvNhanVien.Columns.Contains("HoTen"))
                dgvNhanVien.Columns["HoTen"].HeaderText = "Họ Tên";

            if (dgvNhanVien.Columns.Contains("DiaChi"))
                dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";

            if (dgvNhanVien.Columns.Contains("SoDT"))
                dgvNhanVien.Columns["SoDT"].HeaderText = "Số Điện Thoại";
        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenNV.Text))
            {
                MessageBox.Show("Nhập tên nhân viên!");
                return;
            }

            using (var db = new QLBanGiayContext())
            {
                NhanVien nv = new NhanVien
                {
                    HoTen = txtTenNV.Text.Trim(),
                    DiaChi = txtDiaChiNV.Text.Trim(),
                    SoDT = txtSDTNV.Text.Trim()
                };

                db.NhanViens.Add(nv);
                db.SaveChanges();
            }

            // Tạo lại XML từ DB (đảm bảo đồng bộ)
            RegenerateNhanVienXml();

            // Load lại DGV từ XML
            LoadDanhSachNhanVien();
            ClearTextBoxes(tabQlNhanVien);
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaNV.Text.Trim(), out int maNV))
            {
                MessageBox.Show("Mã NV không hợp lệ!");
                return;
            }

            using (var db = new QLBanGiayContext())
            {
                var nv = db.NhanViens.FirstOrDefault(n => n.MaNV == maNV);
                if (nv == null)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!");
                    return;
                }

                nv.HoTen = txtTenNV.Text.Trim();
                nv.DiaChi = txtDiaChiNV.Text.Trim();
                nv.SoDT = txtSDTNV.Text.Trim();

                db.SaveChanges();
            }

            RegenerateNhanVienXml();
            LoadDanhSachNhanVien();
            ClearTextBoxes(tabQlNhanVien);
        }

        private void btnXoaNV_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaNV.Text.Trim(), out int maNV))
            {
                MessageBox.Show("Mã NV không hợp lệ!");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using (var db = new QLBanGiayContext())
            {
                var nv = db.NhanViens.FirstOrDefault(n => n.MaNV == maNV);
                if (nv == null)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!");
                    return;
                }

                db.NhanViens.Remove(nv);
                db.SaveChanges();
            }

            RegenerateNhanVienXml();
            LoadDanhSachNhanVien();
            ClearTextBoxes(tabQlNhanVien);
        }

        private void btnThoatNV_Click(object sender, EventArgs e)
        {
            tabQlHeThong.SelectedTab = tabQlNhanVien;
            ClearTextBoxes(tabQlNhanVien);
        }

        private void btnThemGiay_Click(object sender, EventArgs e)
        {
            using (var db = new QLBanGiayContext())
            {
                Giay giay = new Giay
                {
                    TenGiay = txtTenGiay.Text.Trim(),
                    ThuongHieu = txtThuongHieu.Text.Trim(),
                    KichCo = int.TryParse(txtKichCo.Text.Trim(), out int kc) ? kc : 0,
                    SoLuong = int.TryParse(txtSoLuong.Text.Trim(), out int sl) ? sl : 0,
                    Gia = decimal.TryParse(txtGia.Text.Trim(), out decimal gia) ? gia : 0
                };
                db.Giays.Add(giay);
                db.SaveChanges();

            }
            RegenerateGiayXml();
            LoadDanhSachGiay();
            ClearTextBoxes(tabQlGiay);

        }

        private void btnSuaGiay_Click(object sender, EventArgs e)
        {
            using (var db = new QLBanGiayContext())
            {
                int maGiay = int.TryParse(txtMaGiay.Text.Trim(), out int mg) ? mg : 0;
                var giay = db.Giays.FirstOrDefault(g => g.MaGiay == maGiay);

                if (giay != null)
                {
                    giay.TenGiay = txtTenGiay.Text.Trim();
                    giay.ThuongHieu = txtThuongHieu.Text.Trim();
                    giay.KichCo = int.TryParse(txtKichCo.Text.Trim(), out int kc) ? kc : giay.KichCo;
                    giay.SoLuong = int.TryParse(txtSoLuong.Text.Trim(), out int sl) ? sl : giay.SoLuong;
                    giay.Gia = decimal.TryParse(txtGia.Text.Trim(), out decimal gia) ? gia : giay.Gia;

                    db.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Mã Giày không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            RegenerateGiayXml();
            LoadDanhSachGiay();
            ClearTextBoxes(tabQlGiay);
        }

        private void btnXoaGiay_Click(object sender, EventArgs e)
        {
            using (var db = new QLBanGiayContext())
            {
                int maGiay = int.TryParse(txtMaGiay.Text.Trim(), out int mg) ? mg : 0;
                var giay = db.Giays.FirstOrDefault(g => g.MaGiay == maGiay);

                if (giay != null)
                {
                    var confirm = MessageBox.Show("Bạn có chắc muốn xóa giày này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.Yes)
                    {
                        db.Giays.Remove(giay);
                        db.SaveChanges();
                    }
                }
                else
                {
                    MessageBox.Show("Mã Giày không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            RegenerateGiayXml();
            LoadDanhSachGiay();
            ClearTextBoxes(tabQlGiay);
        }

        private void btnThoatGiay_Click(object sender, EventArgs e)
        {
            tabQlHeThong.SelectedTab = tabQlNhanVien;
            ClearTextBoxes(tabQlGiay);
        }


        private void ClearTextBoxes(TabPage tab)
        {
            foreach (Control ctl in tab.Controls)
            {
                if (ctl is TextBox tb)
                    tb.Clear();
            }
        }


        private void dtgGiay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgGiay_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgGiay.Rows[e.RowIndex];

                txtMaGiay.Text = row.Cells["MaGiay"].Value?.ToString();
                txtTenGiay.Text = row.Cells["TenGiay"].Value?.ToString();
                txtThuongHieu.Text = row.Cells["ThuongHieu"].Value?.ToString();
                txtKichCo.Text = row.Cells["KichCo"].Value?.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value?.ToString();
                txtGia.Text = row.Cells["Gia"].Value?.ToString();
            }
        }
        //Khi click 1 dòng của Datagridview QL NhanVien
        private void dtgNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgNhanVien.Rows[e.RowIndex];

                txtMaNV.Text = row.Cells["MaNV"].Value?.ToString();
                txtTenNV.Text = row.Cells["HoTen"].Value?.ToString();
                txtDiaChiNV.Text = row.Cells["DiaChi"].Value?.ToString();
                txtSDTNV.Text = row.Cells["SoDT"].Value?.ToString();
            }
        }

        private void btnSuaHoaDon123_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu
            if (string.IsNullOrEmpty(txtHoaDon123.Text) ||
                string.IsNullOrEmpty(txtMaKH123.Text) ||
                string.IsNullOrEmpty(txtMaNV123.Text) ||
                string.IsNullOrEmpty(txtNgayLap123.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hóa đơn!",
                                "Thiếu dữ liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtHoaDon123.Text.Trim(), out int maHD))
            {
                MessageBox.Show("Mã hóa đơn không hợp lệ!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(txtMaKH123.Text.Trim(), out int maKH) ||
                !int.TryParse(txtMaNV123.Text.Trim(), out int maNV))
            {
                MessageBox.Show("Mã KH hoặc Mã NV không hợp lệ!", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!DateTime.TryParse(txtNgayLap123.Text.Trim(), out DateTime ngayLap))
            {
                MessageBox.Show("Ngày lập không hợp lệ! (yyyy-MM-dd)",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            using (var db = new QLBanGiayContext())
            {
                // 2. Kiểm tra hóa đơn tồn tại
                var hoaDon = db.HoaDons.FirstOrDefault(h => h.MaHD == maHD);

                if (hoaDon == null)
                {
                    MessageBox.Show("Hóa đơn không tồn tại!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // 3. Kiểm tra KH & NV tồn tại
                bool khTonTai = db.KhachHangs.Any(k => k.MaKH == maKH);
                bool nvTonTai = db.NhanViens.Any(n => n.MaNV == maNV);

                if (!khTonTai || !nvTonTai)
                {
                    MessageBox.Show("Mã khách hàng hoặc mã nhân viên không tồn tại!",
                                    "Lỗi",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                // 4. Cập nhật dữ liệu
                hoaDon.MaKH = maKH;
                hoaDon.MaNV = maNV;
                hoaDon.NgayLap = ngayLap;

                db.SaveChanges();
            }

            // 5. Load lại danh sách
            RegenerateHoaDonXml();
            LoadDanhSachHoaDon();
            ClearTextBoxes(tabQlHoaDon);

            MessageBox.Show("Sửa hóa đơn thành công!",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnThoat123_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra mã hóa đơn
            if (string.IsNullOrEmpty(txtHoaDon123.Text))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn cần xóa!",
                                "Thiếu dữ liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtHoaDon123.Text.Trim(), out int maHD))
            {
                MessageBox.Show("Mã hóa đơn không hợp lệ!",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            using (var db = new QLBanGiayContext())
            {
                // 2. Kiểm tra hóa đơn tồn tại
                var hoaDon = db.HoaDons.FirstOrDefault(h => h.MaHD == maHD);

                if (hoaDon == null)
                {
                    MessageBox.Show("Hóa đơn không tồn tại!",
                                    "Thông báo",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                    return;
                }

                // 3. Xác nhận xóa
                var confirm = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa hóa đơn này?\n(Toàn bộ chi tiết hóa đơn sẽ bị xóa)",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm != DialogResult.Yes)
                    return;

                // 4. Xóa chi tiết hóa đơn trước
                var chiTietHD = db.ChiTietHoaDons.Where(ct => ct.MaHD == maHD).ToList();
                db.ChiTietHoaDons.RemoveRange(chiTietHD);

                // 5. Xóa hóa đơn
                db.HoaDons.Remove(hoaDon);
                db.SaveChanges();
            }

            // 6. Load lại danh sách
            RegenerateHoaDonXml();
            LoadDanhSachHoaDon();
            ClearTextBoxes(tabQlHoaDon);

            MessageBox.Show("Xóa hóa đơn thành công!",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnThem345_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra dữ liệu nhập
            if (string.IsNullOrWhiteSpace(txtTK345.Text) ||
    string.IsNullOrWhiteSpace(txtMK345.Text) ||
    string.IsNullOrWhiteSpace(txtQuyen345.Text) ||
    string.IsNullOrWhiteSpace(txtMaNV345.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin tài khoản!",
                                "Thiếu dữ liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMaNV345.Text.Trim(), out int maNV))
            {
                MessageBox.Show("Mã nhân viên không hợp lệ!",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // 2. Load XML hiện tại
            DataSet ds = new DataSet();
            if (File.Exists(TaiKhoanXmlPath))
                ds.ReadXml(TaiKhoanXmlPath);

            // Nếu chưa có bảng, tạo mới
            if (ds.Tables.Count == 0)
            {
                DataTable dtTaiKhoan = new DataTable("TaiKhoan");
                dtTaiKhoan.Columns.Add("MaTK");
                dtTaiKhoan.Columns.Add("TenTaiKhoan");
                dtTaiKhoan.Columns.Add("MatKhau");
                dtTaiKhoan.Columns.Add("QuyenHan");
                dtTaiKhoan.Columns.Add("MaNV");
                ds.Tables.Add(dtTaiKhoan);
            }

            DataTable dt = ds.Tables[0];

            // 3. Kiểm tra trùng tên tài khoản
            bool tonTaiTK = dt.AsEnumerable()
                              .Any(row => row.Field<string>("TenTaiKhoan") == txtTK345.Text.Trim());
            if (tonTaiTK)
            {
                MessageBox.Show("Tên tài khoản đã tồn tại!",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // 4. Kiểm tra nhân viên tồn tại trong XML Nhân Viên
            DataSet dsNV = new DataSet();
            if (!File.Exists(NhanVienXmlPath))
            {
                MessageBox.Show("File XML Nhân Viên không tồn tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dsNV.ReadXml(NhanVienXmlPath);
            DataTable dtNV = dsNV.Tables[0];

            bool tonTaiNV = dtNV.AsEnumerable().Any(row => row.Field<string>("MaNV") == maNV.ToString());
            if (!tonTaiNV)
            {
                MessageBox.Show("Mã nhân viên không tồn tại trong XML!",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // 5. Thêm tài khoản mới
            int newMaTK = 1;
            if (dt.Rows.Count > 0)
                newMaTK = dt.AsEnumerable().Max(r => Convert.ToInt32(r["MaTK"])) + 1;

            dt.Rows.Add(newMaTK, txtTK345.Text.Trim(), txtMK345.Text.Trim(), txtQuyen345.Text.Trim(), maNV);

            // 6. Lưu lại XML
            ds.WriteXml(TaiKhoanXmlPath, XmlWriteMode.WriteSchema);

            // 7. Load lại DataGridView từ XML
            LoadTaiKhoan();

            // 8. Xóa trắng textbox
            ClearTextBoxes(tabQlTaiKhoan);

            MessageBox.Show("Thêm tài khoản thành công!",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void btnXoa345_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaTK345.Text))
            {
                MessageBox.Show("Vui lòng nhập mã tài khoản cần xóa!",
                                "Thiếu dữ liệu",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtMaTK345.Text.Trim(), out int maTK))
            {
                MessageBox.Show("Mã tài khoản không hợp lệ!",
                                "Lỗi",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return;
            }

            // 2. Load XML Tài Khoản
            if (!File.Exists(TaiKhoanXmlPath))
            {
                MessageBox.Show("File XML Tài Khoản không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataSet ds = new DataSet();
            ds.ReadXml(TaiKhoanXmlPath);
            DataTable dt = ds.Tables[0];

            // 3. Tìm tài khoản
            var row = dt.AsEnumerable().FirstOrDefault(r => r.Field<string>("MaTK") == maTK.ToString());
            if (row == null)
            {
                MessageBox.Show("Tài khoản không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Xác nhận xóa
            var confirm = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa tài khoản [{row["TenTaiKhoan"]}]?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes)
                return;

            // 5. Xóa và lưu lại XML
            dt.Rows.Remove(row);
            ds.WriteXml(TaiKhoanXmlPath, XmlWriteMode.WriteSchema);

            // 6. Load lại DataGridView
            LoadTaiKhoan();

            // 7. Xóa textbox
            ClearTextBoxes(tabQlTaiKhoan);

            MessageBox.Show("Xóa tài khoản thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThoat345_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(
                "Bạn có muốn thoát khỏi chức năng quản lý tài khoản?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            tabQlHeThong.SelectedTab = tabQlNhanVien;
            ClearTextBoxes(tabQlTaiKhoan);
        }

        private void btnTaoXMLNV_Click(object sender, EventArgs e)
        {
            try
            {
                RegenerateNhanVienXml();
                LoadGridFromXml(NhanVienXmlPath, dtgNhanVien);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi tạo XML Nhân Viên:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnTaoXMLGiay_Click(object sender, EventArgs e)
        {
            try
            {
                RegenerateGiayXml();
                LoadGridFromXml(GiayXmlPath, dtgGiay);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi tạo XML Giày:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnTaoXmlHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                RegenerateHoaDonXml();              // chỉ tạo XML
                LoadGridFromXml(HoaDonXmlPath, dgvHoaDon); // load lại grid
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Lỗi khi tạo XML Hóa Đơn:\n" + ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnTaoXmlTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                RegenerateTaiKhoanXml();              // tạo file XML
                LoadGridFromXml(TaiKhoanXmlPath, dgvTaiKhoan345); // load lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo XML Tài Khoản:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabDuyetHoaDon_Click(object sender, EventArgs e)
        {
            LoadHoaDonChoDuyet();
        }

        void LoadHoaDonChoDuyet()
        {
            using (var db = new QLBanGiayContext())
            {
                var ds = db.HoaDons
                    .Where(hd => hd.trangThai == 0)
                    .Select(hd => new
                    {
                        hd.MaHD,
                        KhachHang = hd.KhachHang.HoTen,
                        NhanVien = hd.NhanVien.HoTen,
                        hd.NgayLap
                    })
                    .ToList();

                dgvDuyetHoaDon.DataSource = ds;
                dgvDuyetHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void dgvDuyetHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvDuyetHoaDon.Rows[e.RowIndex];

            txtMaHD.Text = row.Cells["MaHD"].Value.ToString();
            txtKhachHang.Text = row.Cells["KhachHang"].Value.ToString();
            txtNhanVien.Text = row.Cells["NhanVien"].Value.ToString();
            txtNgayLap.Text = Convert.ToDateTime(row.Cells["NgayLap"].Value).ToString("yyyy-MM-dd");

            LoadChiTietHoaDon(int.Parse(txtMaHD.Text));
        }

        void LoadChiTietHoaDon(int maHD)
        {
            using (var db = new QLBanGiayContext())
            {
                var ct = db.ChiTietHoaDons
                    .Where(x => x.MaHD == maHD)
                    .Select(x => new
                    {
                        TenGiay = x.Giay.TenGiay,
                        x.KichCo,
                        x.SoLuongMua,
                        DonGia = x.Giay.Gia,
                        ThanhTien = x.SoLuongMua * x.Giay.Gia
                    })
                    .ToList();

                dgvChiTietHoaDon.DataSource = ct;
            }
        }

        private void btnDuyet_Click(object sender, EventArgs e)
        {
            int maHD = int.Parse(txtMaHD.Text);

            using (var db = new QLBanGiayContext())
            {
                var hd = db.HoaDons.Find(maHD);
                hd.trangThai = 1;
                db.SaveChanges();
            }

            MessageBox.Show("Duyệt hóa đơn thành công");
            LoadHoaDonChoDuyet();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            int maHD = int.Parse(txtMaHD.Text);

            using (var db = new QLBanGiayContext())
            {
                var hd = db.HoaDons.Find(maHD);
                hd.trangThai = 2;
                db.SaveChanges();
            }

            MessageBox.Show("Đã từ chối hóa đơn");
            LoadHoaDonChoDuyet();
        }

        private void tabQlHeThong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabQlHeThong.SelectedTab == tabDuyetHoaDon)
            {
                LoadHoaDonChoDuyet();
            }
        }

        private void dgvChiTietHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            int maHD = Convert.ToInt32(
                dgvChiTietHoaDon.Rows[e.RowIndex].Cells["MaHD"].Value
            );

            LoadChiTietHoaDon(maHD);
        }

        void ThongKeTongHop(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new QLBanGiayContext())
            {
                var hoaDons = db.HoaDons
                    .Include(hd => hd.ChiTietHoaDons.Select(ct => ct.Giay))
                    .Where(hd =>
                        hd.trangThai == 1 &&
                        hd.NgayLap >= tuNgay &&
                        hd.NgayLap <= denNgay)
                    .ToList();

                txtTongHoaDon.Text = hoaDons.Count.ToString();

                int tongSoLuong = hoaDons
                    .SelectMany(hd => hd.ChiTietHoaDons)
                    .Sum(ct => ct.SoLuongMua);

                txtTongSoLuong.Text = tongSoLuong.ToString();

                decimal tongDoanhThu = hoaDons
                    .SelectMany(hd => hd.ChiTietHoaDons)
                    .Sum(ct => ct.SoLuongMua * ct.Giay.Gia);

                txtTongDoanhThu.Text = tongDoanhThu.ToString("N0");
            }
        }


        void ThongKeSanPham(DateTime tuNgay, DateTime denNgay)
        {
            using (var db = new QLBanGiayContext())
            {
                var ds = db.ChiTietHoaDons
                    .Include(ct => ct.Giay)
                    .Include(ct => ct.HoaDon)
                    .Where(ct =>
                        ct.HoaDon.trangThai == 1 &&
                        ct.HoaDon.NgayLap >= tuNgay &&
                        ct.HoaDon.NgayLap <= denNgay)
                    .GroupBy(ct => ct.Giay.TenGiay)
                    .Select(g => new
                    {
                        TenGiay = g.Key,
                        TongSoLuong = g.Sum(x => x.SoLuongMua),
                        DoanhThu = g.Sum(x => x.SoLuongMua * x.Giay.Gia)
                    })
                    .ToList();

                dgvThongKe.DataSource = ds;
                dgvThongKe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvThongKe.Columns["TenGiay"].HeaderText = "Tên giày";
                dgvThongKe.Columns["TongSoLuong"].HeaderText = "Số lượng bán";
                dgvThongKe.Columns["DoanhThu"].HeaderText = "Doanh thu (VNĐ)";
            }
        }


        void VeBieuDo(DateTime tuNgay, DateTime denNgay)
        {
            chartDoanhThu.Series.Clear();
            chartDoanhThu.ChartAreas.Clear();

            chartDoanhThu.ChartAreas.Add("ChartArea1");

            Series series = new Series("Doanh thu");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            using (var db = new QLBanGiayContext())
            {
                var ds = db.HoaDons
                    .Include(hd => hd.ChiTietHoaDons.Select(ct => ct.Giay))
                    .Where(hd =>
                        hd.trangThai == 1 &&
                        hd.NgayLap >= tuNgay &&
                        hd.NgayLap <= denNgay)
                    .GroupBy(hd => DbFunctions.TruncateTime(hd.NgayLap))
                    .Select(g => new
                    {
                        Ngay = g.Key.Value,
                        DoanhThu = g.SelectMany(hd => hd.ChiTietHoaDons)
                                    .Sum(ct => ct.SoLuongMua * ct.Giay.Gia)
                    })
                    .ToList();

                foreach (var item in ds)
                {
                    series.Points.AddXY(
                        item.Ngay.ToString("dd/MM"),
                        item.DoanhThu
                    );
                }
            }

            chartDoanhThu.Series.Add(series);
        }




        private void grpBoLoc_Enter(object sender, EventArgs e)
        {

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime tuNgay = dtpTuNgay.Value.Date;
            DateTime denNgay = dtpDenNgay.Value.Date.AddDays(1).AddSeconds(-1);

            ThongKeTongHop(tuNgay, denNgay);
            ThongKeSanPham(tuNgay, denNgay);
            VeBieuDo(tuNgay, denNgay);
        }
    }
}


