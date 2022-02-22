using AddToCart.Data.Repositories.Abstract;
using AddToCart.Model.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddToCart.Data.Repositories.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepository()
        {
            _products = new List<Product>();
        }

        public Product AddInventoryItem(Product item)
        {
            _products.Add(item);
            return item;
        }

        public List<Product> GetProducts()
        {
            List<Product> items = new List<Product>();
            var currentDirectory = System.IO.Directory.GetCurrentDirectory();
            using (StreamReader r = new StreamReader(currentDirectory + @"\Content\flowers.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<Product>>(json);
            }
            return items;
        }
    }
}
