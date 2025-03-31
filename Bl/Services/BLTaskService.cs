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
            dal.Task.Create(toTask(item));
        }

        public void Delete(int id)
        {
            dal.Task.Delete(id);
        }

        public List<BlTask> Get()
        {
            var tList = dal.Task.GetAll();
            List<BlTask> list = new();
            tList.ForEach(t => list.Add(
                toBlTask(t)));
            return list;
        }

        public BlTask GetById(int id)
        {
            Dal.Models.Task t = dal.Task.GetById(id);
            return toBlTask(t);
        }

        public void Update(BlTask item)
        {
            dal.Task.Update(toTask(item));
        }

        private BlTask toBlTask(Dal.Models.Task t)
        {
            BlTask task = new();
            task.TaskId = t.TaskId;
            task.TaskIsDone=t.TaskIsDone;
            task.TaskDescription = t.TaskDescription;
            task.TaskTime = t.TaskTime;
            return task;
        }
        private Dal.Models.Task  toTask(BlTask t)
        {
            Dal.Models.Task task = new Dal.Models.Task();
            task.TaskId = t.TaskId;
            task.TaskIsDone = t.TaskIsDone;          
            task.TaskDescription = t.TaskDescription;
            task.TaskTime = t.TaskTime;
            return task;
        }
    }
}
