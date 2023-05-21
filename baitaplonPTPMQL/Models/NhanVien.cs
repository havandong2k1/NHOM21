using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baitaplonPTPMQL.Models
{
    public class NhanVien
    {
        [Key]
        [Display (Name = "Mã nhân viên")]
        [Required(ErrorMessage ="Mã nhân viên không được bỏ trống")]
        public string? MaNhanVien {get; set;} 
        [Display (Name = "Tên nhân viên")]
        [Required(ErrorMessage ="Tên nhân viên không được bỏ trống")] 
        public string? TenNhanVien {get; set;}
        [Display (Name = "Ngày sinh")]
        [DataType(DataType.Date)]
        public DateTime? Ngaysinh {get; set;}
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