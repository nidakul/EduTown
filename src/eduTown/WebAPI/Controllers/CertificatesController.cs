using Application.Features.Certificates.Commands.Create;
using Application.Features.Certificates.Commands.Delete;
using Application.Features.Certificates.Commands.Update;
using Application.Features.Certificates.Queries.GetById;
using Application.Features.Certificates.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CertificatesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedCertificateResponse>> Add([FromBody] CreateCertificateCommand command)
    {
        CreatedCertificateResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedCertificateResponse>> Update([FromBody] UpdateCertificateCommand command)
    {
        UpdatedCertificateResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedCertificateResponse>> Delete([FromRoute] int id)
    {
        DeleteCertificateCommand command = new() { Id = id };

        DeletedCertificateResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdCertificateResponse>> GetById([FromRoute] int id)
    {
        GetByIdCertificateQuery query = new() { Id = id };

        GetByIdCertificateResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListCertificateQuery>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCertificateQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListCertificateListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}