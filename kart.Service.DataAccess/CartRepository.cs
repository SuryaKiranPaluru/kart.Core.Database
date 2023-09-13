using kart.Core.Dto.RequestModel;
using kart.Core.Dto.ResponseModel;
using kart.Service.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Service.DataAccess
{
    public class CartRepository: ICartRepository
    {
        private readonly kartContext _context;

        public CartRepository(kartContext context) 
        {
            _context = context;
        }
        public void AddProductToCart(CartRequestModel product)
        {
            _context.Carts.Add(new Cart
            {
                SessionId = product.SessionId,
                ProductId = product.ProductId,
                UserId = product.UserId,
                Quantity = product.Quantity,
            });

            _context.SaveChanges();
        }

        void ICartRepository.RemoveProductFromCart(int productId)
        {
            var itemToRemove = _context.Carts.Where(r => r.ProductId == productId)
                           .FirstOrDefault();

            _context.Carts.Remove(itemToRemove);

            _context.SaveChanges();
        }

        void ICartRepository.ModifyProductInCart(int productid, int quantity)
        {
            var itemToModify = _context.Carts.Where(r => r.ProductId == productid)
                                .FirstOrDefault();

            itemToModify.Quantity += quantity;

            _context.SaveChanges();
        }

        CartResponseModel ICartRepository.ViewItemsInCart(int sessionId)
        {
            var cartItems = (from c in _context.Carts
                             where c.SessionId == sessionId
                             select c).ToList();
            var cart = new CartResponseModel();
            decimal totalAmount = (decimal)0.0;

            foreach (Cart item in cartItems)
            {

                var price = (from p in _context.Products
                where item.ProductId == p.ProductId
                             select p.Price).FirstOrDefault();

                var discount = (from p in _context.Products
                                where item.ProductId == p.ProductId
                                select p.Discount).FirstOrDefault();

                var sellingPrice = price - ((price * discount) / 100);



                var _cartItemnew = new CartItemResponseModel
                {
                    ProductName = (from p in _context.Products
                                   where item.ProductId == p.ProductId
                                   select p.ProductName).FirstOrDefault(),

                    Quantity = item.Quantity,

                    Current_Price = sellingPrice
                };

                totalAmount += (decimal)(sellingPrice * item.Quantity);

                cart.Items.Add(_cartItemnew);
            }

            cart.TotalAmount = totalAmount;
            return cart;
        }

    }
}
