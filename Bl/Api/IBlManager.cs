
//בס"ד
using BL.Models;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Api
{
    public interface IBlManager:IBlCrud<BlManager,Manager>
    {
        List<BlActivity> GetActivitiesByManagerId(int managerId);

        public List<BlCustomer> GetCustomersByManagerId(int managerId);
        public List<BlOrder> GetOrdersByManagerId(int managerId);
    }
}
