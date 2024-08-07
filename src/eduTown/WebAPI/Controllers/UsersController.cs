﻿using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Commands.UpdateFromAuth;
using Application.Features.Users.Queries.GetById;
using Application.Features.Users.Queries.GetCertificatesByUserId;
using Application.Features.Users.Queries.GetInstructorByUserId;
using Application.Features.Users.Queries.GetList;
using Application.Features.Users.Queries.GetStudentByUserId;
using Application.Features.Users.Queries.GetStudentExamDateByUserId;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : BaseController
{
    [HttpGet("{Id}")]
    public async Task<IActionResult> GetById([FromRoute] GetByIdUserQuery getByIdUserQuery)
    {
        GetByIdUserResponse result = await Mediator.Send(getByIdUserQuery);
        return Ok(result);
    }

    [HttpGet("GetFromAuth")]
    public async Task<IActionResult> GetFromAuth()
    {
        GetByIdUserQuery getByIdUserQuery = new() { Id = getUserIdFromRequest() };
        GetByIdUserResponse result = await Mediator.Send(getByIdUserQuery);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserQuery getListUserQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListUserListItemDto> result = await Mediator.Send(getListUserQuery);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommand)
    {
        CreatedUserResponse result = await Mediator.Send(createUserCommand);
        return Created(uri: "", result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand updateUserCommand)
    {
        UpdatedUserResponse result = await Mediator.Send(updateUserCommand);
        return Ok(result);
    }

    [HttpPut("FromAuth")]
    public async Task<IActionResult> UpdateFromAuth([FromBody] UpdateUserFromAuthCommand updateUserFromAuthCommand)
    {
        updateUserFromAuthCommand.Id = getUserIdFromRequest();
        UpdatedUserFromAuthResponse result = await Mediator.Send(updateUserFromAuthCommand);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteUserCommand deleteUserCommand)
    {
        DeletedUserResponse result = await Mediator.Send(deleteUserCommand);
        return Ok(result);
    }

    [HttpGet("getStudentDetail/{id}")]
    public async Task<IActionResult> GetStudentByUserId([FromRoute] Guid id)
    {
        GetStudentByUserIdResponse response = await Mediator.Send(new GetStudentByUserIdQuery { Id = id });
        return Ok(response);
    }

    [HttpGet("getInstructorDetail/{id}")]
    public async Task<IActionResult> GetInstructorByUserId([FromRoute] Guid id)
    {
        GetInstructorByUserIdResponse response = await Mediator.Send(new GetInstructorByUserIdQuery { Id = id });
        return Ok(response);
    }


    [HttpGet("getStudentCertificate/{id}")]
    public async Task<IActionResult> GetCertificatesByUserId([FromRoute] Guid id)
    {
        GetCertificatesByUserIdResponse response = await Mediator.Send(new GetCertificatesByUserIdQuery { Id = id });
        return Ok(response);
    }

    
    [HttpGet("getStudentExamDate/{id}")]
    public async Task<IActionResult> GetStudentExamDateByUserId([FromRoute] Guid id)
    {
        GetStudentExamDateByUserIdResponse response = await Mediator.Send(new GetStudentExamDateByUserIdQuery { Id = id });
        return Ok(response);
    }

}

