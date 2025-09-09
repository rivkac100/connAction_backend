//בס"ד

using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;


namespace BL.Services
{
    public class BLCustomersService : IBlCustomer
    {
        IDal dal;
        IBlOrder order;
        public BLCustomersService(IDal dal,IBlOrder order)
        {
            this.dal = dal;
            this.order = order;
        }
        public  Task Create(BlCustomer customer)=> 
            dal.Customer.Create(fromBlToDal(customer).Result);


        public Task Delete(int id)=>         
            dal.Customer.Delete(id);


        public async Task<Customer> fromBlToDal(BlCustomer item)=>
          new Customer()
            {
                InstituteId = item.InstituteId,
                InstituteName = item.InstituteName,
                Pass=item.Pass,
                Fax = item.Fax,
                Mobile = item.Mobile,
                Email = item.Email,
                ContactName = item.ContactName,
                ContactPhone = item.ContactPhone,
                City = item.City,
                Community = item.Community,
                Amount = 0,
                Due = 0,
               // Orders =order.listFromBlToDal(item.Orders.ToList())
           };

        public async  Task<BlCustomer> fromDalToBl(Customer item)=>
           new BlCustomer()
            {
                InstituteId = item.InstituteId,
                InstituteName = item.InstituteName,
                Pass=item.Pass,
                UserType="customer",
                Fax = item.Fax,
                Mobile = item.Mobile,
                Email = item.Email,
                ContactName = item.ContactName,
                ContactPhone = item.ContactPhone,
                City = item.City,
                Community = item.Community,
                Amount = item.Amount,
                Due = item.Due,
                Orders= order.listFromDalToBl(item.Orders.ToList())
            };



        public async Task<List<BlCustomer>> Get()=>
            listFromDalToBl(dal.Customer.GetAll().Result);


        public async Task<BlCustomer> GetById(int id)=>
              await  fromDalToBl(dal.Customer.GetById(id).Result);


        public List<Customer> listFromBlToDal(List<BlCustomer> item)
        {
            List<Customer> list = new();    
            item.ForEach(x=> list.Add(fromBlToDal(x).Result));
            return list;
        }

        public List<BlCustomer> listFromDalToBl(List<Customer> item)
        {
            List<BlCustomer> list = new();
            item.ForEach(x => list.Add(fromDalToBl(x).Result));
            return list;
        }

        public Task Update(BlCustomer customer)=>
            dal.Customer.Update(fromBlToDal(customer).Result);
    }
}
