using Api.Crud.Data.Dapper;
using Api.Crud.Domain.Configuration.Settings;
using Api.Crud.Domain.Model;
using Api.Crud.Domain.ViewModel;
using Microsoft.Extensions.Options;

namespace Api.Crud.Data.RepositoryCommand;

public class ProductRepositoryCommand : CommandRepositoryBase, IProductRepositoryCommand
{
    private readonly IDapperCommand _command;

    public ProductRepositoryCommand(IDapperCommand command)
    {
        _command = command ?? throw new ArgumentNullException(nameof(command));
    }

    public async Task<ResultAsBoolViewModel> InsertCartAsync(string connectionString, InsertCartModel model)
    {
        return await _command.ActionCommand<ResultAsBoolViewModel>(connectionString, sp_InsertCart, model);
    }

    public async Task<ResultAsBoolViewModel> DeleteProductAsync(string connectionString, DeleteCartModel model)
    {
        return await _command.ActionCommand<ResultAsBoolViewModel>(connectionString, sp_DeleteCartItemByProductId, model);
    }

    public async Task<ResultAsBoolViewModel> SaveCartAsync(string connectionString, SaveCartModel model)
    {
        return await _command.ActionCommand<ResultAsBoolViewModel>(connectionString, sp_SaveCart, model);   
    }
}
