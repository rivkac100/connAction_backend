using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalManagerService : IDalManager
    {
        dbcontext dbcontext;
        public DalManagerService(dbcontext data)
        {
            dbcontext = data;
        }
        public async Task Create(Manager entity)
        {
            dbcontext.Managers.Add(entity);
            await dbcontext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var mlist = dbcontext.Managers.ToList();
            var elist = dbcontext.Events.ToList();
            var alist= dbcontext.Activities.ToList();
            if (elist.FindAll(x => x.ManagerId == id) != null)
               dbcontext.Events.RemoveRange(elist.FindAll(x => x.ManagerId == id));
            if (alist.FindAll(x => x.ManagerId == id) != null)
               dbcontext.Activities.RemoveRange(alist.FindAll(x => x.ManagerId == id));
            if (mlist.Find(x => x.Id == id) != null)
                dbcontext.Managers.Remove(mlist.Find(x => x.Id == id));
            try
            {
               await dbcontext?.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("cant save chenges -manager");
            }

        }

        public async Task<List<Manager>> GetAll()
        {
            try
            {
             return   dbcontext.Managers.Include(x => x.Activities).Include(x => x.Events).ToList();

            }
            catch (Exception ex) {
                throw new Exception("cant give get all");

            }
         

            
        }


            public async Task<Manager> GetById(int id)=>
           GetAll().Result.Find(x => x.Id == id);


        public async Task Update(Manager entity)
        {
            //dbcontext.Customers.Update(customer);
            var mlist = dbcontext.Managers.ToList();
            var x = mlist.Find(x => x.Id == entity.Id);
            if (x != null)
            {
                // dbcontext.Customers.Update(x);

                x.ManagerEmail = entity.ManagerEmail;
                x.ManagerTel = entity.ManagerTel;
                x.ManagerFax = entity.ManagerFax;
                x.ManagerPhone = entity.ManagerPhone;
                x.ManagerName = entity.ManagerName;
                x.CompName = entity.CompName;
                x.Address = entity.Address;
                x.City = entity.City;
                x.MOrP = entity.MOrP;
                x.NumOfComp = entity.NumOfComp;
                x.Bank = entity.Bank;
                x.BankBranch = entity.BankBranch;
                x.AccountNum = entity.AccountNum;
                x.Description = entity.Description;
                x.Kategoty = entity.Kategoty;
                x.ImgPath = entity.ImgPath;
                x.Pass = entity.Pass;
                //x.Activities = entity.Activities;
                //x.Events = entity.Events;


                // all file
               await dbcontext.SaveChangesAsync();
            }
        }
    }
}
