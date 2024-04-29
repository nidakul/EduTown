using Application.Features.StudentGradeLessons.Constants;
using Application.Features.StudentGradeLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentGradeLessons.Commands.Delete;

public class DeleteStudentGradeLessonCommand : IRequest<DeletedStudentGradeLessonResponse>
{
    public int Id { get; set; }

    public class DeleteStudentGradeLessonCommandHandler : IRequestHandler<DeleteStudentGradeLessonCommand, DeletedStudentGradeLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentGradeLessonRepository _studentGradeLessonRepository;
        private readonly StudentGradeLessonBusinessRules _studentGradeLessonBusinessRules;

        public DeleteStudentGradeLessonCommandHandler(IMapper mapper, IStudentGradeLessonRepository studentGradeLessonRepository,
                                         StudentGradeLessonBusinessRules studentGradeLessonBusinessRules)
        {
            _mapper = mapper;
            _studentGradeLessonRepository = studentGradeLessonRepository;
            _studentGradeLessonBusinessRules = studentGradeLessonBusinessRules;
        }

        public async Task<DeletedStudentGradeLessonResponse> Handle(DeleteStudentGradeLessonCommand request, CancellationToken cancellationToken)
        {
            StudentGradeLesson? studentGradeLesson = await _studentGradeLessonRepository.GetAsync(predicate: sgl => sgl.Id == request.Id, cancellationToken: cancellationToken);
            await _studentGradeLessonBusinessRules.StudentGradeLessonShouldExistWhenSelected(studentGradeLesson);

            await _studentGradeLessonRepository.DeleteAsync(studentGradeLesson!);

            DeletedStudentGradeLessonResponse response = _mapper.Map<DeletedStudentGradeLessonResponse>(studentGradeLesson);
            return response;
        }
    }
}