using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Posts.Queries.GetList;

public class GetListPostQuery : IRequest<GetListResponse<GetListPostListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListPostQueryHandler : IRequestHandler<GetListPostQuery, GetListResponse<GetListPostListItemDto>>
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public GetListPostQueryHandler(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPostListItemDto>> Handle(GetListPostQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Post> posts = await _postRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPostListItemDto> response = _mapper.Map<GetListResponse<GetListPostListItemDto>>(posts);
            return response;
        }
    }
}