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
    public class BLTaskService : IBlTask
    {

        IDal dal;
        public BLTaskService(IDal dal)
        {
            this.dal = dal;
        }
        public void Create(BlTask item)
        {
            dal.Task.Create(fromBlToDal(item));
        }

        public void Delete(int id)
        {
            dal.Task.Delete(id);
        }

        public List<BlTask> Get()
        {
            var tList = dal.Task.GetAll();
           
            return listFromDalToBl(tList);
        }

        public BlTask GetById(int id)
        {
            Dal.Models.Task t = dal.Task.GetById(id);
            return fromDalToBl(t);
        }

        public List<Dal.Models.Task> listFromBlToDal(List<BlTask> item)
        {
            var ls= new List<Dal.Models.Task>();
            item.ForEach(x => ls.Add(fromBlToDal(x)));
            return ls;
        }

        public List<BlTask> listFromDalToBl(List<Dal.Models.Task> item)
        {
            List<BlTask> ls= new List<BlTask>();
            item.ForEach(x=>ls.Add(fromDalToBl(x)));
            return ls;
        }

        public void Update(BlTask item)
        {
            dal.Task.Update(fromBlToDal(item));
        }

         public BlTask fromDalToBl(Dal.Models.Task item)
         {
            BlTask task = new();
            task.TaskId = item.TaskId;
            task.TaskIsDone= item.TaskIsDone;
            task.TaskDescription = item.TaskDescription;
            task.TaskTime = item.TaskTime;
            return task;
         }

           public Dal.Models.Task fromBlToDal(BlTask item)
           {
            Dal.Models.Task task = new();
            task.TaskId = item.TaskId;
            task.TaskIsDone = item.TaskIsDone;          
            task.TaskDescription = item.TaskDescription;
            task.TaskTime = item.TaskTime;
            return task;
           }
    }
}
