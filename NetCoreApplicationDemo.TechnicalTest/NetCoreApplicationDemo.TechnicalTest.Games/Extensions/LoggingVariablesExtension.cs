using Microsoft.Extensions.Configuration;
using NetCoreApplicationDemo.TechnicalTest.Games.DTOs;

namespace NetCoreApplicationDemo.TechnicalTest.Games.Extensions
{
    public static class LoggingVariablesExtension
    {
        public static LoggingConfiguration AddCustomLoggingVariablesExtension(this IConfiguration config)
        {
            var _loggingConfiguration = new LoggingConfiguration();
            config.GetSection("CustomSerilogVariables").Bind(_loggingConfiguration);
            _loggingConfiguration.MinimumLevel = config.GetValue<string>("Serilog:MinimumLevel:Default");
            return _loggingConfiguration;
        }
    }
}