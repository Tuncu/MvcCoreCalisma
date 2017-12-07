using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.Northwind.Entities.Concrate;
using Abc.Northwind.MvcWebUI.ExtensionMethods;
using Microsoft.AspNetCore.Http;

namespace Abc.Northwind.MvcWebUI.Services
{
    public class CartSessionService : ICartSessionService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CartSessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Cart GetCart()
        {
            Cart cartToCheack=_httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");

            if (cartToCheack == null)
            {
                _httpContextAccessor.HttpContext.Session.SetObject("cart", new Cart());
                cartToCheack = _httpContextAccessor.HttpContext.Session.GetObject<Cart>("cart");
            }
                

            return cartToCheack;
        }

        public void SetCart(Cart cart)
        {
            _httpContextAccessor.HttpContext.Session.SetObject("cart", cart);
        }
    }
}
