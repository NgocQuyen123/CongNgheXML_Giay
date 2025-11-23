using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyShopGiay.Models
{
    [Table("ChiTietHoaDon")]
    public class ChiTietHoaDon
    {
        [Key]
        public int MaCTHD { get; set; }

        [ForeignKey("HoaDon")]
        public int MaHD { get; set; }

        [ForeignKey("Giay")]
        public int MaGiay { get; set; }

        public int KichCo { get; set; }
        public int SoLuongMua { get; set; }

        public virtual HoaDon HoaDon { get; set; }
        public virtual Giay Giay { get; set; }
    }
}
