using Application.Features.Students.Commands.Create;
using Application.Features.Students.Commands.Delete;
using Application.Features.Students.Commands.Update;
using Application.Features.Students.Queries.GetById;
using Application.Features.Students.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Users.Queries.GetStudentByUserId;
using Application.Features.Students.Queries.GetStudentDetail;
using Application.Features.Students.Queries.GetStudentGradesByStudentId;
using Application.Features.Students.Queries.GetListStudentsSchoolIdClassIdBranchId;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedStudentResponse>> Add([FromBody] CreateStudentCommand command)
    {
        CreatedStudentResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedStudentResponse>> Update([FromBody] UpdateStudentCommand command)
    {
        UpdatedStudentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedStudentResponse>> Delete([FromRoute] Guid id)
    {
        DeleteStudentCommand command = new() { Id = id };

        DeletedStudentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdStudentResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdStudentQuery query = new() { Id = id };

        GetByIdStudentResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListStudentQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStudentQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListStudentListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("getListStudentDetail")] 
    public async Task<ActionResult<GetListStudentDetailQuery>> GetListStudentDetail([FromQuery] PageRequest pageRequest)
    {
        GetListStudentDetailQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListStudentDetailResponse> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("getStudentGrades/{id}")]
    public async Task<IActionResult> GetStudentGradesByStudentId([FromRoute] Guid id)
    {
        GetStudentGradesByStudentIdResponse response = await Mediator.Send(new GetStudentGradesByStudentIdQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getListStudentsBySchoolIdClassIdBranchId/{schoolId}/{classroomId}/{branchId}")]
    public async Task<IActionResult> GetListStudentsBySchoolIdClassIdBranchId([FromRoute] int schoolId, [FromRoute] int classroomId, [FromRoute] int branchId)
    {
        GetListStudentsSchoolIdClassIdBranchIdResponse response = await Mediator.Send(new GetListStudentsSchoolIdClassIdBranchIdQuery { SchoolId = schoolId, ClassroomId = classroomId, BranchId = branchId });
            return Ok(response);
    }
}

