//בס"ד
using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BLOrdersService : IBlOrder
    {
        IDal dal;
        public BLOrdersService(IDal dal)
        {
            this.dal = dal;
        }
        public void Create(BlOrder item)
        {
            dal.Order.Create(fromBlToDal(item));
        }

        public void Delete(int id)
        {
            dal.Order.Delete(id);
        }



        public List<BlOrder> Get()
        {
            var oList = dal.Order.GetAll();
            List<BlOrder> list = new();
            oList.ForEach(o => list.Add(
                fromDalToBl(o)));
            return list;
        }

        public List<BlOrder> GetByCustomerId(int customerId)
        {
           return Get().FindAll(x=>x.CustomerId==customerId).ToList();
        }

        public BlOrder GetById(int id)
        {
            Order o = dal.Order.GetById(id);
            return fromDalToBl(o);
        }
        public List<BlOrder> GetByDate(DateOnly date)
        {
            List<Order> o = dal.Order.GetByDate(date);
            return listFromDalToBl(o);
        }

        public void Update(BlOrder item)
        {
            dal.Order.Update(fromBlToDal(item));
        }

        public BlOrder fromDalToBl(Order item)
        {

            BlOrder order = new();
            order.OrderId = item.OrderId;
            order.CustomerId = item.CustomerId;
            order.ActivityId = item.ActivityId;
            order.AmountOfParticipants = item.AmountOfParticipants;
            order.BrokerId = item.BrokerId;
            order.BrokerName = item.Broker?.BrokerName;
            order.CustomerName = item.Customer?.InstituteName;
            order.ActivityName = item.Activity?.ActivityDescription;
            order.Payment = item.Payment;
            order.ActiveHour = TimeOnly.FromDateTime(item.Date);//new(o.Date.TimeOfDay.Hours, o.Date.TimeOfDay.Minutes, o.Date.TimeOfDay.Seconds);
            order.Date = DateOnly.FromDateTime( item.Date);
            return order;
        }
        public Order fromBlToDal(BlOrder item)
        {
            Order order = new Order
            {
                OrderId = item.OrderId,
                BrokerId = item.BrokerId,
                CustomerId = item.CustomerId,
                ActivityId = item.ActivityId,
                AmountOfParticipants = item.AmountOfParticipants,
                Date =new DateTime( item.Date.Year, item.Date.Month, item.Date.Day, item.ActiveHour.Hour, item.ActiveHour.Minute, item.ActiveHour.Second),
                Payment = item.Payment,
                
            };

            return order;
        }
        public List<BlOrder> listFromDalToBl(List<Order> item)

        {
            List< BlOrder> orders = new();
            item.ForEach(x=> orders.Add(fromDalToBl(x)));
            return orders;
        }
        public List<Order> listFromBlToDal(List<BlOrder> item)
        {
            List<Order> orders = new();
            item.ForEach(x => orders.Add(fromBlToDal(x)));
            return orders;
        }

        

       
       

    }
}
