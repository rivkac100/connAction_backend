using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dal.Models;

public partial class dbcontext : DbContext
{
    public dbcontext()
    {
    }

    public dbcontext(DbContextOptions<dbcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<Activity> Activities { get; set; }

    public virtual DbSet<Broker> Brokers { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<MyTask> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\תיקייה כללית חדש\\שנה ב תשפה\\קבוצה א\\תלמידות\\0000000000000000000000חוי וגיטי\\database\\db2.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK__tmp_ms_x__0FC9CBECFB015D43");

            entity.Property(e => e.ActivityId).HasColumnName("activityId");
            entity.Property(e => e.ActivityDescription)
                .HasMaxLength(250)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("activityDescription");
            entity.Property(e => e.ActivityName)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("activityName");
            entity.Property(e => e.ImgPath)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("imgPath");
            entity.Property(e => e.LenOfActivity).HasColumnName("lenOfActivity");
            entity.Property(e => e.Location)
                .HasMaxLength(100)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("location");
            entity.Property(e => e.ManagerId).HasColumnName("managerId");
            entity.Property(e => e.NightPrice).HasColumnName("nightPrice");
            entity.Property(e => e.Price).HasColumnName("price");

            //entity.HasOne(d => d.Manager).WithMany(p => p.Activities)
            //    .HasForeignKey(d => d.ManagerId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Activities");
        });

        modelBuilder.Entity<Broker>(entity =>
        {
            entity.HasKey(e => e.BrokerId).HasName("PK__Brokers__E40C2B1D4FD65332");

            entity.Property(e => e.BrokerId).HasColumnName("brokerId");
            entity.Property(e => e.BrokerEmail)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("brokerEmail");
            entity.Property(e => e.BrokerName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("brokerName");
            entity.Property(e => e.BrokerPhone)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("brokerPhone");
            entity.Property(e => e.Brokerage).HasColumnName("brokerage");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.InstituteId).HasName("PK__Customer__AF018B2C7F479291");

            entity.Property(e => e.InstituteId).HasColumnName("instituteId");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("city");
            entity.Property(e => e.Community)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("community");
            entity.Property(e => e.ContactName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("contactName");
            entity.Property(e => e.ContactPhone)
                .HasMaxLength(11)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("contactPhone");
            entity.Property(e => e.Due)
                .HasColumnType("money")
                .HasColumnName("due");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("email");
            entity.Property(e => e.Fax)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("fax");
            entity.Property(e => e.InstituteName)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("instituteName");
            entity.Property(e => e.Mobile)
                .HasMaxLength(11)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("mobile");
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__events__3214EC071D45AB7D");

            entity.ToTable("events");

            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("description");
            entity.Property(e => e.LenOfEvent).HasColumnName("lenOfEvent");
            entity.Property(e => e.ManagerId).HasColumnName("managerId");
            entity.Property(e => e.Title)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("title");

            //    entity.HasOne(d => d.Manager).WithMany(p => p.Events)
            //        .HasForeignKey(d => d.ManagerId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_events_ToTable");
        });

        modelBuilder.Entity<Manager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__managers__3214EC0705210E12");

            entity.ToTable("managers");

            entity.Property(e => e.AccountNum).HasColumnName("accountNum");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("address");
            entity.Property(e => e.Bank)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("bank");
            entity.Property(e => e.BankBranch).HasColumnName("bankBranch");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("city");
            entity.Property(e => e.CompName)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("compName");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("description");
            entity.Property(e => e.ImgPath)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("imgPath");
            entity.Property(e => e.Kategoty)
                .HasMaxLength(30)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("kategoty");
            entity.Property(e => e.MOrP).HasColumnName("mOrP");
            entity.Property(e => e.ManagerEmail)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("managerEmail");
            entity.Property(e => e.ManagerFax)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("managerFax");
            entity.Property(e => e.ManagerName)
                .HasMaxLength(30)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("managerName");
            entity.Property(e => e.ManagerPhone)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("managerPhone");
            entity.Property(e => e.ManagerTel)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("managerTel");
            entity.Property(e => e.NumOfComp).HasColumnName("numOfComp");
            entity.Property(e => e.Pass)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("pass");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__tmp_ms_x__0809335DC5B9C397");

            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.ActivityId).HasColumnName("activityId");
            entity.Property(e => e.AmountOfParticipants).HasColumnName("amountOfParticipants");
            entity.Property(e => e.BrokerId).HasColumnName("brokerId");
            entity.Property(e => e.CustomerId).HasColumnName("customerId");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Payment)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("payment");

            //entity.HasOne(d => d.Activity).WithMany(p => p.Orders)
            //    .HasForeignKey(d => d.ActivityId)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Orders_ToTable");

            entity.HasOne(d => d.Broker).WithMany(p => p.Orders)
                .HasForeignKey(d => d.BrokerId)
                .HasConstraintName("FK_Orders_ToTable_0");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Orders_ToTable_1");
        });

        modelBuilder.Entity<MyTask>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("PK__tmp_ms_x__DD5D5A4272AC8F11");

            entity.Property(e => e.TaskId).HasColumnName("taskId");
            entity.Property(e => e.TaskDescription)
                .HasMaxLength(1000)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("taskDescription");
            entity.Property(e => e.TaskIsDone).HasColumnName("taskIsDone");
            entity.Property(e => e.TaskTime).HasColumnName("taskTime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
