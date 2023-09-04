using kart.Core.Dto.RequestModel;
using kart.Core.Dto.ResponseModel;
using kart.Service.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Service.DataAccess
{
    public interface IkartRepository
    {
        public IEnumerable<Product> GetProductsByTitle(string title);

        public IEnumerable<Product> GetProductsByCategory(int categoryId);

        public IEnumerable<Product> GetAllProducts();

        public void AddProductToCart(CartRequestModel product);
        
    }
}
