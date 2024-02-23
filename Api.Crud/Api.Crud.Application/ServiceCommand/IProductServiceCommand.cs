using Api.Crud.Domain.MediatR;
using Api.Crud.Domain.Request;

namespace Api.Crud.Application.ServiceCommand;

public interface IProductServiceCommand
{
    Task<AutoWrap> InsertCart(InsertCartRequest request);
    Task<AutoWrap> DeleteProduct(DeleteCartRequest request);
    Task<AutoWrap> SaveCart(SaveCartRequest request);
}
