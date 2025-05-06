using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Broker
{
    public int BrokerId { get; set; }

    public string BrokerName { get; set; } = null!;

    public string BrokerEmail { get; set; } = null!;

    public string BrokerPhone { get; set; } = null!;

    public int Brokerage { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
