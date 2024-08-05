using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.PostInteractions.Queries.GetList;

public class GetListPostInteractionQuery : IRequest<GetListResponse<GetListPostInteractionListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListPostInteractionQueryHandler : IRequestHandler<GetListPostInteractionQuery, GetListResponse<GetListPostInteractionListItemDto>>
    {
        private readonly IPostInteractionRepository _postInteractionRepository;
        private readonly IMapper _mapper;

        public GetListPostInteractionQueryHandler(IPostInteractionRepository postInteractionRepository, IMapper mapper)
        {
            _postInteractionRepository = postInteractionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPostInteractionListItemDto>> Handle(GetListPostInteractionQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PostInteraction> postInteractions = await _postInteractionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPostInteractionListItemDto> response = _mapper.Map<GetListResponse<GetListPostInteractionListItemDto>>(postInteractions);
            return response;
        }
    }
}