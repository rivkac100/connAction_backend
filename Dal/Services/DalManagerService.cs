using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    public class DalManagerService : IManager
    {
        dbcontext dbcontext;
        public DalManagerService(dbcontext data)
        {
            dbcontext = data;
        }
        public void Create(Manager entity)
        {
            dbcontext.Managers.Add(entity);
            dbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Manager> GetAll()
        {
            return dbcontext.Managers.ToList();

        }

        public Manager GetById(int id)
        {
            return GetAll().Find(x => x.Id == id);

        }

        public void Update(Manager entity)
        {
            //dbcontext.Customers.Update(customer);
            var mlist = dbcontext.Managers.ToList();
            var x = mlist.Find(x => x.Id == entity.Id);
            if (x != null)
            {
                // dbcontext.Customers.Update(x);

                x.ManagerEmail = entity.ManagerEmail;
                x.ManagerTel = entity.ManagerTel;
                x.ManagerFax = entity.ManagerFax;
                x.ManagerPhone = entity.ManagerPhone;
                x.ManagerName = entity.ManagerName;
             

                // all file
                dbcontext.SaveChanges();
            }
        }
    }
}
