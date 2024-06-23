using Application.Features.SchoolLessons.Commands.Create;
using Application.Features.SchoolLessons.Commands.Delete;
using Application.Features.SchoolLessons.Commands.Update;
using Application.Features.SchoolLessons.Queries.GetById;
using Application.Features.SchoolLessons.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.SchoolLessons.Queries.GetLessonBySchoolIdAndClassId;

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
        CreateMap<SchoolLesson, GetLessonBySchoolIdAndClassIdResponse>()
            .ForMember(dest => dest.ClassroomName, opt => opt.MapFrom(src => src.Classrooms.FirstOrDefault().Name))
            .ForMember(sl => sl.LessonName, opt => opt.MapFrom(sl => sl.Lesson.Name.ToList()))
            .ForMember(sl => sl.SchoolName, opt => opt.MapFrom(sl => sl.School.Name))
            .ReverseMap();
        CreateMap<IPaginate<SchoolLesson>, GetListResponse<GetListSchoolLessonListItemDto>>();
    }
}


