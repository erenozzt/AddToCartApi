using AddToCart.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddToCart.Data.Repositories.Abstract
{
    public interface IProductRepository
    {
        Product AddInventoryItem(Product item);
        List<Product> GetProducts();
    }
}
