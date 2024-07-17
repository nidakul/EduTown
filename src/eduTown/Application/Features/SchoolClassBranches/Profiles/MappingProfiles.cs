using Application.Features.SchoolClassBranches.Commands.Create;
using Application.Features.SchoolClassBranches.Commands.Delete;
using Application.Features.SchoolClassBranches.Commands.Update;
using Application.Features.SchoolClassBranches.Queries.GetById;
using Application.Features.SchoolClassBranches.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.SchoolClassBranches.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateSchoolClassBranchCommand, SchoolClassBranch>();
        CreateMap<SchoolClassBranch, CreatedSchoolClassBranchResponse>();

        CreateMap<UpdateSchoolClassBranchCommand, SchoolClassBranch>();
        CreateMap<SchoolClassBranch, UpdatedSchoolClassBranchResponse>();

        CreateMap<DeleteSchoolClassBranchCommand, SchoolClassBranch>();
        CreateMap<SchoolClassBranch, DeletedSchoolClassBranchResponse>();

        CreateMap<SchoolClassBranch, GetByIdSchoolClassBranchResponse>();

        CreateMap<SchoolClassBranch, GetListSchoolClassBranchListItemDto>();
        CreateMap<IPaginate<SchoolClassBranch>, GetListResponse<GetListSchoolClassBranchListItemDto>>();
    }
}