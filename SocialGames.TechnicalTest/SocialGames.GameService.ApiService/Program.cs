using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using SocialGames.TechnicalTest.Games.Extensions;

namespace SocialGames.GameService.ApiService
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
                var loggingVariables = webhostingContext.Configuration.AddCustomLoggingVariablesExtension();
                var minimumLevel = Enum.Parse<Serilog.Events.LogEventLevel>(loggingVariables.MinimumLevel);

                Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(webhostingContext.Configuration)
                    .WriteTo.Map(
                        keyPropertyName: loggingVariables.NormalLogSufix,
                        defaultKey: string.Empty,
                        configure: (name, wt) => wt.File(string.Format(loggingVariables.PathLogBase + "-" + loggingVariables.NormalLogSufix + loggingVariables.DefaultExtensionFile), minimumLevel),
                        sinkMapCountLimit: null,
                        restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Information,
                        levelSwitch: null)
                    .CreateLogger();
            })
            .UseSerilog()
            .UseStartup<Startup>();
    }
}