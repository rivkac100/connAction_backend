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
        public void Create(BlCustomer customer)
        {
      
            dal.Customer.Create(fromBlToDal(customer));
        }

        public void Delete(int id)
        {
            
            dal.Customer.Delete(id);
        }

        public Customer fromBlToDal(BlCustomer item)
        {
            Customer c = new Customer()
            {
                InstituteId = item.InstituteId,
                InstituteName = item.InstituteName,
                Fax = item.Fax,
                Mobile = item.Mobile,
                Email = item.Email,
                ContactName = item.ContactName,
                ContactPhone = item.ContactPhone,
                City = item.City,
                Community = item.Community,
                Amount = item.Amount,
                Due = item.Due,
                Orders =order.listFromBlToDal(item.Orders.ToList())
            };
            return c;
        }

        public BlCustomer fromDalToBl(Customer item)
        {
            BlCustomer c = new BlCustomer()
            {
                InstituteId = item.InstituteId,
                InstituteName = item.InstituteName,
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
            return c;
        }

        public List<BlCustomer> Get()
        {
            var cList = dal.Customer.GetAll();
            List<BlCustomer> list = new();
            cList.ForEach(c => list.Add(fromDalToBl(c)));
            return list;
        }

        public BlCustomer GetById(int id)
        {
            Customer c = dal.Customer.GetById(id);
            return fromDalToBl(c);

        }

        public List<Customer> listFromBlToDal(List<BlCustomer> item)
        {
            List<Customer> list = new();    
            item.ForEach(x=> list.Add(fromBlToDal(x)));
            return list;
        }

        public List<BlCustomer> listFromDalToBl(List<Customer> item)
        {
            List<BlCustomer> list = new();
            item.ForEach(x => list.Add(fromDalToBl(x)));
            return list;
        }

        public void Update(BlCustomer customer)
        {
            dal.Customer.Update(fromBlToDal(customer));
        }
    }
}
