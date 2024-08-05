using Application.Features.PostFiles.Commands.Create;
using Application.Features.PostFiles.Commands.Delete;
using Application.Features.PostFiles.Commands.Update;
using Application.Features.PostFiles.Queries.GetById;
using Application.Features.PostFiles.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.PostFiles.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostFileCommand, PostFile>();
        CreateMap<PostFile, CreatedPostFileResponse>();

        CreateMap<UpdatePostFileCommand, PostFile>();
        CreateMap<PostFile, UpdatedPostFileResponse>();

        CreateMap<DeletePostFileCommand, PostFile>();
        CreateMap<PostFile, DeletedPostFileResponse>();

        CreateMap<PostFile, GetByIdPostFileResponse>();

        CreateMap<PostFile, GetListPostFileListItemDto>();
        CreateMap<IPaginate<PostFile>, GetListResponse<GetListPostFileListItemDto>>();
    }
}