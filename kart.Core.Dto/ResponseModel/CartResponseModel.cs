using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Core.Dto.ResponseModel
{
    public class CartResponseModel

    {
        public int SessionId { get; set; }

        public int ProductId { get; set; }

        public int UserId { get; set; }

        public int Quantity { get; set; }
    }
}
