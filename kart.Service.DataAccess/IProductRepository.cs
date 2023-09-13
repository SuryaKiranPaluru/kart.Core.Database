using kart.Core.Dto.RequestModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Service.DataAccess
{
    public interface IProductRepository
    {
        public void AddNewProduct(ProductRequestModel product);

        public void DeleteProduct(int productid);

        public void ModifyProduct(int productid, string itemToModify, string value);
    }
}
