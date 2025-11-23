using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyShopGiay.Models
{
    [Table("TaiKhoan")]
    public class TaiKhoan
    {
        [Key]
        public int MaTK { get; set; }

        [Required, StringLength(50)]
        public string TenTaiKhoan { get; set; }

        public string MatKhau { get; set; }
        public string QuyenHan { get; set; }

        [ForeignKey("NhanVien")]
        public int MaNV { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
