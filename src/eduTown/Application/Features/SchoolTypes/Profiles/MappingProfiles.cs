using Application.Features.SchoolTypes.Commands.Create;
using Application.Features.SchoolTypes.Commands.Delete;
using Application.Features.SchoolTypes.Commands.Update;
using Application.Features.SchoolTypes.Queries.GetById;
using Application.Features.SchoolTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SchoolTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSchoolTypeCommand, SchoolType>();
        CreateMap<SchoolType, CreatedSchoolTypeResponse>();

        CreateMap<UpdateSchoolTypeCommand, SchoolType>();
        CreateMap<SchoolType, UpdatedSchoolTypeResponse>();

        CreateMap<DeleteSchoolTypeCommand, SchoolType>();
        CreateMap<SchoolType, DeletedSchoolTypeResponse>();

        CreateMap<SchoolType, GetByIdSchoolTypeResponse>();

        CreateMap<SchoolType, GetListSchoolTypeListItemDto>();
        CreateMap<IPaginate<SchoolType>, GetListResponse<GetListSchoolTypeListItemDto>>();
    }
}