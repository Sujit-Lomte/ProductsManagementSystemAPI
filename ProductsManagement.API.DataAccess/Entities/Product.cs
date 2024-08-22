using System.ComponentModel.DataAnnotations;

namespace ProductsManagement.API.DataAccess.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public Decimal ProductPrice { get; set; }
        [Required]
        public int ProductQuantity { get; set; } 
    }
}
