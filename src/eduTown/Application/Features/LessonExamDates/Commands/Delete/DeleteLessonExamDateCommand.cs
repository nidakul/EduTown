using Application.Features.LessonExamDates.Constants;
using Application.Features.LessonExamDates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonExamDates.Commands.Delete;

public class DeleteLessonExamDateCommand : IRequest<DeletedLessonExamDateResponse>
{
    public int Id { get; set; }

    public class DeleteLessonExamDateCommandHandler : IRequestHandler<DeleteLessonExamDateCommand, DeletedLessonExamDateResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonExamDateRepository _lessonExamDateRepository;
        private readonly LessonExamDateBusinessRules _lessonExamDateBusinessRules;

        public DeleteLessonExamDateCommandHandler(IMapper mapper, ILessonExamDateRepository lessonExamDateRepository,
                                         LessonExamDateBusinessRules lessonExamDateBusinessRules)
        {
            _mapper = mapper;
            _lessonExamDateRepository = lessonExamDateRepository;
            _lessonExamDateBusinessRules = lessonExamDateBusinessRules;
        }

        public async Task<DeletedLessonExamDateResponse> Handle(DeleteLessonExamDateCommand request, CancellationToken cancellationToken)
        {
            LessonExamDate? lessonExamDate = await _lessonExamDateRepository.GetAsync(predicate: led => led.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonExamDateBusinessRules.LessonExamDateShouldExistWhenSelected(lessonExamDate);

            await _lessonExamDateRepository.DeleteAsync(lessonExamDate!);

            DeletedLessonExamDateResponse response = _mapper.Map<DeletedLessonExamDateResponse>(lessonExamDate);
            return response;
        }
    }
}