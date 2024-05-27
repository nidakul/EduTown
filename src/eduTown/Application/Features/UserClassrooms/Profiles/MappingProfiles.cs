using Application.Features.UserClassrooms.Commands.Create;
using Application.Features.UserClassrooms.Commands.Delete;
using Application.Features.UserClassrooms.Commands.Update;
using Application.Features.UserClassrooms.Queries.GetById;
using Application.Features.UserClassrooms.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserClassrooms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUserClassroomCommand, UserClassroom>();
        CreateMap<UserClassroom, CreatedUserClassroomResponse>();

        CreateMap<UpdateUserClassroomCommand, UserClassroom>();
        CreateMap<UserClassroom, UpdatedUserClassroomResponse>();

        CreateMap<DeleteUserClassroomCommand, UserClassroom>();
        CreateMap<UserClassroom, DeletedUserClassroomResponse>();

        CreateMap<UserClassroom, GetByIdUserClassroomResponse>();

        CreateMap<UserClassroom, GetListUserClassroomListItemDto>();
        CreateMap<IPaginate<UserClassroom>, GetListResponse<GetListUserClassroomListItemDto>>();
    }
}