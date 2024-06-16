using Application.Features.UserLessons.Commands.Create;
using Application.Features.UserLessons.Commands.Delete;
using Application.Features.UserLessons.Commands.Update;
using Application.Features.UserLessons.Queries.GetById;
using Application.Features.UserLessons.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserLessonsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedUserLessonResponse>> Add([FromBody] CreateUserLessonCommand command)
    {
        CreatedUserLessonResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedUserLessonResponse>> Update([FromBody] UpdateUserLessonCommand command)
    {
        UpdatedUserLessonResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedUserLessonResponse>> Delete([FromRoute] int id)
    {
        DeleteUserLessonCommand command = new() { Id = id };

        DeletedUserLessonResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdUserLessonResponse>> GetById([FromRoute] int id)
    {
        GetByIdUserLessonQuery query = new() { Id = id };

        GetByIdUserLessonResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListUserLessonQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserLessonQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListUserLessonListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}