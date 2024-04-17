using Application.Features.Instructors.Commands.Create;
using Application.Features.Instructors.Commands.Delete;
using Application.Features.Instructors.Commands.Update;
using Application.Features.Instructors.Queries.GetById;
using Application.Features.Instructors.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Instructors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateInstructorCommand, Instructor>();
        CreateMap<Instructor, CreatedInstructorResponse>();

        CreateMap<UpdateInstructorCommand, Instructor>();
        CreateMap<Instructor, UpdatedInstructorResponse>();

        CreateMap<DeleteInstructorCommand, Instructor>();
        CreateMap<Instructor, DeletedInstructorResponse>();

        CreateMap<Instructor, GetByIdInstructorResponse>();

        CreateMap<Instructor, GetListInstructorListItemDto>();
        CreateMap<IPaginate<Instructor>, GetListResponse<GetListInstructorListItemDto>>();
    }
}