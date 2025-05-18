using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime Date { get; set; }

    public string Description { get; set; } = null!;

    public int LenOfEvent { get; set; }

    public int ManagerId { get; set; }

    public virtual Manager Manager { get; set; } = null!;
}
