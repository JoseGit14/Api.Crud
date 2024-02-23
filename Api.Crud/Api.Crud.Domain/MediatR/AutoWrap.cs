using AutoWrapper.Wrappers;
using MediatR;

namespace Api.Crud.Domain.MediatR;

public class AutoWrap : ApiResponse, IRequest
{
    public AutoWrap()
    {
    }

    public AutoWrap(object result, int statusCode = 200)
                    : base(result, statusCode)
    {

    }

    public AutoWrap(string message, object result = null, int statusCode = 200, string apiVersion = "1.0.0.0")
                : base(message, result, statusCode, apiVersion)
    {
    }

    public AutoWrap(int statusCode, object apiError)
                : base(statusCode, apiError)
    {
    }
}
