using Application.Features.SchoolClasses.Commands.Create;
using Application.Features.SchoolClasses.Commands.Delete;
using Application.Features.SchoolClasses.Commands.Update;
using Application.Features.SchoolClasses.Queries.GetById;
using Application.Features.SchoolClasses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.SchoolClasses.Queries.GetLessonsBySchoolIdAndClassId;

namespace Application.Features.SchoolClasses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSchoolClassCommand, SchoolClass>();
        CreateMap<SchoolClass, CreatedSchoolClassResponse>();

        CreateMap<UpdateSchoolClassCommand, SchoolClass>();
        CreateMap<SchoolClass, UpdatedSchoolClassResponse>();

        CreateMap<DeleteSchoolClassCommand, SchoolClass>();
        CreateMap<SchoolClass, DeletedSchoolClassResponse>();

        CreateMap<SchoolClass, GetByIdSchoolClassResponse>();

        CreateMap<SchoolClass, GetListSchoolClassListItemDto>();

        CreateMap<SchoolClass, GetLessonsBySchoolIdAndClassIdResponse>()
            .ForMember(sc => sc.ClassroomName, opt => opt.MapFrom(sc => sc.Classroom.Name))
            .ForMember(sc => sc.LessonName, opt => opt.MapFrom(sc => sc.SchoolClassLessons.Select(sc => sc.Lesson.Name)))
            .ForMember(sc => sc.SchoolName, opt => opt.MapFrom(sc => sc.School.Name))
            .ReverseMap();
        CreateMap<IPaginate<SchoolClass>, GetListResponse<GetListSchoolClassListItemDto>>();
    }
}