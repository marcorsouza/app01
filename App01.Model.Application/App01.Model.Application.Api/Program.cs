using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace App01.Model.Application.Api {
    public class Program {
        public static void Main (string[] args) {
            var env = "DEV"; //MyEnvironment: PROD, STAGE, DEV, ETC

            // Configure Serilog for logging

            var logger = new LoggerConfiguration ()
                .MinimumLevel.Debug ()
                .MinimumLevel.Override ("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext ()
                .Enrich.WithProperty ("Environment", env)
                .WriteTo.ColoredConsole ()
                .WriteTo.File ("logs/log.log", rollingInterval : RollingInterval.Day)
                //.WriteTo.MySQL ("Server=localhost;Port=3307;Database=msapp;Uid=root;Pwd=", "logs", LogEventLevel.Information)
                ;

            if (env.ToLower () == "prod") { logger.MinimumLevel.Warning (); }

            Log.Logger = logger.CreateLogger ();

            try {
                //Serilog.Debugging.SelfLog.Enable(msg =>                        {                            Debug.Print(msg);                            Debugger.Break();                        });

                Log.Information ("Starting Amplifier web host");
                CreateWebHostBuilder (args).Build ().Run ();
            } catch (Exception ex) {
                Log.Fatal (ex, "Host terminated unexpectedly");
            } finally {
                Log.CloseAndFlush ();
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder (string[] args) =>
            WebHost.CreateDefaultBuilder (args)
            .ConfigureAppConfiguration(
            (WebHostBuilderContext context, IConfigurationBuilder builder) =>
            {
                builder.Sources.Clear();

                builder
                    .AddEnvironmentVariables()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .UseStartup<Startup> ()
            .UseSerilog (); // <-- Add this line;
    }
}