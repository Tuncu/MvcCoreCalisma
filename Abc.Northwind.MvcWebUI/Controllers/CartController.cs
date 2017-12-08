using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Entities.Concrate;
using Abc.Northwind.MvcWebUI.Models;
using Abc.Northwind.MvcWebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Abc.Northwind.MvcWebUI.Controllers
{
    public class CartController : Controller
    {
        private ICartSessionService _cartSessionService;
        private ICartService _cartService;
        private IProductService _productService;
        public CartController(ICartSessionService cartSessionService,IProductService productService,ICartService cartService)
        {
            _cartSessionService = cartSessionService;
            _cartService = cartService;
            _productService = productService;
        }

     

        public IActionResult AddToCart(int productId)
        {
            var productToAdded = _productService.GetById(productId);
            var cart = _cartSessionService.GetCart();
            _cartService.AddToCart(cart, productToAdded);
            _cartSessionService.SetCart(cart);

            TempData.Add("message",string.Format("{0} başarı ile sepete eklendi",productToAdded.ProductName));

            return RedirectToAction("Index", "Product");
        }
        public IActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            CartListViewModel cartListViewModel = new CartListViewModel()
            {
                Cart = cart
            };
            return View(cartListViewModel);
        }
        public IActionResult Remove(int productId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, productId);
            _cartSessionService.SetCart(cart);

            TempData.Add("message", "Ürün silindi");
            return RedirectToAction("List");
        }
        public IActionResult Complete()
        {
            var shippingDetailsViewModel = new ShippingDetailsViewModel
            {
                ShippingDetails = new ShippingDetails()
            };
            return View(shippingDetailsViewModel);
        }
        [HttpPost]
        public IActionResult Complete(ShippingDetails shippingDetails)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            TempData.Add("message", "Alışverişiniz tamamlanmıştır");
            return View();
        }
    }
}