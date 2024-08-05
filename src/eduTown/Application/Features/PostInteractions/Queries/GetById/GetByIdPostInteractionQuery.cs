using Application.Features.PostInteractions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostInteractions.Queries.GetById;

public class GetByIdPostInteractionQuery : IRequest<GetByIdPostInteractionResponse>
{
    public int Id { get; set; }

    public class GetByIdPostInteractionQueryHandler : IRequestHandler<GetByIdPostInteractionQuery, GetByIdPostInteractionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostInteractionRepository _postInteractionRepository;
        private readonly PostInteractionBusinessRules _postInteractionBusinessRules;

        public GetByIdPostInteractionQueryHandler(IMapper mapper, IPostInteractionRepository postInteractionRepository, PostInteractionBusinessRules postInteractionBusinessRules)
        {
            _mapper = mapper;
            _postInteractionRepository = postInteractionRepository;
            _postInteractionBusinessRules = postInteractionBusinessRules;
        }

        public async Task<GetByIdPostInteractionResponse> Handle(GetByIdPostInteractionQuery request, CancellationToken cancellationToken)
        {
            PostInteraction? postInteraction = await _postInteractionRepository.GetAsync(predicate: pi => pi.Id == request.Id, cancellationToken: cancellationToken);
            await _postInteractionBusinessRules.PostInteractionShouldExistWhenSelected(postInteraction);

            GetByIdPostInteractionResponse response = _mapper.Map<GetByIdPostInteractionResponse>(postInteraction);
            return response;
        }
    }
}