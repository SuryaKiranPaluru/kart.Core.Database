
using AutoMapper;
using kart.Core.Dto.RequestModel;
using kart.Core.Dto.ResponseModel;
using kart.Service.DataAccess;
using kart.Service.Domain.Models;

namespace kart.Service.Buisness
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;

        public OrderService(IOrderRepository repository)
        {
            _repository = repository;
        }


        void IOrderService.PlaceOrder(OrderRequestModel order)
        {
            _repository.PlaceOrder(order);  
        }
    }
}
