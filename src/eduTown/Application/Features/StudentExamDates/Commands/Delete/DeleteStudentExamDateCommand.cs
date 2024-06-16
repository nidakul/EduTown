using Application.Features.StudentExamDates.Constants;
using Application.Features.StudentExamDates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentExamDates.Commands.Delete;

public class DeleteStudentExamDateCommand : IRequest<DeletedStudentExamDateResponse>
{
    public int Id { get; set; }

    public class DeleteStudentExamDateCommandHandler : IRequestHandler<DeleteStudentExamDateCommand, DeletedStudentExamDateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentExamDateRepository _studentExamDateRepository;
        private readonly StudentExamDateBusinessRules _studentExamDateBusinessRules;

        public DeleteStudentExamDateCommandHandler(IMapper mapper, IStudentExamDateRepository studentExamDateRepository,
                                         StudentExamDateBusinessRules studentExamDateBusinessRules)
        {
            _mapper = mapper;
            _studentExamDateRepository = studentExamDateRepository;
            _studentExamDateBusinessRules = studentExamDateBusinessRules;
        }

        public async Task<DeletedStudentExamDateResponse> Handle(DeleteStudentExamDateCommand request, CancellationToken cancellationToken)
        {
            StudentExamDate? studentExamDate = await _studentExamDateRepository.GetAsync(predicate: sed => sed.Id == request.Id, cancellationToken: cancellationToken);
            await _studentExamDateBusinessRules.StudentExamDateShouldExistWhenSelected(studentExamDate);

            await _studentExamDateRepository.DeleteAsync(studentExamDate!);

            DeletedStudentExamDateResponse response = _mapper.Map<DeletedStudentExamDateResponse>(studentExamDate);
            return response;
        }
    }
}