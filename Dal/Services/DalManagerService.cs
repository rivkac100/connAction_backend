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
        public void Create(Manager entity)
        {
            dbcontext.Managers.Add(entity);
            dbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var mlist = dbcontext.Managers.ToList();
           // var olist = dbcontext.Orders.ToList();
            //if (olist.Find(x => x.CustomerId == id) != null)
            //    dbcontext.Orders.Remove(olist.Find(x => x.CustomerId == id));
            if (mlist.Find(x => x.Id == id) != null)
                dbcontext.Managers.Remove(mlist.Find(x => x.Id == id));
            try
            {
                dbcontext?.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("cant save chenges -manager");
            }

        }

        public List<Manager> GetAll()
        {
            return dbcontext.Managers.Include(x=> x.Activities).Include(x=>x.Events).ToList();

        }

        public Manager GetById(int id)
        {
            return GetAll().Find(x => x.Id == id);

        }

        public void Update(Manager entity)
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
                dbcontext.SaveChanges();
            }
        }
    }
}
