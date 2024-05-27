using Application.Features.UserClassrooms.Commands.Create;
using Application.Features.UserClassrooms.Commands.Delete;
using Application.Features.UserClassrooms.Commands.Update;
using Application.Features.UserClassrooms.Queries.GetById;
using Application.Features.UserClassrooms.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserClassroomsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedUserClassroomResponse>> Add([FromBody] CreateUserClassroomCommand command)
    {
        CreatedUserClassroomResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedUserClassroomResponse>> Update([FromBody] UpdateUserClassroomCommand command)
    {
        UpdatedUserClassroomResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedUserClassroomResponse>> Delete([FromRoute] int id)
    {
        DeleteUserClassroomCommand command = new() { Id = id };

        DeletedUserClassroomResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdUserClassroomResponse>> GetById([FromRoute] int id)
    {
        GetByIdUserClassroomQuery query = new() { Id = id };

        GetByIdUserClassroomResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListUserClassroomQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserClassroomQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListUserClassroomListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}