using kart.Core.Dto.RequestModel;
using kart.Core.Dto.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Service.DataAccess
{
    public interface ICartRepository
    {
        public void AddProductToCart(CartRequestModel product);

        public void RemoveProductFromCart(int productId);

        public void ModifyProductInCart(int productid, int quantity);

        public CartResponseModel ViewItemsInCart(int sessionId);
    }
}
