using Application.Features.PostComments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostComments.Commands.Create;

public class CreatePostCommentCommand : IRequest<CreatedPostCommentResponse>
{
    public required Guid UserId { get; set; }
    public required int PostId { get; set; }
    public required string Comment { get; set; }
    public int? ParentCommentId { get; set; }

    public class CreatePostCommentCommandHandler : IRequestHandler<CreatePostCommentCommand, CreatedPostCommentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly PostCommentBusinessRules _postCommentBusinessRules;

        public CreatePostCommentCommandHandler(IMapper mapper, IPostCommentRepository postCommentRepository,
                                         PostCommentBusinessRules postCommentBusinessRules)
        {
            _mapper = mapper;
            _postCommentRepository = postCommentRepository;
            _postCommentBusinessRules = postCommentBusinessRules;
        }

        public async Task<CreatedPostCommentResponse> Handle(CreatePostCommentCommand request, CancellationToken cancellationToken)
        {
            PostComment postComment = _mapper.Map<PostComment>(request);

            await _postCommentRepository.AddAsync(postComment);

            CreatedPostCommentResponse response = _mapper.Map<CreatedPostCommentResponse>(postComment);
            return response;
        }
    }
}