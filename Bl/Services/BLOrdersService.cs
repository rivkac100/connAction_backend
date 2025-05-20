//בס"ד
using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BL.Services
{
    public class BLOrdersService : IBlOrder
    {
        IDal dal;
       
        public BLOrdersService(IDal dal)
        {
            this.dal = dal;
   

        }
        public Task Create(BlOrder item)=>
            dal.Order.Create(fromBlToDal(item).Result);


        public Task Delete(int id)=>
            dal.Order.Delete(id);


        public async Task<List<BlOrder>> Get()=>
           listFromDalToBl(dal.Order.GetAll().Result);


        //public async Task<List<BlOrder>> GetByCustomerId(int customerId)=>
        //Get().Result.FindAll(x=>x.CustomerId==customerId).ToList();


        public async Task<BlOrder> GetById(int id)=>
           await fromDalToBl(dal.Order.GetById(id).Result);
        public async Task<List<BlOrder>> GetByDate(DateOnly date)=>
            listFromDalToBl(dal.Order.GetByDate(date).Result);


        public Task Update(BlOrder item)=>
            dal.Order.Update(fromBlToDal(item).Result);


        public async Task<BlOrder> fromDalToBl(Order item)
        {
            //var activ =dal.Activity.GetById(item.ActivityId).Result;
            BlOrder order = new();
            order.OrderId = item.OrderId;
            order.CustomerId = item.CustomerId;
            order.ActivityId = item.ActivityId;
            order.AmountOfParticipants = item.AmountOfParticipants;
            order.BrokerId = item.BrokerId;
            order.BrokerName = item.Broker?.BrokerName;
            order.CustomerName = item.Customer?.InstituteName;
            order.Payment = item.Payment;
            order.ActivityPrice = item.Activity.Price;
            order.ActivityNightPrice = item.Activity.NightPrice;
            order.ActiveHour = TimeOnly.FromDateTime(item.Date);//new(o.Date.TimeOfDay.Hours, o.Date.TimeOfDay.Minutes, o.Date.TimeOfDay.Seconds);
            order.Date = DateOnly.FromDateTime( item.Date);
            order.LenOfActivity=item.Activity.LenOfActivity;
            //order.ActivityName =activ==null? activ?.ActivityName :null;
            order.ActivityName = item.Activity.ActivityName;
            return order;
        }
        public async Task<Order> fromBlToDal(BlOrder item)
        {
            //var activ = dal.Activity.GetById(item.ActivityId).Result;

            Order order = new Order
            {
                OrderId = item.OrderId,
                BrokerId = item.BrokerId,
                CustomerId = item.CustomerId,
                ActivityId = item.ActivityId,
                AmountOfParticipants = item.AmountOfParticipants, 
                Date =new DateTime( item.Date.Year, item.Date.Month, item.Date.Day, item.ActiveHour.Hour, item.ActiveHour.Minute, item.ActiveHour.Second),
                Payment =(item.ActiveHour.Hour>21 && item.ActiveHour.Hour<6)? item.ActivityNightPrice*item.AmountOfParticipants: item.ActivityPrice * item.AmountOfParticipants,
                
            };

            return order;
        }
        public List<BlOrder> listFromDalToBl(List<Order> item)

        {
            List< BlOrder> orders = new();
            item.ForEach(x=> orders.Add(fromDalToBl(x).Result));
            return orders;
        }
        public List<Order> listFromBlToDal(List<BlOrder> item)
        {
            List<Order> orders = new();
            item.ForEach(x => orders.Add(fromBlToDal(x).Result));
            return orders;
        }

        public async Task<List<BlOrder>> GetByActivityId( int activityId)=>
            Get().Result.FindAll(x=>x.ActivityId==activityId).ToList();
        

    }
}
