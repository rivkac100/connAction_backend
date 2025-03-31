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
        public BLManager()
        {
            /*IDal dal = new DalManager();
            Customer = new BLCustomersService(dal);
            Order = new BLOrdersService(dal);
            Task = new BLTaskService(dal);*/
            ServiceCollection services = new ServiceCollection();

            services.AddSingleton<IDal, DalManager>();
            services.AddSingleton<IBlCustomer, BLCustomersService>();
            services.AddSingleton<IBlOrder, BLOrdersService>();
            services.AddSingleton<IBlTask, BLTaskService>();
            services.AddSingleton<IBlActivity, BLActivityService>();
            services.AddSingleton<IBlEvent, BLEventService>();

            // ... 
            // הגדרת ספק לאוסף הסרוויסים
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            Customer = serviceProvider.GetRequiredService<IBlCustomer>();
            Order = serviceProvider.GetRequiredService<IBlOrder>();
            Task = serviceProvider.GetRequiredService<IBlTask>();
            Activity =serviceProvider.GetRequiredService<IBlActivity>();
            Event=serviceProvider.GetRequiredService<IBlEvent>();
        }
    }
}