using Application.Features.PostCommentTaggedUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostCommentTaggedUsers.Commands.Create;

public class CreatePostCommentTaggedUserCommand : IRequest<CreatedPostCommentTaggedUserResponse>
{
    public required int PostCommentId { get; set; }
    public required Guid UserId { get; set; }

    public class CreatePostCommentTaggedUserCommandHandler : IRequestHandler<CreatePostCommentTaggedUserCommand, CreatedPostCommentTaggedUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostCommentTaggedUserRepository _postCommentTaggedUserRepository;
        private readonly PostCommentTaggedUserBusinessRules _postCommentTaggedUserBusinessRules;

        public CreatePostCommentTaggedUserCommandHandler(IMapper mapper, IPostCommentTaggedUserRepository postCommentTaggedUserRepository,
                                         PostCommentTaggedUserBusinessRules postCommentTaggedUserBusinessRules)
        {
            _mapper = mapper;
            _postCommentTaggedUserRepository = postCommentTaggedUserRepository;
            _postCommentTaggedUserBusinessRules = postCommentTaggedUserBusinessRules;
        }

        public async Task<CreatedPostCommentTaggedUserResponse> Handle(CreatePostCommentTaggedUserCommand request, CancellationToken cancellationToken)
        {
            PostCommentTaggedUser postCommentTaggedUser = _mapper.Map<PostCommentTaggedUser>(request);

            await _postCommentTaggedUserRepository.AddAsync(postCommentTaggedUser);

            CreatedPostCommentTaggedUserResponse response = _mapper.Map<CreatedPostCommentTaggedUserResponse>(postCommentTaggedUser);
            return response;
        }
    }
}