using Application.Features.Posts.Constants;
using Application.Features.Posts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Commands.Delete;

public class DeletePostCommand : IRequest<DeletedPostResponse>
{
    public int Id { get; set; }

    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, DeletedPostResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly PostBusinessRules _postBusinessRules;

        public DeletePostCommandHandler(IMapper mapper, IPostRepository postRepository,
                                         PostBusinessRules postBusinessRules)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _postBusinessRules = postBusinessRules;
        }

        public async Task<DeletedPostResponse> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            Post? post = await _postRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _postBusinessRules.PostShouldExistWhenSelected(post);

            await _postRepository.DeleteAsync(post!);

            DeletedPostResponse response = _mapper.Map<DeletedPostResponse>(post);
            return response;
        }
    }
}