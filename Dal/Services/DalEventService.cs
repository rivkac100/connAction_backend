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
    public class DalEventService : IDalEvent
    {
        dbcontext dbcontext;
        public DalEventService(dbcontext db) 
        {
            dbcontext = db;
        }
        public async Task Create(Event entity)
        {

            try
            {
                dbcontext.Events.Add(entity);

                await dbcontext?.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("cant save changes ");

            }

        }

        public async Task Delete(int id)
        {
            var elist = dbcontext.Events.ToList();
            dbcontext.Remove(elist.Find(x => x.Id == id));
            await dbcontext.SaveChangesAsync();
        }

        public async Task<List<Event>> GetAll()=>
            dbcontext.Events.Include(e=> e.Manager).ToList();

        public async Task<Event?> GetById(int id)=>
           GetAll().Result.Find(x => x.Id == id);


        public async Task Update(Event entity)
        {
            var elist = dbcontext.Events.ToList();
            var x = elist.Find(x => x.Id == entity.Id);
            if (x != null)
            {
                // dbcontext.orders.Update(x);


                //x.Id = entity.Id;
                x.Title = entity.Title;
                x.Description = entity.Description;       
                x.Date = entity.Date;
                x.LenOfEvent = entity.LenOfEvent;
                x.ManagerId = entity.ManagerId;
                // all file
                await dbcontext.SaveChangesAsync();
            }
        }
    }
}
