using Application.Features.PostInteractions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostInteractions.Commands.Update;

public class UpdatePostInteractionCommand : IRequest<UpdatedPostInteractionResponse>
{
    public int Id { get; set; }
    public required int PostId { get; set; }
    public required Guid UserId { get; set; }
    public required string Comment { get; set; }
    public required bool IsFavorite { get; set; }
    public required bool IsLiked { get; set; }

    public class UpdatePostInteractionCommandHandler : IRequestHandler<UpdatePostInteractionCommand, UpdatedPostInteractionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostInteractionRepository _postInteractionRepository;
        private readonly PostInteractionBusinessRules _postInteractionBusinessRules;

        public UpdatePostInteractionCommandHandler(IMapper mapper, IPostInteractionRepository postInteractionRepository,
                                         PostInteractionBusinessRules postInteractionBusinessRules)
        {
            _mapper = mapper;
            _postInteractionRepository = postInteractionRepository;
            _postInteractionBusinessRules = postInteractionBusinessRules;
        }

        public async Task<UpdatedPostInteractionResponse> Handle(UpdatePostInteractionCommand request, CancellationToken cancellationToken)
        {
            PostInteraction? postInteraction = await _postInteractionRepository.GetAsync(predicate: pi => pi.Id == request.Id, cancellationToken: cancellationToken);
            await _postInteractionBusinessRules.PostInteractionShouldExistWhenSelected(postInteraction);
            postInteraction = _mapper.Map(request, postInteraction);

            await _postInteractionRepository.UpdateAsync(postInteraction!);

            UpdatedPostInteractionResponse response = _mapper.Map<UpdatedPostInteractionResponse>(postInteraction);
            return response;
        }
    }
}