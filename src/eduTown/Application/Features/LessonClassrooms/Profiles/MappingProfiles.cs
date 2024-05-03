using Application.Features.LessonClassrooms.Commands.Create;
using Application.Features.LessonClassrooms.Commands.Delete;
using Application.Features.LessonClassrooms.Commands.Update;
using Application.Features.LessonClassrooms.Queries.GetById;
using Application.Features.LessonClassrooms.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.LessonClassrooms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateLessonClassroomCommand, LessonClassroom>();
        CreateMap<LessonClassroom, CreatedLessonClassroomResponse>();

        CreateMap<UpdateLessonClassroomCommand, LessonClassroom>();
        CreateMap<LessonClassroom, UpdatedLessonClassroomResponse>();

        CreateMap<DeleteLessonClassroomCommand, LessonClassroom>();
        CreateMap<LessonClassroom, DeletedLessonClassroomResponse>();

        CreateMap<LessonClassroom, GetByIdLessonClassroomResponse>();

        CreateMap<LessonClassroom, GetListLessonClassroomListItemDto>();
        CreateMap<IPaginate<LessonClassroom>, GetListResponse<GetListLessonClassroomListItemDto>>();
    }
}