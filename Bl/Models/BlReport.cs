using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlReport
    {
        public int Id { get; set; }

        public int ManagerId { get; set; }
        public string? ManagerName { get; set; }
        public string? CompName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Tel { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? kategory { get; set; }
        public int? MOrP { get; set; }
        public int? CompNumber { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerPhone { get; set; }
        public string? CustomerCity { get; set; }
        public string? CustomerTel { get; set; }
        public string? CustomerEmail { get; set; }
        public string? ActivityName { get; set; }
        public string? ActivityDescription { get; set; }
        public int? ActivityPrice { get; set; }
        public int? ActivityNightPrice { get; set; }
        public DateOnly? OrderDate { get; set; }
        public TimeOnly? OrderTime { get; set; }
        public decimal? Payment { get; set; }
        public int? IsOrderOk { get; set; }

        public int? IsPayment { get; set; }
        public int? AmountOfParticipants { get; set; }
        public double? LenOfActivity { get; set; }

        public int CustomerId { get; set; }

        public int OrderId { get; set; }

        public int ActivityId { get; set; }

        public string? PaymentType { get; set; } = null!;

        public DateOnly Date { get; set; }

        public string? IsOk { get; set; }
    }
}
