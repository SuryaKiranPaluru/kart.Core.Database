
using AutoMapper;
using kart.Core.Dto.RequestModel;
using kart.Core.Dto.ResponseModel;
using kart.Service.DataAccess;
using kart.Service.Domain.Models;

namespace kart.Service.Buisness
{
    public class kartService : IkartService
    {
        private readonly IkartRepository _repository;
        private readonly IMapper _mapper;

        public kartService(IkartRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        IEnumerable<ProductResponseModel> IkartService.GetAllProducts()
        {
            return _mapper.Map<IEnumerable<ProductResponseModel>>( _repository.GetAllProducts()) ;
        }

        IEnumerable<ProductResponseModel> IkartService.GetProductsByCategory(int categoryId)
        {
            return _mapper.Map<IEnumerable<ProductResponseModel>>(_repository.GetProductsByCategory(categoryId));
        }

        IEnumerable<ProductResponseModel> IkartService.GetProductsByTitle(string title)
        {
            return _mapper.Map<IEnumerable<ProductResponseModel>>(_repository.GetProductsByTitle(title));
        }



        public void AddProductToCart(CartRequestModel product)
        {
            _repository.AddProductToCart(product);
        }
            
    }
}
