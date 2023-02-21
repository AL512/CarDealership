using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using �arDealership.Persistence;

namespace �arDealership.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
#if DEBUG
                .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
#else
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
#endif
                .WriteTo.File($"{AppContext.BaseDirectory}/Log/�arDealershipWebAppLog-.txt", rollingInterval:
                    RollingInterval.Day)
                .CreateLogger();

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                //�������� ������ ��������� ��� ���������� ������������
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    //�������� ��������
                    var context = serviceProvider.GetRequiredService<�arDealershipDbContext>();
                    //�������������� ��
                    DbInitializer.Initialize(context);
                }
                catch (Exception exception)
                {
                    Log.Fatal(exception, "An error occurred while app initialization");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
