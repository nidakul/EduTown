using Application.Features.SchoolClassBranches.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolClassBranches.Commands.Update;

public class UpdateSchoolClassBranchCommand : IRequest<UpdatedSchoolClassBranchResponse>
{
    public int Id { get; set; }
    public required int SchoolClassId { get; set; }
    public required int BranchId { get; set; }

    public class UpdateSchoolClassBranchCommandHandler : IRequestHandler<UpdateSchoolClassBranchCommand, UpdatedSchoolClassBranchResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClassBranchRepository _schoolClassBranchRepository;
        private readonly SchoolClassBranchBusinessRules _schoolClassBranchBusinessRules;

        public UpdateSchoolClassBranchCommandHandler(IMapper mapper, ISchoolClassBranchRepository schoolClassBranchRepository,
                                         SchoolClassBranchBusinessRules schoolClassBranchBusinessRules)
        {
            _mapper = mapper;
            _schoolClassBranchRepository = schoolClassBranchRepository;
            _schoolClassBranchBusinessRules = schoolClassBranchBusinessRules;
        }

        public async Task<UpdatedSchoolClassBranchResponse> Handle(UpdateSchoolClassBranchCommand request, CancellationToken cancellationToken)
        {
            SchoolClassBranch? schoolClassBranch = await _schoolClassBranchRepository.GetAsync(predicate: scb => scb.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolClassBranchBusinessRules.SchoolClassBranchShouldExistWhenSelected(schoolClassBranch);
            schoolClassBranch = _mapper.Map(request, schoolClassBranch);

            await _schoolClassBranchRepository.UpdateAsync(schoolClassBranch!);

            UpdatedSchoolClassBranchResponse response = _mapper.Map<UpdatedSchoolClassBranchResponse>(schoolClassBranch);
            return response;
        }
    }
}