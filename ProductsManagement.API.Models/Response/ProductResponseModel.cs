using Newtonsoft.Json;

namespace ProductsManagement.API.Models.Response
{
    public class ProductResponseModel
    {
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string? ProductName { get; set; }

        [JsonProperty("Price")]
        public Decimal? ProductPrice { get; set; }

        [JsonProperty("Quantity")]
        public int? ProductQuantity { get; set; }
    }
}
