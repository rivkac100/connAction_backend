//בס"ד

using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Services
{
    public class DalReportService : IDalReport
    {
        dbcontext dbcontext;
        public DalReportService(dbcontext data)
        {
            dbcontext = data;
        }



        public async Task Create(Report a)
        {
            dbcontext.Reports.Add(a);
            await dbcontext.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
 
            if (dbcontext.Reports.ToList().Find(x => x.Id == id) != null)
                dbcontext.Reports.Remove(dbcontext.Reports.ToList().Find(x => x.Id == id));
            try
            {
                await dbcontext?.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception("cant save chenges -customer");
            };
        }

        public async Task<List<Report>> GetAll()=>
            dbcontext.Reports.Include(x => x.Order).Include(x=> x.Manager).Include(x=>x.Activity).Include(x=>x.Customer).ToList();
        public dbcontext GetDbcontext()
        {
            return dbcontext;
        }


        public  async Task<Report?> GetById(int id)=>
              GetAll().Result.Find(x => x.Id == id);


        public async Task Update(Report Report)
        {

            var alist = dbcontext.Reports.ToList();
            var x = alist.Find(x => x.Id == Report.Id);
            if (x != null)
            {
             x.ManagerId = Report.ManagerId;
             x.CustomerId = Report.CustomerId;
             x.OrderId = Report.OrderId;
             x.ActivityId = Report.ActivityId;
             x.Date= Report.Date;
             x.IsOk = Report.IsOk;
             x.PaymentType = Report.PaymentType;
   
             await dbcontext.SaveChangesAsync();
            }
        }
    }
}
