using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL.Services
{
    public class BLEventService : IBlEvent
    {
        IDal dal;
        
       
        public BLEventService(IDal dal) 
        { 
            this.dal = dal;
        }
        public Task Create(BlEvent item)=>
            dal.Event.Create(fromBlToDal(item).Result);


        public Task Delete(int id)=>
            dal.Event.Delete(id);


        public async Task<List<BlEvent>> Get()=>
           listFromDalToBl(dal.Event.GetAll().Result);
         


       public async Task<BlEvent> GetById(int id)=>
          await fromDalToBl(dal.Event.GetById(id).Result);


        public List<Event> listFromBlToDal(List<BlEvent> item)
        {
           List<Event> list = new List<Event>();
            item.ForEach(x=> list.Add(fromBlToDal(x).Result));
            return list;
        }

        public List<BlEvent> listFromDalToBl(List<Event> item)
        {
            List<BlEvent> list = new List<BlEvent>();
            item.ForEach(x => list.Add(fromDalToBl(x).Result));
            return list;
        }

        public  Task Update(BlEvent item)=>
            dal.Event.Update(fromBlToDal(item).Result);

        public async Task<BlEvent> fromDalToBl(Event item) =>
          new()
          {
              Id = item.Id,
              Time = TimeOnly.FromDateTime(item.Date),//new TimeSpan(e.Date.TimeOfDay.Hours, e.Date.TimeOfDay.Minutes, e.Date.TimeOfDay.Seconds);
              Date = DateOnly.FromDateTime(item.Date),
              Description = item.Description,
              Title = item.Title,
              LenOfEvent = item.LenOfEvent,
              ManagerId = item.ManagerId
          };

        public async Task<Event> fromBlToDal(BlEvent item)=>
        new() {  
           Id = item.Id,
           Title = item.Title,
           Description = item.Description,
           LenOfEvent= item.LenOfEvent,
           Date =new DateTime(item.Date.Year, item.Date.Month, item.Date.Day, item.Time.Hour, item.Time.Minute,item.Time.Second),
           ManagerId = item.ManagerId
        };
    }
}
