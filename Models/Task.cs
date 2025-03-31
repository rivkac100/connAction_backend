using System;
using System.Collections.Generic;

namespace Server.Models;

public partial class Task
{
    public int TaskId { get; set; }

    public int TaskTime { get; set; }

    public string TaskDescription { get; set; } = null!;

    public bool TaskIsDone { get; set; }
}
