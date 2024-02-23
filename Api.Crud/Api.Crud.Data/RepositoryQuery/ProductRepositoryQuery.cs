using Api.Crud.Data.Dapper;
using Api.Crud.Domain.Model;
using Api.Crud.Domain.ViewModel;

namespace Api.Crud.Data.RepositoryQuery;

public class ProductRepositoryQuery : QueryRepositoryBase, IProductRepositoryQuery
{
    private readonly IDapperQuery _query;

    public ProductRepositoryQuery(IDapperQuery query)
    {
        _query = query ?? throw new ArgumentNullException(nameof(query));
    }

    public async Task<TotalAmountViewModel<GetCartViewModel>> GetCartAsync(string connectionString, GetCartModel model)
    {

        var result = await _query.QueryAsync<GetCartViewModel>(connectionString, sp_GetCartByCartId, model);

        return new TotalAmountViewModel<GetCartViewModel>()
        {
            Results = result,
            TotalAmount = 0
        };

    }
}
