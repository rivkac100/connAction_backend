using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public int? BrokerId { get; set; }

    public decimal? Payment { get; set; }

    public int AmountOfParticipants { get; set; }

    public DateTime Date { get; set; }

    public int ActivityId { get; set; }

    public virtual Activity Activity { get; set; } = null!;

    public virtual Broker? Broker { get; set; }

    public virtual Customer Customer { get; set; } = null!;
}
