using AutoWrapper.Wrappers;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Api.Crud.Data.Dapper;

public class DapperCommand : DapperBase, IDapperCommand
{
    public async Task<TEntity> ActionCommand<TEntity>(string connectionString, string storedProcedure, object parameter)
    {
        try
        {
            using var cnn = new SqlConnection(connectionString);
            cnn.Open();

            var result = await SqlMapper.QuerySingleOrDefaultAsync(cnn,
                        sql: storedProcedure,
                        param: parameter,
                        commandType: CommandType.StoredProcedure).ConfigureAwait(false);

            ErrorExceptionInfo(result);
            return ParseDynamicInfo<TEntity>(result);
        }
        catch (SqlException ex)
        {
            throw new ApiException(ex.Message, 500);
        }
    }
}
