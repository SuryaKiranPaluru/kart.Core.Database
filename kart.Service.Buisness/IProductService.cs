using kart.Core.Dto.RequestModel;
using kart.Core.Dto.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Service.Buisness
{
    public interface IProductService
    {
        public void AddNewProduct(ProductRequestModel product);

        public void DeleteProduct(int productid);

        public void ModifyProduct(int productid, string itemToModify, string value);
    }
}
