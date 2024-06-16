using Application.Features.ExamDates.Constants;
using Application.Features.ExamDates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExamDates.Commands.Delete;

public class DeleteExamDateCommand : IRequest<DeletedExamDateResponse>
{
    public int Id { get; set; }

    public class DeleteExamDateCommandHandler : IRequestHandler<DeleteExamDateCommand, DeletedExamDateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamDateRepository _examDateRepository;
        private readonly ExamDateBusinessRules _examDateBusinessRules;

        public DeleteExamDateCommandHandler(IMapper mapper, IExamDateRepository examDateRepository,
                                         ExamDateBusinessRules examDateBusinessRules)
        {
            _mapper = mapper;
            _examDateRepository = examDateRepository;
            _examDateBusinessRules = examDateBusinessRules;
        }

        public async Task<DeletedExamDateResponse> Handle(DeleteExamDateCommand request, CancellationToken cancellationToken)
        {
            ExamDate? examDate = await _examDateRepository.GetAsync(predicate: ed => ed.Id == request.Id, cancellationToken: cancellationToken);
            await _examDateBusinessRules.ExamDateShouldExistWhenSelected(examDate);

            await _examDateRepository.DeleteAsync(examDate!);

            DeletedExamDateResponse response = _mapper.Map<DeletedExamDateResponse>(examDate);
            return response;
        }
    }
}