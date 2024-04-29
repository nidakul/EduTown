using Application.Features.StudentGrades.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentGrades.Commands.Update;

public class UpdateStudentGradeCommand : IRequest<UpdatedStudentGradeResponse>
{
    public int Id { get; set; }
    public required Guid UserId { get; set; }
    public required int GradeTypeId { get; set; }
    public required int LessonId { get; set; }
    public required int ExamCount { get; set; }
    public required double Grade { get; set; }

    public class UpdateStudentGradeCommandHandler : IRequestHandler<UpdateStudentGradeCommand, UpdatedStudentGradeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentGradeRepository _studentGradeRepository;
        private readonly StudentGradeBusinessRules _studentGradeBusinessRules;

        public UpdateStudentGradeCommandHandler(IMapper mapper, IStudentGradeRepository studentGradeRepository,
                                         StudentGradeBusinessRules studentGradeBusinessRules)
        {
            _mapper = mapper;
            _studentGradeRepository = studentGradeRepository;
            _studentGradeBusinessRules = studentGradeBusinessRules;
        }

        public async Task<UpdatedStudentGradeResponse> Handle(UpdateStudentGradeCommand request, CancellationToken cancellationToken)
        {
            StudentGrade? studentGrade = await _studentGradeRepository.GetAsync(predicate: sg => sg.Id == request.Id, cancellationToken: cancellationToken);
            await _studentGradeBusinessRules.StudentGradeShouldExistWhenSelected(studentGrade);
            studentGrade = _mapper.Map(request, studentGrade);

            await _studentGradeRepository.UpdateAsync(studentGrade!);

            UpdatedStudentGradeResponse response = _mapper.Map<UpdatedStudentGradeResponse>(studentGrade);
            return response;
        }
    }
}