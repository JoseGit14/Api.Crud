using Api.Crud.Application.ServiceCommand;
using Api.Crud.Application.ServiceQuery;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Crud.Application.Configuration.Dependencies;

public static class ServiceDependencies
{
    public static void AddServiceDependencies(this IServiceCollection services)
    {
        services.AddScoped<IProductServiceCommand, ProductServiceCommand>();

        services.AddScoped<IProductServiceQuery, ProductServiceQuery>();
    }
}
