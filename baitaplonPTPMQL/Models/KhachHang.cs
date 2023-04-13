using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baitaplonPTPMQL.Models
{
    public class KhachHang
    {
        [Key]
        [Display (Name = "Mã khách hàng")]
        [Required(ErrorMessage ="Mã khách hàng không được bỏ trống")]
        public string? MaKhachHang {get; set;} 
        [Display (Name = "Tên khách hàng")]
        [Required(ErrorMessage ="Tên khách hàng không được bỏ trống")] 
        public string? TenKhachHang {get; set;}
        [Display (Name = "Ngày sinh")]
        public DateTime Ngaysinh {get; set;}
        [Display (Name = "Giới tính")]
        public string? TenGioiTinh {get; set;}
        [ForeignKey ("TenGioiTinh")] 
        [Display (Name = "Giới tính")]
        public GioiTinh? GioiTinh {get; set;}
        [Display (Name = "Địa chỉ")]
        public string? Diachi {get; set;}
        [Display (Name = "Chứng minh nhân dân")]
        [Required(ErrorMessage ="Số chứng minh không được bỏ trống")] 
        public string? CMND {get; set;}
        [Display (Name = "Số điện thoại")]
        [Required(ErrorMessage ="Số điện thoại không được bỏ trống")] 
        [MinLength(10)]// do dai toi thieu
        public string? SoDienThoai {get; set;}
    }
}