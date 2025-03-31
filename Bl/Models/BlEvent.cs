using System;
using System.Collections.Generic;
using System.Linq;
//בס"ד

using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlEvent
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public DateOnly Date { get; set; }
        public TimeOnly  Time { get; set; }
        //

        public string Description { get; set; } = null!;

        public int LenOfEvent { get; set; }

        //public BlEvent()
        //{
        //    DateTime d= DateTime.Now;
        //    DateOnly dd = DateOnly.FromDateTime(d);
        //    TimeOnly tt = TimeOnly.FromDateTime(d);
        //}
    }
}
