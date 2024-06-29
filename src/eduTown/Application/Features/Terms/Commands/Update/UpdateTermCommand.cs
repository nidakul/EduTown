using Application.Features.Terms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Terms.Commands.Update;

public class UpdateTermCommand : IRequest<UpdatedTermResponse>
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public class UpdateTermCommandHandler : IRequestHandler<UpdateTermCommand, UpdatedTermResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITermRepository _termRepository;
        private readonly TermBusinessRules _termBusinessRules;

        public UpdateTermCommandHandler(IMapper mapper, ITermRepository termRepository,
                                         TermBusinessRules termBusinessRules)
        {
            _mapper = mapper;
            _termRepository = termRepository;
            _termBusinessRules = termBusinessRules;
        }

        public async Task<UpdatedTermResponse> Handle(UpdateTermCommand request, CancellationToken cancellationToken)
        {
            Term? term = await _termRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _termBusinessRules.TermShouldExistWhenSelected(term);
            term = _mapper.Map(request, term);

            await _termRepository.UpdateAsync(term!);

            UpdatedTermResponse response = _mapper.Map<UpdatedTermResponse>(term);
            return response;
        }
    }
}