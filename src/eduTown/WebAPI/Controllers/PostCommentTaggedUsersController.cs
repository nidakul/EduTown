using Application.Features.PostCommentTaggedUsers.Commands.Create;
using Application.Features.PostCommentTaggedUsers.Commands.Delete;
using Application.Features.PostCommentTaggedUsers.Commands.Update;
using Application.Features.PostCommentTaggedUsers.Queries.GetById;
using Application.Features.PostCommentTaggedUsers.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostCommentTaggedUsersController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPostCommentTaggedUserResponse>> Add([FromBody] CreatePostCommentTaggedUserCommand command)
    {
        CreatedPostCommentTaggedUserResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedPostCommentTaggedUserResponse>> Update([FromBody] UpdatePostCommentTaggedUserCommand command)
    {
        UpdatedPostCommentTaggedUserResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPostCommentTaggedUserResponse>> Delete([FromRoute] int id)
    {
        DeletePostCommentTaggedUserCommand command = new() { Id = id };

        DeletedPostCommentTaggedUserResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPostCommentTaggedUserResponse>> GetById([FromRoute] int id)
    {
        GetByIdPostCommentTaggedUserQuery query = new() { Id = id };

        GetByIdPostCommentTaggedUserResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListPostCommentTaggedUserQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPostCommentTaggedUserQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPostCommentTaggedUserListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}