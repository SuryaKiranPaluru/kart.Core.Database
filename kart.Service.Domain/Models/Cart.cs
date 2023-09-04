using System;
using System.Collections.Generic;

namespace kart.Service.Domain.Models;

public partial class Cart
{
    public int SessionId { get; set; }

    public int ProductId { get; set; }

    public int UserId { get; set; }

    public int Quantity { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
