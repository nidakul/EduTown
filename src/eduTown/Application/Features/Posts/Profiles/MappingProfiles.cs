using Application.Features.Posts.Commands.Create;
using Application.Features.Posts.Commands.Delete;
using Application.Features.Posts.Commands.Update;
using Application.Features.Posts.Queries.GetById;
using Application.Features.Posts.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.Posts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostCommand, Post>();
        CreateMap<Post, CreatedPostResponse>();

        CreateMap<UpdatePostCommand, Post>();
        CreateMap<Post, UpdatedPostResponse>();

        CreateMap<DeletePostCommand, Post>();
        CreateMap<Post, DeletedPostResponse>();

        CreateMap<Post, GetByIdPostResponse>();

        CreateMap<Post, GetListPostListItemDto>();
        CreateMap<IPaginate<Post>, GetListResponse<GetListPostListItemDto>>();
    }
}