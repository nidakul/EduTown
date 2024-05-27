using Application.Features.UserClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserClassrooms.Commands.Update;

public class UpdateUserClassroomCommand : IRequest<UpdatedUserClassroomResponse>
{
    public int Id { get; set; }
    public required Guid UserId { get; set; }
    public required int ClassroomId { get; set; }

    public class UpdateUserClassroomCommandHandler : IRequestHandler<UpdateUserClassroomCommand, UpdatedUserClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserClassroomRepository _userClassroomRepository;
        private readonly UserClassroomBusinessRules _userClassroomBusinessRules;

        public UpdateUserClassroomCommandHandler(IMapper mapper, IUserClassroomRepository userClassroomRepository,
                                         UserClassroomBusinessRules userClassroomBusinessRules)
        {
            _mapper = mapper;
            _userClassroomRepository = userClassroomRepository;
            _userClassroomBusinessRules = userClassroomBusinessRules;
        }

        public async Task<UpdatedUserClassroomResponse> Handle(UpdateUserClassroomCommand request, CancellationToken cancellationToken)
        {
            UserClassroom? userClassroom = await _userClassroomRepository.GetAsync(predicate: uc => uc.Id == request.Id, cancellationToken: cancellationToken);
            await _userClassroomBusinessRules.UserClassroomShouldExistWhenSelected(userClassroom);
            userClassroom = _mapper.Map(request, userClassroom);

            await _userClassroomRepository.UpdateAsync(userClassroom!);

            UpdatedUserClassroomResponse response = _mapper.Map<UpdatedUserClassroomResponse>(userClassroom);
            return response;
        }
    }
}