namespace kart.Core.Dto.ResponseModel
{
    public class ProductResponseModel
    {
        public string ProductName { get; set; } = null!;

        public string? ProductDesc { get; set; }

        public int StockQuantity { get; set; }

        public int Discount { get; set; }

        public decimal? Price { get; set; }
    }
}