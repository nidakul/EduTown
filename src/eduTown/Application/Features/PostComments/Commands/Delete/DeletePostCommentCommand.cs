using Application.Features.PostComments.Constants;
using Application.Features.PostComments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostComments.Commands.Delete;

public class DeletePostCommentCommand : IRequest<DeletedPostCommentResponse>
{
    public int Id { get; set; }

    public class DeletePostCommentCommandHandler : IRequestHandler<DeletePostCommentCommand, DeletedPostCommentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly PostCommentBusinessRules _postCommentBusinessRules;

        public DeletePostCommentCommandHandler(IMapper mapper, IPostCommentRepository postCommentRepository,
                                         PostCommentBusinessRules postCommentBusinessRules)
        {
            _mapper = mapper;
            _postCommentRepository = postCommentRepository;
            _postCommentBusinessRules = postCommentBusinessRules;
        }

        public async Task<DeletedPostCommentResponse> Handle(DeletePostCommentCommand request, CancellationToken cancellationToken)
        {
            PostComment? postComment = await _postCommentRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _postCommentBusinessRules.PostCommentShouldExistWhenSelected(postComment);

            await _postCommentRepository.DeleteAsync(postComment!);

            DeletedPostCommentResponse response = _mapper.Map<DeletedPostCommentResponse>(postComment);
            return response;
        }
    }
}