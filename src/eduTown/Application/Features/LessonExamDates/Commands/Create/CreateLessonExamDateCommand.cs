using Application.Features.LessonExamDates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonExamDates.Commands.Create;

public class CreateLessonExamDateCommand : IRequest<CreatedLessonExamDateResponse>
{
    public required int LessonId { get; set; }
    public required int ExamDateId { get; set; }

    public class CreateLessonExamDateCommandHandler : IRequestHandler<CreateLessonExamDateCommand, CreatedLessonExamDateResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonExamDateRepository _lessonExamDateRepository;
        private readonly LessonExamDateBusinessRules _lessonExamDateBusinessRules;

        public CreateLessonExamDateCommandHandler(IMapper mapper, ILessonExamDateRepository lessonExamDateRepository,
                                         LessonExamDateBusinessRules lessonExamDateBusinessRules)
        {
            _mapper = mapper;
            _lessonExamDateRepository = lessonExamDateRepository;
            _lessonExamDateBusinessRules = lessonExamDateBusinessRules;
        }

        public async Task<CreatedLessonExamDateResponse> Handle(CreateLessonExamDateCommand request, CancellationToken cancellationToken)
        {
            LessonExamDate lessonExamDate = _mapper.Map<LessonExamDate>(request);

            await _lessonExamDateRepository.AddAsync(lessonExamDate);

            CreatedLessonExamDateResponse response = _mapper.Map<CreatedLessonExamDateResponse>(lessonExamDate);
            return response;
        }
    }
}