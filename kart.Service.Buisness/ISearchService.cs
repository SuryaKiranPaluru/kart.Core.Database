using kart.Core.Dto.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Service.Buisness
{
    public interface ISearchService
    {
        public IEnumerable<ProductResponseModel> GetProductsByTitle(string title);

        public IEnumerable<ProductResponseModel> GetAllProducts();

        public IEnumerable<ProductResponseModel> GetProductsByCategory(int categoryId);
    }
}
