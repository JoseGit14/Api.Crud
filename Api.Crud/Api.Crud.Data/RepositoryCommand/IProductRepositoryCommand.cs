using Api.Crud.Domain.Model;
using Api.Crud.Domain.ViewModel;

namespace Api.Crud.Data.RepositoryCommand;

public interface IProductRepositoryCommand
{
    Task<ResultAsBoolViewModel> InsertCartAsync(string connectionString, InsertCartModel model);
    Task<ResultAsBoolViewModel> DeleteProductAsync(string connectionString, DeleteCartModel model);
    Task<ResultAsBoolViewModel> SaveCartAsync(string connectionString, SaveCartModel model);
}
