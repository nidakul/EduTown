using Application.Features.SchoolLessonClasses.Commands.Create;
using Application.Features.SchoolLessonClasses.Commands.Delete;
using Application.Features.SchoolLessonClasses.Commands.Update;
using Application.Features.SchoolLessonClasses.Queries.GetById;
using Application.Features.SchoolLessonClasses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SchoolLessonClasses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSchoolLessonClassCommand, SchoolLessonClass>();
        CreateMap<SchoolLessonClass, CreatedSchoolLessonClassResponse>();

        CreateMap<UpdateSchoolLessonClassCommand, SchoolLessonClass>();
        CreateMap<SchoolLessonClass, UpdatedSchoolLessonClassResponse>();

        CreateMap<DeleteSchoolLessonClassCommand, SchoolLessonClass>();
        CreateMap<SchoolLessonClass, DeletedSchoolLessonClassResponse>();

        CreateMap<SchoolLessonClass, GetByIdSchoolLessonClassResponse>();

        CreateMap<SchoolLessonClass, GetListSchoolLessonClassListItemDto>();
        CreateMap<IPaginate<SchoolLessonClass>, GetListResponse<GetListSchoolLessonClassListItemDto>>();
    }
}