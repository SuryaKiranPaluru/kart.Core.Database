using System;
using System.Collections.Generic;

namespace kart.Service.Domain.Models;

public partial class User
{
    public int UserId { get; set; }

    public int RoleId { get; set; }

    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string Email { get; set; } = null!;

    public string UserAddress { get; set; } = null!;

    public string? UserContact { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual Role Role { get; set; } = null!;
}
