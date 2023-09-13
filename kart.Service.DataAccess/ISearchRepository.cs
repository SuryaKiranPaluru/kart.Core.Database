using kart.Core.Dto.ResponseModel;
using kart.Service.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Service.DataAccess
{
    public interface ISearchRepository
    {
        public IEnumerable<Product> GetProductsByTitle(string title);

        public IEnumerable<Product> GetProductsByCategory(int categoryId);

        public IEnumerable<Product> GetAllProducts();

    }
}
