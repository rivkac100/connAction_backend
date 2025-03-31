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
        public void Create(BlActivity item)
        {
            dal.Activity.Create(toActiv(item));
        }

        public void Delete(int id)
        {
            dal.Activity.Delete(id);
        }

        public List<BlActivity> Get()
        {
            var aList = dal.Activity.GetAll();
            List<BlActivity> list = new();
            aList.ForEach(c => list.Add(
                new BlActivity { ActivityId = c.ActivityId, ActivityDescription = c.ActivityDescription, Location = c.Location, NightPrice = c.NightPrice, Price = c.Price,
                    Orders = order.ListToBl(c.Orders.ToList())
                }
            ));
            return list;
        }
        public BlActivity GetById(int id)
        {
           Dal.Models.Activity a = dal.Activity.GetById(id);
            BlActivity activity = new BlActivity { ActivityId = a.ActivityId, ActivityDescription = a.ActivityDescription, Location = a.Location, Price = a.Price, NightPrice = a.NightPrice,
                Orders = order.ListToBl(a.Orders.ToList())
            };
            return activity;
        }

        public void Update(BlActivity item)
        {
            dal.Activity.Update(toActiv(item));
        }
        
        public Dal.Models.Activity toActiv(BlActivity item)
        {
            Dal.Models.Activity a = new ();
            a.ActivityId = item.ActivityId;
            a.ActivityDescription = item.ActivityDescription;
            a.NightPrice = item.NightPrice;
            a.Price = item.Price;
            a.Location = item.Location;
            return a;
        }
        public BlActivity toBlActiv(Dal.Models.Activity item) {
            BlActivity a = new BlActivity();
           // a.ActivityId = item.ActivityId;
            a.ActivityDescription = item.ActivityDescription;
            a.NightPrice = item.NightPrice;
            a.Price = item.Price;
            a.Location = item.Location;
            return a;
        }




    }
} 
