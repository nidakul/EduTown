using Application.Features.StudentGrades.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentGrades.Queries.GetById;

public class GetByIdStudentGradeQuery : IRequest<GetByIdStudentGradeResponse>
{
    public int Id { get; set; }

    public class GetByIdStudentGradeQueryHandler : IRequestHandler<GetByIdStudentGradeQuery, GetByIdStudentGradeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentGradeRepository _studentGradeRepository;
        private readonly StudentGradeBusinessRules _studentGradeBusinessRules;

        public GetByIdStudentGradeQueryHandler(IMapper mapper, IStudentGradeRepository studentGradeRepository, StudentGradeBusinessRules studentGradeBusinessRules)
        {
            _mapper = mapper;
            _studentGradeRepository = studentGradeRepository;
            _studentGradeBusinessRules = studentGradeBusinessRules;
        }

        public async Task<GetByIdStudentGradeResponse> Handle(GetByIdStudentGradeQuery request, CancellationToken cancellationToken)
        {
            StudentGrade? studentGrade = await _studentGradeRepository.GetAsync(predicate: sg => sg.Id == request.Id, cancellationToken: cancellationToken);
            await _studentGradeBusinessRules.StudentGradeShouldExistWhenSelected(studentGrade);

            GetByIdStudentGradeResponse response = _mapper.Map<GetByIdStudentGradeResponse>(studentGrade);
            return response;
        }
    }
}