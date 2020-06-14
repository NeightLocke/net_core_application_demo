using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialGames.TechnicalTest.ApiService.Extensions
{
    public static class ServiceCollectionSwaggerExtension
    {
        private static string _apiName = typeof(Startup).Assembly.GetName().Name;

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = string.Format(_apiName + "_v1"), Version = "v1" });
                c.SwaggerDoc("v2", new OpenApiInfo { Title = string.Format(_apiName + "_v2"), Version = "v2" });
            });
            return services;
        }

        public static IApplicationBuilder AddCustomSwaggerUI(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", string.Format(_apiName + "_v1"));
                c.SwaggerEndpoint("/swagger/v2/swagger.json", string.Format(_apiName + "_v2"));
                c.DisplayOperationId();
                c.DisplayRequestDuration();
            });
            return app;
        }
    }
}