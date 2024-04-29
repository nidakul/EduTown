using Application.Features.StudentGradeLessons.Commands.Create;
using Application.Features.StudentGradeLessons.Commands.Delete;
using Application.Features.StudentGradeLessons.Commands.Update;
using Application.Features.StudentGradeLessons.Queries.GetById;
using Application.Features.StudentGradeLessons.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentGradeLessonsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedStudentGradeLessonResponse>> Add([FromBody] CreateStudentGradeLessonCommand command)
    {
        CreatedStudentGradeLessonResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedStudentGradeLessonResponse>> Update([FromBody] UpdateStudentGradeLessonCommand command)
    {
        UpdatedStudentGradeLessonResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedStudentGradeLessonResponse>> Delete([FromRoute] int id)
    {
        DeleteStudentGradeLessonCommand command = new() { Id = id };

        DeletedStudentGradeLessonResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdStudentGradeLessonResponse>> GetById([FromRoute] int id)
    {
        GetByIdStudentGradeLessonQuery query = new() { Id = id };

        GetByIdStudentGradeLessonResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListStudentGradeLessonQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentGradeLessonQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListStudentGradeLessonListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}