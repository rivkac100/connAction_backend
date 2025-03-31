using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Activity
{
    public int ActivityId { get; set; }

    public string ActivityDescription { get; set; } = null!;

    public double LenOfActivity { get; set; }

    public string? Location { get; set; }

    public int Price { get; set; }

    public int NightPrice { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
