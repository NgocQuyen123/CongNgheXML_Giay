using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyShopGiay.Models
{
    [Table("Giay")]
    public class Giay
    {
        [Key]
        public int MaGiay { get; set; }

        public string TenGiay { get; set; }
        public string ThuongHieu { get; set; }
        public int KichCo { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }

        // Quan hệ 1-n
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public Giay()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }
    }
}
