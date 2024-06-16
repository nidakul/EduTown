using Application.Features.LessonExamDates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonExamDates.Commands.Update;

public class UpdateLessonExamDateCommand : IRequest<UpdatedLessonExamDateResponse>
{
    public int Id { get; set; }
    public required int LessonId { get; set; }
    public required int ExamDateId { get; set; }

    public class UpdateLessonExamDateCommandHandler : IRequestHandler<UpdateLessonExamDateCommand, UpdatedLessonExamDateResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonExamDateRepository _lessonExamDateRepository;
        private readonly LessonExamDateBusinessRules _lessonExamDateBusinessRules;

        public UpdateLessonExamDateCommandHandler(IMapper mapper, ILessonExamDateRepository lessonExamDateRepository,
                                         LessonExamDateBusinessRules lessonExamDateBusinessRules)
        {
            _mapper = mapper;
            _lessonExamDateRepository = lessonExamDateRepository;
            _lessonExamDateBusinessRules = lessonExamDateBusinessRules;
        }

        public async Task<UpdatedLessonExamDateResponse> Handle(UpdateLessonExamDateCommand request, CancellationToken cancellationToken)
        {
            LessonExamDate? lessonExamDate = await _lessonExamDateRepository.GetAsync(predicate: led => led.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonExamDateBusinessRules.LessonExamDateShouldExistWhenSelected(lessonExamDate);
            lessonExamDate = _mapper.Map(request, lessonExamDate);

            await _lessonExamDateRepository.UpdateAsync(lessonExamDate!);

            UpdatedLessonExamDateResponse response = _mapper.Map<UpdatedLessonExamDateResponse>(lessonExamDate);
            return response;
        }
    }
}