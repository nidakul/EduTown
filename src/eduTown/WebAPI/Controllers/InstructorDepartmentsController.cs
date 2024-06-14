using Application.Features.InstructorDepartments.Commands.Create;
using Application.Features.InstructorDepartments.Commands.Delete;
using Application.Features.InstructorDepartments.Commands.Update;
using Application.Features.InstructorDepartments.Queries.GetById;
using Application.Features.InstructorDepartments.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorDepartmentsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedInstructorDepartmentResponse>> Add([FromBody] CreateInstructorDepartmentCommand command)
    {
        CreatedInstructorDepartmentResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedInstructorDepartmentResponse>> Update([FromBody] UpdateInstructorDepartmentCommand command)
    {
        UpdatedInstructorDepartmentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedInstructorDepartmentResponse>> Delete([FromRoute] int id)
    {
        DeleteInstructorDepartmentCommand command = new() { Id = id };

        DeletedInstructorDepartmentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdInstructorDepartmentResponse>> GetById([FromRoute] int id)
    {
        GetByIdInstructorDepartmentQuery query = new() { Id = id };

        GetByIdInstructorDepartmentResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListInstructorDepartmentQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListInstructorDepartmentQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListInstructorDepartmentListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}