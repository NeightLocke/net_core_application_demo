using NetCoreApplicationDemo.TechnicalTest.Games.Interface.Shared;
using NetCoreApplicationDemo.TechnicalTest.Games.Interface.MainService;

namespace NetCoreApplicationDemo.TechnicalTest.Games.Implementations.MainService
{
    public class WebApiValidator : IValidatorProvider
    {
        private readonly IWebApiServiceConfigurationLibrary _webapiConfig;

        public WebApiValidator(IWebApiServiceConfigurationLibrary webapiConfig)
        {
            _webapiConfig = webapiConfig;
        }

        public bool HasValidId(string id)
        {
            if (_webapiConfig.WebApiServiceConfiguration.ValidId == id)
            {
                return true;
            }
            return false;
        }
    }
}