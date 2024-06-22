using Application.Features.SchoolLessons.Commands.Create;
using Application.Features.SchoolLessons.Commands.Delete;
using Application.Features.SchoolLessons.Commands.Update;
using Application.Features.SchoolLessons.Queries.GetById;
using Application.Features.SchoolLessons.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchoolLessonsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSchoolLessonResponse>> Add([FromBody] CreateSchoolLessonCommand command)
    {
        CreatedSchoolLessonResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSchoolLessonResponse>> Update([FromBody] UpdateSchoolLessonCommand command)
    {
        UpdatedSchoolLessonResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSchoolLessonResponse>> Delete([FromRoute] int id)
    {
        DeleteSchoolLessonCommand command = new() { Id = id };

        DeletedSchoolLessonResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSchoolLessonResponse>> GetById([FromRoute] int id)
    {
        GetByIdSchoolLessonQuery query = new() { Id = id };

        GetByIdSchoolLessonResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSchoolLessonQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSchoolLessonQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSchoolLessonListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}