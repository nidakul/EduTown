using Application.Features.PostCommentTaggedUsers.Commands.Create;
using Application.Features.PostCommentTaggedUsers.Commands.Delete;
using Application.Features.PostCommentTaggedUsers.Commands.Update;
using Application.Features.PostCommentTaggedUsers.Queries.GetById;
using Application.Features.PostCommentTaggedUsers.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.PostCommentTaggedUsers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostCommentTaggedUserCommand, PostCommentTaggedUser>();
        CreateMap<PostCommentTaggedUser, CreatedPostCommentTaggedUserResponse>();

        CreateMap<UpdatePostCommentTaggedUserCommand, PostCommentTaggedUser>();
        CreateMap<PostCommentTaggedUser, UpdatedPostCommentTaggedUserResponse>();

        CreateMap<DeletePostCommentTaggedUserCommand, PostCommentTaggedUser>();
        CreateMap<PostCommentTaggedUser, DeletedPostCommentTaggedUserResponse>();

        CreateMap<PostCommentTaggedUser, GetByIdPostCommentTaggedUserResponse>();

        CreateMap<PostCommentTaggedUser, GetListPostCommentTaggedUserListItemDto>();
        CreateMap<IPaginate<PostCommentTaggedUser>, GetListResponse<GetListPostCommentTaggedUserListItemDto>>();
    }
}