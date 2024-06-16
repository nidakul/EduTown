using Application.Features.StudentExamDates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentExamDates.Commands.Create;

public class CreateStudentExamDateCommand : IRequest<CreatedStudentExamDateResponse>
{
    public required Guid StudentId { get; set; }
    public required int ExamDateId { get; set; }

    public class CreateStudentExamDateCommandHandler : IRequestHandler<CreateStudentExamDateCommand, CreatedStudentExamDateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentExamDateRepository _studentExamDateRepository;
        private readonly StudentExamDateBusinessRules _studentExamDateBusinessRules;

        public CreateStudentExamDateCommandHandler(IMapper mapper, IStudentExamDateRepository studentExamDateRepository,
                                         StudentExamDateBusinessRules studentExamDateBusinessRules)
        {
            _mapper = mapper;
            _studentExamDateRepository = studentExamDateRepository;
            _studentExamDateBusinessRules = studentExamDateBusinessRules;
        }

        public async Task<CreatedStudentExamDateResponse> Handle(CreateStudentExamDateCommand request, CancellationToken cancellationToken)
        {
            StudentExamDate studentExamDate = _mapper.Map<StudentExamDate>(request);

            await _studentExamDateRepository.AddAsync(studentExamDate);

            CreatedStudentExamDateResponse response = _mapper.Map<CreatedStudentExamDateResponse>(studentExamDate);
            return response;
        }
    }
}