using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyShopGiay.Models
{
    [Table("NhanVien")]
    public class NhanVien
    {
        [Key]
        public int MaNV { get; set; }

        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string SoDT { get; set; }

        // Quan hệ 1-n
        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public NhanVien()
        {
            TaiKhoans = new HashSet<TaiKhoan>();
            HoaDons = new HashSet<HoaDon>();
        }
    }
}
