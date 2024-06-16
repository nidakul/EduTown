using Application.Features.LessonExamDates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonExamDates.Queries.GetById;

public class GetByIdLessonExamDateQuery : IRequest<GetByIdLessonExamDateResponse>
{
    public int Id { get; set; }

    public class GetByIdLessonExamDateQueryHandler : IRequestHandler<GetByIdLessonExamDateQuery, GetByIdLessonExamDateResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonExamDateRepository _lessonExamDateRepository;
        private readonly LessonExamDateBusinessRules _lessonExamDateBusinessRules;

        public GetByIdLessonExamDateQueryHandler(IMapper mapper, ILessonExamDateRepository lessonExamDateRepository, LessonExamDateBusinessRules lessonExamDateBusinessRules)
        {
            _mapper = mapper;
            _lessonExamDateRepository = lessonExamDateRepository;
            _lessonExamDateBusinessRules = lessonExamDateBusinessRules;
        }

        public async Task<GetByIdLessonExamDateResponse> Handle(GetByIdLessonExamDateQuery request, CancellationToken cancellationToken)
        {
            LessonExamDate? lessonExamDate = await _lessonExamDateRepository.GetAsync(predicate: led => led.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonExamDateBusinessRules.LessonExamDateShouldExistWhenSelected(lessonExamDate);

            GetByIdLessonExamDateResponse response = _mapper.Map<GetByIdLessonExamDateResponse>(lessonExamDate);
            return response;
        }
    }
}