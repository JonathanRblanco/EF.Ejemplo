using EF.Domian.Contracts;
using EF.Infraestructure.Context;
using EF.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class InfraestructureConfiguration
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddScoped<IUnitOfWork, EFContext>()
                .AddScoped<ITodoRepository, TodoRepository>()
                .AddDbContext<EFContext>(options => options
                .UseSqlServer(configuration.GetConnectionString("EFContext")));
        }
    }
}
