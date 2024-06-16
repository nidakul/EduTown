using Application.Features.ExamDates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ExamDates.Queries.GetById;

public class GetByIdExamDateQuery : IRequest<GetByIdExamDateResponse>
{
    public int Id { get; set; }

    public class GetByIdExamDateQueryHandler : IRequestHandler<GetByIdExamDateQuery, GetByIdExamDateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IExamDateRepository _examDateRepository;
        private readonly ExamDateBusinessRules _examDateBusinessRules;

        public GetByIdExamDateQueryHandler(IMapper mapper, IExamDateRepository examDateRepository, ExamDateBusinessRules examDateBusinessRules)
        {
            _mapper = mapper;
            _examDateRepository = examDateRepository;
            _examDateBusinessRules = examDateBusinessRules;
        }

        public async Task<GetByIdExamDateResponse> Handle(GetByIdExamDateQuery request, CancellationToken cancellationToken)
        {
            ExamDate? examDate = await _examDateRepository.GetAsync(predicate: ed => ed.Id == request.Id, cancellationToken: cancellationToken);
            await _examDateBusinessRules.ExamDateShouldExistWhenSelected(examDate);

            GetByIdExamDateResponse response = _mapper.Map<GetByIdExamDateResponse>(examDate);
            return response;
        }
    }
}