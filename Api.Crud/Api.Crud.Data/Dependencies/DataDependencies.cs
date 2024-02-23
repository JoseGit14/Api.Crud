using Api.Crud.Data.Dapper;
using Api.Crud.Data.RepositoryCommand;
using Api.Crud.Data.RepositoryQuery;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Crud.Data.Dependencies;

public static class DataDependencies
{
    public static void AddDataDependencies(this IServiceCollection services)
    {
        services.AddScoped<IDapperCommand, DapperCommand>();
        services.AddScoped<IDapperQuery, DapperQuery>();

        services.AddScoped<IProductRepositoryCommand, ProductRepositoryCommand>();

        services.AddScoped<IProductRepositoryQuery, ProductRepositoryQuery>();
    }
}
