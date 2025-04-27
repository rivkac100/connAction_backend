//בס"ד

using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlCustomer
    {
        public int InstituteId { get; set; }

        public string InstituteName { get; set; } = null!;

        public string? Fax { get; set; }

        public string Mobile { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string ContactName { get; set; } = null!;

        public string ContactPhone { get; set; } = null!;

        public string? City { get; set; }

        public string Community { get; set; } = null!;

        public int? Amount { get; set; }

        public decimal? Due { get; set; }

        public  ICollection<BlOrder> Orders { get; set; } = new List<BlOrder>();
        //public BlCustomer(string instituteName, string mobile, string email, string contactName, string contactPhone, string community)
        //{
        //    this.InstituteName = instituteName;
        //    this.Mobile = mobile;
        //    this.Email = email;
        //    this.ContactName = contactName;
        //    this.ContactPhone = contactPhone;
        //    this.Community = community;
        //    this.Amount = 0;
        //    this.Due = 0;

        //}
    }
}
