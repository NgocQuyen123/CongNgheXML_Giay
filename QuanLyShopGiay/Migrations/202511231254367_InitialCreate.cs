namespace QuanLyShopGiay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietHoaDons",
                c => new
                    {
                        MaCTHD = c.Int(nullable: false, identity: true),
                        MaHD = c.Int(nullable: false),
                        MaGiay = c.Int(nullable: false),
                        KichCo = c.Int(nullable: false),
                        SoLuongMua = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaCTHD)
                .ForeignKey("dbo.Giays", t => t.MaGiay, cascadeDelete: true)
                .ForeignKey("dbo.HoaDons", t => t.MaHD, cascadeDelete: true)
                .Index(t => t.MaHD)
                .Index(t => t.MaGiay);
            
            CreateTable(
                "dbo.Giays",
                c => new
                    {
                        MaGiay = c.Int(nullable: false, identity: true),
                        TenGiay = c.String(),
                        ThuongHieu = c.String(),
                        KichCo = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                        Gia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaGiay);
            
            CreateTable(
                "dbo.HoaDons",
                c => new
                    {
                        MaHD = c.Int(nullable: false, identity: true),
                        MaKH = c.Int(nullable: false),
                        MaNV = c.Int(nullable: false),
                        NgayLap = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MaHD)
                .ForeignKey("dbo.KhachHangs", t => t.MaKH, cascadeDelete: true)
                .ForeignKey("dbo.NhanViens", t => t.MaNV, cascadeDelete: true)
                .Index(t => t.MaKH)
                .Index(t => t.MaNV);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        MaKH = c.Int(nullable: false, identity: true),
                        HoTen = c.String(),
                        DiaChi = c.String(),
                        SoDT = c.String(),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        MaNV = c.Int(nullable: false, identity: true),
                        HoTen = c.String(),
                        DiaChi = c.String(),
                        SoDT = c.String(),
                    })
                .PrimaryKey(t => t.MaNV);
            
            CreateTable(
                "dbo.TaiKhoans",
                c => new
                    {
                        MaTK = c.Int(nullable: false, identity: true),
                        TenTaiKhoan = c.String(nullable: false, maxLength: 50),
                        MatKhau = c.String(),
                        QuyenHan = c.String(),
                        MaNV = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaTK)
                .ForeignKey("dbo.NhanViens", t => t.MaNV, cascadeDelete: true)
                .Index(t => t.MaNV);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChiTietHoaDons", "MaHD", "dbo.HoaDons");
            DropForeignKey("dbo.HoaDons", "MaNV", "dbo.NhanViens");
            DropForeignKey("dbo.TaiKhoans", "MaNV", "dbo.NhanViens");
            DropForeignKey("dbo.HoaDons", "MaKH", "dbo.KhachHangs");
            DropForeignKey("dbo.ChiTietHoaDons", "MaGiay", "dbo.Giays");
            DropIndex("dbo.TaiKhoans", new[] { "MaNV" });
            DropIndex("dbo.HoaDons", new[] { "MaNV" });
            DropIndex("dbo.HoaDons", new[] { "MaKH" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaGiay" });
            DropIndex("dbo.ChiTietHoaDons", new[] { "MaHD" });
            DropTable("dbo.TaiKhoans");
            DropTable("dbo.NhanViens");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.HoaDons");
            DropTable("dbo.Giays");
            DropTable("dbo.ChiTietHoaDons");
        }
    }
}
