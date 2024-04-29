using Application.Features.GradeTypes.Commands.Create;
using Application.Features.GradeTypes.Commands.Delete;
using Application.Features.GradeTypes.Commands.Update;
using Application.Features.GradeTypes.Queries.GetById;
using Application.Features.GradeTypes.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.GradeTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateGradeTypeCommand, GradeType>();
        CreateMap<GradeType, CreatedGradeTypeResponse>();

        CreateMap<UpdateGradeTypeCommand, GradeType>();
        CreateMap<GradeType, UpdatedGradeTypeResponse>();

        CreateMap<DeleteGradeTypeCommand, GradeType>();
        CreateMap<GradeType, DeletedGradeTypeResponse>();

        CreateMap<GradeType, GetByIdGradeTypeResponse>();

        CreateMap<GradeType, GetListGradeTypeListItemDto>();
        CreateMap<IPaginate<GradeType>, GetListResponse<GetListGradeTypeListItemDto>>();
    }
}