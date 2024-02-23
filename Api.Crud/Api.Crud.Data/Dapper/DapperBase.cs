using Api.Crud.Domain.Extensions;
using AutoWrapper.Wrappers;
using System.Text.Json;

namespace Api.Crud.Data.Dapper;

public abstract class DapperBase
{
    public void ErrorExceptionInfo(dynamic result)
    {
        if (result == null) return;
        string jsonString = JsonSerializer.Serialize(result);
        if (jsonString.Contains("StatusCode"))
        {
            jsonString = jsonString.Replace("[", "").Replace("]", "");
            var error = JsonSerializer.Deserialize<ErrorExceptionInfo>(jsonString);
            throw new ApiException(error.StatusMessage, error.StatusCode);
        }
    }

    public T ParseDynamicInfo<T>(dynamic result)
    {
        string jsonString = JsonSerializer.Serialize(result);
        return JsonSerializer.Deserialize<T>(jsonString);
    }
}