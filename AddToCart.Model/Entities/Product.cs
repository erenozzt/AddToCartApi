using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddToCart.Model.Entities
{
    public class Product
    {
        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("details")]
        public string Details { get; set; }

        [JsonProperty("productName")]
        public string ProductName { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }
        [JsonProperty("stock")]
        public int Stock { get; set; }
    }
}
