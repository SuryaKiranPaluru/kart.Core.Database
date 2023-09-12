using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Core.Dto.ResponseModel
{

    public class CartResponseModel
    {
        public decimal TotalAmount { get; set; }
        public List<CartItemResponseModel> Items { get; set; } = new List<CartItemResponseModel>();

    }

    public class CartItemResponseModel
    {
        public string ProductName { get; set; } = null!;

        public int Quantity { get; set; }

        public decimal? Current_Price { get; set; }


    }
}
