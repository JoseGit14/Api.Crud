using Api.Crud.Domain.MediatR;
using MediatR;

namespace Api.Crud.Domain.Request;

public class InsertCartRequest : IRequest<AutoWrap>
{
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string CreatedBy { get; set; }
}
