using Application.Features.Classrooms.Commands.Create;
using Application.Features.Classrooms.Commands.Delete;
using Application.Features.Classrooms.Commands.Update;
using Application.Features.Classrooms.Queries.GetById;
using Application.Features.Classrooms.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Classrooms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateClassroomCommand, Classroom>();
        CreateMap<Classroom, CreatedClassroomResponse>();

        CreateMap<UpdateClassroomCommand, Classroom>();
        CreateMap<Classroom, UpdatedClassroomResponse>();

        CreateMap<DeleteClassroomCommand, Classroom>();
        CreateMap<Classroom, DeletedClassroomResponse>();

        CreateMap<Classroom, GetByIdClassroomResponse>();

        CreateMap<Classroom, GetListClassroomListItemDto>();
        CreateMap<IPaginate<Classroom>, GetListResponse<GetListClassroomListItemDto>>();
    }
}