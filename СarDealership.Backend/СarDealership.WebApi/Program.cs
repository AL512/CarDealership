using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using System;
using СarDealership.Persistence;

namespace СarDealership.WebApi
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
                .WriteTo.File($"{AppContext.BaseDirectory}/Log/СarDealershipWebAppLog-.txt", rollingInterval:
                    RollingInterval.Day)
                .CreateLogger();

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                //Получаем сервис провайдер для разрешения зависимостей
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    //получаем контекст
                    var context = serviceProvider.GetRequiredService<СarDealershipDbContext>();
                    //Инициализируем БД
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
