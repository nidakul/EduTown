using Application.Features.UserLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserLessons.Commands.Update;

public class UpdateUserLessonCommand : IRequest<UpdatedUserLessonResponse>
{
    public int Id { get; set; }
    public required Guid UserId { get; set; }
    public required int LessonId { get; set; }

    public class UpdateUserLessonCommandHandler : IRequestHandler<UpdateUserLessonCommand, UpdatedUserLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserLessonRepository _userLessonRepository;
        private readonly UserLessonBusinessRules _userLessonBusinessRules;

        public UpdateUserLessonCommandHandler(IMapper mapper, IUserLessonRepository userLessonRepository,
                                         UserLessonBusinessRules userLessonBusinessRules)
        {
            _mapper = mapper;
            _userLessonRepository = userLessonRepository;
            _userLessonBusinessRules = userLessonBusinessRules;
        }

        public async Task<UpdatedUserLessonResponse> Handle(UpdateUserLessonCommand request, CancellationToken cancellationToken)
        {
            UserLesson? userLesson = await _userLessonRepository.GetAsync(predicate: ul => ul.Id == request.Id, cancellationToken: cancellationToken);
            await _userLessonBusinessRules.UserLessonShouldExistWhenSelected(userLesson);
            userLesson = _mapper.Map(request, userLesson);

            await _userLessonRepository.UpdateAsync(userLesson!);

            UpdatedUserLessonResponse response = _mapper.Map<UpdatedUserLessonResponse>(userLesson);
            return response;
        }
    }
}