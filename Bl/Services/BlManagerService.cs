
//בס"ד
using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BlManagerService : IBlManager
    {
        IDal dal;
        //IBlOrder order;
        public BlManagerService(IDal dal)
        {
            this.dal = dal;
            //this.order = order;
        }
        public void Create(BlManager item)
        {
           
            dal.Manager.Create(fromBlToDal(item));
        }

        public void Delete(int id)
        {
            dal.Manager.Delete(id);
        }

        public Manager fromBlToDal(BlManager item)
        {
            Manager m = new Manager()
            {
               
                Id = item.Id,
                ManagerEmail = item.ManagerEmail,
                ManagerName = item.ManagerName,
                ManagerPhone = item.ManagerPhone,
                ManagerFax = item.ManagerFax,

            };
            return m;
        }

        public BlManager fromDalToBl(Manager item)
        {
            BlManager m = new BlManager()
            {
                
                Id = item.Id,
                ManagerEmail = item.ManagerEmail,
                ManagerName = item.ManagerName,
                ManagerPhone = item.ManagerPhone,
                ManagerFax = item.ManagerFax,

            };
            return m;
        }

        public List<BlManager> Get()
        {
            var mList = dal.Manager.GetAll();
         return listFromDalToBl(mList);
        
        }

        public BlManager GetById(int id)
        {
            Manager c = dal.Manager.GetById(id);
            return fromDalToBl(c);
        }

        public List<Manager> listFromBlToDal(List<BlManager> item)
        {
            List<Manager> list = new List<Manager>();
            item.ForEach(x=> list.Add(fromBlToDal(x)));
            return list;
        }

        public List<BlManager> listFromDalToBl(List<Manager> item)
        {
            List<BlManager> list = new();
            item.ForEach(c => list.Add(fromDalToBl(c)));
            return list;
        }

        public void Update(BlManager item)
        {
         
            dal.Manager.Update(fromBlToDal(item));
        }
    }
}
