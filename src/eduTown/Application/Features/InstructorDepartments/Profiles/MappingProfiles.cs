using Application.Features.InstructorDepartments.Commands.Create;
using Application.Features.InstructorDepartments.Commands.Delete;
using Application.Features.InstructorDepartments.Commands.Update;
using Application.Features.InstructorDepartments.Queries.GetById;
using Application.Features.InstructorDepartments.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.InstructorDepartments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateInstructorDepartmentCommand, InstructorDepartment>();
        CreateMap<InstructorDepartment, CreatedInstructorDepartmentResponse>();

        CreateMap<UpdateInstructorDepartmentCommand, InstructorDepartment>();
        CreateMap<InstructorDepartment, UpdatedInstructorDepartmentResponse>();

        CreateMap<DeleteInstructorDepartmentCommand, InstructorDepartment>();
        CreateMap<InstructorDepartment, DeletedInstructorDepartmentResponse>();

        CreateMap<InstructorDepartment, GetByIdInstructorDepartmentResponse>();

        CreateMap<InstructorDepartment, GetListInstructorDepartmentListItemDto>();
        CreateMap<IPaginate<InstructorDepartment>, GetListResponse<GetListInstructorDepartmentListItemDto>>();
    }
}