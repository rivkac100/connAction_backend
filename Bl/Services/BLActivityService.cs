//בס"ד

using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLActivityService : IBlActivity
    {
        IDal dal;
        IBlOrder order;
        public BLActivityService(IDal dal,IBlOrder order)
        {
            this.dal = dal;
            this.order = order;
            
        }
        public void Create(BlActivity item)=>
            dal.Activity.Create(fromBlToDal(item));


        public void Delete(int id)=>
            dal.Activity.Delete(id);


        public List<BlActivity> Get()=>
            listFromDalToBl(dal.Activity.GetAll());

        public BlActivity GetById(int id)=>
         fromDalToBl(dal.Activity.GetById(id));
       

        public void Update(BlActivity item)=>      
            dal.Activity.Update(fromBlToDal(item));
        
        
       
       

        public BlActivity fromDalToBl(Dal.Models.Activity item)
        {
            BlActivity a = new BlActivity();
            a.ActivityId = item.ActivityId;
            a.ActivityDescription = item.ActivityDescription;
            a.NightPrice = item.NightPrice;
            a.Price = item.Price;
            a.Location = item.Location;
            a.ManagerId = item.ManagerId;
            //a.Manager=item.Manager;
            a.Orders = order.listFromDalToBl(item.Orders);
            return a;
        }

        public Dal.Models.Activity fromBlToDal(BlActivity item)
        {
            Dal.Models.Activity a = new();
            a.ActivityId = item.ActivityId;
            a.ActivityDescription = item.ActivityDescription;
            a.NightPrice = item.NightPrice;
            a.Price = item.Price;
            a.Location = item.Location;
            //a.Manager = item.Manager;
            a.ManagerId = item.ManagerId;
            a.Orders =order.listFromBlToDal(item.Orders);
            return a;
        }

      

        public List<BlActivity> listFromDalToBl(List<Dal.Models.Activity> item)
        {
            List<BlActivity> ls= new List<BlActivity>();    
            item.ForEach(x=>ls.Add(fromDalToBl(x)));
            return ls;
        }

        public List<Dal.Models.Activity> listFromBlToDal(List<BlActivity> item)
        {
            List<Dal.Models.Activity> ls = new List<Dal.Models.Activity>();
            item.ForEach(x => ls.Add(fromBlToDal(x)));
            return ls;
        }
      
    }
} 
