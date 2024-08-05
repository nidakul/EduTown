using Application.Features.PostFiles.Commands.Create;
using Application.Features.PostFiles.Commands.Delete;
using Application.Features.PostFiles.Commands.Update;
using Application.Features.PostFiles.Queries.GetById;
using Application.Features.PostFiles.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostFilesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedPostFileResponse>> Add([FromBody] CreatePostFileCommand command)
    {
        CreatedPostFileResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedPostFileResponse>> Update([FromBody] UpdatePostFileCommand command)
    {
        UpdatedPostFileResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedPostFileResponse>> Delete([FromRoute] int id)
    {
        DeletePostFileCommand command = new() { Id = id };

        DeletedPostFileResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdPostFileResponse>> GetById([FromRoute] int id)
    {
        GetByIdPostFileQuery query = new() { Id = id };

        GetByIdPostFileResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListPostFileQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListPostFileQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListPostFileListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}