using System.Data.Entity;
using QuanLyShopGiay.Models;

namespace QuanLyShopGiay.context
{
    public class QLBanGiayContext : DbContext
    {
        public QLBanGiayContext() : base("name=QLBanGiayConnection") { }

        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<Giay> Giays { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Nếu muốn Fluent API mapping nâng cao thì viết ở đây
            base.OnModelCreating(modelBuilder);
        }
    }
}
