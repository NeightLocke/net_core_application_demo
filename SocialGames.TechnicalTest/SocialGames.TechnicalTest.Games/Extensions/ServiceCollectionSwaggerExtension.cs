using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace SocialGames.TechnicalTest.ApiService.Extensions
{
    public static class ServiceCollectionSwaggerExtension
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services, string apiName)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = string.Format(apiName + "_v1"), Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = string.Format(apiName + "_v2"), Version = "v2" });
            });
            return services;
        }

        public static IApplicationBuilder AddCustomSwaggerUI(this IApplicationBuilder app, string apiName)
        {
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", string.Format(apiName + "_v1"));
                c.SwaggerEndpoint("/swagger/v2/swagger.json", string.Format(apiName + "_v2"));
                c.DisplayOperationId();
                c.DisplayRequestDuration();
            });
            return app;
        }
    }
}