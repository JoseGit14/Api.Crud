//using Api.Crud.Domain.MediatR;
//using Api.Crud.Domain.Request;
//using MediatR;
//using Microsoft.AspNetCore.Mvc;

//namespace Api.Crud.Controllers;

//[Route("v{version:apiVersion}")]
//[ApiController]
//[ApiVersion("1.0")]
//[ApiExplorerSettings(GroupName = "v1")]
//public class MemberController : ControllerBase
//{
//    private readonly IMediator _mediator;

//    public MemberController(IMediator mediator)
//    {
//        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
//    }

//    [HttpPost("insert")]
//    public async Task<AutoWrap> InsertMember([FromBody] InsertCustomerRequest request)
//    {
//        return await _mediator.Send(request);
//    }
//}
