namespace QuanLyShopGiay.views
{
    partial class NhanVienForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.grpThongTinHoaDon = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.cboKhachHang = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.grpChiTietHoaDon = new System.Windows.Forms.GroupBox();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.btnLuuHoaDon = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.grpChonSanPham = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboGiay = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSize = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.grpThongTinHoaDon.SuspendLayout();
            this.grpChiTietHoaDon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.grpChonSanPham.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(382, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(414, 36);
            this.label1.TabIndex = 0;
            this.label1.Text = "LẬP HÓA ĐƠN BÁN HÀNG";
            // 
            // grpThongTinHoaDon
            // 
            this.grpThongTinHoaDon.Controls.Add(this.dtpNgayLap);
            this.grpThongTinHoaDon.Controls.Add(this.label5);
            this.grpThongTinHoaDon.Controls.Add(this.cboKhachHang);
            this.grpThongTinHoaDon.Controls.Add(this.label4);
            this.grpThongTinHoaDon.Controls.Add(this.txtTenNV);
            this.grpThongTinHoaDon.Controls.Add(this.label3);
            this.grpThongTinHoaDon.Controls.Add(this.txtMaNV);
            this.grpThongTinHoaDon.Controls.Add(this.label2);
            this.grpThongTinHoaDon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTinHoaDon.Location = new System.Drawing.Point(69, 109);
            this.grpThongTinHoaDon.Name = "grpThongTinHoaDon";
            this.grpThongTinHoaDon.Size = new System.Drawing.Size(431, 293);
            this.grpThongTinHoaDon.TabIndex = 1;
            this.grpThongTinHoaDon.TabStop = false;
            this.grpThongTinHoaDon.Text = "THÔNG TIN HÓA ĐƠN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 26);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã nhân viên";
            // 
            // txtMaNV
            // 
            this.txtMaNV.Location = new System.Drawing.Point(181, 43);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.ReadOnly = true;
            this.txtMaNV.Size = new System.Drawing.Size(184, 35);
            this.txtMaNV.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 26);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên nhân viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 26);
            this.label4.TabIndex = 4;
            this.label4.Text = "Khách hàng";
            // 
            // txtTenNV
            // 
            this.txtTenNV.Location = new System.Drawing.Point(181, 104);
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.ReadOnly = true;
            this.txtTenNV.Size = new System.Drawing.Size(184, 35);
            this.txtTenNV.TabIndex = 3;
            // 
            // cboKhachHang
            // 
            this.cboKhachHang.FormattingEnabled = true;
            this.cboKhachHang.Location = new System.Drawing.Point(181, 171);
            this.cboKhachHang.Name = "cboKhachHang";
            this.cboKhachHang.Size = new System.Drawing.Size(184, 34);
            this.cboKhachHang.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 26);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ngày lập:";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Location = new System.Drawing.Point(181, 241);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(200, 35);
            this.dtpNgayLap.TabIndex = 7;
            // 
            // grpChiTietHoaDon
            // 
            this.grpChiTietHoaDon.Controls.Add(this.dgvChiTietHoaDon);
            this.grpChiTietHoaDon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChiTietHoaDon.Location = new System.Drawing.Point(518, 109);
            this.grpChiTietHoaDon.Name = "grpChiTietHoaDon";
            this.grpChiTietHoaDon.Size = new System.Drawing.Size(856, 293);
            this.grpChiTietHoaDon.TabIndex = 2;
            this.grpChiTietHoaDon.TabStop = false;
            this.grpChiTietHoaDon.Text = "CHI TIẾT HÓA ĐƠN";
            this.grpChiTietHoaDon.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(0, 47);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.RowHeadersWidth = 62;
            this.dgvChiTietHoaDon.RowTemplate.Height = 28;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(856, 246);
            this.dgvChiTietHoaDon.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(880, 434);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 26);
            this.label6.TabIndex = 3;
            this.label6.Text = "TỔNG TIỀN:";
            // 
            // txtTongTien
            // 
            this.txtTongTien.Location = new System.Drawing.Point(1067, 433);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.ReadOnly = true;
            this.txtTongTien.Size = new System.Drawing.Size(193, 26);
            this.txtTongTien.TabIndex = 4;
            // 
            // btnLuuHoaDon
            // 
            this.btnLuuHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnLuuHoaDon.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuHoaDon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLuuHoaDon.Location = new System.Drawing.Point(899, 512);
            this.btnLuuHoaDon.Name = "btnLuuHoaDon";
            this.btnLuuHoaDon.Size = new System.Drawing.Size(159, 70);
            this.btnLuuHoaDon.TabIndex = 5;
            this.btnLuuHoaDon.Text = "Lưu hóa đơn";
            this.btnLuuHoaDon.UseVisualStyleBackColor = false;
            this.btnLuuHoaDon.Click += new System.EventHandler(this.btnLuuHoaDon_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.BackColor = System.Drawing.Color.Red;
            this.btnHuy.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHuy.Location = new System.Drawing.Point(1101, 512);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(159, 70);
            this.btnHuy.TabIndex = 6;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = false;
            // 
            // grpChonSanPham
            // 
            this.grpChonSanPham.Controls.Add(this.txtSoLuong);
            this.grpChonSanPham.Controls.Add(this.label9);
            this.grpChonSanPham.Controls.Add(this.txtSize);
            this.grpChonSanPham.Controls.Add(this.label8);
            this.grpChonSanPham.Controls.Add(this.cboGiay);
            this.grpChonSanPham.Controls.Add(this.label7);
            this.grpChonSanPham.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChonSanPham.Location = new System.Drawing.Point(69, 455);
            this.grpChonSanPham.Name = "grpChonSanPham";
            this.grpChonSanPham.Size = new System.Drawing.Size(344, 256);
            this.grpChonSanPham.TabIndex = 7;
            this.grpChonSanPham.TabStop = false;
            this.grpChonSanPham.Text = "CHỌN SẢN PHẨM";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 57);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 26);
            this.label7.TabIndex = 0;
            this.label7.Text = "Giày";
            // 
            // cboGiay
            // 
            this.cboGiay.FormattingEnabled = true;
            this.cboGiay.Location = new System.Drawing.Point(131, 57);
            this.cboGiay.Name = "cboGiay";
            this.cboGiay.Size = new System.Drawing.Size(191, 34);
            this.cboGiay.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 26);
            this.label8.TabIndex = 2;
            this.label8.Text = "Size";
            // 
            // txtSize
            // 
            this.txtSize.Location = new System.Drawing.Point(131, 124);
            this.txtSize.Name = "txtSize";
            this.txtSize.Size = new System.Drawing.Size(191, 35);
            this.txtSize.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 26);
            this.label9.TabIndex = 4;
            this.label9.Text = "Số lượng";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(131, 189);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(191, 35);
            this.txtSoLuong.TabIndex = 5;
            this.txtSoLuong.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSoLuong_KeyDown);
            // 
            // NhanVienForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1386, 803);
            this.Controls.Add(this.grpChonSanPham);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuuHoaDon);
            this.Controls.Add(this.txtTongTien);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.grpChiTietHoaDon);
            this.Controls.Add(this.grpThongTinHoaDon);
            this.Controls.Add(this.label1);
            this.Name = "NhanVienForm";
            this.Text = "NhanVienForm";
            this.Load += new System.EventHandler(this.NhanVienForm_Load_1);
            this.grpThongTinHoaDon.ResumeLayout(false);
            this.grpThongTinHoaDon.PerformLayout();
            this.grpChiTietHoaDon.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.grpChonSanPham.ResumeLayout(false);
            this.grpChonSanPham.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpThongTinHoaDon;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboKhachHang;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox grpChiTietHoaDon;
        private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTongTien;
        private System.Windows.Forms.Button btnLuuHoaDon;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.GroupBox grpChonSanPham;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboGiay;
        private System.Windows.Forms.Label label7;
    }
}