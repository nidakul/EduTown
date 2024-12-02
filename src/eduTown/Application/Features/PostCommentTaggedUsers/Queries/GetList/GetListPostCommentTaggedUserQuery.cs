using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.PostCommentTaggedUsers.Queries.GetList;

public class GetListPostCommentTaggedUserQuery : IRequest<GetListResponse<GetListPostCommentTaggedUserListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListPostCommentTaggedUserQueryHandler : IRequestHandler<GetListPostCommentTaggedUserQuery, GetListResponse<GetListPostCommentTaggedUserListItemDto>>
    {
        private readonly IPostCommentTaggedUserRepository _postCommentTaggedUserRepository;
        private readonly IMapper _mapper;

        public GetListPostCommentTaggedUserQueryHandler(IPostCommentTaggedUserRepository postCommentTaggedUserRepository, IMapper mapper)
        {
            _postCommentTaggedUserRepository = postCommentTaggedUserRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPostCommentTaggedUserListItemDto>> Handle(GetListPostCommentTaggedUserQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PostCommentTaggedUser> postCommentTaggedUsers = await _postCommentTaggedUserRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPostCommentTaggedUserListItemDto> response = _mapper.Map<GetListResponse<GetListPostCommentTaggedUserListItemDto>>(postCommentTaggedUsers);
            return response;
        }
    }
}