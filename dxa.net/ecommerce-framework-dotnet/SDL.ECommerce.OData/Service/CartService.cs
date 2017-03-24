﻿using Sdl.ECommerce.Api.Service;

using System.Linq;

using Sdl.ECommerce.Api.Model;
using Sdl.Web.Delivery.Service;

namespace Sdl.ECommerce.OData
{
    public class CartService : ICartService
    {
        private IECommerceODataV4Service service;

        internal CartService(IECommerceODataV4Service service)
        {
            this.service = service;
        }

        public ICart CreateCart()
        {
            ODataV4ClientFunction func = new ODataV4ClientFunction("CreateCart");
            func.AllowCaching = false;
            return Enumerable.FirstOrDefault<Cart>(this.service.Execute<Cart>(func));
        }

        public ICart AddProductToCart(ICart cart, string productId, int quantity)
        {
            ODataV4ClientFunction func = new ODataV4ClientFunction("AddProductToCart");
            func.AllowCaching = false;
            func.WithParam("cartId", cart.Id);
            func.WithParam("sessionId", cart.SessionId);
            func.WithParam("productId", productId);
            func.WithParam("quantity", quantity);
            return Enumerable.FirstOrDefault<Cart>(this.service.Execute<Cart>(func));
        }

        public ICart RemoveProductFromCart(ICart cart, string productId)
        {
            ODataV4ClientFunction func = new ODataV4ClientFunction("RemoveProductFromCart");
            func.AllowCaching = false;
            func.WithParam("cartId", cart.Id);
            func.WithParam("sessionId", cart.SessionId);
            func.WithParam("productId", productId);
            return Enumerable.FirstOrDefault<Cart>(this.service.Execute<Cart>(func));
        }
    }
}
