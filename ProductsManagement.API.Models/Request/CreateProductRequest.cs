using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ProductsManagement.API.Models.Request
{
    public class CreateProductRequest
    {
        [Required(ErrorMessage = "Product Name is required")]
        //[JsonProperty("Name")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Product Price is required")]
        //[JsonProperty("Price")]
        public Decimal ProductPrice { get; set; }

        [Required(ErrorMessage = "Product Quantity is required")]
        //[JsonProperty("Quantity")]
        public int ProductQuantity { get; set; }
    }
}