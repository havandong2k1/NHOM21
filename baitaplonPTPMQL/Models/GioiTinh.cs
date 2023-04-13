using System.ComponentModel.DataAnnotations;

namespace baitaplonPTPMQL.Models
{
    public class GioiTinh
    {
        public string? ID {get; set;}
        [Display (Name = "Giới tính")]
        public string? TenGioiTinh {get; set;}
    }
}