using System.ComponentModel.DataAnnotations;
namespace baitaplonPTPMQL.Models
{
    public class BangGia
    {
        [Key]
        public string? GiaID {get; set;}
        [Display (Name = "Giá vé")]
        public string? GiaVe {get; set;}
    }
}