using Application.Features.SchoolTypeClasses.Commands.Create;
using Application.Features.SchoolTypeClasses.Commands.Delete;
using Application.Features.SchoolTypeClasses.Commands.Update;
using Application.Features.SchoolTypeClasses.Queries.GetById;
using Application.Features.SchoolTypeClasses.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SchoolTypeClasses.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSchoolTypeClassCommand, SchoolTypeClass>();
        CreateMap<SchoolTypeClass, CreatedSchoolTypeClassResponse>();

        CreateMap<UpdateSchoolTypeClassCommand, SchoolTypeClass>();
        CreateMap<SchoolTypeClass, UpdatedSchoolTypeClassResponse>();

        CreateMap<DeleteSchoolTypeClassCommand, SchoolTypeClass>();
        CreateMap<SchoolTypeClass, DeletedSchoolTypeClassResponse>();

        CreateMap<SchoolTypeClass, GetByIdSchoolTypeClassResponse>();

        CreateMap<SchoolTypeClass, GetListSchoolTypeClassListItemDto>();
        CreateMap<IPaginate<SchoolTypeClass>, GetListResponse<GetListSchoolTypeClassListItemDto>>();
    }
}