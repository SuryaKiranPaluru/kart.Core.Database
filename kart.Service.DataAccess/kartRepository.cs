using kart.Core.Dto.RequestModel;
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

        IEnumerable<CartRequestModel> IkartRepository.ViewItemsInCart(int sessionId)
        {
            var res = (from c in _context.Carts
                       where c.SessionId == sessionId
                       select new
                       {
                           SessionId = sessionId,
                           ProductId = c.ProductId,
                           Quantity = c.Quantity,
                           UserId = c.UserId
                       });
            return (IEnumerable<CartRequestModel>)res;
            //            return (IEnumerable<CartRequestModel>)_context.Carts.Where(_c => _c.SessionId == sessionId);

        }
    }
}
