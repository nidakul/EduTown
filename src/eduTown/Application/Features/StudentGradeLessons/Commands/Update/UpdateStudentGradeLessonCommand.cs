using Application.Features.StudentGradeLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentGradeLessons.Commands.Update;

public class UpdateStudentGradeLessonCommand : IRequest<UpdatedStudentGradeLessonResponse>
{
    public int Id { get; set; }
    public required int StudentGradeId { get; set; }
    public required int LessonId { get; set; }

    public class UpdateStudentGradeLessonCommandHandler : IRequestHandler<UpdateStudentGradeLessonCommand, UpdatedStudentGradeLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentGradeLessonRepository _studentGradeLessonRepository;
        private readonly StudentGradeLessonBusinessRules _studentGradeLessonBusinessRules;

        public UpdateStudentGradeLessonCommandHandler(IMapper mapper, IStudentGradeLessonRepository studentGradeLessonRepository,
                                         StudentGradeLessonBusinessRules studentGradeLessonBusinessRules)
        {
            _mapper = mapper;
            _studentGradeLessonRepository = studentGradeLessonRepository;
            _studentGradeLessonBusinessRules = studentGradeLessonBusinessRules;
        }

        public async Task<UpdatedStudentGradeLessonResponse> Handle(UpdateStudentGradeLessonCommand request, CancellationToken cancellationToken)
        {
            StudentGradeLesson? studentGradeLesson = await _studentGradeLessonRepository.GetAsync(predicate: sgl => sgl.Id == request.Id, cancellationToken: cancellationToken);
            await _studentGradeLessonBusinessRules.StudentGradeLessonShouldExistWhenSelected(studentGradeLesson);
            studentGradeLesson = _mapper.Map(request, studentGradeLesson);

            await _studentGradeLessonRepository.UpdateAsync(studentGradeLesson!);

            UpdatedStudentGradeLessonResponse response = _mapper.Map<UpdatedStudentGradeLessonResponse>(studentGradeLesson);
            return response;
        }
    }
}