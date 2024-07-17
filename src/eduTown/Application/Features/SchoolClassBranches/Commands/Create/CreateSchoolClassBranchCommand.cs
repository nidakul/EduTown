using Application.Features.SchoolClassBranches.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolClassBranches.Commands.Create;

public class CreateSchoolClassBranchCommand : IRequest<CreatedSchoolClassBranchResponse>
{
    public required int SchoolClassId { get; set; }
    public required int BranchId { get; set; }

    public class CreateSchoolClassBranchCommandHandler : IRequestHandler<CreateSchoolClassBranchCommand, CreatedSchoolClassBranchResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClassBranchRepository _schoolClassBranchRepository;
        private readonly SchoolClassBranchBusinessRules _schoolClassBranchBusinessRules;

        public CreateSchoolClassBranchCommandHandler(IMapper mapper, ISchoolClassBranchRepository schoolClassBranchRepository,
                                         SchoolClassBranchBusinessRules schoolClassBranchBusinessRules)
        {
            _mapper = mapper;
            _schoolClassBranchRepository = schoolClassBranchRepository;
            _schoolClassBranchBusinessRules = schoolClassBranchBusinessRules;
        }

        public async Task<CreatedSchoolClassBranchResponse> Handle(CreateSchoolClassBranchCommand request, CancellationToken cancellationToken)
        {
            SchoolClassBranch schoolClassBranch = _mapper.Map<SchoolClassBranch>(request);

            await _schoolClassBranchRepository.AddAsync(schoolClassBranch);

            CreatedSchoolClassBranchResponse response = _mapper.Map<CreatedSchoolClassBranchResponse>(schoolClassBranch);
            return response;
        }
    }
}