using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Core.Dto.RequestModel
{
    public class OrderRequestModel
    {
        public int UserId { get; set; }

        public required string PaymentMethod { get; set; }

        public required string ShipmentAddress { get; set; }
    }
}
