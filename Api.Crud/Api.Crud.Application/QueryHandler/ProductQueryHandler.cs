using Api.Crud.Application.ServiceQuery;
using Api.Crud.Domain.MediatR;
using Api.Crud.Domain.Request;
using MediatR;

namespace Api.Crud.Application.QueryHandler;

public class ProductQueryHandler : IRequestHandler<GetCartRequest, AutoWrap>
{
    private readonly IProductServiceQuery _query;

    public ProductQueryHandler(IProductServiceQuery query)
    {
        _query = query ?? throw new ArgumentNullException(nameof(query));
    }

    public async Task<AutoWrap> Handle(GetCartRequest request, CancellationToken cancellationToken)
    {
        return await _query.GetCart(request);
    }
}
