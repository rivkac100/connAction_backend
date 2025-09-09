
////��"�

//using Bl;
//using BL.Api;
//using System;
//using Microsoft.EntityFrameworkCore;
//using Dal.Models;

//namespace Server
//{

//    public class Program
//    {


//        public static void Main(string[] args)
//        {

//            var builder = WebApplication.CreateBuilder(args);

//            builder.Services.AddDbContext<dbcontext>(options =>
//                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));



//            //var builder = WebApplication.CreateBuilder(args);

//            // Add services to the container.
//            builder.Services.AddSingleton<IBl,BLManager>();

//            builder.Services.AddControllers();
//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();
//            builder.Services.AddSwaggerGen();
//            builder.Services.AddCors(c => c.AddPolicy("AllowAll",
//             option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

//            //������ ���� ����� � app




//            var app = builder.Build();
//            app.UseStaticFiles();
//            app.UseCors("AllowAll");
//            // Configure the HTTP request pipeline.
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();
//            }

//            app.UseHttpsRedirection();

//            app.UseAuthorization();

//            app.MapControllers();

//            app.Run();
//        }
//    }
//}
//��"�

using Bl;
using BL.Api;
using System;
using Microsoft.EntityFrameworkCore;
using Dal.Models;
using Dal;
using Dal.Api;

namespace Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ����� DbContext
            builder.Services.AddDbContext<dbcontext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

            // ����� connection string ������
            builder.Services.AddSingleton<string>(provider =>
                builder.Configuration.GetConnectionString("DefaultConnection"));

            // ����� DalManager �� connection string
            builder.Services.AddScoped<IDal, DalManager>();

            // ����� BLManager
            builder.Services.AddScoped<IBl, BLManager>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(c => c.AddPolicy("AllowAll",
                option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseCors("AllowAll");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
