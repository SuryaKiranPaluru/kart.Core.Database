using kart.Core.Dto.RequestModel;
using kart.Core.Dto.ResponseModel;
using kart.Service.DataAccess;
using kart.Service.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Service.Buisness
{
    public class CartService: ICartService
    {
        public readonly ICartRepository _repository;

        public CartService(ICartRepository repository)
        {
            _repository = repository;
        }

        public void AddProductToCart(CartRequestModel product)
        {
            _repository.AddProductToCart(product);
        }

        void ICartService.RemoveProductFromCart(int productId)
        {
            _repository.RemoveProductFromCart(productId);
        }

        void ICartService.ModifyProductInCart(int productid, int quantity)
        {
            _repository.ModifyProductInCart(productid, quantity);
        }

        CartResponseModel ICartService.ViewItemsInCart(int sessionId)
        {
            return _repository.ViewItemsInCart(sessionId);
        }
    }
}
