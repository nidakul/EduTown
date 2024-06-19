using Application.Features.SchoolClassLessons.Commands.Create;
using Application.Features.SchoolClassLessons.Commands.Delete;
using Application.Features.SchoolClassLessons.Commands.Update;
using Application.Features.SchoolClassLessons.Queries.GetById;
using Application.Features.SchoolClassLessons.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SchoolClassLessons.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSchoolClassLessonCommand, SchoolClassLesson>();
        CreateMap<SchoolClassLesson, CreatedSchoolClassLessonResponse>();

        CreateMap<UpdateSchoolClassLessonCommand, SchoolClassLesson>();
        CreateMap<SchoolClassLesson, UpdatedSchoolClassLessonResponse>();

        CreateMap<DeleteSchoolClassLessonCommand, SchoolClassLesson>();
        CreateMap<SchoolClassLesson, DeletedSchoolClassLessonResponse>();

        CreateMap<SchoolClassLesson, GetByIdSchoolClassLessonResponse>();

        CreateMap<SchoolClassLesson, GetListSchoolClassLessonListItemDto>();
        CreateMap<IPaginate<SchoolClassLesson>, GetListResponse<GetListSchoolClassLessonListItemDto>>();
    }
}