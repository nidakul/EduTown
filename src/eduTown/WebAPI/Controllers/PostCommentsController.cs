using Application.Features.PostComments.Commands.Create;
using Application.Features.PostComments.Commands.Delete;
using Application.Features.PostComments.Commands.Update;
using Application.Features.PostComments.Queries.GetById;
using Application.Features.PostComments.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostCommentsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPostCommentResponse>> Add([FromBody] CreatePostCommentCommand command)
    {
        CreatedPostCommentResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedPostCommentResponse>> Update([FromBody] UpdatePostCommentCommand command)
    {
        UpdatedPostCommentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPostCommentResponse>> Delete([FromRoute] int id)
    {
        DeletePostCommentCommand command = new() { Id = id };

        DeletedPostCommentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPostCommentResponse>> GetById([FromRoute] int id)
    {
        GetByIdPostCommentQuery query = new() { Id = id };

        GetByIdPostCommentResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListPostCommentQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPostCommentQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPostCommentListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}