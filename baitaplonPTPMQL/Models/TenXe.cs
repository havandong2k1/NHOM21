using System.ComponentModel.DataAnnotations;
namespace baitaplonPTPMQL.Models
{
    public class TenXe 
    {
        [Key]
        public string? XeID {get; set;}
        [Display (Name = "Tên xe - Biển số")]
        public string? TenXe_BienSo {get; set;}
    }
}