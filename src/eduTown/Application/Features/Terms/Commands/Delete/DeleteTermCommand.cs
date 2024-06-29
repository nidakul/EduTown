using Application.Features.Terms.Constants;
using Application.Features.Terms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Terms.Commands.Delete;

public class DeleteTermCommand : IRequest<DeletedTermResponse>
{
    public int Id { get; set; }

    public class DeleteTermCommandHandler : IRequestHandler<DeleteTermCommand, DeletedTermResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITermRepository _termRepository;
        private readonly TermBusinessRules _termBusinessRules;

        public DeleteTermCommandHandler(IMapper mapper, ITermRepository termRepository,
                                         TermBusinessRules termBusinessRules)
        {
            _mapper = mapper;
            _termRepository = termRepository;
            _termBusinessRules = termBusinessRules;
        }

        public async Task<DeletedTermResponse> Handle(DeleteTermCommand request, CancellationToken cancellationToken)
        {
            Term? term = await _termRepository.GetAsync(predicate: t => t.Id == request.Id, cancellationToken: cancellationToken);
            await _termBusinessRules.TermShouldExistWhenSelected(term);

            await _termRepository.DeleteAsync(term!);

            DeletedTermResponse response = _mapper.Map<DeletedTermResponse>(term);
            return response;
        }
    }
}