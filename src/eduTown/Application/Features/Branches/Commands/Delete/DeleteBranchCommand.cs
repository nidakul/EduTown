using Application.Features.Branches.Constants;
using Application.Features.Branches.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Branches.Commands.Delete;

public class DeleteBranchCommand : IRequest<DeletedBranchResponse>
{
    public int Id { get; set; }

    public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, DeletedBranchResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;
        private readonly BranchBusinessRules _branchBusinessRules;

        public DeleteBranchCommandHandler(IMapper mapper, IBranchRepository branchRepository,
                                         BranchBusinessRules branchBusinessRules)
        {
            _mapper = mapper;
            _branchRepository = branchRepository;
            _branchBusinessRules = branchBusinessRules;
        }

        public async Task<DeletedBranchResponse> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            Branch? branch = await _branchRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _branchBusinessRules.BranchShouldExistWhenSelected(branch);

            await _branchRepository.DeleteAsync(branch!);

            DeletedBranchResponse response = _mapper.Map<DeletedBranchResponse>(branch);
            return response;
        }
    }
}