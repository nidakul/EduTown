using Application.Features.Classrooms.Commands.Create;
using Application.Features.Classrooms.Commands.Delete;
using Application.Features.Classrooms.Commands.Update;
using Application.Features.Classrooms.Queries.GetById;
using Application.Features.Classrooms.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClassroomsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedClassroomResponse>> Add([FromBody] CreateClassroomCommand command)
    {
        CreatedClassroomResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedClassroomResponse>> Update([FromBody] UpdateClassroomCommand command)
    {
        UpdatedClassroomResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedClassroomResponse>> Delete([FromRoute] int id)
    {
        DeleteClassroomCommand command = new() { Id = id };

        DeletedClassroomResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdClassroomResponse>> GetById([FromRoute] int id)
    {
        GetByIdClassroomQuery query = new() { Id = id };

        GetByIdClassroomResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListClassroomQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListClassroomQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListClassroomListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}