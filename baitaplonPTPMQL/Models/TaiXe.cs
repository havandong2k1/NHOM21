using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace baitaplonPTPMQL.Models
{
    public class TaiXe
    {
        [Key]
        [Display (Name = "Mã tài xế")]
        [Required(ErrorMessage ="Mã tài xế không được bỏ trống")]
        public string? MaTaiXe {get; set;} 
        [Display (Name = "Tên tài xế")]
        [Required(ErrorMessage ="Tên tài xế không được bỏ trống")] 
        public string? TenTaiXe {get; set;}
        [Display (Name = "Ngày sinh")]
        [DataType(DataType.Date)]
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