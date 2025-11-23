namespace QuanLyShopGiay.views
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.tabHeThong = new System.Windows.Forms.TabPage();
            this.tabQlHeThong = new System.Windows.Forms.TabControl();
            this.tabQlNhanVien = new System.Windows.Forms.TabPage();
            this.tabQlGiay = new System.Windows.Forms.TabPage();
            this.tabQlHoaDon = new System.Windows.Forms.TabPage();
            this.tabQlTaiKhoan = new System.Windows.Forms.TabPage();
            this.tabTimKiem = new System.Windows.Forms.TabPage();
            this.tabThoat = new System.Windows.Forms.TabPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabLienHe = new System.Windows.Forms.TabPage();
            this.tabGioiThieu = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabMenu.SuspendLayout();
            this.tabHeThong.SuspendLayout();
            this.tabQlHeThong.SuspendLayout();
            this.tabQlNhanVien.SuspendLayout();
            this.tabQlGiay.SuspendLayout();
            this.tabQlHoaDon.SuspendLayout();
            this.tabQlTaiKhoan.SuspendLayout();
            this.tabTimKiem.SuspendLayout();
            this.tabLienHe.SuspendLayout();
            this.tabGioiThieu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.tabHeThong);
            this.tabMenu.Controls.Add(this.tabLienHe);
            this.tabMenu.Controls.Add(this.tabGioiThieu);
            this.tabMenu.ImageList = this.imageList1;
            this.tabMenu.Location = new System.Drawing.Point(2, 12);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(1379, 835);
            this.tabMenu.TabIndex = 0;
            // 
            // tabHeThong
            // 
            this.tabHeThong.Controls.Add(this.tabQlHeThong);
            this.tabHeThong.ImageIndex = 0;
            this.tabHeThong.Location = new System.Drawing.Point(4, 37);
            this.tabHeThong.Name = "tabHeThong";
            this.tabHeThong.Padding = new System.Windows.Forms.Padding(3);
            this.tabHeThong.Size = new System.Drawing.Size(1371, 794);
            this.tabHeThong.TabIndex = 0;
            this.tabHeThong.Text = "Hệ Thống";
            this.tabHeThong.UseVisualStyleBackColor = true;
            // 
            // tabQlHeThong
            // 
            this.tabQlHeThong.Controls.Add(this.tabQlNhanVien);
            this.tabQlHeThong.Controls.Add(this.tabQlGiay);
            this.tabQlHeThong.Controls.Add(this.tabQlHoaDon);
            this.tabQlHeThong.Controls.Add(this.tabQlTaiKhoan);
            this.tabQlHeThong.Controls.Add(this.tabTimKiem);
            this.tabQlHeThong.Controls.Add(this.tabThoat);
            this.tabQlHeThong.ImageList = this.imageList1;
            this.tabQlHeThong.Location = new System.Drawing.Point(4, 7);
            this.tabQlHeThong.Name = "tabQlHeThong";
            this.tabQlHeThong.SelectedIndex = 0;
            this.tabQlHeThong.Size = new System.Drawing.Size(1364, 791);
            this.tabQlHeThong.TabIndex = 0;
            // 
            // tabQlNhanVien
            // 
            this.tabQlNhanVien.Controls.Add(this.label3);
            this.tabQlNhanVien.ImageIndex = 5;
            this.tabQlNhanVien.Location = new System.Drawing.Point(4, 37);
            this.tabQlNhanVien.Name = "tabQlNhanVien";
            this.tabQlNhanVien.Padding = new System.Windows.Forms.Padding(3);
            this.tabQlNhanVien.Size = new System.Drawing.Size(1356, 750);
            this.tabQlNhanVien.TabIndex = 0;
            this.tabQlNhanVien.Text = "Quản Lý Nhân Viên";
            this.tabQlNhanVien.UseVisualStyleBackColor = true;
            // 
            // tabQlGiay
            // 
            this.tabQlGiay.Controls.Add(this.label4);
            this.tabQlGiay.ImageIndex = 3;
            this.tabQlGiay.Location = new System.Drawing.Point(4, 37);
            this.tabQlGiay.Name = "tabQlGiay";
            this.tabQlGiay.Padding = new System.Windows.Forms.Padding(3);
            this.tabQlGiay.Size = new System.Drawing.Size(1356, 750);
            this.tabQlGiay.TabIndex = 1;
            this.tabQlGiay.Text = "Quản Lý Giày";
            this.tabQlGiay.UseVisualStyleBackColor = true;
            // 
            // tabQlHoaDon
            // 
            this.tabQlHoaDon.Controls.Add(this.label5);
            this.tabQlHoaDon.ImageIndex = 4;
            this.tabQlHoaDon.Location = new System.Drawing.Point(4, 37);
            this.tabQlHoaDon.Name = "tabQlHoaDon";
            this.tabQlHoaDon.Padding = new System.Windows.Forms.Padding(3);
            this.tabQlHoaDon.Size = new System.Drawing.Size(1356, 750);
            this.tabQlHoaDon.TabIndex = 2;
            this.tabQlHoaDon.Text = "Quản Lý Hóa Đơn";
            this.tabQlHoaDon.UseVisualStyleBackColor = true;
            // 
            // tabQlTaiKhoan
            // 
            this.tabQlTaiKhoan.Controls.Add(this.label6);
            this.tabQlTaiKhoan.ImageIndex = 6;
            this.tabQlTaiKhoan.Location = new System.Drawing.Point(4, 37);
            this.tabQlTaiKhoan.Name = "tabQlTaiKhoan";
            this.tabQlTaiKhoan.Padding = new System.Windows.Forms.Padding(3);
            this.tabQlTaiKhoan.Size = new System.Drawing.Size(1356, 750);
            this.tabQlTaiKhoan.TabIndex = 3;
            this.tabQlTaiKhoan.Text = "Quản Lý Tài Khoản";
            this.tabQlTaiKhoan.UseVisualStyleBackColor = true;
            // 
            // tabTimKiem
            // 
            this.tabTimKiem.Controls.Add(this.label7);
            this.tabTimKiem.ImageIndex = 8;
            this.tabTimKiem.Location = new System.Drawing.Point(4, 37);
            this.tabTimKiem.Name = "tabTimKiem";
            this.tabTimKiem.Padding = new System.Windows.Forms.Padding(3);
            this.tabTimKiem.Size = new System.Drawing.Size(1356, 750);
            this.tabTimKiem.TabIndex = 4;
            this.tabTimKiem.Text = "Tìm Kiếm";
            this.tabTimKiem.UseVisualStyleBackColor = true;
            // 
            // tabThoat
            // 
            this.tabThoat.ImageIndex = 7;
            this.tabThoat.Location = new System.Drawing.Point(4, 37);
            this.tabThoat.Name = "tabThoat";
            this.tabThoat.Padding = new System.Windows.Forms.Padding(3);
            this.tabThoat.Size = new System.Drawing.Size(1356, 750);
            this.tabThoat.TabIndex = 5;
            this.tabThoat.Text = "Thoát";
            this.tabThoat.UseVisualStyleBackColor = true;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "hethong.jpg");
            this.imageList1.Images.SetKeyName(1, "lienhe.jpg");
            this.imageList1.Images.SetKeyName(2, "gioithieu.png");
            this.imageList1.Images.SetKeyName(3, "giay.png");
            this.imageList1.Images.SetKeyName(4, "hoadon.jpg");
            this.imageList1.Images.SetKeyName(5, "nhanvien.jpg");
            this.imageList1.Images.SetKeyName(6, "taikhoan.jpg");
            this.imageList1.Images.SetKeyName(7, "thoat.jpg");
            this.imageList1.Images.SetKeyName(8, "timkiem.jpg");
            // 
            // tabLienHe
            // 
            this.tabLienHe.Controls.Add(this.label1);
            this.tabLienHe.ImageIndex = 1;
            this.tabLienHe.Location = new System.Drawing.Point(4, 37);
            this.tabLienHe.Name = "tabLienHe";
            this.tabLienHe.Padding = new System.Windows.Forms.Padding(3);
            this.tabLienHe.Size = new System.Drawing.Size(1371, 794);
            this.tabLienHe.TabIndex = 1;
            this.tabLienHe.Text = "Liên Hệ";
            this.tabLienHe.UseVisualStyleBackColor = true;
            // 
            // tabGioiThieu
            // 
            this.tabGioiThieu.Controls.Add(this.label2);
            this.tabGioiThieu.ImageIndex = 2;
            this.tabGioiThieu.Location = new System.Drawing.Point(4, 37);
            this.tabGioiThieu.Name = "tabGioiThieu";
            this.tabGioiThieu.Padding = new System.Windows.Forms.Padding(3);
            this.tabGioiThieu.Size = new System.Drawing.Size(1371, 794);
            this.tabGioiThieu.TabIndex = 2;
            this.tabGioiThieu.Text = "Giới Thiệu";
            this.tabGioiThieu.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "trang liên hệ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(547, 294);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "trang giới thiệu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(496, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "quản lý nhân viên";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(630, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 1;
            this.label4.Text = "quản lý giày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(630, 365);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "quản lý hóa đơn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(630, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 20);
            this.label6.TabIndex = 1;
            this.label6.Text = "quản lý tài khoản";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(630, 365);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 20);
            this.label7.TabIndex = 1;
            this.label7.Text = "tìm kiếm";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1378, 844);
            this.Controls.Add(this.tabMenu);
            this.Name = "Main";
            this.Text = "Main";
            this.tabMenu.ResumeLayout(false);
            this.tabHeThong.ResumeLayout(false);
            this.tabQlHeThong.ResumeLayout(false);
            this.tabQlNhanVien.ResumeLayout(false);
            this.tabQlNhanVien.PerformLayout();
            this.tabQlGiay.ResumeLayout(false);
            this.tabQlGiay.PerformLayout();
            this.tabQlHoaDon.ResumeLayout(false);
            this.tabQlHoaDon.PerformLayout();
            this.tabQlTaiKhoan.ResumeLayout(false);
            this.tabQlTaiKhoan.PerformLayout();
            this.tabTimKiem.ResumeLayout(false);
            this.tabTimKiem.PerformLayout();
            this.tabLienHe.ResumeLayout(false);
            this.tabLienHe.PerformLayout();
            this.tabGioiThieu.ResumeLayout(false);
            this.tabGioiThieu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage tabHeThong;
        private System.Windows.Forms.TabPage tabLienHe;
        private System.Windows.Forms.TabPage tabGioiThieu;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tabQlHeThong;
        private System.Windows.Forms.TabPage tabQlNhanVien;
        private System.Windows.Forms.TabPage tabQlGiay;
        private System.Windows.Forms.TabPage tabQlHoaDon;
        private System.Windows.Forms.TabPage tabQlTaiKhoan;
        private System.Windows.Forms.TabPage tabTimKiem;
        private System.Windows.Forms.TabPage tabThoat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
    }
}