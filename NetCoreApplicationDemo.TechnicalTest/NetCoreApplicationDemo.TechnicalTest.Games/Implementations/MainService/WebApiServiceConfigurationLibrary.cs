using Microsoft.Extensions.Configuration;
using NetCoreApplicationDemo.TechnicalTest.Games.DTOs;
using NetCoreApplicationDemo.TechnicalTest.Games.Interface.MainService;

namespace NetCoreApplicationDemo.TechnicalTest.Games.Implementations.MainService
{
    public class WebApiServiceConfigurationLibrary : IWebApiServiceConfigurationLibrary
    {
        private readonly IConfiguration _config;
        private WebApiServiceConfiguration _webapiServiceConfig;

        public WebApiServiceConfigurationLibrary(IConfiguration config)
        {
            _config = config;
        }

        public WebApiServiceConfiguration WebApiServiceConfiguration
        {
            get
            {
                if (_webapiServiceConfig == null)
                {
                    _webapiServiceConfig = new WebApiServiceConfiguration();
                    _config.GetSection("WebApiServiceProperties").Bind(_webapiServiceConfig);
                }
                return _webapiServiceConfig;
            }
        }
    }
}