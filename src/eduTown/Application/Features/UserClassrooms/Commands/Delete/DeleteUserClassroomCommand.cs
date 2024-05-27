using Application.Features.UserClassrooms.Constants;
using Application.Features.UserClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserClassrooms.Commands.Delete;

public class DeleteUserClassroomCommand : IRequest<DeletedUserClassroomResponse>
{
    public int Id { get; set; }

    public class DeleteUserClassroomCommandHandler : IRequestHandler<DeleteUserClassroomCommand, DeletedUserClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserClassroomRepository _userClassroomRepository;
        private readonly UserClassroomBusinessRules _userClassroomBusinessRules;

        public DeleteUserClassroomCommandHandler(IMapper mapper, IUserClassroomRepository userClassroomRepository,
                                         UserClassroomBusinessRules userClassroomBusinessRules)
        {
            _mapper = mapper;
            _userClassroomRepository = userClassroomRepository;
            _userClassroomBusinessRules = userClassroomBusinessRules;
        }

        public async Task<DeletedUserClassroomResponse> Handle(DeleteUserClassroomCommand request, CancellationToken cancellationToken)
        {
            UserClassroom? userClassroom = await _userClassroomRepository.GetAsync(predicate: uc => uc.Id == request.Id, cancellationToken: cancellationToken);
            await _userClassroomBusinessRules.UserClassroomShouldExistWhenSelected(userClassroom);

            await _userClassroomRepository.DeleteAsync(userClassroom!);

            DeletedUserClassroomResponse response = _mapper.Map<DeletedUserClassroomResponse>(userClassroom);
            return response;
        }
    }
}