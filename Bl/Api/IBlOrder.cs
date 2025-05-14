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
    public interface IBlOrder : IBlCrud<BlOrder,Order>
    {
        //public List<BlOrder> GetByCustomerId(int customerId);
        //public List<BlOrder> ListToBl(List<Order> o);
        //public List<Order> ListToDal(List<BlOrder> o);
        public Task<List<BlOrder>> GetByDate(DateOnly date);
        Task<List<BlOrder>> GetByActivityId(int activityId);
    }
}
