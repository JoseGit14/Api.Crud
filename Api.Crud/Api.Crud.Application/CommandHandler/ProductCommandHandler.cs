using Api.Crud.Application.ServiceCommand;
using Api.Crud.Domain.MediatR;
using Api.Crud.Domain.Request;
using MediatR;

namespace Api.Crud.Application.CommandHandler;

public class ProductCommandHandler : IRequestHandler<InsertCartRequest, AutoWrap>,
                                     IRequestHandler<DeleteCartRequest, AutoWrap>,
                                     IRequestHandler<SaveCartRequest, AutoWrap>
{
    private readonly IProductServiceCommand _command;

    public ProductCommandHandler(IProductServiceCommand command)
    {
        _command = command ?? throw new ArgumentNullException(nameof(command)); 
    }

    public async Task<AutoWrap> Handle(InsertCartRequest request, CancellationToken cancellationToken)
    {
        return await _command.InsertCart(request);
    }

    public async Task<AutoWrap> Handle(DeleteCartRequest request, CancellationToken cancellationToken)
    {
        return await _command.DeleteProduct(request);
    }

    public async Task<AutoWrap> Handle(SaveCartRequest request, CancellationToken cancellationToken)
    {
        return await _command.SaveCart(request);
    }
}
