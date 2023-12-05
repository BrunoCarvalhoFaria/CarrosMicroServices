using Carros.Aluguel.Application.Interfaces;
using Carros.Aluguel.Application.Services;
using Carros.Aluguel.Domain.Interfaces;
using Carros.Aluguel.Infra.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Carros.Aluguel.Infra.IoC
{
    public class Injector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IRecebimentoRepository, RecebimentoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IEstoqueRepository, EstoqueRepository>();
            services.AddScoped<IFabricanteRepository, FabricanteRepository>();
            services.AddScoped<IModeloRepository, ModeloRepository>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();

            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IEstoqueService, EstoqueService>();
            services.AddScoped<IFabricanteService, FabricanteService>();
            services.AddScoped<IModeloService, ModeloService>();
            services.AddScoped<IEmprestimoService, EmprestimoService>();
            services.AddScoped<IRecebimentoService, RecebimentoService>();
        }
    }
}