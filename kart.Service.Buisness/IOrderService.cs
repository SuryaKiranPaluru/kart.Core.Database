using kart.Core.Dto.RequestModel;
using kart.Core.Dto.ResponseModel;
using kart.Service.Domain.Models;


namespace kart.Service.Buisness
{
    public interface IOrderService
    {

        public void PlaceOrder(OrderRequestModel order);
    }
}