using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dal.Models;

public partial class MyTask
{
    [Key]
    public int TaskId { get; set; }

    public int TaskTime { get; set; }

    public string TaskDescription { get; set; } = null!;

    public bool TaskIsDone { get; set; }
}
