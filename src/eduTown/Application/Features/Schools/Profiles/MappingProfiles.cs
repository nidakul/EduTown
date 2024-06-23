using Application.Features.Schools.Commands.Create;
using Application.Features.Schools.Commands.Delete;
using Application.Features.Schools.Commands.Update;
using Application.Features.Schools.Queries.GetById;
using Application.Features.Schools.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;
using Application.Features.Schools.Queries.GetClassesBySchoolId;

namespace Application.Features.Schools.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSchoolCommand, School>();
        CreateMap<School, CreatedSchoolResponse>();

        CreateMap<UpdateSchoolCommand, School>();
        CreateMap<School, UpdatedSchoolResponse>();

        CreateMap<DeleteSchoolCommand, School>();
        CreateMap<School, DeletedSchoolResponse>();

        CreateMap<School, GetByIdSchoolResponse>();

        CreateMap<School, GetListSchoolListItemDto>();
        CreateMap<School, GetClassesBySchoolIdResponse>()
            .ForMember(s => s.ClassroomName, opt => opt.MapFrom(s => s.SchoolClasses.Select(s => s.Classroom.Name).ToList())) 
            .ForMember(s => s.SchoolName, opt => opt.MapFrom(s => s.Name))
            .ReverseMap();

        CreateMap<IPaginate<School>, GetListResponse<GetListSchoolListItemDto>>();
    }
}


