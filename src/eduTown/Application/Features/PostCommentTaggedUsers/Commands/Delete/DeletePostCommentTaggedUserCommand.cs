using Application.Features.PostCommentTaggedUsers.Constants;
using Application.Features.PostCommentTaggedUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostCommentTaggedUsers.Commands.Delete;

public class DeletePostCommentTaggedUserCommand : IRequest<DeletedPostCommentTaggedUserResponse>
{
    public int Id { get; set; }

    public class DeletePostCommentTaggedUserCommandHandler : IRequestHandler<DeletePostCommentTaggedUserCommand, DeletedPostCommentTaggedUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostCommentTaggedUserRepository _postCommentTaggedUserRepository;
        private readonly PostCommentTaggedUserBusinessRules _postCommentTaggedUserBusinessRules;

        public DeletePostCommentTaggedUserCommandHandler(IMapper mapper, IPostCommentTaggedUserRepository postCommentTaggedUserRepository,
                                         PostCommentTaggedUserBusinessRules postCommentTaggedUserBusinessRules)
        {
            _mapper = mapper;
            _postCommentTaggedUserRepository = postCommentTaggedUserRepository;
            _postCommentTaggedUserBusinessRules = postCommentTaggedUserBusinessRules;
        }

        public async Task<DeletedPostCommentTaggedUserResponse> Handle(DeletePostCommentTaggedUserCommand request, CancellationToken cancellationToken)
        {
            PostCommentTaggedUser? postCommentTaggedUser = await _postCommentTaggedUserRepository.GetAsync(predicate: pctu => pctu.Id == request.Id, cancellationToken: cancellationToken);
            await _postCommentTaggedUserBusinessRules.PostCommentTaggedUserShouldExistWhenSelected(postCommentTaggedUser);

            await _postCommentTaggedUserRepository.DeleteAsync(postCommentTaggedUser!);

            DeletedPostCommentTaggedUserResponse response = _mapper.Map<DeletedPostCommentTaggedUserResponse>(postCommentTaggedUser);
            return response;
        }
    }
}