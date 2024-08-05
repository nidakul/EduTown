using Application.Features.PostInteractions.Commands.Create;
using Application.Features.PostInteractions.Commands.Delete;
using Application.Features.PostInteractions.Commands.Update;
using Application.Features.PostInteractions.Queries.GetById;
using Application.Features.PostInteractions.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.PostInteractions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostInteractionCommand, PostInteraction>();
        CreateMap<PostInteraction, CreatedPostInteractionResponse>();

        CreateMap<UpdatePostInteractionCommand, PostInteraction>();
        CreateMap<PostInteraction, UpdatedPostInteractionResponse>();

        CreateMap<DeletePostInteractionCommand, PostInteraction>();
        CreateMap<PostInteraction, DeletedPostInteractionResponse>();

        CreateMap<PostInteraction, GetByIdPostInteractionResponse>();

        CreateMap<PostInteraction, GetListPostInteractionListItemDto>();
        CreateMap<IPaginate<PostInteraction>, GetListResponse<GetListPostInteractionListItemDto>>();
    }
}