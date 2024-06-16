using Application.Features.UserLessons.Constants;
using Application.Features.UserLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserLessons.Commands.Delete;

public class DeleteUserLessonCommand : IRequest<DeletedUserLessonResponse>
{
    public int Id { get; set; }

    public class DeleteUserLessonCommandHandler : IRequestHandler<DeleteUserLessonCommand, DeletedUserLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserLessonRepository _userLessonRepository;
        private readonly UserLessonBusinessRules _userLessonBusinessRules;

        public DeleteUserLessonCommandHandler(IMapper mapper, IUserLessonRepository userLessonRepository,
                                         UserLessonBusinessRules userLessonBusinessRules)
        {
            _mapper = mapper;
            _userLessonRepository = userLessonRepository;
            _userLessonBusinessRules = userLessonBusinessRules;
        }

        public async Task<DeletedUserLessonResponse> Handle(DeleteUserLessonCommand request, CancellationToken cancellationToken)
        {
            UserLesson? userLesson = await _userLessonRepository.GetAsync(predicate: ul => ul.Id == request.Id, cancellationToken: cancellationToken);
            await _userLessonBusinessRules.UserLessonShouldExistWhenSelected(userLesson);

            await _userLessonRepository.DeleteAsync(userLesson!);

            DeletedUserLessonResponse response = _mapper.Map<DeletedUserLessonResponse>(userLesson);
            return response;
        }
    }
}