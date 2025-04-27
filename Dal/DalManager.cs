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
        dbcontext data = new dbcontext();
        public IDalCustomer Customer { get; }
        public IDalOrder Order { get; }
        public IDalTask Task { get; }
        public IDalActivity Activity { get; }
        public IDalEvent Event { get; }
        public IDalManager Manager { get; }
        //IDalManager IDal.Manager { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public DalManager()
        {
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<dbcontext, dbcontext>();
            services.AddSingleton<IDalCustomer, DalCustomerService>();
            services.AddSingleton<IDalOrder, DalOrderService>();
            services.AddSingleton<IDalTask, DalTaskService>();
            services.AddSingleton<IDalActivity, DalActivityService>();
            services.AddSingleton<IDalEvent, DalEventService>();
            services.AddSingleton<IDalManager, DalManagerService>();

            // services.AddDbContext<dbcontext>(ServiceLifetime.Transient);
            // ... 
            // הגדרת ספק לאוסף הסרוויסים
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            Customer = serviceProvider.GetRequiredService<IDalCustomer>();
            Order = serviceProvider.GetRequiredService<IDalOrder>();
            Task = serviceProvider.GetRequiredService<IDalTask>();
            Activity=serviceProvider.GetRequiredService<IDalActivity>();
            Event=serviceProvider.GetRequiredService<IDalEvent>();  
            Manager=serviceProvider.GetRequiredService<IDalManager>();
        }

    }
}