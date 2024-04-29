using Application.Features.StudentGradeLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentGradeLessons.Commands.Create;

public class CreateStudentGradeLessonCommand : IRequest<CreatedStudentGradeLessonResponse>
{
    public required int StudentGradeId { get; set; }
    public required int LessonId { get; set; }

    public class CreateStudentGradeLessonCommandHandler : IRequestHandler<CreateStudentGradeLessonCommand, CreatedStudentGradeLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentGradeLessonRepository _studentGradeLessonRepository;
        private readonly StudentGradeLessonBusinessRules _studentGradeLessonBusinessRules;

        public CreateStudentGradeLessonCommandHandler(IMapper mapper, IStudentGradeLessonRepository studentGradeLessonRepository,
                                         StudentGradeLessonBusinessRules studentGradeLessonBusinessRules)
        {
            _mapper = mapper;
            _studentGradeLessonRepository = studentGradeLessonRepository;
            _studentGradeLessonBusinessRules = studentGradeLessonBusinessRules;
        }

        public async Task<CreatedStudentGradeLessonResponse> Handle(CreateStudentGradeLessonCommand request, CancellationToken cancellationToken)
        {
            StudentGradeLesson studentGradeLesson = _mapper.Map<StudentGradeLesson>(request);

            await _studentGradeLessonRepository.AddAsync(studentGradeLesson);

            CreatedStudentGradeLessonResponse response = _mapper.Map<CreatedStudentGradeLessonResponse>(studentGradeLesson);
            return response;
        }
    }
}