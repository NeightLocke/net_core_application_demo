using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialGames.TechnicalTest.Games.Implementations;
using SocialGames.TechnicalTest.Games.Interface;

namespace SocialGames.TechnicalTest.Games.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IValidatorProvider, WebApiValidator>();
            services.AddSingleton<IWebApiServiceConfigurationLibrary, WebApiServiceConfigurationLibrary>();
            return services;
        }
    }
}