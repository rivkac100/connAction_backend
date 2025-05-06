
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
        public BlManagerService(IDal dal,IBlActivity activity, IBlCustomer customer)
        {
            this.dal = dal;
            this.activity = activity;
            this.customer = customer;
        }
        public void Create(BlManager item)
        {
           
            dal.Manager.Create(fromBlToDal(item));
        }

        public void Delete(int id)
        {
            dal.Manager.Delete(id);
        }

        public Manager fromBlToDal(BlManager item)=>
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
                Activities = activity.listFromBlToDal(item.Activities.ToList()).ToList()
            };
      

        public BlManager fromDalToBl(Manager item)=>
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
                Activities= activity.listFromDalToBl(item.Activities.ToList()).ToList()
            };


        public List<BlManager> Get()
        {
            var mList = dal.Manager.GetAll();
         return listFromDalToBl(mList);
        
        }

        public BlManager GetById(int id)
        {
            Manager c = dal.Manager.GetById(id);
            return fromDalToBl(c);
        }

        public List<Manager> listFromBlToDal(List<BlManager> item)
        {
            List<Manager> list = new List<Manager>();
            item.ForEach(x=> list.Add(fromBlToDal(x)));
            return list;
        }

        public List<BlManager> listFromDalToBl(List<Manager> item)
        {
            List<BlManager> list = new();
            item.ForEach(c => list.Add(fromDalToBl(c)));
            return list;
        }

        public void Update(BlManager item)
        {
         
            dal.Manager.Update(fromBlToDal(item));
        }
        public List<BlActivity> GetActivitiesByManagerId(int managerId) =>
                GetById(managerId).Activities.ToList();
        public List<BlOrder> GetOrdersByManagerId(int managerId)
        {
            List<BlOrder> orders = new();
            
            GetActivitiesByManagerId(managerId).ForEach(x=>orders.AddRange(x.Orders));
            return orders;

        }



        public List<BlCustomer> GetCustomersByManagerId(int managerId)
        {   
            var olist = GetOrdersByManagerId(managerId);
            List<BlCustomer> ls = new();//customer.Get().ToList();
            olist.ForEach(x => ls.Add(customer.GetById(x.CustomerId)));
            ls.Distinct();
           // ls=(from n in ls   select  n  ).ToList();
          return ls;
        }
    }
}
