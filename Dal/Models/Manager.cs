using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Manager
{
    public int Id { get; set; }

    public string ManagerName { get; set; } = null!;

    public int Pass { get; set; }

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

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();
}
