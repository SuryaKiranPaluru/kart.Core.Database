using AutoMapper;
using kart.Core.Dto.ResponseModel;
using kart.Service.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Service.Buisness
{
    public class SearchService: ISearchService
    {
        private readonly ISearchRepository _repository;
        private readonly IMapper _mapper;

        public SearchService(ISearchRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        IEnumerable<ProductResponseModel> ISearchService.GetAllProducts()
        {
            return _mapper.Map<IEnumerable<ProductResponseModel>>(_repository.GetAllProducts());
        }

        IEnumerable<ProductResponseModel> ISearchService.GetProductsByCategory(int categoryId)
        {
            return _mapper.Map<IEnumerable<ProductResponseModel>>(_repository.GetProductsByCategory(categoryId));
        }

        IEnumerable<ProductResponseModel> ISearchService.GetProductsByTitle(string title)
        {
            return _mapper.Map<IEnumerable<ProductResponseModel>>(_repository.GetProductsByTitle(title));
        }
    }
}
