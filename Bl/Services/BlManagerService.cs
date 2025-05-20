
//בס"ד
using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BlManagerService : IBlManager
    {
        IDal dal;
        IBlActivity activity;
        IBlOrder order;
        IBlCustomer customer;
        IBlEvent evnt;
        public BlManagerService(IDal dal,IBlActivity activity, IBlCustomer customer,IBlEvent evnt)
        {
            this.dal = dal;
            this.activity = activity;
            this.customer = customer;
            this.evnt = evnt;
        }
        public Task Create(BlManager item)=>
            dal.Manager.Create(fromBlToDal(item).Result);


        public Task Delete(int id) =>
            dal.Manager.Delete(id);

        public async Task<Manager> fromBlToDal(BlManager item)=>
           new Manager()
            {
                Id = item.Id,
                ManagerEmail = item.ManagerEmail,
                ManagerName = item.ManagerName,
                CompName = item.CompName,
                Address = item.Address,
                City = item.City,
                ManagerPhone = item.ManagerPhone,
                ManagerFax = item.ManagerFax,
                ManagerTel = item.ManagerTel,
                MOrP = item.MOrP,
                NumOfComp = item.NumOfComp,
                Bank = item.Bank,
                BankBranch = item.BankBranch,
                AccountNum = item.AccountNum,
                Description = item.Description,
                Kategoty = item.Kategoty,
                ImgPath = item.ImgPath,
                Pass = item.Pass,
                Activities = activity.listFromBlToDal(item.Activities.ToList()),
                Events = evnt.listFromBlToDal(item.Events.ToList())

           };
      

        public async Task<BlManager> fromDalToBl(Manager item)=>
            new BlManager()
            {
                
                Id = item.Id,
                ManagerEmail = item.ManagerEmail,
                ManagerName = item.ManagerName,
                CompName=item.CompName,
                Address=item.Address,
                City=item.City,
                ManagerPhone = item.ManagerPhone,
                ManagerFax = item.ManagerFax,
                ManagerTel = item.ManagerTel,
                MOrP = item.MOrP,
                NumOfComp = item.NumOfComp,
                Bank=item.Bank,
                BankBranch = item.BankBranch,
                AccountNum = item.AccountNum,
                Description =item.Description,
                Kategoty=item.Kategoty,
                ImgPath=item.ImgPath,
                Pass=item.Pass,
                Activities= activity.listFromDalToBl(item.Activities.ToList()),
                Events=evnt.listFromDalToBl(item.Events.ToList())
            };


        public async  Task<List<BlManager>> Get()=>
             listFromDalToBl(dal.Manager.GetAll().Result);
          

        public Task<BlManager> GetById(int id)=>
             fromDalToBl(dal.Manager.GetById(id).Result);
 

        public List<Manager> listFromBlToDal(List<BlManager> item)
        {
            List<Manager> list = new List<Manager>();
            item.ForEach(x=> list.Add(fromBlToDal(x).Result));
            return list;
        }

        public List<BlManager> listFromDalToBl(List<Manager> item)
        {
            List<BlManager> list = new();
            item.ForEach(c => list.Add(fromDalToBl(c).Result));
            return list;
        }

        public Task Update(BlManager item)=>

            dal.Manager.Update(fromBlToDal(item).Result);

        public async Task<List<BlActivity>> GetActivitiesByManagerId(int managerId) =>
                GetById(managerId).Result.Activities.ToList();
        public async Task<List<BlOrder>> GetOrdersByManagerId(int managerId)
        {
            List<BlOrder> orders = new();
            
            GetActivitiesByManagerId(managerId).Result.ForEach(x=>orders.AddRange(x.Orders));
            return orders;

        }



        public async Task<List<BlCustomer>> GetCustomersByManagerId(int managerId)
        {   
            var olist = GetOrdersByManagerId(managerId).Result;
            List<BlCustomer> ls = new();//customer.Get().ToList();
            olist.ForEach(x => ls.Add(customer.GetById(x.CustomerId).Result));
            return ls.Select(x=>x).DistinctBy(x => x.InstituteId).ToList();
            //return ls;
            //ls = (from n in ls select n).ToList();

        }

        public async Task<bool> isTimeEmpty(int managerId, DateOnly date, TimeOnly time, double len)
        {
            var ols = GetOrdersByManagerId(managerId).Result.FindAll(x=> x.Date.Equals(date)).ToList();
            var els =GetById(managerId).Result.Events.FindAll(x=> x.Date==date).ToList();
           if(ols.Find(x=> x.ActiveHour.IsBetween(time, new TimeOnly((time.Hour + (int)len + 1) % 24, 30)))!=null )
              return false;
            if (ols.Find(x => x.ActiveHour.IsBetween(x.ActiveHour, new TimeOnly((x.ActiveHour.Hour + (int)x.LenOfActivity + 1) % 24, 30))) != null)
              return false;          
            if(els.Find(x=> x.Date.Equals(date) && x.Time.IsBetween(time, new TimeOnly((time.Hour + (int)len + 1) % 24, 30)))!=null)
              return false;
            if (els.Find(x => x.Date.Equals(date) && time.IsBetween(x.Time, new TimeOnly((x.Time.Hour +(int) x.LenOfEvent + 1) % 24, 30))) != null)
              return false;
            return true;
        }
    }
}
