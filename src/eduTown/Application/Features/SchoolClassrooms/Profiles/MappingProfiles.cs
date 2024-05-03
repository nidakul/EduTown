using Application.Features.SchoolClassrooms.Commands.Create;
using Application.Features.SchoolClassrooms.Commands.Delete;
using Application.Features.SchoolClassrooms.Commands.Update;
using Application.Features.SchoolClassrooms.Queries.GetById;
using Application.Features.SchoolClassrooms.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SchoolClassrooms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSchoolClassroomCommand, SchoolClassroom>();
        CreateMap<SchoolClassroom, CreatedSchoolClassroomResponse>();

        CreateMap<UpdateSchoolClassroomCommand, SchoolClassroom>();
        CreateMap<SchoolClassroom, UpdatedSchoolClassroomResponse>();

        CreateMap<DeleteSchoolClassroomCommand, SchoolClassroom>();
        CreateMap<SchoolClassroom, DeletedSchoolClassroomResponse>();

        CreateMap<SchoolClassroom, GetByIdSchoolClassroomResponse>();

        CreateMap<SchoolClassroom, GetListSchoolClassroomListItemDto>();
        CreateMap<IPaginate<SchoolClassroom>, GetListResponse<GetListSchoolClassroomListItemDto>>();
    }
}