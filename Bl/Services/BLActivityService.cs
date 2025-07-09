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
        public  Task Create(BlActivity item)=>
            dal.Activity.Create(fromBlToDal(item).Result);


        public Task Delete(int id)=>
            dal.Activity.Delete(id);


        public async Task<List<BlActivity>> Get()=>
           listFromDalToBl(dal.Activity.GetAll().Result);

        public   Task<BlActivity> GetById(int id)=>
           fromDalToBl(dal.Activity.GetById(id).Result);
       

        public async Task Update(BlActivity item)=>      
            dal.Activity.Update(fromBlToDal(item).Result);



 

        public async Task<BlActivity> fromDalToBl(Dal.Models.Activity item)=>
            new BlActivity() {
              
                ActivityId = item.ActivityId,
                ActivityName = item.ActivityName,
                ActivityDescription = item.ActivityDescription,
                NightPrice = item.NightPrice,
                Price = item.Price,
                Location = item.Location,
                LenOfActivity = item.LenOfActivity,
                //a.Manager = item.Manager;
                ManagerId = item.ManagerId,
                ImgPath = item.ImgPath,
                Orders = order.listFromDalToBl(item.Orders.ToList())
            };
            


        public async Task<Dal.Models.Activity> fromBlToDal(BlActivity item)=>
             new()
             {
                ActivityId = item.ActivityId,
                ActivityName = item.ActivityName,
                ActivityDescription = item.ActivityDescription,
                NightPrice = item.NightPrice,
                Price = item.Price,
                Location = item.Location,
                LenOfActivity = item.LenOfActivity,
                //a.Manager = item.Manager;
                ManagerId = item.ManagerId,
                ImgPath = item.ImgPath,
                 Orders = order.listFromBlToDal(item.Orders)
             };
         
       

      

        public  List<BlActivity> listFromDalToBl(List<Dal.Models.Activity> item)
        {
            
            List<BlActivity> ls= new List<BlActivity>();    
            item.ForEach(x=>ls.Add(fromDalToBl(x).Result));
            return ls;
        }

        public List<Dal.Models.Activity> listFromBlToDal(List<BlActivity> item)
        {
            List<Dal.Models.Activity> ls = new List<Dal.Models.Activity>();
            item.ForEach(x => ls.Add(fromBlToDal(x).Result));
            return ls;
        }

    }
} 
