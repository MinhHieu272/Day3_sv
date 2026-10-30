using System.ComponentModel.DataAnnotations;
namespace Day3_sv.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, MinimumLength =2, ErrorMessage = "Tên danh mục phải từ 2 đến 100 ký tự")]
        public string Name { get; set; } = string.Empty;
        public List<Product> Products { get; set; }
    }
}
