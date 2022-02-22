using AddToCart.Core.Helpers;
using AddToCart.Data.Repositories.Abstract;
using AddToCart.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AddToCart.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBasketController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductBasketController(IProductRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        [Route("GetAllProducts")]
        public IActionResult GetInventoryItems()
        {
            return Ok(_repository.GetProducts());
        }

        [HttpPost]
        [Route("AddToCart")]
        public IActionResult AddToCart(Cart addToCart)
        {
            if (ModelState.IsValid)
            {
                var product = _repository.GetProducts().Where(a => a.ProductId == addToCart.ProductId).FirstOrDefault();
                var getSessionObject = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
                List<Cart> cart = new List<Cart>();
                if (product != null && product.Stock > addToCart.Quantity && getSessionObject == null)
                {
                    cart.Add(new Cart { ProductId = addToCart.ProductId, Quantity = addToCart.Quantity });
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
                else
                {
                    cart = getSessionObject;
                    int index = isExist(product.ProductId);
                    if (index != -1)
                        if (product.Stock >= (cart[index].Quantity + addToCart.Quantity))
                            cart[index].Quantity += addToCart.Quantity;
                        else
                           return NotFound("insufficient stock");
                    else
                        cart.Add(new Cart { ProductId = addToCart.ProductId, Quantity = addToCart.Quantity });
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                }
            }

            return Ok();
        }

        private int isExist(int id)
        {
            List<Cart> cart = SessionHelper.GetObjectFromJson<List<Cart>>(HttpContext.Session, "cart");
            if (cart != null)
            {
                for (int i = 0; i < cart.Count; i++)
                {
                    if (cart[i].ProductId.Equals(id))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}
