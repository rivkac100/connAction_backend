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
        IBlReport rep;
        public BLOrdersService(IDal dal, IBlReport rep)
        {
            this.dal = dal;
            this.rep = rep;


        }
        public  async Task Create(BlOrder item) { 
          if(dal.Order.Create(fromBlToDal(item).Result).IsCompleted) { 
            var a = Get().Result.Last().OrderId;
            var r = new BlReport()
            {
                OrderId = a,
                CustomerId = item.CustomerId,
                ActivityId = item.ActivityId,
                ManagerId = dal.Activity.GetById(item.ActivityId).Result.ManagerId,
                IsOk = item.IsPayment==1 ? "true" : "false",
                PaymentType="creditCard",
                Date=DateOnly.FromDateTime(DateTime.Now),
            };
            await  rep.Create(r);}
        }
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


        public async Task<BlOrder> fromDalToBl(Order item) =>
         new()
         {
             OrderId = item.OrderId,
             CustomerId = item.CustomerId,
             ActivityId = item.ActivityId,
             AmountOfParticipants = item.AmountOfParticipants,
             BrokerId = item.BrokerId,
             BrokerName = item.Broker?.BrokerName,
             CustomerName = item.Customer?.InstituteName,
             Payment = item.Payment,
             ActivityPrice = item.Activity.Price,
             ActivityNightPrice = item.Activity.NightPrice,
             ActiveHour = TimeOnly.FromDateTime(item.Date),//new(o.Date.TimeOfDay.Hours, o.Date.TimeOfDay.Minutes, o.Date.TimeOfDay.Seconds);
             Date = DateOnly.FromDateTime(item.Date),
             LenOfActivity = item.Activity.LenOfActivity,
             IsOk = item.IsOk,
             IsPayment = item.IsPayment,
             ActivityName = item.Activity.ActivityName,
             //Report =await !item.Reports.Count?null:rep.fromDalToBl(item.Reports.ToList().First()),
             Report=await rep.GetByOrderId(item.OrderId),
         };
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
                IsOk = item.IsOk,
                IsPayment = item.IsPayment
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
