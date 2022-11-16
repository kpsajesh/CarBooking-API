using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace CarBooking_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration() // To configure the SeriLog logging option
                .WriteTo.File(
                    path: "C:\\Logs\\CarBookingAPI\\log-.txt",
                    outputTemplate: "{Timestamp:dd-MM-yyyy HH:MM:ss.fff zzz} [{Level:u3}] {Message:lj} {NewLine} {Exception}",
                    rollingInterval: RollingInterval.Day,
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information
                ).CreateLogger();
            try
            {
                Log.Information("\n\n"); // SeriLog just updates the application is starting
                Log.Information("Application is Starting"); // SeriLog just updates the application is starting
                CreateHostBuilder(args).Build().Run();                
            }
            catch(Exception ex)
            {
                Log.Fatal(ex, "Application failed to start"); // Serilog Log the exceptions
            }
            finally
            {
                Log.CloseAndFlush();
            }
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
