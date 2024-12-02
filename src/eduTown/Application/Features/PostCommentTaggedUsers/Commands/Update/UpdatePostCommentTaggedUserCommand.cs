using Application.Features.PostCommentTaggedUsers.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.PostCommentTaggedUsers.Commands.Update;

public class UpdatePostCommentTaggedUserCommand : IRequest<UpdatedPostCommentTaggedUserResponse>
{
    public int Id { get; set; }
    public required int PostCommentId { get; set; }
    public required Guid UserId { get; set; }

    public class UpdatePostCommentTaggedUserCommandHandler : IRequestHandler<UpdatePostCommentTaggedUserCommand, UpdatedPostCommentTaggedUserResponse>
    {
        private readonly IMapper _mapper;
        private readonly IPostCommentTaggedUserRepository _postCommentTaggedUserRepository;
        private readonly PostCommentTaggedUserBusinessRules _postCommentTaggedUserBusinessRules;

        public UpdatePostCommentTaggedUserCommandHandler(IMapper mapper, IPostCommentTaggedUserRepository postCommentTaggedUserRepository,
                                         PostCommentTaggedUserBusinessRules postCommentTaggedUserBusinessRules)
        {
            _mapper = mapper;
            _postCommentTaggedUserRepository = postCommentTaggedUserRepository;
            _postCommentTaggedUserBusinessRules = postCommentTaggedUserBusinessRules;
        }

        public async Task<UpdatedPostCommentTaggedUserResponse> Handle(UpdatePostCommentTaggedUserCommand request, CancellationToken cancellationToken)
        {
            PostCommentTaggedUser? postCommentTaggedUser = await _postCommentTaggedUserRepository.GetAsync(predicate: pctu => pctu.Id == request.Id, cancellationToken: cancellationToken);
            await _postCommentTaggedUserBusinessRules.PostCommentTaggedUserShouldExistWhenSelected(postCommentTaggedUser);
            postCommentTaggedUser = _mapper.Map(request, postCommentTaggedUser);

            await _postCommentTaggedUserRepository.UpdateAsync(postCommentTaggedUser!);

            UpdatedPostCommentTaggedUserResponse response = _mapper.Map<UpdatedPostCommentTaggedUserResponse>(postCommentTaggedUser);
            return response;
        }
    }
}