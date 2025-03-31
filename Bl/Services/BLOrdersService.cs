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
            dal.Order.Create(toOrder(item));
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
                toBlOrder(o)));
            return list;
        }

        public List<BlOrder> GetByCustomerId(int customerId)
        {
           return Get().FindAll(x=>x.CustomerId==customerId).ToList();
        }

        public BlOrder GetById(int id)
        {
            Order o = dal.Order.GetById(id);
            return toBlOrder(o);
        }

        public void Update(BlOrder item)
        {
            dal.Order.Update(toOrder(item));
        }

        public BlOrder toBlOrder(Order o)
        {
            
            BlOrder order = new();
            order.OrderId = o.OrderId;
            order.CustomerId = o.CustomerId;
            order.ActivityId = o.ActivityId;
            order.AmountOfParticipants = o.AmountOfParticipants;
            order.BrokerId = o.BrokerId;
            order.BrokerName = o.Broker?.BrokerName;
            order.CustomerName = o.Customer?.InstituteName;
            order.ActivityName = o.Activity?.ActivityDescription;
            order.Payment = o.Payment;
            order.ActiveHour = TimeOnly.FromDateTime(o.Date);//new(o.Date.TimeOfDay.Hours, o.Date.TimeOfDay.Minutes, o.Date.TimeOfDay.Seconds);
            order.Date = DateOnly.FromDateTime( o.Date);
            return order;
        }
        public Order toOrder(BlOrder item)
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
        public List<BlOrder> ListToBl(List<Order> o)
        {
           List< BlOrder> orders = new();
           o.ForEach(x=> orders.Add(toBlOrder(x)));
            return orders;
        }
        public List<Order> ListToDal(List<BlOrder> o)
        {
            List<Order> orders = new();
            o.ForEach(x => orders.Add(toOrder(x)));
            return orders;
        }
    }
}
