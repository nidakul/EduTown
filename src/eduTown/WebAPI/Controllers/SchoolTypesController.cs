using Application.Features.SchoolTypes.Commands.Create;
using Application.Features.SchoolTypes.Commands.Delete;
using Application.Features.SchoolTypes.Commands.Update;
using Application.Features.SchoolTypes.Queries.GetById;
using Application.Features.SchoolTypes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.SchoolTypes.Queries.GetClassesBySchoolTypeId;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchoolTypesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSchoolTypeResponse>> Add([FromBody] CreateSchoolTypeCommand command)
    {
        CreatedSchoolTypeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSchoolTypeResponse>> Update([FromBody] UpdateSchoolTypeCommand command)
    {
        UpdatedSchoolTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSchoolTypeResponse>> Delete([FromRoute] int id)
    {
        DeleteSchoolTypeCommand command = new() { Id = id };

        DeletedSchoolTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSchoolTypeResponse>> GetById([FromRoute] int id)
    {
        GetByIdSchoolTypeQuery query = new() { Id = id };

        GetByIdSchoolTypeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSchoolTypeQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSchoolTypeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSchoolTypeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("getClassesBySchoolTypeId/{id}")]
    public async Task<ActionResult<GetClassesBySchoolTypeIdResponse>> GetClassesBySchoolTypeId([FromRoute] int id)
    {
        GetClassesBySchoolTypeIdQuery query = new() { Id = id };

        GetClassesBySchoolTypeIdResponse response = await Mediator.Send(query);

        return Ok(response);
    }
}

