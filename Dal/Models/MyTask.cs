using System;
using System.Collections.Generic;

namespace Dal.Models;

 public   class MyTask
{
    public int TaskId { get; set; }

    public int TaskTime { get; set; }

    public string TaskDescription { get; set; } = null!;

    public bool TaskIsDone { get; set; }
}
