using Application.Features.Terms.Commands.Create;
using Application.Features.Terms.Commands.Delete;
using Application.Features.Terms.Commands.Update;
using Application.Features.Terms.Queries.GetById;
using Application.Features.Terms.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Terms.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateTermCommand, Term>();
        CreateMap<Term, CreatedTermResponse>();

        CreateMap<UpdateTermCommand, Term>();
        CreateMap<Term, UpdatedTermResponse>();

        CreateMap<DeleteTermCommand, Term>();
        CreateMap<Term, DeletedTermResponse>();

        CreateMap<Term, GetByIdTermResponse>();

        CreateMap<Term, GetListTermListItemDto>();
        CreateMap<IPaginate<Term>, GetListResponse<GetListTermListItemDto>>();
    }
}