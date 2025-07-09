//בס"ד

using Dal.Api;
using Dal.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Dal.Services
{
    public class DalCustomerService : IDalCustomer
    {
        dbcontext dbcontext;
        public DalCustomerService(dbcontext data)
        {
            dbcontext = data;
        }

        public async Task Create(Customer customer)
        {
             dbcontext.Customers.Add(customer);
             await dbcontext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var clist = dbcontext.Customers.ToList();
            var olist =dbcontext.Orders.ToList();
            if(olist.Find(x => x.CustomerId == id)!=null)
            dbcontext.Orders.RemoveRange(olist.FindAll(x => x.CustomerId == id));
            if (clist.Find(x => x.InstituteId == id) != null)
            dbcontext.Customers.Remove(clist.Find(x => x.InstituteId == id));
            try
            {
              await  dbcontext?.SaveChangesAsync();
            }catch (Exception ex)
            {
                throw new Exception("cant save chenges -customer");
            }
           
        }

        public async Task<List<Customer>> GetAll()=>
            dbcontext.Customers.Include(x => x.Orders).ToList();
     

        public dbcontext GetDbcontext()
        {
            return dbcontext;
        }

        public async Task<Customer?> GetById(int id)=>
               GetAll().Result.Find(x => x.InstituteId == id);

        public async Task Update(Customer customer)
        {
            
            //dbcontext.Customers.Update(customer);
            var clist = dbcontext.Customers.ToList();
            var x=clist.Find(x => x.Pass == customer.Pass);
           if (x != null) {
                // dbcontext.Customers.Update(x);

                x.Email = customer.Email;
                x.City = customer.City;
                x.Amount = customer.Amount;
                x.Mobile = customer.Mobile;
                x.Community = customer.Community;
                x.ContactName = customer.ContactName;
                x.InstituteName = customer.InstituteName;
                x.ContactPhone = customer.ContactPhone;
                x.Fax = customer.Fax;
                x.Due = customer.Due;

                // all file
                await dbcontext.SaveChangesAsync();
            }
        }
    }
}
