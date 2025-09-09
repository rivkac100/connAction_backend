﻿//בס"ד

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlManager:BlUser
    {
      
        public int Id { get; set; }

        public string ManagerName { get; set; } = null!;

        //public string Pass { get; set; } = null!;


        public string CompName { get; set; } = null!;

        public string ManagerEmail { get; set; } = null!;

        public string ManagerPhone { get; set; } = null!;

        public string? ManagerFax { get; set; }

        public string? ManagerTel { get; set; }

        public string Address { get; set; } = null!;

        public string City { get; set; } = null!;

        public int MOrP { get; set; }

        public int NumOfComp { get; set; }

        public string Bank { get; set; } = null!;

        public int BankBranch { get; set; }

        public int AccountNum { get; set; }

        public string Kategoty { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string? ImgPath { get; set; }


        public  List<BlActivity> Activities { get; set; } = new List<BlActivity>();
        public  List<BlEvent> Events { get; set; } = new List<BlEvent>();

    }
}
