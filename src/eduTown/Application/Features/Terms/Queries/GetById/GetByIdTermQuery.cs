using Application.Features.Terms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Terms.Queries.GetById;

public class GetByIdTermQuery : IRequest<GetByIdTermResponse>
{
    public int Id { get; set; }

    public class GetByIdTermQueryHandler : IRequestHandler<GetByIdTermQuery, GetByIdTermResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITermRepository _termRepository;
        private readonly TermBusinessRules _termBusinessRules;

        public GetByIdTermQueryHandler(IMapper mapper, ITermRepository termRepository, TermBusinessRules termBusinessRules)
        {
            _mapper = mapper;
            _termRepository = termRepository;
            _termBusinessRules = termBusinessRules;
        }

        public async Task<GetByIdTermResponse> Handle(GetByIdTermQuery request, CancellationToken cancellationToken)
        {
            Term? term = await _termRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _termBusinessRules.TermShouldExistWhenSelected(term);

            GetByIdTermResponse response = _mapper.Map<GetByIdTermResponse>(term);
            return response;
        }
    }
}