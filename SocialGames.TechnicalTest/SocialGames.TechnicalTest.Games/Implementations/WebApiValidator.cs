using SocialGames.TechnicalTest.Games.Interface;

namespace SocialGames.TechnicalTest.Games.Implementations
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