using Application.Features.ExamDates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExamDates.Commands.Create;

public class CreateExamDateCommand : IRequest<CreatedExamDateResponse>
{
    public required string ExamType { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }

    public class CreateExamDateCommandHandler : IRequestHandler<CreateExamDateCommand, CreatedExamDateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamDateRepository _examDateRepository;
        private readonly ExamDateBusinessRules _examDateBusinessRules;

        public CreateExamDateCommandHandler(IMapper mapper, IExamDateRepository examDateRepository,
                                         ExamDateBusinessRules examDateBusinessRules)
        {
            _mapper = mapper;
            _examDateRepository = examDateRepository;
            _examDateBusinessRules = examDateBusinessRules;
        }

        public async Task<CreatedExamDateResponse> Handle(CreateExamDateCommand request, CancellationToken cancellationToken)
        {
            ExamDate examDate = _mapper.Map<ExamDate>(request);

            await _examDateRepository.AddAsync(examDate);

            CreatedExamDateResponse response = _mapper.Map<CreatedExamDateResponse>(examDate);
            return response;
        }
    }
}