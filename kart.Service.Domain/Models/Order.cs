using System;
using System.Collections.Generic;

namespace kart.Service.Domain.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }

    public int TransactionId { get; set; }

    public decimal TotalAmount { get; set; }

    public string ShipmentStatus { get; set; } = null!;

    public string ShipmentAddress { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual Transaction Transaction { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
