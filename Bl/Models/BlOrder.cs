//בס"ד

using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlOrder
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int? BrokerId { get; set; }
        public string? BrokerName { get; set; }

        public decimal? Payment { get; set; }

        public int AmountOfParticipants { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly ActiveHour { get; set; }

        public int ActivityId { get; set; }
        public int ActivityPrice { get; set; }
        public int ActivityNightPrice { get; set; }
        public double LenOfActivity { get; set; }

        public string? ActivityName { get; set; }


    }
}
