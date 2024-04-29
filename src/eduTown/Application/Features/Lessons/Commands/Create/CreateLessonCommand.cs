using Application.Features.Lessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Lessons.Commands.Create;

public class CreateLessonCommand : IRequest<CreatedLessonResponse>
{
    public required string Name { get; set; }

    public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, CreatedLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonRepository _lessonRepository;
        private readonly LessonBusinessRules _lessonBusinessRules;

        public CreateLessonCommandHandler(IMapper mapper, ILessonRepository lessonRepository,
                                         LessonBusinessRules lessonBusinessRules)
        {
            _mapper = mapper;
            _lessonRepository = lessonRepository;
            _lessonBusinessRules = lessonBusinessRules;
        }

        public async Task<CreatedLessonResponse> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            Lesson lesson = _mapper.Map<Lesson>(request);

            await _lessonRepository.AddAsync(lesson);

            CreatedLessonResponse response = _mapper.Map<CreatedLessonResponse>(lesson);
            return response;
        }
    }
}