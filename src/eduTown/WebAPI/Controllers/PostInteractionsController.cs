using Application.Features.PostInteractions.Commands.Create;
using Application.Features.PostInteractions.Commands.Delete;
using Application.Features.PostInteractions.Commands.Update;
using Application.Features.PostInteractions.Queries.GetById;
using Application.Features.PostInteractions.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostInteractionsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPostInteractionResponse>> Add([FromBody] CreatePostInteractionCommand command)
    {
        CreatedPostInteractionResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedPostInteractionResponse>> Update([FromBody] UpdatePostInteractionCommand command)
    {
        UpdatedPostInteractionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPostInteractionResponse>> Delete([FromRoute] int id)
    {
        DeletePostInteractionCommand command = new() { Id = id };

        DeletedPostInteractionResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPostInteractionResponse>> GetById([FromRoute] int id)
    {
        GetByIdPostInteractionQuery query = new() { Id = id };

        GetByIdPostInteractionResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListPostInteractionQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPostInteractionQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPostInteractionListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}