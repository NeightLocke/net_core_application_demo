using Microsoft.Extensions.Configuration;
using SocialGames.TechnicalTest.Games.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SocialGames.TechnicalTest.Games.Extensions
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