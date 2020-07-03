using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreApplicationDemo.TechnicalTest.Games.DTOs;
using NetCoreApplicationDemo.TechnicalTest.Games.Implementations.ExternalServices;
using NetCoreApplicationDemo.TechnicalTest.Games.Implementations.MainService;
using NetCoreApplicationDemo.TechnicalTest.Games.Interface.ExternalServices;
using NetCoreApplicationDemo.TechnicalTest.Games.Interface.MainService;
using NetCoreApplicationDemo.TechnicalTest.Games.Interface.Shared;

namespace NetCoreApplicationDemo.TechnicalTest.Games.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddCustomMainServiceLibraries(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IGamesService, GamesService>();
            services.AddScoped<IGamesServiceProxyClient, GamesServiceProxyClient>();
            services.AddSingleton<GamesServiceProxyClientConfiguration>((instance) =>
            {
                return new GamesServiceProxyClientConfiguration()
                {
                    BaseAddressClientConfiguration = configuration.GetSection("GamesServiceProxyClient").GetSection("BaseAddressClientConfiguration").Value
                };
            });
            services.AddSingleton<IWebApiServiceConfigurationLibrary, WebApiServiceConfigurationLibrary>();
            services.AddSingleton<IValidatorProvider, WebApiValidator>();
            services.AddSingleton<IWebApiServiceConfigurationLibrary, WebApiServiceConfigurationLibrary>();
            return services;
        }

        public static IServiceCollection AddCustomGamesDataServiceLibrary(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IGamesEvaluator, GamesEvaluator>();
            return services;
        }
    }
}