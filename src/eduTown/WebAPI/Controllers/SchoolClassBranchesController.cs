using Application.Features.SchoolClassBranches.Commands.Create;
using Application.Features.SchoolClassBranches.Commands.Delete;
using Application.Features.SchoolClassBranches.Commands.Update;
using Application.Features.SchoolClassBranches.Queries.GetById;
using Application.Features.SchoolClassBranches.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SchoolClassBranchesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedSchoolClassBranchResponse>> Add([FromBody] CreateSchoolClassBranchCommand command)
    {
        CreatedSchoolClassBranchResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedSchoolClassBranchResponse>> Update([FromBody] UpdateSchoolClassBranchCommand command)
    {
        UpdatedSchoolClassBranchResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedSchoolClassBranchResponse>> Delete([FromRoute] int id)
    {
        DeleteSchoolClassBranchCommand command = new() { Id = id };

        DeletedSchoolClassBranchResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdSchoolClassBranchResponse>> GetById([FromRoute] int id)
    {
        GetByIdSchoolClassBranchQuery query = new() { Id = id };

        GetByIdSchoolClassBranchResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListSchoolClassBranchQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListSchoolClassBranchQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListSchoolClassBranchListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}