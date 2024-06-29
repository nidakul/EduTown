using Application.Features.Terms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Terms.Commands.Create;

public class CreateTermCommand : IRequest<CreatedTermResponse>
{
    public required string Name { get; set; }

    public class CreateTermCommandHandler : IRequestHandler<CreateTermCommand, CreatedTermResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITermRepository _termRepository;
        private readonly TermBusinessRules _termBusinessRules;

        public CreateTermCommandHandler(IMapper mapper, ITermRepository termRepository,
                                         TermBusinessRules termBusinessRules)
        {
            _mapper = mapper;
            _termRepository = termRepository;
            _termBusinessRules = termBusinessRules;
        }

        public async Task<CreatedTermResponse> Handle(CreateTermCommand request, CancellationToken cancellationToken)
        {
            Term term = _mapper.Map<Term>(request);

            await _termRepository.AddAsync(term);

            CreatedTermResponse response = _mapper.Map<CreatedTermResponse>(term);
            return response;
        }
    }
}