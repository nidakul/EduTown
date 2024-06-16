using Application.Features.UserLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserLessons.Commands.Create;

public class CreateUserLessonCommand : IRequest<CreatedUserLessonResponse>
{
    public required Guid UserId { get; set; }
    public required int LessonId { get; set; }

    public class CreateUserLessonCommandHandler : IRequestHandler<CreateUserLessonCommand, CreatedUserLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserLessonRepository _userLessonRepository;
        private readonly UserLessonBusinessRules _userLessonBusinessRules;

        public CreateUserLessonCommandHandler(IMapper mapper, IUserLessonRepository userLessonRepository,
                                         UserLessonBusinessRules userLessonBusinessRules)
        {
            _mapper = mapper;
            _userLessonRepository = userLessonRepository;
            _userLessonBusinessRules = userLessonBusinessRules;
        }

        public async Task<CreatedUserLessonResponse> Handle(CreateUserLessonCommand request, CancellationToken cancellationToken)
        {
            UserLesson userLesson = _mapper.Map<UserLesson>(request);

            await _userLessonRepository.AddAsync(userLesson);

            CreatedUserLessonResponse response = _mapper.Map<CreatedUserLessonResponse>(userLesson);
            return response;
        }
    }
}