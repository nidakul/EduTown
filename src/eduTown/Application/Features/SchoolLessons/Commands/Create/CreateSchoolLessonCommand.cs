using Application.Features.SchoolLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolLessons.Commands.Create;

public class CreateSchoolLessonCommand : IRequest<CreatedSchoolLessonResponse>
{
    public required int SchoolId { get; set; }
    public required int LessonId { get; set; }

    public class CreateSchoolLessonCommandHandler : IRequestHandler<CreateSchoolLessonCommand, CreatedSchoolLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolLessonRepository _schoolLessonRepository;
        private readonly SchoolLessonBusinessRules _schoolLessonBusinessRules;

        public CreateSchoolLessonCommandHandler(IMapper mapper, ISchoolLessonRepository schoolLessonRepository,
                                         SchoolLessonBusinessRules schoolLessonBusinessRules)
        {
            _mapper = mapper;
            _schoolLessonRepository = schoolLessonRepository;
            _schoolLessonBusinessRules = schoolLessonBusinessRules;
        }

        public async Task<CreatedSchoolLessonResponse> Handle(CreateSchoolLessonCommand request, CancellationToken cancellationToken)
        {
            SchoolLesson schoolLesson = _mapper.Map<SchoolLesson>(request);

            await _schoolLessonRepository.AddAsync(schoolLesson);

            CreatedSchoolLessonResponse response = _mapper.Map<CreatedSchoolLessonResponse>(schoolLesson);
            return response;
        }
    }
}