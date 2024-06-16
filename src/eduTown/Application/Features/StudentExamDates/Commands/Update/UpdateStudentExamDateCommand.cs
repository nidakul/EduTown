using Application.Features.StudentExamDates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentExamDates.Commands.Update;

public class UpdateStudentExamDateCommand : IRequest<UpdatedStudentExamDateResponse>
{
    public int Id { get; set; }
    public required int StudentId { get; set; }
    public required int ExamDateId { get; set; }

    public class UpdateStudentExamDateCommandHandler : IRequestHandler<UpdateStudentExamDateCommand, UpdatedStudentExamDateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentExamDateRepository _studentExamDateRepository;
        private readonly StudentExamDateBusinessRules _studentExamDateBusinessRules;

        public UpdateStudentExamDateCommandHandler(IMapper mapper, IStudentExamDateRepository studentExamDateRepository,
                                         StudentExamDateBusinessRules studentExamDateBusinessRules)
        {
            _mapper = mapper;
            _studentExamDateRepository = studentExamDateRepository;
            _studentExamDateBusinessRules = studentExamDateBusinessRules;
        }

        public async Task<UpdatedStudentExamDateResponse> Handle(UpdateStudentExamDateCommand request, CancellationToken cancellationToken)
        {
            StudentExamDate? studentExamDate = await _studentExamDateRepository.GetAsync(predicate: sed => sed.Id == request.Id, cancellationToken: cancellationToken);
            await _studentExamDateBusinessRules.StudentExamDateShouldExistWhenSelected(studentExamDate);
            studentExamDate = _mapper.Map(request, studentExamDate);

            await _studentExamDateRepository.UpdateAsync(studentExamDate!);

            UpdatedStudentExamDateResponse response = _mapper.Map<UpdatedStudentExamDateResponse>(studentExamDate);
            return response;
        }
    }
}