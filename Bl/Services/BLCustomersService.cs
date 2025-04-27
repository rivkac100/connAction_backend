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
            Customer c = new Customer()
            {
                //InstituteId = customer.InstituteId,
                InstituteName = customer.InstituteName,
                Fax = customer.Fax,
                Mobile = customer.Mobile,
                Email = customer.Email,
                ContactName = customer.ContactName,
                ContactPhone = customer.ContactPhone,
                City = customer.City,
                Community = customer.Community,
                Amount = customer.Amount,
                Due = customer.Due
            };
            dal.Customer.Create(c);
        }

        public void Delete(int id)
        {
            
            dal.Customer.Delete(id);
        }

        public Customer fromBlToDal(BlCustomer item)
        {
            throw new NotImplementedException();
        }

        public BlCustomer fromDalToBl(Customer item)
        {
            throw new NotImplementedException();
        }

        public List<BlCustomer> Get()
        {
            var cList = dal.Customer.GetAll();
            List<BlCustomer> list = new();
            cList.ForEach(c => list.Add(new BlCustomer(c.InstituteName, c.Mobile, c.Email, c.ContactName, c.ContactPhone, c.Community)
            { InstituteId = c.InstituteId, Fax = c.Fax, Amount = c.Amount,City=c.City, Due = c.Due,Orders=order.listFromDalToBl(c.Orders.ToList()) }));
            return list;
        }

        public BlCustomer GetById(int id)
        {
            Customer c = dal.Customer.GetById(id);
            BlCustomer customer = new(c.InstituteName, c.Mobile, c.Email, c.ContactName, c.ContactPhone, c.Community)
            { InstituteId = c.InstituteId, Fax = c.Fax, City = c.City, Amount = c.Amount, Due = c.Due, Orders = order.listFromDalToBl(c.Orders.ToList()) };
            return customer;

        }

        public List<Customer> listFromBlToDal(List<BlCustomer> item)
        {
            throw new NotImplementedException();
        }

        public List<BlCustomer> listFromDalToBl(List<Customer> item)
        {
            throw new NotImplementedException();
        }

        public void Update(BlCustomer customer)
        {
            Customer c = new Customer()
            {
                InstituteId = customer.InstituteId,
                InstituteName = customer.InstituteName,
                Fax = customer.Fax,
                Mobile = customer.Mobile,
                Email = customer.Email,
                ContactName = customer.ContactName,
                ContactPhone = customer.ContactPhone,
                City = customer.City,
                Community = customer.Community,
                Amount = customer.Amount,
                Due = customer.Due
            };
            dal.Customer.Update(c);
        }
    }
}
