using AutoWrapper.Wrappers;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace Api.Crud.Data.Dapper;

public class DapperQuery : DapperBase, IDapperQuery
{
    //public async Task<GetWithCountInfo<TEntity>> GetDataWithTotal<TEntity>(string connectionString, string storedProcedure, DynamicParameters parameter)
    //{
    //    try
    //    {
    //        using (var connection = new SqlConnection(connectionString))
    //        {
    //            var result = await connection.QueryAsync<TEntity>(storedProcedure, parameter, commandType: CommandType.StoredProcedure);
    //            var total = parameter.Get<int>("Count");

    //            return new GetWithCountInfo<TEntity>
    //            {
    //                Count = total,
    //                Results = result
    //            };
    //        }

    //    }
    //    catch (SqlException ex)
    //    {
    //        throw new ApiException(ex.Message, 500);
    //    }
    //}

    public async Task<TEntity> DynamicQuerySingleData<TEntity>(string sqlConnection, string storeProcedure = "", object parameter = null)
    {
        try
        {
            using (var connection = new SqlConnection(sqlConnection))
            {
                connection.Open();


                var result = await connection.QueryFirstOrDefaultAsync<TEntity>(storeProcedure, parameter,
                                              commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                ErrorExceptionInfo(result);

                return result;
            }
        }
        catch (SqlException ex)
        {
            throw new ApiException(ex.Message, 500);
        }
    }

    public async Task<IEnumerable<TEntity>> QueryAsync<TEntity>(string sqlConnection, string storeProcedure = "", object parameter = null)
    {
        try
        {
            using (var connection = new SqlConnection(sqlConnection))
            {
                connection.Open();


                var result = await connection.QueryAsync<TEntity>(storeProcedure, parameter,
                                              commandType: CommandType.StoredProcedure).ConfigureAwait(false);
                ErrorExceptionInfo(result);

                return ParseDynamicInfo<IEnumerable<TEntity>>(result);
            }
        }
        catch (SqlException ex)
        {
            throw new ApiException(ex.Message, 500);
        }
    }
}
