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
        dal.Event.Create(toEvent(item));

        }

        public void Delete(int id)
        {
            dal.Event.Delete(id);
        }

        public List<BlEvent> Get()
        {
            var eList = dal.Event.GetAll();
            List<BlEvent> list = new();
            eList.ForEach(e => list.Add(toBlEvent(e)));
            return list;
        }

    public BlEvent GetById(int id)
        {

            Event e = dal.Event.GetById(id);
                return toBlEvent(e);
    }

        public void Update(BlEvent item)
        {
            dal.Event.Update(toEvent(item));
        }
        private BlEvent toBlEvent(Event e)
        {   
            if(e!=null) { 
            BlEvent evnt = new();
            evnt.Id = e.Id;
            evnt.Time = TimeOnly.FromDateTime(e.Date);//new TimeSpan(e.Date.TimeOfDay.Hours, e.Date.TimeOfDay.Minutes, e.Date.TimeOfDay.Seconds);
            evnt.Date = DateOnly.FromDateTime(e.Date);
            evnt.Description = e.Description;
            evnt.Title = e.Title;
            evnt.LenOfEvent = e.LenOfEvent;
            return evnt;
            }
            return null;
        }
        private Event toEvent(BlEvent e)
        {
            Event evnt = new ();
            evnt.Id = e.Id;
            evnt.Title = e.Title;
            evnt.Description = e.Description;
            evnt.LenOfEvent= e.LenOfEvent;
            evnt.Date =new DateTime(e.Date.Year, e.Date.Month, e.Date.Day, e.Time.Hour, e.Time.Minute,e.Time.Second);
            return evnt;
        }
    }
}
