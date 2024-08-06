using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.PostComments.Queries.GetList;

public class GetListPostCommentQuery : IRequest<GetListResponse<GetListPostCommentListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListPostCommentQueryHandler : IRequestHandler<GetListPostCommentQuery, GetListResponse<GetListPostCommentListItemDto>>
    {
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly IMapper _mapper;

        public GetListPostCommentQueryHandler(IPostCommentRepository postCommentRepository, IMapper mapper)
        {
            _postCommentRepository = postCommentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPostCommentListItemDto>> Handle(GetListPostCommentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PostComment> postComments = await _postCommentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPostCommentListItemDto> response = _mapper.Map<GetListResponse<GetListPostCommentListItemDto>>(postComments);
            return response;
        }
    }
}