using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Customer
{
    public int InstituteId { get; set; }

    public string InstituteName { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public string? Fax { get; set; }

    public string? Mobile { get; set; }

    public string Email { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public string ContactPhone { get; set; } = null!;

    public string? City { get; set; }

    public string Community { get; set; } = null!;

    public int? Amount { get; set; }

    public decimal? Due { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
