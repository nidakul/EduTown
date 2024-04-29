using Application.Features.StudentGrades.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentGrades.Commands.Create;

public class CreateStudentGradeCommand : IRequest<CreatedStudentGradeResponse>
{
    public required Guid UserId { get; set; }
    public required int GradeTypeId { get; set; }
    public required int LessonId { get; set; }
    public required int ExamCount { get; set; }
    public required double Grade { get; set; }

    public class CreateStudentGradeCommandHandler : IRequestHandler<CreateStudentGradeCommand, CreatedStudentGradeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentGradeRepository _studentGradeRepository;
        private readonly StudentGradeBusinessRules _studentGradeBusinessRules;

        public CreateStudentGradeCommandHandler(IMapper mapper, IStudentGradeRepository studentGradeRepository,
                                         StudentGradeBusinessRules studentGradeBusinessRules)
        {
            _mapper = mapper;
            _studentGradeRepository = studentGradeRepository;
            _studentGradeBusinessRules = studentGradeBusinessRules;
        }

        public async Task<CreatedStudentGradeResponse> Handle(CreateStudentGradeCommand request, CancellationToken cancellationToken)
        {
            StudentGrade studentGrade = _mapper.Map<StudentGrade>(request);

            await _studentGradeRepository.AddAsync(studentGrade);

            CreatedStudentGradeResponse response = _mapper.Map<CreatedStudentGradeResponse>(studentGrade);
            return response;
        }
    }
}