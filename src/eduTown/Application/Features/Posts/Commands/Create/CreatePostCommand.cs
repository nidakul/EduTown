using Application.Features.Posts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Posts.Commands.Create;

public class CreatePostCommand : IRequest<CreatedPostResponse>
{
    public required Guid UserId { get; set; }
    public required int SchoolId { get; set; }
    public required int ClassroomId { get; set; }
    public required int BranchId { get; set; }
    public required int LikeCount { get; set; }
    public required string Message { get; set; }
    public required bool IsCommentable { get; set; }
    public List<string> FilePath { get; set; }


    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatedPostResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;
        private readonly PostBusinessRules _postBusinessRules;

        public CreatePostCommandHandler(IMapper mapper, IPostRepository postRepository,
                                         PostBusinessRules postBusinessRules)
        {
            _mapper = mapper;
            _postRepository = postRepository;
            _postBusinessRules = postBusinessRules;
        }

        public async Task<CreatedPostResponse> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            Post post = _mapper.Map<Post>(request);

            await _postRepository.AddAsync(post);

            CreatedPostResponse response = _mapper.Map<CreatedPostResponse>(post);
            return response;
        }
    }
}