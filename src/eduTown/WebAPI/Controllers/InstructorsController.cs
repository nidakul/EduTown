using Application.Features.Instructors.Commands.Create;
using Application.Features.Instructors.Commands.Delete;
using Application.Features.Instructors.Commands.Update;
using Application.Features.Instructors.Queries.GetById;
using Application.Features.Instructors.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstructorsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedInstructorResponse>> Add([FromBody] CreateInstructorCommand command)
    {
        CreatedInstructorResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedInstructorResponse>> Update([FromBody] UpdateInstructorCommand command)
    {
        UpdatedInstructorResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedInstructorResponse>> Delete([FromRoute] Guid id)
    {
        DeleteInstructorCommand command = new() { Id = id };

        DeletedInstructorResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdInstructorResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdInstructorQuery query = new() { Id = id };

        GetByIdInstructorResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListInstructorQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListInstructorQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListInstructorListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}