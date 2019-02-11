using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductStore.Infrastructured;
using ProductStore.Models;
using ProductStore.Models.ViewModels;

namespace ProductStore.Controllers
{
    public class CartController:Controller
    {
        private readonly IRepository _repository;

        public CartController(IRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index(string returnUrl) => View(new CartIndexViewModel
        {
            Cart = GetCart(),
            ReturnUrl = returnUrl
        });

        public IActionResult AddToCart(int productId)
        {
            var product = from r in _repository.Product where r.ProductID.Equals(productId) select r;
            if (product.Any())
            {
                Cart cart = GetCart();
                cart.AddItem(product.FirstOrDefault(),1);
                SaveCart(cart);
            }

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCart(int productId, int quantity)
        {
            Cart cart = GetCart();
            cart.RemoveItem(productId,quantity);
            SaveCart(cart);
            return RedirectToAction("Index");
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            return cart;
        }
        private void SaveCart(Cart cart)
        {
            HttpContext.Session.SetJson("Cart",cart);
        }

    }
}
