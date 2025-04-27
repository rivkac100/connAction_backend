using System;
using System.Collections.Generic;

namespace Dal.Models;

public partial class Manager
{
    public int Id { get; set; }

    public string ManagerName { get; set; } = null!;

    public string ManagerEmail { get; set; } = null!;

    public string ManagerPhone { get; set; } = null!;

    public string ManagerFax { get; set; } = null!;

    public string ManagerTel { get; set; } = null!;
}
