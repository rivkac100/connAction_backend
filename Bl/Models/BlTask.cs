//בס"ד

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlTask
    {
        public int TaskId { get; set; }

        public int TaskTime { get; set; }

        public string TaskDescription { get; set; } = null!;

        public bool TaskIsDone { get; set; }
    }
}
