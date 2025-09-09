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

        public async Task Create(MyTask entity)
        {
            dbcontext.MyTasks.Add(entity);
            await dbcontext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var tlist = dbcontext.MyTasks.ToList();
            dbcontext.Remove(tlist.Find(x => x.TaskId == id));
            await dbcontext?.SaveChangesAsync();
        }

        public async Task<List<MyTask>> GetAll() =>
              dbcontext.MyTasks.ToList();


        public async Task<MyTask?> GetById(int id) =>
           GetAll().Result.Find(x => x.TaskId == id);


        public async Task Update(MyTask entity)
        {
            var tlist = dbcontext.MyTasks.ToList();

            //dbcontext.Tasks.Update(tlist.Find(x => x.TaskId == entity.TaskId));
            var x = tlist.Find(x => x.TaskId == entity.TaskId);
            if (x != null)
            {
                // dbcontext.Customers.Update(x);

                x.TaskTime = entity.TaskTime;
                x.TaskDescription = entity.TaskDescription;
                x.TaskIsDone = entity.TaskIsDone;

                // all file
                dbcontext.SaveChanges();
            }

            await dbcontext.SaveChangesAsync();
        }
    }
}

