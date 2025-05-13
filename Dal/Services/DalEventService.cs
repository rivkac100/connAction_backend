using Dal.Api;
using Dal.Models;
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
        public void Create(Event entity)
        {
            dbcontext.Events.Add(entity);
            dbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var elist = dbcontext.Events.ToList();
            dbcontext.Remove(elist.Find(x => x.Id == id));
            dbcontext.SaveChanges();
        }

        public List<Event> GetAll()
        {
            return dbcontext.Events.ToList();

        }

        public Event? GetById(int id)
        {
            return dbcontext.Events.ToList().Find(x => x.Id == id);
            
        }

        public void Update(Event entity)
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
                dbcontext.SaveChanges();
            }
        }
    }
}
