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
        public async Task Create(Order entity)
        {
            dbcontext.Orders.Add(entity);
            try
            {
              await  dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("cant save changes ");

            }
        }

        public async Task Delete(int id)
        {
            var olist = GetAll().Result;
            dbcontext.Remove(olist.Find(x => x.OrderId == id));
            try { 
           await dbcontext.SaveChangesAsync();
            }
            catch(Exception ex) {
                throw new Exception("cant save changes ");
                    
            }
            
        }

        public async Task<List<Order>> GetAll()=>
            dbcontext.Orders.Include(o=> o.Broker).Include(o=>o.Customer).ToList();   


        public async Task<Order?> GetById(int id)=>
             GetAll().Result.Find(x=>x.OrderId==id);
  
        public async Task<List<Order>?> GetByDate(DateOnly date)=>
            GetAll().Result.FindAll(x => DateOnly.FromDateTime(x.Date)  == date).ToList();


        /// <summary> 
        ///update order in data base
        /// </summary>
        /// <param name="order">עדכון הזמנה</param>
        public async Task Update(Order order)
        {
            var olist = GetAll().Result;
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
               await dbcontext.SaveChangesAsync();
            }
        }
    }
}
