using kart.Core.Dto.RequestModel;
using kart.Service.Domain.Models;
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
            return _context.Products;
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
    }
}
