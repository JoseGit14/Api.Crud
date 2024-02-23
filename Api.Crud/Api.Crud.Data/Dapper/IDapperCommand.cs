namespace Api.Crud.Data.Dapper;

public interface IDapperCommand
{
    Task<TEntity> ActionCommand<TEntity>(string connectionString, string storedProcedure, object parameter);
}
