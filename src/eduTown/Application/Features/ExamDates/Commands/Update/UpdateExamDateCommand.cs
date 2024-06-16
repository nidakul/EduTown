using Application.Features.ExamDates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExamDates.Commands.Update;

public class UpdateExamDateCommand : IRequest<UpdatedExamDateResponse>
{
    public int Id { get; set; }
    public required string ExamType { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }

    public class UpdateExamDateCommandHandler : IRequestHandler<UpdateExamDateCommand, UpdatedExamDateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamDateRepository _examDateRepository;
        private readonly ExamDateBusinessRules _examDateBusinessRules;

        public UpdateExamDateCommandHandler(IMapper mapper, IExamDateRepository examDateRepository,
                                         ExamDateBusinessRules examDateBusinessRules)
        {
            _mapper = mapper;
            _examDateRepository = examDateRepository;
            _examDateBusinessRules = examDateBusinessRules;
        }

        public async Task<UpdatedExamDateResponse> Handle(UpdateExamDateCommand request, CancellationToken cancellationToken)
        {
            ExamDate? examDate = await _examDateRepository.GetAsync(predicate: ed => ed.Id == request.Id, cancellationToken: cancellationToken);
            await _examDateBusinessRules.ExamDateShouldExistWhenSelected(examDate);
            examDate = _mapper.Map(request, examDate);

            await _examDateRepository.UpdateAsync(examDate!);

            UpdatedExamDateResponse response = _mapper.Map<UpdatedExamDateResponse>(examDate);
            return response;
        }
    }
}