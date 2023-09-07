using kart.Core.Dto.RequestModel;
using kart.Core.Dto.ResponseModel;
using kart.Service.Domain.Models;


namespace kart.Service.Buisness
{
    public interface IkartService
    {
        public IEnumerable<ProductResponseModel> GetProductsByTitle(string title);

        public IEnumerable<ProductResponseModel> GetAllProducts();

        public IEnumerable<ProductResponseModel> GetProductsByCategory(int categoryId);

        public void AddProductToCart(CartRequestModel product);

        public void RemoveProductFromCart(int productId);

        public void ModifyProductInCart(int productid, int quantity);

        public IEnumerable<CartRequestModel> ViewItemsInCart(int sessionId);
    }
}