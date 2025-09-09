////בס"ד

//using Dal.Api;
//using Dal.Models;
//using Dal.Services;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;

//namespace Dal
//{
//    public class DalManager : IDal
//    {
//        public IDalCustomer Customer { get; }
//        public IDalOrder Order { get; }
//        public IDalTask Task { get; }
//        public IDalActivity Activity { get; }
//        public IDalEvent Event { get; }
//        public IDalManager Manager { get; }
//        public IDalReport Report { get; }

//        public DalManager(string connectionString)
//        {
//            ServiceCollection services = new ServiceCollection();

//            // מוסיפים DbContext עם החיבור ל־PostgreSQL
//            services.AddDbContext<dbcontext>(options =>
//                options.UseNpgsql(connectionString),
//                ServiceLifetime.Singleton);

//            // רישום השירותים
//            services.AddSingleton<IDalCustomer, DalCustomerService>();
//            services.AddSingleton<IDalOrder, DalOrderService>();
//            services.AddSingleton<IDalTask, DalTaskService>();
//            services.AddSingleton<IDalActivity, DalActivityService>();
//            services.AddSingleton<IDalEvent, DalEventService>();
//            services.AddSingleton<IDalManager, DalManagerService>();
//            services.AddSingleton<IDalReport, DalReportService>();

//            // בניית ServiceProvider
//            ServiceProvider serviceProvider = services.BuildServiceProvider();

//            Customer = serviceProvider.GetRequiredService<IDalCustomer>();
//            Order = serviceProvider.GetRequiredService<IDalOrder>();
//            Task = serviceProvider.GetRequiredService<IDalTask>();
//            Activity = serviceProvider.GetRequiredService<IDalActivity>();
//            Event = serviceProvider.GetRequiredService<IDalEvent>();
//            Manager = serviceProvider.GetRequiredService<IDalManager>();
//            Report = serviceProvider.GetRequiredService<IDalReport>();
//        }
//    }
//}
//בס"ד

//using Dal.Api;
//using Dal.Models;
//using Dal.Services;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;

//namespace Dal
//{
//    public class DalManager : IDal
//    {
//        public IDalCustomer Customer { get; }
//        public IDalOrder Order { get; }
//        public IDalTask Task { get; }
//        public IDalActivity Activity { get; }
//        public IDalEvent Event { get; }
//        public IDalManager Manager { get; }
//        public IDalReport Report { get; }

//        public DalManager(string connectionString)
//        {
//            ServiceCollection services = new ServiceCollection();

//            // מוסיפים DbContext עם החיבור ל־PostgreSQL
//            services.AddDbContext<dbcontext>(options =>
//                options.UseNpgsql(connectionString),
//                ServiceLifetime.Scoped); // שונה מ-Singleton ל-Scoped

//            // רישום השירותים
//            services.AddScoped<IDalCustomer, DalCustomerService>(); // שונה מ-Singleton ל-Scoped
//            services.AddScoped<IDalOrder, DalOrderService>();
//            services.AddScoped<IDalTask, DalTaskService>();
//            services.AddScoped<IDalActivity, DalActivityService>();
//            services.AddScoped<IDalEvent, DalEventService>();
//            services.AddScoped<IDalManager, DalManagerService>();
//            services.AddScoped<IDalReport, DalReportService>();

//            // בניית ServiceProvider
//            ServiceProvider serviceProvider = services.BuildServiceProvider();

//            Customer = serviceProvider.GetRequiredService<IDalCustomer>();
//            Order = serviceProvider.GetRequiredService<IDalOrder>();
//            Task = serviceProvider.GetRequiredService<IDalTask>();
//            Activity = serviceProvider.GetRequiredService<IDalActivity>();
//            Event = serviceProvider.GetRequiredService<IDalEvent>();
//            Manager = serviceProvider.GetRequiredService<IDalManager>();
//            Report = serviceProvider.GetRequiredService<IDalReport>();
//        }
//    }
//}


//using Dal.Api;
//using Dal.Services;
//using Microsoft.Extensions.DependencyInjection;

//---------------------------------
    //בס"ד

using Dal.Api;
using Dal.Models;
using Dal.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dal
{
    public class DalManager : IDal
    {
        public IDalCustomer Customer { get; }
        public IDalOrder Order { get; }
        public IDalTask Task { get; }
        public IDalActivity Activity { get; }
        public IDalEvent Event { get; }
        public IDalManager Manager { get; }
        public IDalReport Report { get; }

        public DalManager(string connectionString)
        {
            ServiceCollection services = new ServiceCollection();

            // שנה מ-Singleton ל-Transient
            services.AddDbContext<dbcontext>(options =>
                options.UseNpgsql(connectionString),
                ServiceLifetime.Transient);

            // שנה את כל השירותים ל-Transient
            services.AddTransient<IDalCustomer, DalCustomerService>();
            services.AddTransient<IDalOrder, DalOrderService>();
            services.AddTransient<IDalTask, DalTaskService>();
            services.AddTransient<IDalActivity, DalActivityService>();
            services.AddTransient<IDalEvent, DalEventService>();
            services.AddTransient<IDalManager, DalManagerService>();
            services.AddTransient<IDalReport, DalReportService>();

            ServiceProvider serviceProvider = services.BuildServiceProvider();

            Customer = serviceProvider.GetRequiredService<IDalCustomer>();
            Order = serviceProvider.GetRequiredService<IDalOrder>();
            Task = serviceProvider.GetRequiredService<IDalTask>();
            Activity = serviceProvider.GetRequiredService<IDalActivity>();
            Event = serviceProvider.GetRequiredService<IDalEvent>();
            Manager = serviceProvider.GetRequiredService<IDalManager>();
            Report = serviceProvider.GetRequiredService<IDalReport>();
        }
    }
}

