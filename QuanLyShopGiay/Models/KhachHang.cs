using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyShopGiay.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }

        public string HoTen { get; set; }
        public string DiaChi { get; set; }
        public string SoDT { get; set; }

        // Quan hệ 1-n
        public virtual ICollection<HoaDon> HoaDons { get; set; }

        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }
    }
}
