using Api.Crud.Domain.MediatR;
using MediatR;

namespace Api.Crud.Domain.Request;

public class GetCartRequest : IRequest<AutoWrap>
{
    public int CartId { get; set; }
}
