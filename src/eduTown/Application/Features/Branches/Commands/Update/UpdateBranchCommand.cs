using Application.Features.Branches.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Branches.Commands.Update;

public class UpdateBranchCommand : IRequest<UpdatedBranchResponse>
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, UpdatedBranchResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;
        private readonly BranchBusinessRules _branchBusinessRules;

        public UpdateBranchCommandHandler(IMapper mapper, IBranchRepository branchRepository,
                                         BranchBusinessRules branchBusinessRules)
        {
            _mapper = mapper;
            _branchRepository = branchRepository;
            _branchBusinessRules = branchBusinessRules;
        }

        public async Task<UpdatedBranchResponse> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            Branch? branch = await _branchRepository.GetAsync(predicate: b => b.Id == request.Id, cancellationToken: cancellationToken);
            await _branchBusinessRules.BranchShouldExistWhenSelected(branch);
            branch = _mapper.Map(request, branch);

            await _branchRepository.UpdateAsync(branch!);

            UpdatedBranchResponse response = _mapper.Map<UpdatedBranchResponse>(branch);
            return response;
        }
    }
}