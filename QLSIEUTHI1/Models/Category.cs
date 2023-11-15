using System.ComponentModel.DataAnnotations;

namespace QLSIEUTHI1.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }

    }
}
