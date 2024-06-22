using Application.Features.SchoolClassLessons.Commands.Create;
using Application.Features.SchoolClassLessons.Commands.Delete;
using Application.Features.SchoolClassLessons.Commands.Update;
using Application.Features.SchoolClassLessons.Queries.GetById;
using Application.Features.SchoolClassLessons.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.SchoolClassLessons.Queries.GetLessonsBySchoolIdAndClassroomId;

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

        //CreateMap<SchoolClassLesson, GetLessonsBySchoolIdAndClassroomIdResponse>()
        //         .ForMember(dest => dest.ClassroomName, opt => opt.MapFrom(src => src.SchoolClassroom.Classroom.Name))
        //         .ForMember(dest => dest.SchoolName, opt => opt.MapFrom(src => src.SchoolClassroom.School.Name))
        //         .ForMember(dest => dest.LessonNames, opt => opt.MapFrom(src =>
        //             new List<LessonDto> { new LessonDto { LessonName = src.Lesson.Name }}.ToList()
        //         ))
        //         .ReverseMap();


    }
}