using LightInject;

namespace SocialGames.TechnicalTest.Api
{
    public class GamesBootstrapper
    {
        IServiceContainer _serviceContainer;

        public GamesBootstrapper(IServiceContainer container)
        {
            _serviceContainer = container;
        }

        public void Run()
        {
            RegisterServices();
        }

        protected void RegisterServices()
        {

        }
    }
}
