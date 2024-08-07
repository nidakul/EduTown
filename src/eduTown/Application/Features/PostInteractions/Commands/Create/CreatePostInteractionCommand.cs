using Application.Features.PostInteractions.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostInteractions.Commands.Create;

public class CreatePostInteractionCommand : IRequest<CreatedPostInteractionResponse>
{
    public required int PostId { get; set; }
    public required Guid UserId { get; set; }
    public required bool IsFavorite { get; set; }
    public required bool IsLiked { get; set; }

    public class CreatePostInteractionCommandHandler : IRequestHandler<CreatePostInteractionCommand, CreatedPostInteractionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostInteractionRepository _postInteractionRepository;
        private readonly PostInteractionBusinessRules _postInteractionBusinessRules;

        public CreatePostInteractionCommandHandler(IMapper mapper, IPostInteractionRepository postInteractionRepository,
                                         PostInteractionBusinessRules postInteractionBusinessRules)
        {
            _mapper = mapper;
            _postInteractionRepository = postInteractionRepository;
            _postInteractionBusinessRules = postInteractionBusinessRules;
        }

        public async Task<CreatedPostInteractionResponse> Handle(CreatePostInteractionCommand request, CancellationToken cancellationToken)
        {
            PostInteraction postInteraction = _mapper.Map<PostInteraction>(request);

            await _postInteractionRepository.AddAsync(postInteraction);

            CreatedPostInteractionResponse response = _mapper.Map<CreatedPostInteractionResponse>(postInteraction);
            return response;
        }
    }
}