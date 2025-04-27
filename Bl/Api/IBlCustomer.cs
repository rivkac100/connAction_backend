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
    public interface IBlCustomer : IBlCrud<BlCustomer,Customer>
    {
        //List<BlCustomer> Get();
        //BlCustomer GetById(int id);
        //void Create(BlCustomer customer);
        //void Update(BlCustomer customer);
        //void Delete(BlCustomer customer);

    }
}
