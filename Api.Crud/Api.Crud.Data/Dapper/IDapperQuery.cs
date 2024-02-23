namespace Api.Crud.Data.Dapper;

public interface IDapperQuery
{
    //Task<GetWithCountInfo<TEntity>> GetDataWithTotal<TEntity>(string connectionString, string storedProcedure, DynamicParameters parameter);
    Task<TEntity> DynamicQuerySingleData<TEntity>(string sqlConnection, string storeProcedure = "", object parameter = null);
    Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string sqlConnection, string storeProcedure = "", object parameter = null);
}
