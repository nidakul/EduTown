using Application.Features.Posts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Commands.Update;

public class UpdatePostCommand : IRequest<UpdatedPostResponse>
{
    public int Id { get; set; }
    public required Guid UserId { get; set; }
    public required int SchoolId { get; set; }
    public required int ClassroomId { get; set; }
    public required int BranchId { get; set; }
    public required int LikeCount { get; set; }
    public required string Message { get; set; }
    public required bool IsCommentable { get; set; }

    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, UpdatedPostResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly PostBusinessRules _postBusinessRules;

        public UpdatePostCommandHandler(IMapper mapper, IPostRepository postRepository,
                                         PostBusinessRules postBusinessRules)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _postBusinessRules = postBusinessRules;
        }

        public async Task<UpdatedPostResponse> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            Post? post = await _postRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _postBusinessRules.PostShouldExistWhenSelected(post);
            post = _mapper.Map(request, post);

            await _postRepository.UpdateAsync(post!);

            UpdatedPostResponse response = _mapper.Map<UpdatedPostResponse>(post);
            return response;
        }
    }
}