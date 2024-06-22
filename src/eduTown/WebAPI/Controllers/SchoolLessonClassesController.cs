using Application.Features.SchoolLessonClasses.Commands.Create;
using Application.Features.SchoolLessonClasses.Commands.Delete;
using Application.Features.SchoolLessonClasses.Commands.Update;
using Application.Features.SchoolLessonClasses.Queries.GetById;
using Application.Features.SchoolLessonClasses.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchoolLessonClassesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSchoolLessonClassResponse>> Add([FromBody] CreateSchoolLessonClassCommand command)
    {
        CreatedSchoolLessonClassResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSchoolLessonClassResponse>> Update([FromBody] UpdateSchoolLessonClassCommand command)
    {
        UpdatedSchoolLessonClassResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSchoolLessonClassResponse>> Delete([FromRoute] int id)
    {
        DeleteSchoolLessonClassCommand command = new() { Id = id };

        DeletedSchoolLessonClassResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSchoolLessonClassResponse>> GetById([FromRoute] int id)
    {
        GetByIdSchoolLessonClassQuery query = new() { Id = id };

        GetByIdSchoolLessonClassResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSchoolLessonClassQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSchoolLessonClassQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSchoolLessonClassListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}