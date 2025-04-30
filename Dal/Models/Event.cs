using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Event
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public DateTime Date { get; set; }

    public string Description { get; set; } = null!;

    public int LenOfEvent { get; set; }
}
