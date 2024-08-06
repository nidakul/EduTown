using Application.Features.PostComments.Commands.Create;
using Application.Features.PostComments.Commands.Delete;
using Application.Features.PostComments.Commands.Update;
using Application.Features.PostComments.Queries.GetById;
using Application.Features.PostComments.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.PostComments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostCommentCommand, PostComment>();
        CreateMap<PostComment, CreatedPostCommentResponse>();

        CreateMap<UpdatePostCommentCommand, PostComment>();
        CreateMap<PostComment, UpdatedPostCommentResponse>();

        CreateMap<DeletePostCommentCommand, PostComment>();
        CreateMap<PostComment, DeletedPostCommentResponse>();

        CreateMap<PostComment, GetByIdPostCommentResponse>();

        CreateMap<PostComment, GetListPostCommentListItemDto>();
        CreateMap<IPaginate<PostComment>, GetListResponse<GetListPostCommentListItemDto>>();
    }
}