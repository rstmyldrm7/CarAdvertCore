using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CarAdvertCore.Application.Contracts.Persistence;
using CarAdvertCore.Persistence.Repositories;
using CarAdvertCore.Application.Assembler.Abstract;
using CarAdvertCore.Application.Assembler.Concrete;
using CarAdvertCore.Application.Features.Tasks.Service.Abstract;
using CarAdvertCore.Application.Features.Tasks.Service.Concrete;

namespace CarAdvertCore.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICarAdvertRepository, CarAdvertRepository>();
            services.AddScoped<IVisitRepository, VisitRepository>();
            services.AddScoped<IAdvertAssembler, AdvertAssembler>();
            services.AddScoped<IApacheService, ApacheService>();

            return services;
        }
    }
}
