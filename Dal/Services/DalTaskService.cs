//בס"ד

using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalTaskService : IDalTask
    {
        dbcontext dbcontext;
        public DalTaskService(dbcontext db)
        {
            dbcontext = db;
        }

        public void Create(Models.Task entity)
        {
            dbcontext.Tasks.Add(entity);
            dbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var tlist = dbcontext.Tasks.ToList();
            dbcontext.Remove(tlist.Find(x => x.TaskId == id));
            dbcontext?.SaveChanges();
        }

        public List<Models.Task> GetAll()
        {
            return dbcontext.Tasks.ToList();
        }

        public Models.Task? GetById(int id)
        {
            return dbcontext.Tasks.ToList().Find(x=>x.TaskId==id);

        }

        public void Update(Models.Task entity)
        {
            var tlist = dbcontext.Tasks.ToList();

            //dbcontext.Tasks.Update(tlist.Find(x => x.TaskId == entity.TaskId));
           var x=tlist.Find(x => x.TaskId == entity.TaskId);
            if (x != null)
            {
                // dbcontext.Customers.Update(x);

                x.TaskTime = entity.TaskTime;              
                x.TaskDescription = entity.TaskDescription;
                x.TaskIsDone = entity.TaskIsDone;
                
                // all file
                dbcontext.SaveChanges();
            }

            dbcontext.SaveChanges();
        }
    }
}
