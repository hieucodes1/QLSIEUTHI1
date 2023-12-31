using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLSIEUTHI1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [System.ComponentModel.DisplayName("Tên sản phẩm")]
        public string? Name { get; set; }
        public string? Description { get; set; } //mô tả
        public string? ImageUrl { get; set; } //ảnh
        public decimal Price { get; set; } //giá cả
        public int Quantity { get; set; } //số lượng

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual Category? category { get; set; } //loại
    }
}
