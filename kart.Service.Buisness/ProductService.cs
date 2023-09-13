using AutoMapper;
using kart.Core.Dto.RequestModel;
using kart.Core.Dto.ResponseModel;
using kart.Service.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Service.Buisness
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        void IProductService.AddNewProduct(ProductRequestModel product)
        {
            _repository.AddNewProduct(product);
        }

        void IProductService.DeleteProduct(int productid)
        {
            _repository.DeleteProduct(productid);
        }

        void IProductService.ModifyProduct(int productid, string itemToModify, string value)
        {
            _repository.ModifyProduct(productid, itemToModify, value);
        }
    }
}
