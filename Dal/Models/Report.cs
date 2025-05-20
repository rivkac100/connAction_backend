using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Report
{
    public int Id { get; set; }

    public int ManagerId { get; set; }

    public int CustomerId { get; set; }

    public int OrderId { get; set; }

    public int ActivityId { get; set; }

    public string PaymentType { get; set; } = null!;

    public DateTime Date { get; set; }

    public string? IsOk { get; set; }

    public virtual Activity Activity { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual Manager Manager { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
