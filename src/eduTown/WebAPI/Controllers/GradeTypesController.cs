using Application.Features.GradeTypes.Commands.Create;
using Application.Features.GradeTypes.Commands.Delete;
using Application.Features.GradeTypes.Commands.Update;
using Application.Features.GradeTypes.Queries.GetById;
using Application.Features.GradeTypes.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GradeTypesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedGradeTypeResponse>> Add([FromBody] CreateGradeTypeCommand command)
    {
        CreatedGradeTypeResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedGradeTypeResponse>> Update([FromBody] UpdateGradeTypeCommand command)
    {
        UpdatedGradeTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedGradeTypeResponse>> Delete([FromRoute] int id)
    {
        DeleteGradeTypeCommand command = new() { Id = id };

        DeletedGradeTypeResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdGradeTypeResponse>> GetById([FromRoute] int id)
    {
        GetByIdGradeTypeQuery query = new() { Id = id };

        GetByIdGradeTypeResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListGradeTypeQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListGradeTypeQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListGradeTypeListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}