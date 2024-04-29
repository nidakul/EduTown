using Application.Features.StudentGrades.Commands.Create;
using Application.Features.StudentGrades.Commands.Delete;
using Application.Features.StudentGrades.Commands.Update;
using Application.Features.StudentGrades.Queries.GetById;
using Application.Features.StudentGrades.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentGradesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedStudentGradeResponse>> Add([FromBody] CreateStudentGradeCommand command)
    {
        CreatedStudentGradeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedStudentGradeResponse>> Update([FromBody] UpdateStudentGradeCommand command)
    {
        UpdatedStudentGradeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedStudentGradeResponse>> Delete([FromRoute] int id)
    {
        DeleteStudentGradeCommand command = new() { Id = id };

        DeletedStudentGradeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdStudentGradeResponse>> GetById([FromRoute] int id)
    {
        GetByIdStudentGradeQuery query = new() { Id = id };

        GetByIdStudentGradeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListStudentGradeQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentGradeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListStudentGradeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}