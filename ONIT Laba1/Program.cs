using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ONIT_Laba1.Data;
using ONIT_Laba1.Data.Repositories;

namespace ONIT_Laba1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services;

            Application.Run(ServiceProvider.GetRequiredService<Form1>());
        }

        public static IServiceProvider ServiceProvider { get; private set; }
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {
                    services.AddScoped<ISongRepository, SongRepository>();
                    services.AddDbContext<AppDbContext>
                (options => options.UseSqlServer("Server =DESKTOP-7J3746N; Database=OnitLaba1; Trusted_Connection=True; MultipleActiveResultSets=True;"));
                    
                    services.AddTransient<Form1>();
                    
                });
        }
    }
}