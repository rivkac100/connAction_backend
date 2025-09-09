﻿////בס"ד

//using BL.Api;
//using BL.Services;
//using Dal;
//using Dal.Api;
//using Microsoft.Extensions.DependencyInjection;

//namespace Bl
//{
//    public class BLManager : IBl
//    {
//        public IBlCustomer Customer { get; }

//        public IBlOrder Order { get; }

//        public IBlTask Task { get; }

//        public IBlActivity Activity { get; }
//        public IBlEvent Event { get; set; }
//        public IBlManager Manager { get; set; }
//        public IBlUser User { get; set; }
//        public IBlReport Report { get; }

//        public BLManager()
//        {
//            /*IDal dal = new DalManager();
//            Customer = new BLCustomersService(dal);
//            Order = new BLOrdersService(dal);
//            Task = new BLTaskService(dal);*/
//            ServiceCollection services = new ServiceCollection();

//            services.AddSingleton<IDal, DalManager>();
//            services.AddSingleton<IBlCustomer, BLCustomersService>();
//            services.AddSingleton<IBlOrder, BLOrdersService>();
//            services.AddSingleton<IBlTask, BLTaskService>();
//            services.AddSingleton<IBlActivity, BLActivityService>();
//            services.AddSingleton<IBlEvent, BLEventService>();
//            services.AddSingleton<IBlManager, BlManagerService>();
//            services.AddSingleton<IBlUser, BLUserService>();
//            services.AddSingleton<IBlReport,BlReportService>();

//            // ... 
//            // הגדרת ספק לאוסף הסרוויסים
//            ServiceProvider serviceProvider = services.BuildServiceProvider();

//            Customer = serviceProvider.GetRequiredService<IBlCustomer>();
//            Order = serviceProvider.GetRequiredService<IBlOrder>();
//            Task = serviceProvider.GetRequiredService<IBlTask>();
//            Activity =serviceProvider.GetRequiredService<IBlActivity>();
//            Event=serviceProvider.GetRequiredService<IBlEvent>();
//            Manager=serviceProvider.GetRequiredService<IBlManager>();
//            User=serviceProvider.GetRequiredService<IBlUser>();
//            Report= serviceProvider.GetRequiredService<IBlReport>();
//        }
//    }
//}
//בס"ד

//בס"ד

using BL.Api;
using BL.Services;
using Dal;
using Dal.Api;
using Microsoft.Extensions.DependencyInjection;

namespace Bl
{
    public class BLManager : IBl
    {
        public IBlCustomer Customer { get; }
        public IBlOrder Order { get; }
        public IBlTask Task { get; }
        public IBlActivity Activity { get; }
        public IBlEvent Event { get; set; }
        public IBlManager Manager { get; set; }
        public IBlUser User { get; set; }
        public IBlReport Report { get; }

        public BLManager(IDal dal)
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IDal>(dal);

            // שנה את כל השירותים ל-Transient
            services.AddTransient<IBlCustomer, BLCustomersService>();
            services.AddTransient<IBlOrder, BLOrdersService>();
            services.AddTransient<IBlTask, BLTaskService>();
            services.AddTransient<IBlActivity, BLActivityService>();
            services.AddTransient<IBlEvent, BLEventService>();
            services.AddTransient<IBlManager, BlManagerService>();
            services.AddTransient<IBlUser, BLUserService>();
            services.AddTransient<IBlReport, BlReportService>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            Customer = serviceProvider.GetRequiredService<IBlCustomer>();
            Order = serviceProvider.GetRequiredService<IBlOrder>();
            Task = serviceProvider.GetRequiredService<IBlTask>();
            Activity = serviceProvider.GetRequiredService<IBlActivity>();
            Event = serviceProvider.GetRequiredService<IBlEvent>();
            Manager = serviceProvider.GetRequiredService<IBlManager>();
            User = serviceProvider.GetRequiredService<IBlUser>();
            Report = serviceProvider.GetRequiredService<IBlReport>();
        }
    }
}
