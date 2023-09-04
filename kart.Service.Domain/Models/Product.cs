using System;
using System.Collections.Generic;

namespace kart.Service.Domain.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? ProductDesc { get; set; }

    public int CategoryId { get; set; }

    public int StockQuantity { get; set; }

    public int Discount { get; set; }

    public decimal? Price { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User? User { get; set; }
}
