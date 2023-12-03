using Carros.Compra.Application.Interfaces;
using Carros.Compra.Application.Services;
using Carros.Compra.Domain.Interfaces;
using Carros.Compra.Infra.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Carros.Compra.Infra.IoC
{
    public class Injector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IFabricanteRepository, FabricanteRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IMensagemRepository, MensagemRepository>();

            services.AddScoped<IFabricanteService, FabricanteService>();
            services.AddScoped<IModeloService, ModeloService>();
            services.AddScoped<IPedidoService, PedidoService>();
        }
    }
}
