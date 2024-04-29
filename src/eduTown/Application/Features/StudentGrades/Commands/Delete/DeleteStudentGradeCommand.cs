using Application.Features.StudentGrades.Constants;
using Application.Features.StudentGrades.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentGrades.Commands.Delete;

public class DeleteStudentGradeCommand : IRequest<DeletedStudentGradeResponse>
{
    public int Id { get; set; }

    public class DeleteStudentGradeCommandHandler : IRequestHandler<DeleteStudentGradeCommand, DeletedStudentGradeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentGradeRepository _studentGradeRepository;
        private readonly StudentGradeBusinessRules _studentGradeBusinessRules;

        public DeleteStudentGradeCommandHandler(IMapper mapper, IStudentGradeRepository studentGradeRepository,
                                         StudentGradeBusinessRules studentGradeBusinessRules)
        {
            _mapper = mapper;
            _studentGradeRepository = studentGradeRepository;
            _studentGradeBusinessRules = studentGradeBusinessRules;
        }

        public async Task<DeletedStudentGradeResponse> Handle(DeleteStudentGradeCommand request, CancellationToken cancellationToken)
        {
            StudentGrade? studentGrade = await _studentGradeRepository.GetAsync(predicate: sg => sg.Id == request.Id, cancellationToken: cancellationToken);
            await _studentGradeBusinessRules.StudentGradeShouldExistWhenSelected(studentGrade);

            await _studentGradeRepository.DeleteAsync(studentGrade!);

            DeletedStudentGradeResponse response = _mapper.Map<DeletedStudentGradeResponse>(studentGrade);
            return response;
        }
    }
}