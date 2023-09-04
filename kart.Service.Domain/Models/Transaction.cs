using System;
using System.Collections.Generic;

namespace kart.Service.Domain.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public string TransactionType { get; set; } = null!;

    public string TransactionStatus { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
