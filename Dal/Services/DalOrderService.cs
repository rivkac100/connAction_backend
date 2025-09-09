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
        /// <summary> 
        ///create new order/add
        /// </summary>
        /// <param name="order">עדכון הזמנה</param>
        public async Task Create(Order entity)
        {
            await  dbcontext.Orders.AddAsync(entity);
            try
            {
                dbcontext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("cant save changes ");

            }
        }

        /// <summary> 
        ///delete order by OrderId
        /// </summary>
        /// <param name="order">עדכון הזמנה</param>
        public async Task Delete(int id)
        {
            dbcontext.Remove(GetAll().Result.Find(x => x.OrderId == id));
            try { 
            await dbcontext.SaveChangesAsync();
            }
            catch(Exception ex) {
                throw new Exception("cant save changes ");
                    
            } 
        }

        /// <summary> 
        ///get all oprders
        /// </summary>
        /// <param name="order">עדכון הזמנה</param>
        public async Task<List<Order>> GetAll()=>
            dbcontext.Orders.Include(o=> o.Broker).Include(o=>o.Customer).Include(a=> a.Activity).Include(x=> x.Reports).ToList();

        /// <summary> 
        ///get order by orderId
        /// </summary>
        /// <param name="order">עדכון הזמנה</param>

        public async Task<Order?> GetById(int id)=>
             GetAll().Result.Find(x=>x.OrderId==id);

        /// <summary> 
        ///get order by  data
        /// </summary>
        /// <param name="order">עדכון הזמנה</param>
        public async Task<List<Order>?> GetByDate(DateOnly date)=>
            GetAll().Result.FindAll(x => DateOnly.FromDateTime(x.Date)  == date).ToList();


        /// <summary> 
        ///update order in db
        /// </summary>
        /// <param name="order">עדכון הזמנה</param>
        public async Task Update(Order order)
        {
            var x= GetAll().Result.Find(x => x.OrderId == order.OrderId);
            if (x != null)
            {
                x.ActivityId = order.ActivityId;               
                x.BrokerId = order.BrokerId;
                x.AmountOfParticipants = order.AmountOfParticipants;
                x.Payment= order.Payment;
                x.CustomerId = order.CustomerId;    
                x.Date=order.Date;
               await dbcontext.SaveChangesAsync();
            }
        }
    }
}
