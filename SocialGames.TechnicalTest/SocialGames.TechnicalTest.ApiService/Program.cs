using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace SocialGames.TechnicalTest.ApiService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => WebHost
            .CreateDefaultBuilder(args)
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddEnvironmentVariables();
                if (args != null)
                    config.AddCommandLine(args);
            })
            .ConfigureLogging((webhostingContext, logging) =>
            {
                var pathLogBase = webhostingContext.Configuration["PathLogBase"];
                var normalLogSufix = webhostingContext.Configuration["NormalLogSufix"];
                var errorsLogSufix = webhostingContext.Configuration["ErrorsLogSufix"];
                var defaultExtensionFile = webhostingContext.Configuration["DefaultExtensionFile"];

                var minimumLevel = webhostingContext.Configuration.GetValue<string>("Serilog:MinimumLevel:Default");

                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(webhostingContext.Configuration)
                    .WriteTo.Map(
                        keyPropertyName: normalLogSufix,
                        defaultKey: string.Empty,
                        configure: (name, wt) => wt.File(string.Format(pathLogBase + "-" + normalLogSufix + defaultExtensionFile), LogEventLevel.Information),
                        sinkMapCountLimit: null,
                        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
                        levelSwitch: null)
                    .WriteTo.Map(
                        keyPropertyName: errorsLogSufix,
                        defaultKey: string.Empty,
                        configure: (name, wt) => wt.File(string.Format(pathLogBase + "-" + errorsLogSufix + defaultExtensionFile), LogEventLevel.Error),
                        sinkMapCountLimit: null,
                        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error,
                        levelSwitch: null)
                    .CreateLogger();
            })
            .UseSerilog()
            .UseStartup<Startup>();
    }
}