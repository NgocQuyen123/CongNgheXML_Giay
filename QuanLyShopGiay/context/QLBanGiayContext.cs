using System.Data.Entity;
using QuanLyShopGiay.Models;

namespace QuanLyShopGiay.context
{
    public class QLBanGiayContext : DbContext
    {
        public QLBanGiayContext() : base("name=QLBanGiayConnection")
        {
            // Tắt Lazy Loading để tránh lỗi DataGridView khi DbContext bị dispose
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<TaiKhoan> TaiKhoans { get; set; }
        public DbSet<Giay> Giays { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
