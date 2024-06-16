using Application.Features.StudentExamDates.Commands.Create;
using Application.Features.StudentExamDates.Commands.Delete;
using Application.Features.StudentExamDates.Commands.Update;
using Application.Features.StudentExamDates.Queries.GetById;
using Application.Features.StudentExamDates.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentExamDatesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedStudentExamDateResponse>> Add([FromBody] CreateStudentExamDateCommand command)
    {
        CreatedStudentExamDateResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedStudentExamDateResponse>> Update([FromBody] UpdateStudentExamDateCommand command)
    {
        UpdatedStudentExamDateResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedStudentExamDateResponse>> Delete([FromRoute] int id)
    {
        DeleteStudentExamDateCommand command = new() { Id = id };

        DeletedStudentExamDateResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdStudentExamDateResponse>> GetById([FromRoute] int id)
    {
        GetByIdStudentExamDateQuery query = new() { Id = id };

        GetByIdStudentExamDateResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListStudentExamDateQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentExamDateQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListStudentExamDateListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}