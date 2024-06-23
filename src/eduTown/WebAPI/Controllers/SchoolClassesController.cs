using Application.Features.SchoolClasses.Commands.Create;
using Application.Features.SchoolClasses.Commands.Delete;
using Application.Features.SchoolClasses.Commands.Update;
using Application.Features.SchoolClasses.Queries.GetById;
using Application.Features.SchoolClasses.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.SchoolClasses.Queries.GetLessonsBySchoolIdAndClassId;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchoolClassesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSchoolClassResponse>> Add([FromBody] CreateSchoolClassCommand command)
    {
        CreatedSchoolClassResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSchoolClassResponse>> Update([FromBody] UpdateSchoolClassCommand command)
    {
        UpdatedSchoolClassResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSchoolClassResponse>> Delete([FromRoute] int id)
    {
        DeleteSchoolClassCommand command = new() { Id = id };

        DeletedSchoolClassResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSchoolClassResponse>> GetById([FromRoute] int id)
    {
        GetByIdSchoolClassQuery query = new() { Id = id };

        GetByIdSchoolClassResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSchoolClassQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSchoolClassQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSchoolClassListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("getLessonsBySchoolIdAndClassId/{schoolId}/{classroomId}")]
    public async Task<IActionResult> GetLessonsBySchoolIdAndClassId([FromRoute] int schoolId, [FromRoute] int classroomId)
    {
        GetLessonsBySchoolIdAndClassIdResponse response = await Mediator.Send(new GetLessonsBySchoolIdAndClassIdQuery { SchoolId = schoolId, ClassroomId = classroomId });
        return Ok(response);
    }
}