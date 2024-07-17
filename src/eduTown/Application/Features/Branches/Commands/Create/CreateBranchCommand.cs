using Application.Features.Branches.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Branches.Commands.Create;

public class CreateBranchCommand : IRequest<CreatedBranchResponse>
{
    public required string Name { get; set; }

    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, CreatedBranchResponse>
    {
        private readonly IMapper _mapper;
        private readonly IBranchRepository _branchRepository;
        private readonly BranchBusinessRules _branchBusinessRules;

        public CreateBranchCommandHandler(IMapper mapper, IBranchRepository branchRepository,
                                         BranchBusinessRules branchBusinessRules)
        {
            _mapper = mapper;
            _branchRepository = branchRepository;
            _branchBusinessRules = branchBusinessRules;
        }

        public async Task<CreatedBranchResponse> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            Branch branch = _mapper.Map<Branch>(request);

            await _branchRepository.AddAsync(branch);

            CreatedBranchResponse response = _mapper.Map<CreatedBranchResponse>(branch);
            return response;
        }
    }
}