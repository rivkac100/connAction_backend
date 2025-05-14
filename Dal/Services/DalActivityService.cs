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



        public async Task Create(Activity a)
        {
            dbcontext.Activities.Add(a);
            await dbcontext.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var alist = dbcontext.Activities.ToList();
            var olist = dbcontext.Orders.ToList();
            if (olist.Find(x => x.CustomerId == id) != null)
                dbcontext.Orders.RemoveRange(olist.FindAll(x => x.ActivityId == id));
            if (alist.Find(x => x.ActivityId == id) != null)
                dbcontext.Activities.Remove(alist.Find(x => x.ActivityId == id));
            try
            {
                await dbcontext?.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("cant save chenges -customer");
            };
        }

        public async Task<List<Activity>> GetAll()=>
            dbcontext.Activities.Include(x => x.Orders).ToList();
        public dbcontext GetDbcontext()
        {
            return dbcontext;
        }


        public  async Task<Activity?> GetById(int id)=>
              GetAll().Result.Find(x => x.ActivityId == id);


        public async Task Update(Activity activity)
        {

            var alist = dbcontext.Activities.ToList();
            var x = alist.Find(x => x.ActivityId == activity.ActivityId);
            if (x != null)
            {
                x.Price = activity.Price;
                x.ActivityDescription = activity.ActivityDescription;
                x.Location = activity.Location;
                x.NightPrice = activity.NightPrice;
   
             await dbcontext.SaveChangesAsync();
            }
        }
    }
}
