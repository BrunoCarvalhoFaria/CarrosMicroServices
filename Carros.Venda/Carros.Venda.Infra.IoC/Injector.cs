using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Carros.Venda.Infra.IoC
{
    public class Injector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddScoped<ILivroRepository, LivroRepository>();

            //services.AddScoped<IUsuarioAutorizacaoService, UsuarioAutorizacaoService>();
        }
    }
}