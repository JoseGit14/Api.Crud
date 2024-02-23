using Api.Crud.Domain.Model;
using Api.Crud.Domain.ViewModel;

namespace Api.Crud.Data.RepositoryQuery;

public interface IProductRepositoryQuery
{
    Task<TotalAmountViewModel<GetCartViewModel>> GetCartAsync(string connectionString, GetCartModel model);
}
