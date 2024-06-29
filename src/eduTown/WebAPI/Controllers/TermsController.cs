using Application.Features.Terms.Commands.Create;
using Application.Features.Terms.Commands.Delete;
using Application.Features.Terms.Commands.Update;
using Application.Features.Terms.Queries.GetById;
using Application.Features.Terms.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TermsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedTermResponse>> Add([FromBody] CreateTermCommand command)
    {
        CreatedTermResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedTermResponse>> Update([FromBody] UpdateTermCommand command)
    {
        UpdatedTermResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedTermResponse>> Delete([FromRoute] int id)
    {
        DeleteTermCommand command = new() { Id = id };

        DeletedTermResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdTermResponse>> GetById([FromRoute] int id)
    {
        GetByIdTermQuery query = new() { Id = id };

        GetByIdTermResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListTermQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListTermQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListTermListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}