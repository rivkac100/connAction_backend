using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Activity
{
    public int ActivityId { get; set; }

    public string ActivityName { get; set; } = null!;

    public string ActivityDescription { get; set; } = null!;

    public double LenOfActivity { get; set; }

    public string? Location { get; set; }

    public int Price { get; set; }

    public int NightPrice { get; set; }

    public int ManagerId { get; set; }

    public string? ImgPath { get; set; }

    public virtual Manager Manager { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Report> Reports { get; set; } = new List<Report>();
}
