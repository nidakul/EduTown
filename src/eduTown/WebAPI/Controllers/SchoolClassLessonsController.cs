using Application.Features.SchoolClassLessons.Commands.Create;
using Application.Features.SchoolClassLessons.Commands.Delete;
using Application.Features.SchoolClassLessons.Commands.Update;
using Application.Features.SchoolClassLessons.Queries.GetById;
using Application.Features.SchoolClassLessons.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchoolClassLessonsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSchoolClassLessonResponse>> Add([FromBody] CreateSchoolClassLessonCommand command)
    {
        CreatedSchoolClassLessonResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSchoolClassLessonResponse>> Update([FromBody] UpdateSchoolClassLessonCommand command)
    {
        UpdatedSchoolClassLessonResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSchoolClassLessonResponse>> Delete([FromRoute] int id)
    {
        DeleteSchoolClassLessonCommand command = new() { Id = id };

        DeletedSchoolClassLessonResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSchoolClassLessonResponse>> GetById([FromRoute] int id)
    {
        GetByIdSchoolClassLessonQuery query = new() { Id = id };

        GetByIdSchoolClassLessonResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSchoolClassLessonQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSchoolClassLessonQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSchoolClassLessonListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}