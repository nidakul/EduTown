using Application.Features.SchoolTypeClasses.Commands.Create;
using Application.Features.SchoolTypeClasses.Commands.Delete;
using Application.Features.SchoolTypeClasses.Commands.Update;
using Application.Features.SchoolTypeClasses.Queries.GetById;
using Application.Features.SchoolTypeClasses.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchoolTypeClassesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSchoolTypeClassResponse>> Add([FromBody] CreateSchoolTypeClassCommand command)
    {
        CreatedSchoolTypeClassResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSchoolTypeClassResponse>> Update([FromBody] UpdateSchoolTypeClassCommand command)
    {
        UpdatedSchoolTypeClassResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSchoolTypeClassResponse>> Delete([FromRoute] int id)
    {
        DeleteSchoolTypeClassCommand command = new() { Id = id };

        DeletedSchoolTypeClassResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSchoolTypeClassResponse>> GetById([FromRoute] int id)
    {
        GetByIdSchoolTypeClassQuery query = new() { Id = id };

        GetByIdSchoolTypeClassResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSchoolTypeClassQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSchoolTypeClassQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSchoolTypeClassListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}