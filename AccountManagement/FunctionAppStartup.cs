using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using AccountManagement.Factory;
using AccountManagement.Service;
using DataRepository.Infastructure;
using Factory;
using Microsoft.EntityFrameworkCore;
using Serilog;

[assembly: FunctionsStartup(typeof(AccountManagement.FunctionAppStartup))]

namespace AccountManagement
{
    public class FunctionAppStartup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddScoped<iAccountFactory, AccountFactory>();
            builder.Services.AddScoped<iCustomerFactory, CustomerFactory>();
            builder.Services.AddScoped<IAccountService, AccountService>();

            string connectionString = "Server=tcp:widgetdbecommerce.database.windows.net,1433;Initial Catalog=widgetdbsitedb;Persist Security Info=False;User ID=widgetadmin;Password=qzmp1090#;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            builder.Services.AddDbContext<AccountDbContext>(
                options => SqlServerDbContextOptionsExtensions.UseSqlServer(options, connectionString));
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.RollingFile(@"C:\logs\functionapp.log")
                .CreateLogger();

            builder.Services.AddLogging(b =>
            {
                b.AddSerilog(dispose: true);
            });

        }
    }
}