using Application.Features.LessonExamDates.Commands.Create;
using Application.Features.LessonExamDates.Commands.Delete;
using Application.Features.LessonExamDates.Commands.Update;
using Application.Features.LessonExamDates.Queries.GetById;
using Application.Features.LessonExamDates.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LessonExamDatesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedLessonExamDateResponse>> Add([FromBody] CreateLessonExamDateCommand command)
    {
        CreatedLessonExamDateResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedLessonExamDateResponse>> Update([FromBody] UpdateLessonExamDateCommand command)
    {
        UpdatedLessonExamDateResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedLessonExamDateResponse>> Delete([FromRoute] int id)
    {
        DeleteLessonExamDateCommand command = new() { Id = id };

        DeletedLessonExamDateResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdLessonExamDateResponse>> GetById([FromRoute] int id)
    {
        GetByIdLessonExamDateQuery query = new() { Id = id };

        GetByIdLessonExamDateResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListLessonExamDateQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListLessonExamDateQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListLessonExamDateListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}