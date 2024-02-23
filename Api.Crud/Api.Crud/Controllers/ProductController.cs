using Api.Crud.Domain.MediatR;
using Api.Crud.Domain.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Crud.Controllers;

[Route("v{version:apiVersion}")]
[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "v1")]
public class ProductController
{
    private readonly IMediator _mediatr;

    public ProductController(IMediator mediatr)
    {
        _mediatr = mediatr ?? throw new ArgumentNullException(nameof(mediatr));
    }

    [HttpPost("insert/cart")]
    public async Task<AutoWrap> InsertCart([FromBody] InsertCartRequest request)
    {
        return await _mediatr.Send(request);
    }

    [HttpGet("get/cart")]
    public async Task<AutoWrap> GetCart([FromQuery] GetCartRequest request)
    {
        return await _mediatr.Send(request);
    }

    [HttpDelete("delete/product")]
    public async Task<AutoWrap> DeleteProduct([FromBody] DeleteCartRequest request)
    {
        return await _mediatr.Send(request);
    }

    [HttpPost("save/cart")]
    public async Task<AutoWrap> SaveCart([FromBody] SaveCartRequest request)
    {
        return await _mediatr.Send(request);
    }
}
