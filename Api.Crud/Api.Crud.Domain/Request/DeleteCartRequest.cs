using Api.Crud.Domain.MediatR;
using MediatR;

namespace Api.Crud.Domain.Request;

public class DeleteCartRequest : IRequest<AutoWrap>
{
    public int CartId { get; set; }
    public int ProductId { get; set; }
}
