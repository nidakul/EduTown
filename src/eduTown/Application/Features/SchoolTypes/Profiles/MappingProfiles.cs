using Application.Features.SchoolTypes.Commands.Create;
using Application.Features.SchoolTypes.Commands.Delete;
using Application.Features.SchoolTypes.Commands.Update;
using Application.Features.SchoolTypes.Queries.GetById;
using Application.Features.SchoolTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.SchoolTypes.Queries.GetClassesBySchoolTypeId;

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

        CreateMap<SchoolType, GetClassesBySchoolTypeIdResponse>()
            .ForMember(st => st.SchoolTypeId, opt => opt.MapFrom(st=> st.Id))
            .ForMember(st => st.SchoolTypeName, opt => opt.MapFrom(st=> st.Name))
            .ForMember(st => st.ClassroomName, opt => opt.MapFrom(st=> st.SchoolTypeClasses.Select(st => st.Classroom.Name).ToList()))
           .ReverseMap();

    }
}