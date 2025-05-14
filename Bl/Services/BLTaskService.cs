//בס"ד

using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public Task Create(BlTask item) =>
            dal.Task.Create(fromBlToDal(item).Result);


        public Task Delete(int id) =>
            dal.Task.Delete(id);


        public async Task<List<BlTask>> Get() =>
            listFromDalToBl(dal.Task.GetAll().Result);


        public async Task<BlTask> GetById(int id) =>
          await fromDalToBl(dal.Task.GetById(id).Result);


        public List<MyTask> listFromBlToDal(List<BlTask> item)
        {
            var ls = new List<MyTask>();
            item.ForEach(x => ls.Add(fromBlToDal(x).Result));
            return ls;
        }

        public List<BlTask> listFromDalToBl(List<MyTask> item)
        {
            List<BlTask> ls = new List<BlTask>();
            item.ForEach(x => ls.Add(fromDalToBl(x).Result));
            return ls;
        }

        public Task Update(BlTask item) =>
            dal.Task.Update(fromBlToDal(item).Result);


        public async Task<BlTask> fromDalToBl(MyTask item) =>
         new()
         {
             TaskId = item.TaskId,
             TaskIsDone = item.TaskIsDone,
             TaskDescription = item.TaskDescription,
             TaskTime = item.TaskTime,
         };

        public async Task<MyTask> fromBlToDal(BlTask item) =>
         new()
         {
             TaskId = item.TaskId,
             TaskIsDone = item.TaskIsDone,
             TaskDescription = item.TaskDescription,
             TaskTime = item.TaskTime,
         };

    }
}