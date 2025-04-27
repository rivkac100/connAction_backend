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
        public void Create(BlEvent item)
        {
        dal.Event.Create(fromBlToDal(item));

        }

        public void Delete(int id)
        {
            dal.Event.Delete(id);
        }

      


       

        public List<BlEvent> Get()
        {
            var eList = dal.Event.GetAll();
            List<BlEvent> list = new();
            eList.ForEach(e => list.Add(fromDalToBl(e)));
            return list;
        }

    public BlEvent GetById(int id)
        {

            Event e = dal.Event.GetById(id);
                return fromDalToBl(e);
    }

        public List<Event> listFromBlToDal(List<BlEvent> item)
        {
            throw new NotImplementedException();
        }

        public List<BlEvent> listFromDalToBl(List<Event> item)
        {
            throw new NotImplementedException();
        }

        public void Update(BlEvent item)
        {
            dal.Event.Update(fromBlToDal(item));
        }
        public BlEvent fromDalToBl(Event item)
        {   
            if(item!=null) { 
            BlEvent evnt = new();
            evnt.Id = item.Id;
            evnt.Time = TimeOnly.FromDateTime(item.Date);//new TimeSpan(e.Date.TimeOfDay.Hours, e.Date.TimeOfDay.Minutes, e.Date.TimeOfDay.Seconds);
            evnt.Date = DateOnly.FromDateTime(item.Date);
            evnt.Description = item.Description;
            evnt.Title = item.Title;
            evnt.LenOfEvent = item.LenOfEvent;
            return evnt;
            }
            return null;
        }
        public Event fromBlToDal(BlEvent item)
        {
            Event evnt = new ();
            evnt.Id = item.Id;
            evnt.Title = item.Title;
            evnt.Description = item.Description;
            evnt.LenOfEvent= item.LenOfEvent;
            evnt.Date =new DateTime(item.Date.Year, item.Date.Month, item.Date.Day, item.Time.Hour, item.Time.Minute,item.Time.Second);
            return evnt;
        }
    }
}
