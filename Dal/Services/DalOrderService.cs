//בס"ד

using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalOrderService : IDalOrder
    {
        dbcontext dbcontext;
        public DalOrderService(dbcontext db)
        {
            dbcontext = db;
        }
        public void Create(Order entity)
        {
            dbcontext.Orders.Add(entity);
            try
            {
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("cant save changes ");

            }
        }

        public void Delete(int id)
        {
            var olist = GetAll();
            dbcontext.Remove(olist.Find(x => x.OrderId == id));
            try { 
            dbcontext.SaveChanges();
            }
            catch(Exception ex) {
                throw new Exception("cant save changes ");
                    
            }
            
        }

        public List<Order> GetAll()
        {
            return dbcontext.Orders.Include(o=> o.Broker).Include(o=>o.Customer).ToList();   
        }

        public Order? GetById(int id)
        {
            return GetAll().Find(x=>x.OrderId==id);
        }
        public List<Order>? GetByDate(DateOnly date)
        {
            return GetAll().FindAll(x => DateOnly.FromDateTime(x.Date)  == date).ToList();
        }
        //public List<Order> GetByorderId(int orderId)
        //{
        //    return dbcontext.Orders.ToList().FindAll(x => x.orderId == orderId);
        //}

        /// <summary> 
        ///update order in data base
        /// </summary>
        /// <param name="order">עדכון הזמנה</param>
        public void Update(Order order)
        {
            var olist = GetAll();
            var x=olist.Find(x => x.OrderId == order.OrderId);
            if (x != null)
            {
                // dbcontext.orders.Update(x);
            

                x.ActivityId = order.ActivityId;               
                x.BrokerId = order.BrokerId;
                x.AmountOfParticipants = order.AmountOfParticipants;
                x.Payment= order.Payment;
                x.CustomerId = order.CustomerId;    
                x.Date=order.Date;
                
                // all file
                dbcontext.SaveChanges();
            }
        }
    }
}
