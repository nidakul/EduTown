using Application.Features.SchoolLessons.Commands.Create;
using Application.Features.SchoolLessons.Commands.Delete;
using Application.Features.SchoolLessons.Commands.Update;
using Application.Features.SchoolLessons.Queries.GetById;
using Application.Features.SchoolLessons.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SchoolLessons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSchoolLessonCommand, SchoolLesson>();
        CreateMap<SchoolLesson, CreatedSchoolLessonResponse>();

        CreateMap<UpdateSchoolLessonCommand, SchoolLesson>();
        CreateMap<SchoolLesson, UpdatedSchoolLessonResponse>();

        CreateMap<DeleteSchoolLessonCommand, SchoolLesson>();
        CreateMap<SchoolLesson, DeletedSchoolLessonResponse>();

        CreateMap<SchoolLesson, GetByIdSchoolLessonResponse>();

        CreateMap<SchoolLesson, GetListSchoolLessonListItemDto>();
        CreateMap<IPaginate<SchoolLesson>, GetListResponse<GetListSchoolLessonListItemDto>>();
    }
}