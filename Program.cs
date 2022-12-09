using Microsoft.EntityFrameworkCore;
using Small_ERP.Models;
using Small_ERP.Repository.AccountTreeRepo;
using Small_ERP.Repository.CustomerRepo;
using Small_ERP.Repository.InvoiceRepo;
using Small_ERP.Repository.ItemRepo;
using Small_ERP.Repository.PurchaseBillRepo;
using Small_ERP.Repository.StoreRepo;
using Small_ERP.Repository.SupplierRepo;
using System.Collections.Generic;

namespace Small_ERP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Configuration DbContext
            builder.Services.AddDbContext<ERPDbContext>(
                options => options.UseSqlServer(builder.Configuration.GetConnectionString("ERPDb")));

             builder.Services.AddScoped<IItemRepository, ItemRepository>();
             builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
             builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
             builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
             builder.Services.AddScoped<IPurchaseBillRepository, PurchaseBillRepository>();
             builder.Services.AddScoped<IStoreRepository, StoreRepository>();
             builder.Services.AddScoped<IAccountTreeRepository, AccountTreeRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}