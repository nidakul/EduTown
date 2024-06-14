using Application.Features.Departments.Commands.Create;
using Application.Features.Departments.Commands.Delete;
using Application.Features.Departments.Commands.Update;
using Application.Features.Departments.Queries.GetById;
using Application.Features.Departments.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Departments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDepartmentCommand, Department>();
        CreateMap<Department, CreatedDepartmentResponse>();

        CreateMap<UpdateDepartmentCommand, Department>();
        CreateMap<Department, UpdatedDepartmentResponse>();

        CreateMap<DeleteDepartmentCommand, Department>();
        CreateMap<Department, DeletedDepartmentResponse>();

        CreateMap<Department, GetByIdDepartmentResponse>();

        CreateMap<Department, GetListDepartmentListItemDto>();
        CreateMap<IPaginate<Department>, GetListResponse<GetListDepartmentListItemDto>>();
    }
}