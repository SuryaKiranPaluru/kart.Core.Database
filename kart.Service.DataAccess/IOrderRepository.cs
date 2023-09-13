using kart.Core.Dto.RequestModel;
using kart.Core.Dto.ResponseModel;
using kart.Service.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Service.DataAccess
{
    public interface IOrderRepository
    { 

        public void PlaceOrder(OrderRequestModel order);
        
    }
}
