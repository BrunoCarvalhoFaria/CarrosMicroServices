
using Carros.Compra.Infra.IoC;

namespace Carros.Compra.Api.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            Injector.RegisterServices(services);
        }
    }
}
