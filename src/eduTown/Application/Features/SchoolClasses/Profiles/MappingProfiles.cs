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
using Application.Features.SchoolClasses.GetBranchesBySchoolIdAndClassId;

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
            .ForMember(sc => sc.SchoolName, opt => opt.MapFrom(sc => sc.School.Name))
            .ForMember(sc => sc.Lessons, opt => opt.MapFrom(sc => sc.SchoolClassLessons
            .Select(scl => new LessonDto
            {
                LessonId = scl.Lesson.Id,
                LessonName = scl.Lesson.Name
            }).ToList()))
            .ReverseMap();

        CreateMap<SchoolClass, GetBranchesBySchoolIdAndClassIdResponse>()
           .ForMember(sc => sc.ClassroomName, opt => opt.MapFrom(sc => sc.Classroom.Name))
           .ForMember(sc => sc.SchoolName, opt => opt.MapFrom(sc => sc.School.Name))
           .ForMember(sc => sc.Branches, opt => opt.MapFrom(sc => sc.SchoolClassBranches
           .Select(scl => new BranchDto
           { 
               BranchId = scl.Branch.Id,
               BranchName = scl.Branch.Name
           }).ToList()))
           .ReverseMap();

        CreateMap<IPaginate<SchoolClass>, GetListResponse<GetListSchoolClassListItemDto>>();
    }
}