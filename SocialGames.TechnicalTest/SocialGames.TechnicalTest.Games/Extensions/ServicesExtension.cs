using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialGames.TechnicalTest.Games.Implementations.ExternalServices;
using SocialGames.TechnicalTest.Games.Implementations.MainService;
using SocialGames.TechnicalTest.Games.Interface.ExternalServices;
using SocialGames.TechnicalTest.Games.Interface.MainService;
using SocialGames.TechnicalTest.Games.Interface.Shared;

namespace SocialGames.TechnicalTest.Games.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddCustomMainServiceLibraries(this IServiceCollection services, IConfiguration configuration)
        {
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