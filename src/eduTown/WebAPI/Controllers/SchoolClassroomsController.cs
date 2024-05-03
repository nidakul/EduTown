using Application.Features.SchoolClassrooms.Commands.Create;
using Application.Features.SchoolClassrooms.Commands.Delete;
using Application.Features.SchoolClassrooms.Commands.Update;
using Application.Features.SchoolClassrooms.Queries.GetById;
using Application.Features.SchoolClassrooms.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchoolClassroomsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSchoolClassroomResponse>> Add([FromBody] CreateSchoolClassroomCommand command)
    {
        CreatedSchoolClassroomResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSchoolClassroomResponse>> Update([FromBody] UpdateSchoolClassroomCommand command)
    {
        UpdatedSchoolClassroomResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSchoolClassroomResponse>> Delete([FromRoute] int id)
    {
        DeleteSchoolClassroomCommand command = new() { Id = id };

        DeletedSchoolClassroomResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSchoolClassroomResponse>> GetById([FromRoute] int id)
    {
        GetByIdSchoolClassroomQuery query = new() { Id = id };

        GetByIdSchoolClassroomResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSchoolClassroomQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSchoolClassroomQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSchoolClassroomListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}