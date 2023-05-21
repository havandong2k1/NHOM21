using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace baitaplonPTPMQL.Models
{
    public class ChuyenXe
    {
        [Key]
        [Display (Name = "Mã chuyến xe")]
        [Required(ErrorMessage ="Mã chuyến xe không được bỏ trống")]
        public string? MaChuyenXe {get; set;} 
        [Display (Name = "Tên chuyến xe")]
        public string? TenChuyenXe {get; set;}
        [Display (Name = "Ngày đi")]
        [DataType(DataType.Date)]
        public DateTime NgayDi {get; set;}
        [Display (Name = "Điểm đi")]
        public string? DiemDi {get; set;} 
        [Display (Name = "Điểm đến")]
        public string? DiemDen {get; set;}
        [Display (Name = "Mã tài xế")]
        [Required(ErrorMessage ="Mã tài xế không được bỏ trống")] 
        public string? MaTaiXe {get; set;}
        [ForeignKey("MaTaiXe")]
        [Display (Name = "Mã tài xế")]
        public TaiXe? TaiXe {get; set;}
        [Display (Name = "Giá vé")]
        public string? GiaID {get; set;} 
        [ForeignKey("GiaID")]
        [Display (Name = "Giá vé")]
        public BangGia? BangGia {get; set;}
    }
}