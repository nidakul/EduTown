using Application.Features.UserLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserLessons.Queries.GetById;

public class GetByIdUserLessonQuery : IRequest<GetByIdUserLessonResponse>
{
    public int Id { get; set; }

    public class GetByIdUserLessonQueryHandler : IRequestHandler<GetByIdUserLessonQuery, GetByIdUserLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserLessonRepository _userLessonRepository;
        private readonly UserLessonBusinessRules _userLessonBusinessRules;

        public GetByIdUserLessonQueryHandler(IMapper mapper, IUserLessonRepository userLessonRepository, UserLessonBusinessRules userLessonBusinessRules)
        {
            _mapper = mapper;
            _userLessonRepository = userLessonRepository;
            _userLessonBusinessRules = userLessonBusinessRules;
        }

        public async Task<GetByIdUserLessonResponse> Handle(GetByIdUserLessonQuery request, CancellationToken cancellationToken)
        {
            UserLesson? userLesson = await _userLessonRepository.GetAsync(predicate: ul => ul.Id == request.Id, cancellationToken: cancellationToken);
            await _userLessonBusinessRules.UserLessonShouldExistWhenSelected(userLesson);

            GetByIdUserLessonResponse response = _mapper.Map<GetByIdUserLessonResponse>(userLesson);
            return response;
        }
    }
}