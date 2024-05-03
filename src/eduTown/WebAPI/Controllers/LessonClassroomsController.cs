using Application.Features.LessonClassrooms.Commands.Create;
using Application.Features.LessonClassrooms.Commands.Delete;
using Application.Features.LessonClassrooms.Commands.Update;
using Application.Features.LessonClassrooms.Queries.GetById;
using Application.Features.LessonClassrooms.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonClassroomsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedLessonClassroomResponse>> Add([FromBody] CreateLessonClassroomCommand command)
    {
        CreatedLessonClassroomResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedLessonClassroomResponse>> Update([FromBody] UpdateLessonClassroomCommand command)
    {
        UpdatedLessonClassroomResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedLessonClassroomResponse>> Delete([FromRoute] int id)
    {
        DeleteLessonClassroomCommand command = new() { Id = id };

        DeletedLessonClassroomResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdLessonClassroomResponse>> GetById([FromRoute] int id)
    {
        GetByIdLessonClassroomQuery query = new() { Id = id };

        GetByIdLessonClassroomResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListLessonClassroomQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLessonClassroomQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListLessonClassroomListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}