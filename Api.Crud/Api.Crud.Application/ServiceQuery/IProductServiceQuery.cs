using Api.Crud.Domain.MediatR;
using Api.Crud.Domain.Request;

namespace Api.Crud.Application.ServiceQuery;

public interface IProductServiceQuery
{
    Task<AutoWrap> GetCart(GetCartRequest request);
}
