using Application.Features.Posts.Commands.Create;
using Application.Features.Posts.Commands.Delete;
using Application.Features.Posts.Commands.Update;
using Application.Features.Posts.Queries.GetById;
using Application.Features.Posts.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Posts.Queries.GetCommentByPostId;
using Application.Features.Posts.Queries.GetDetail;
using Application.Features.Posts.Queries.GetPostsBySchoolIdClassIdBranchId;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPostResponse>> Add([FromBody] CreatePostCommand command)
    {
        CreatedPostResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedPostResponse>> Update([FromBody] UpdatePostCommand command)
    {
        UpdatedPostResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPostResponse>> Delete([FromRoute] int id)
    {
        DeletePostCommand command = new() { Id = id };

        DeletedPostResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPostResponse>> GetById([FromRoute] int id)
    {
        GetByIdPostQuery query = new() { Id = id };

        GetByIdPostResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListPostQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPostQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPostListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("getPostComment/{id}")]
    public async Task<IActionResult> GetCommentByPostId([FromRoute] int id)
    {
        GetCommentByPostIdResponse response = await Mediator.Send(new GetCommentByPostIdQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getPostDetail/{id}")]
    public async Task<IActionResult> GetDetailByPostId([FromRoute] int id)
    {
        GetDetailByPostIdResponse response = await Mediator.Send(new GetDetailByPostIdQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getPostsBySchoolIdClassIdBranchId/{schoolId}/{classroomId}/{branchId}")]
    public async Task<IActionResult> GetPostsBySchoolIdClassIdBranchId([FromRoute] int schoolId, [FromRoute] int classroomId, [FromRoute] int branchId)
    {
        GetPostsBySchoolIdClassIdBranchIdResponse response = await Mediator.Send(new GetPostsBySchoolIdClassIdBranchIdQuery { SchoolId = schoolId, ClassroomId = classroomId, BranchId = branchId });
        return Ok(response);
    }
}