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
    public class SearchRepository: ISearchRepository
    {

        private readonly kartContext _context;

        public SearchRepository(kartContext context) 
        {
            _context = context;
        }

        IEnumerable<Product> ISearchRepository.GetAllProducts()
        {
            return _context.Products.Where(p => p.StockQuantity > 0);
        }

        IEnumerable<Product> ISearchRepository.GetProductsByTitle(string title)
        {
            return _context.Products.Where(c => c.ProductName.Contains(title));
        }

        IEnumerable<Product> ISearchRepository.GetProductsByCategory(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId);

        }

        
    }
}
