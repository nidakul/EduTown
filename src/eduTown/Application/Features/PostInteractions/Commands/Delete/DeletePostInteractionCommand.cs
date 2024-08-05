using Application.Features.PostInteractions.Constants;
using Application.Features.PostInteractions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostInteractions.Commands.Delete;

public class DeletePostInteractionCommand : IRequest<DeletedPostInteractionResponse>
{
    public int Id { get; set; }

    public class DeletePostInteractionCommandHandler : IRequestHandler<DeletePostInteractionCommand, DeletedPostInteractionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostInteractionRepository _postInteractionRepository;
        private readonly PostInteractionBusinessRules _postInteractionBusinessRules;

        public DeletePostInteractionCommandHandler(IMapper mapper, IPostInteractionRepository postInteractionRepository,
                                         PostInteractionBusinessRules postInteractionBusinessRules)
        {
            _mapper = mapper;
            _postInteractionRepository = postInteractionRepository;
            _postInteractionBusinessRules = postInteractionBusinessRules;
        }

        public async Task<DeletedPostInteractionResponse> Handle(DeletePostInteractionCommand request, CancellationToken cancellationToken)
        {
            PostInteraction? postInteraction = await _postInteractionRepository.GetAsync(predicate: pi => pi.Id == request.Id, cancellationToken: cancellationToken);
            await _postInteractionBusinessRules.PostInteractionShouldExistWhenSelected(postInteraction);

            await _postInteractionRepository.DeleteAsync(postInteraction!);

            DeletedPostInteractionResponse response = _mapper.Map<DeletedPostInteractionResponse>(postInteraction);
            return response;
        }
    }
}