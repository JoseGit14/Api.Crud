using Api.Crud.Data.RepositoryQuery;
using Api.Crud.Domain.Configuration.Settings;
using Api.Crud.Domain.MediatR;
using Api.Crud.Domain.Model;
using Api.Crud.Domain.Request;
using Api.Crud.Domain.ViewModel;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace Api.Crud.Application.ServiceQuery;

public class ProductServiceQuery : IProductServiceQuery
{
    private readonly IProductRepositoryQuery _query;
    private readonly IOptions<DbConnection> _sqlDbSettings;

    public ProductServiceQuery(IProductRepositoryQuery query, IOptions<DbConnection> sqlDbSettings)
    {
        _query = query ?? throw new ArgumentNullException(nameof(query));
        _sqlDbSettings = sqlDbSettings ?? throw new ArgumentNullException(nameof(sqlDbSettings));
    }

    public async Task<AutoWrap> GetCart(GetCartRequest request)
    {
        var listAmount = new List<double>();


        var map = new MapperConfiguration(x => x.CreateMap<GetCartRequest, GetCartModel>())
                                                .CreateMapper().Map<GetCartModel>(request);

        var result = await _query.GetCartAsync(_sqlDbSettings.Value.ProductDb.ConnectionString, map);

        foreach(var item in result.Results)
        {
            item.Amount = item.Quantity * item.Cost;
            listAmount.Add(item.Amount);
        }


        var sum = listAmount.Sum();

        result.TotalAmount = sum;

        return new AutoWrap(result, 200);
    }
}
