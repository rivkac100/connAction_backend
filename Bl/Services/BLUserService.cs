using BL.Api;
using BL.Models;
using Dal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLUserService : IBlUser
    {
        IDal dal;
        IBlManager manager;
        IBlCustomer customer;

        public BLUserService(IDal dal,IBlManager  manager,IBlCustomer customer)
        {
            this.dal = dal;
            this.manager = manager;
            this.customer = customer;
        }

        public async Task<List<BlUser>> GetAll()
        {
            List<BlUser> list = new List<BlUser>();

            list.AddRange(manager.Get().Result);
            list.AddRange(customer.Get().Result);
            return list;
        }

        public async Task<BlUser>? GetById(string pass)=>
            GetAll().Result.Find(x=>x.Pass==pass);
        public async Task<BlUser> GetById(string userType,int id) =>
            userType=="customer"?customer.GetById(id).Result:manager.GetById(id).Result;
    }
       
}
