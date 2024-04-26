using Application.Features.UserCertificates.Commands.Create;
using Application.Features.UserCertificates.Commands.Delete;
using Application.Features.UserCertificates.Commands.Update;
using Application.Features.UserCertificates.Queries.GetById;
using Application.Features.UserCertificates.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserCertificatesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedUserCertificateResponse>> Add([FromBody] CreateUserCertificateCommand command)
    {
        CreatedUserCertificateResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedUserCertificateResponse>> Update([FromBody] UpdateUserCertificateCommand command)
    {
        UpdatedUserCertificateResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedUserCertificateResponse>> Delete([FromRoute] int id)
    {
        DeleteUserCertificateCommand command = new() { Id = id };

        DeletedUserCertificateResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdUserCertificateResponse>> GetById([FromRoute] int id)
    {
        GetByIdUserCertificateQuery query = new() { Id = id };

        GetByIdUserCertificateResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListUserCertificateQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserCertificateQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListUserCertificateListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}