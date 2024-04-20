using Application.Features.UserClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserClassrooms.Commands.Create;

public class CreateUserClassroomCommand : IRequest<CreatedUserClassroomResponse>
{
    public required Guid UserId { get; set; }
    public required int ClassroomId { get; set; }

    public class CreateUserClassroomCommandHandler : IRequestHandler<CreateUserClassroomCommand, CreatedUserClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserClassroomRepository _userClassroomRepository;
        private readonly UserClassroomBusinessRules _userClassroomBusinessRules;

        public CreateUserClassroomCommandHandler(IMapper mapper, IUserClassroomRepository userClassroomRepository,
                                         UserClassroomBusinessRules userClassroomBusinessRules)
        {
            _mapper = mapper;
            _userClassroomRepository = userClassroomRepository;
            _userClassroomBusinessRules = userClassroomBusinessRules;
        }

        public async Task<CreatedUserClassroomResponse> Handle(CreateUserClassroomCommand request, CancellationToken cancellationToken)
        {
            UserClassroom userClassroom = _mapper.Map<UserClassroom>(request);

            await _userClassroomRepository.AddAsync(userClassroom);

            CreatedUserClassroomResponse response = _mapper.Map<CreatedUserClassroomResponse>(userClassroom);
            return response;
        }
    }
}