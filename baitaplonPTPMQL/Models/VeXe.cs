using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace baitaplonPTPMQL.Models
{
    public class VeXe
    {
        [Key]
        [Display (Name = "Mã vé xe")]
        [Required(ErrorMessage ="Mã xe không được bỏ trống")]
        public string? MaVe {get; set;} 
        [Display (Name = "Tên vé xe")]
        public string? TenVe {get; set;}
        [Display (Name = "Tên xe - Biển số")]       
        public string? TenXe_BienSo {get; set;}
        [ForeignKey ("TenXe_BienSo")]
        [Display (Name = "Tên xe - Biển số")]
        public TenXe? TenXe {get; set;}
        [Display (Name = "Mã nhân viên")]
        public string? MaNhanVien {get; set;}
        [ForeignKey ("MaNhanVien")]
        [Display (Name = "Mã nhân viên")]
        public NhanVien? NhanVien {get; set;}
        [Display (Name = "Mã khách hàng")]
        public string? MaKhachHang {get; set;}
        [ForeignKey ("MaKhachHang")]
        [Display (Name = "Mã khách hàng")]
        public KhachHang? KhachHang {get; set;}
    }
}