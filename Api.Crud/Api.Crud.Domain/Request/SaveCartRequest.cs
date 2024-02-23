using Api.Crud.Domain.MediatR;
using MediatR;

namespace Api.Crud.Domain.Request;

public class SaveCartRequest : IRequest<AutoWrap>
{
    public int CartId { get; set; }
    public double Cash { get; set; }
    public string CreatedBy { get; set; }
}
