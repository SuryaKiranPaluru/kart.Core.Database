using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kart.Core.Dto.RequestModel
{
    public class ProductRequestModel
    {

        public string ProductName { get; set; } = null!;

        public string? ProductDesc { get; set; }

        public int CategoryId { get; set; }

        public int StockQuantity { get; set; }

        public int Discount { get; set; }

        public decimal Price { get; set; }

        public int? UserId { get; set; }
    }
}
