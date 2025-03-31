//בס"ד

using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Services
{
    public class DalActivityService : IDalActivity
    {
        dbcontext dbcontext;
        public DalActivityService(dbcontext data)
        {
            dbcontext = data;
        }



        public void Create(Activity a)
        {
            dbcontext.Activities.Add(a);
            dbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            var alist = dbcontext.Activities.ToList();
            var olist = dbcontext.Orders.ToList();
            dbcontext.Orders.Remove(olist.Find(x => x.ActivityId == id));
            dbcontext.Activities.Remove(alist.Find(x => x.ActivityId == id));
            dbcontext?.SaveChanges();
        }

        public List<Activity> GetAll()
        {
            return dbcontext.Activities.Include(x => x.Orders).ToList();
        }
        public dbcontext GetDbcontext()
        {
            return dbcontext;
        }


        public Activity? GetById(int id)
        {
            return GetAll().Find(x => x.ActivityId == id);
        }

        public void Update(Activity activity)
        {

            //dbcontext.Customers.Update(customer);
            var alist = dbcontext.Activities.ToList();
            var x = alist.Find(x => x.ActivityId == activity.ActivityId);
            if (x != null)
            {
                x.Price = activity.Price;
                x.ActivityDescription = activity.ActivityDescription;
                x.Location = activity.Location;
                x.NightPrice = activity.NightPrice;



                // all file
                dbcontext.SaveChanges();
            }
        }
    }
}
