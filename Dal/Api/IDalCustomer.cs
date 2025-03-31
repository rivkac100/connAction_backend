//בס"ד

using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Api
{
    public interface IDalCustomer : ICrud<Customer>
    {
        //List<Customer> GetAll();
        //Customer GetById(int id);
        //void Update(Customer customer);

        //void Delete(Customer customer);
        //void Create(Customer customer);
    }
}
