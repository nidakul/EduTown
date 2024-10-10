using Application.Features.PostCommentTaggedUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostCommentTaggedUsers.Queries.GetById;

public class GetByIdPostCommentTaggedUserQuery : IRequest<GetByIdPostCommentTaggedUserResponse>
{
    public int Id { get; set; }

    public class GetByIdPostCommentTaggedUserQueryHandler : IRequestHandler<GetByIdPostCommentTaggedUserQuery, GetByIdPostCommentTaggedUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostCommentTaggedUserRepository _postCommentTaggedUserRepository;
        private readonly PostCommentTaggedUserBusinessRules _postCommentTaggedUserBusinessRules;

        public GetByIdPostCommentTaggedUserQueryHandler(IMapper mapper, IPostCommentTaggedUserRepository postCommentTaggedUserRepository, PostCommentTaggedUserBusinessRules postCommentTaggedUserBusinessRules)
        {
            _mapper = mapper;
            _postCommentTaggedUserRepository = postCommentTaggedUserRepository;
            _postCommentTaggedUserBusinessRules = postCommentTaggedUserBusinessRules;
        }

        public async Task<GetByIdPostCommentTaggedUserResponse> Handle(GetByIdPostCommentTaggedUserQuery request, CancellationToken cancellationToken)
        {
            PostCommentTaggedUser? postCommentTaggedUser = await _postCommentTaggedUserRepository.GetAsync(predicate: pctu => pctu.Id == request.Id, cancellationToken: cancellationToken);
            await _postCommentTaggedUserBusinessRules.PostCommentTaggedUserShouldExistWhenSelected(postCommentTaggedUser);

            GetByIdPostCommentTaggedUserResponse response = _mapper.Map<GetByIdPostCommentTaggedUserResponse>(postCommentTaggedUser);
            return response;
        }
    }
}