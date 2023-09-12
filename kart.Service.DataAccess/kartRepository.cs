using kart.Core.Dto.RequestModel;
using kart.Core.Dto.ResponseModel;
using kart.Service.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Service.DataAccess
{
    public class kartRepository : IkartRepository
    {

        private readonly kartContext _context;

        public kartRepository(kartContext context)
        {
            _context = context;
        }

        IEnumerable<Product> IkartRepository.GetAllProducts()
        {
            return _context.Products.Where(p => p.StockQuantity>0);
        }

        IEnumerable<Product> IkartRepository.GetProductsByTitle(string title)
        {
            return _context.Products.Where(c => c.ProductName == title);
        }

        IEnumerable<Product> IkartRepository.GetProductsByCategory(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId);
                     
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

        void IkartRepository.RemoveProductFromCart(int productId)
        {
            var itemToRemove = _context.Carts.Where(r => r.ProductId == productId)
                           .FirstOrDefault();

            _context.Carts.Remove(itemToRemove);

            _context.SaveChanges();
        }

        void IkartRepository.ModifyProductInCart(int productid, int quantity)
        {
            var itemToModify = _context.Carts.Where(r => r.ProductId == productid)
                                .FirstOrDefault();

            itemToModify.Quantity += quantity;

            _context.SaveChanges();

        }

        CartResponseModel IkartRepository.ViewItemsInCart(int sessionId)
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

        void IkartRepository.AddNewProduct(ProductRequestModel product)
        {
            _context.Products.Add(new Product
            {
                ProductName = product.ProductName,
                ProductDesc = product.ProductDesc,
                CategoryId = product.CategoryId,
                StockQuantity = product.StockQuantity,
                Discount = product.Discount,
                Price = product.Price,
                UserId = product.UserId
            });

            _context.SaveChanges();
        }

        void IkartRepository.DeleteProduct(int productid)
        {
            var itemToRemove = _context.Products.Where(r => r.ProductId == productid)
                           .FirstOrDefault();

            _context.Products.Remove(itemToRemove);

            _context.SaveChanges();
        }

        void IkartRepository.ModifyProduct(int productid, string itemToModify, string value)
        {
            var item = _context.Products.Where(r => r.ProductId == productid)
                                .FirstOrDefault();

            switch (itemToModify.ToLower())
            {
                case "productname":
                    item.ProductName = value; break;

                case "product description":
                    item.ProductDesc = value; break;

                case "stockquantity":
                    item.StockQuantity = int.Parse(value); break;

                case "discount":
                    item.Discount = int.Parse(value); break;

                case "price":
                    item.Price = decimal.Parse(value); break;
            }

            _context.SaveChanges();
        }
    
        
    
    
    }
}
