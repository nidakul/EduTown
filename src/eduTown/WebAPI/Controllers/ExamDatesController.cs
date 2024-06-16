using Application.Features.ExamDates.Commands.Create;
using Application.Features.ExamDates.Commands.Delete;
using Application.Features.ExamDates.Commands.Update;
using Application.Features.ExamDates.Queries.GetById;
using Application.Features.ExamDates.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ExamDatesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedExamDateResponse>> Add([FromBody] CreateExamDateCommand command)
    {
        CreatedExamDateResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedExamDateResponse>> Update([FromBody] UpdateExamDateCommand command)
    {
        UpdatedExamDateResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedExamDateResponse>> Delete([FromRoute] int id)
    {
        DeleteExamDateCommand command = new() { Id = id };

        DeletedExamDateResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdExamDateResponse>> GetById([FromRoute] int id)
    {
        GetByIdExamDateQuery query = new() { Id = id };

        GetByIdExamDateResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListExamDateQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListExamDateQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListExamDateListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}