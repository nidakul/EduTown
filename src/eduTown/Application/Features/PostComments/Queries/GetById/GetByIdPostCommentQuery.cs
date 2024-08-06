using Application.Features.PostComments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostComments.Queries.GetById;

public class GetByIdPostCommentQuery : IRequest<GetByIdPostCommentResponse>
{
    public int Id { get; set; }

    public class GetByIdPostCommentQueryHandler : IRequestHandler<GetByIdPostCommentQuery, GetByIdPostCommentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostCommentRepository _postCommentRepository;
        private readonly PostCommentBusinessRules _postCommentBusinessRules;

        public GetByIdPostCommentQueryHandler(IMapper mapper, IPostCommentRepository postCommentRepository, PostCommentBusinessRules postCommentBusinessRules)
        {
            _mapper = mapper;
            _postCommentRepository = postCommentRepository;
            _postCommentBusinessRules = postCommentBusinessRules;
        }

        public async Task<GetByIdPostCommentResponse> Handle(GetByIdPostCommentQuery request, CancellationToken cancellationToken)
        {
            PostComment? postComment = await _postCommentRepository.GetAsync(predicate: pc => pc.Id == request.Id, cancellationToken: cancellationToken);
            await _postCommentBusinessRules.PostCommentShouldExistWhenSelected(postComment);

            GetByIdPostCommentResponse response = _mapper.Map<GetByIdPostCommentResponse>(postComment);
            return response;
        }
    }
}