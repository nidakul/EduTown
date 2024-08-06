using Application.Features.PostComments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostComments.Commands.Update;

public class UpdatePostCommentCommand : IRequest<UpdatedPostCommentResponse>
{
    public int Id { get; set; }
    public required Guid UserId { get; set; }
    public required int PostId { get; set; }
    public required string Comment { get; set; }

    public class UpdatePostCommentCommandHandler : IRequestHandler<UpdatePostCommentCommand, UpdatedPostCommentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly PostCommentBusinessRules _postCommentBusinessRules;

        public UpdatePostCommentCommandHandler(IMapper mapper, IPostCommentRepository postCommentRepository,
                                         PostCommentBusinessRules postCommentBusinessRules)
        {
            _mapper = mapper;
            _postCommentRepository = postCommentRepository;
            _postCommentBusinessRules = postCommentBusinessRules;
        }

        public async Task<UpdatedPostCommentResponse> Handle(UpdatePostCommentCommand request, CancellationToken cancellationToken)
        {
            PostComment? postComment = await _postCommentRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _postCommentBusinessRules.PostCommentShouldExistWhenSelected(postComment);
            postComment = _mapper.Map(request, postComment);

            await _postCommentRepository.UpdateAsync(postComment!);

            UpdatedPostCommentResponse response = _mapper.Map<UpdatedPostCommentResponse>(postComment);
            return response;
        }
    }
}