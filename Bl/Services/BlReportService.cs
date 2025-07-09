using BL.Api;
using BL.Models;
using Dal.Api;
using Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Services
{
    public class BlReportService:IBlReport
    {
        IDal dal;

        public BlReportService(IDal dal)
        {
            this.dal = dal;


        }
        public Task Create(BlReport item) =>
            dal.Report.Create(fromBlToDal(item).Result);


        public Task Delete(int id) =>
            dal.Report.Delete(id);


        public async Task<List<BlReport>> Get() =>
           listFromDalToBl(dal.Report.GetAll().Result);


        //public async Task<List<BlReport>> GetByCustomerId(int customerId)=>
        //Get().Result.FindAll(x=>x.CustomerId==customerId).ToList();


        public async Task<BlReport> GetById(int id) =>
           await fromDalToBl(dal.Report.GetById(id).Result);



        public Task Update(BlReport item) =>
            dal.Report.Update(fromBlToDal(item).Result);


        public async Task<BlReport> fromDalToBl(Report item) =>
         new()
         {
             Id = item.Id,
             ManagerId = item.ManagerId,
             ManagerName=item.Manager.ManagerName,
             CompName=item.Manager.CompName,
             CompNumber=item.Manager.NumOfComp,
             City=item.Manager.City,
             Address=item.Manager.Address,
             kategory=item.Manager.Kategoty,
             Tel=item.Manager.ManagerTel,
             Email=item.Manager.ManagerEmail,
             Phone=item.Manager.ManagerPhone,
             MOrP=item.Manager.MOrP,
             ActivityId = item.ActivityId,
             AmountOfParticipants = item.Order.AmountOfParticipants,
             ActivityDescription=item.Activity.ActivityDescription,
             CustomerId=item.CustomerId,
             CustomerName = item.Customer.InstituteName,
             CustomerCity = item.Customer.City,
             CustomerEmail = item.Customer.Email,
             CustomerPhone = item.Customer.ContactPhone,
             CustomerTel=item.Customer.Mobile,
             IsOrderOk=item.Order.IsOk,
             PaymentType=item.PaymentType,
             OrderId=item.Order.OrderId,
             Payment = item.Order.Payment,
             ActivityPrice = item.Activity.Price,
             ActivityNightPrice = item.Activity.NightPrice,
             OrderTime = TimeOnly.FromDateTime(item.Order.Date),//new(o.Date.TimeOfDay.Hours, o.Date.TimeOfDay.Minutes, o.Date.TimeOfDay.Seconds);
             OrderDate = DateOnly.FromDateTime(item.Order.Date),//new(o.Date.TimeOfDay.Hours, o.Date.TimeOfDay.Minutes, o.Date.TimeOfDay.Seconds);
             Date = DateOnly.FromDateTime(item.Date),
             LenOfActivity = item.Activity.LenOfActivity,
             IsOk = item.IsOk,
             IsPayment = item.Order.IsPayment,
             ActivityName = item.Activity.ActivityName,

         };
        public async Task<Report> fromBlToDal(BlReport item)
        {
            //var activ = dal.Activity.GetById(item.ActivityId).Result;

            Report Report = new Report
            {
                Id = item.Id, 
                OrderId = item.OrderId,
                PaymentType = item.PaymentType,
                ManagerId = item.ManagerId,           
                CustomerId = item.CustomerId,
                ActivityId = item.ActivityId,             
                Date = new DateTime(item.Date.Year, item.Date.Month, item.Date.Day),
                IsOk = item.IsOk,
                
            };

            return Report;
        }
        public List<BlReport> listFromDalToBl(List<Report> item)

        {
            List<BlReport> Reports = new();
            item.ForEach(x => Reports.Add(fromDalToBl(x).Result));
            return Reports;
        }
        public List<Report> listFromBlToDal(List<BlReport> item)
        {
            List<Report> Reports = new();
            item.ForEach(x => Reports.Add(fromBlToDal(x).Result));
            return Reports;
        }

        public async Task<List<BlReport>> GetByActivityId(int activityId) =>
            Get().Result.FindAll(x => x.ActivityId == activityId).ToList();
        public async Task<List<BlReport>> GetByManagerId(int mid) =>
           Get().Result.FindAll(x => x.ManagerId == mid).ToList();
        public async Task<BlReport>? GetByOrderId(int oid) =>
           Get().Result.Find(x => x.OrderId == oid)!=null? Get().Result.Find(x => x.OrderId == oid):null;
        public async Task<List<BlReport>> GetByCustomerId(int cid) =>
            Get().Result.FindAll(x => x.CustomerId == cid).ToList();
    }
}
