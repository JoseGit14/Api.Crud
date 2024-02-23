using Api.Crud.Data.RepositoryCommand;
using Api.Crud.Data.RepositoryQuery;
using Api.Crud.Domain.Configuration.Settings;
using Api.Crud.Domain.MediatR;
using Api.Crud.Domain.Model;
using Api.Crud.Domain.Request;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace Api.Crud.Application.ServiceCommand;

public class ProductServiceCommand : IProductServiceCommand
{
    private readonly IProductRepositoryCommand _command;
    private readonly IProductRepositoryQuery _query;
    private readonly IOptions<DbConnection> _sqlDbSettings;

    public ProductServiceCommand(IProductRepositoryCommand command, IProductRepositoryQuery query, IOptions<DbConnection> sqlDbSettings)
    {
        _command = command ?? throw new ArgumentNullException(nameof(command));
        _query = query ?? throw new ArgumentNullException(nameof(query));
        _sqlDbSettings = sqlDbSettings ?? throw new ArgumentNullException(nameof(command));
    }

    public async Task<AutoWrap> InsertCart(InsertCartRequest request)
    {
        var map = new MapperConfiguration(x => x.CreateMap<InsertCartRequest, InsertCartModel>())
                                                .CreateMapper().Map<InsertCartModel>(request);

        var result = await _command.InsertCartAsync(_sqlDbSettings.Value.ProductDb.ConnectionString, map);

        return new AutoWrap(result, 201);
    }

    public async Task<AutoWrap> DeleteProduct(DeleteCartRequest request)
    {
        var map = new MapperConfiguration(x => x.CreateMap<DeleteCartRequest, DeleteCartModel>())
                                               .CreateMapper().Map<DeleteCartModel>(request);

        var result = await _command.DeleteProductAsync(_sqlDbSettings.Value.ProductDb.ConnectionString, map);

        return new AutoWrap(result, 200);
    }

    public async Task<AutoWrap> SaveCart(SaveCartRequest request)
    {
        var listAmount = new List<double>();

        var map = new MapperConfiguration(x => x.CreateMap<SaveCartRequest, SaveCartModel>())
                                                .CreateMapper().Map<SaveCartModel>(request);

        var amount = await _query.GetCartAsync(_sqlDbSettings.Value.ProductDb.ConnectionString, new GetCartModel { CartId = map.CartId});

        foreach (var item in amount.Results)
        {
            item.Amount = item.Quantity * item.Cost;
            listAmount.Add(item.Amount);
        }

        var sum = listAmount.Sum();

        map.TotalAmount = sum;
        map.ChangeCash = request.Cash - map.TotalAmount;

        var result = await _command.SaveCartAsync(_sqlDbSettings.Value.ProductDb.ConnectionString, map);

        return new AutoWrap(map.ChangeCash, 201);
    }
}
