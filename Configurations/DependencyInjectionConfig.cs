using AcquaJrApplication.Data;
using AcquaJrApplication.Data.Repository;
using AcquaJrApplication.Interfaces;
using AcquaJrApplication.Notificacoes;
using Microsoft.Extensions.DependencyInjection;

namespace AcquaJrApplication.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IMembroRepository, MembroRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IServicoRepository, ServicoRepository>();
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<INotificador, Notificador>();

            return services;
        }
    }
}
