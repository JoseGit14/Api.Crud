using Api.Crud.Domain.MediatR;
using MediatR;

namespace Api.Crud.Domain.Extensions;

public class ErrorExceptionInfo : IRequest<AutoWrap>
{
    public int Id { get; set; }
    public string StatusMessage { get; set; }
    public int StatusCode { get; set; }
}
