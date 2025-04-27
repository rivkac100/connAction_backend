using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BlManager
    {
        public int Id { get; set; }

        public string ManagerName { get; set; } = null!;

        public string ManagerEmail { get; set; } = null!;

        public string ManagerPhone { get; set; } = null!;

        public string ManagerFax { get; set; } = null!;

        public string ManagerTel { get; set; } = null!;
    }
}
