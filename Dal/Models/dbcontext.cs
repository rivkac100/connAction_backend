using Microsoft.EntityFrameworkCore;

namespace Dal.Models
{
    public partial class dbcontext : DbContext
    {
        public dbcontext(DbContextOptions<dbcontext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Broker> Brokers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<MyTask> MyTasks { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Report> Reports { get; set; }

        // כאן אפשר להוסיף התאמות ספציפיות ל־Postgres אם צריך
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
