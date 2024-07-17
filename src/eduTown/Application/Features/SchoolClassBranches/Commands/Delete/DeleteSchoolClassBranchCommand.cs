using Application.Features.SchoolClassBranches.Constants;
using Application.Features.SchoolClassBranches.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolClassBranches.Commands.Delete;

public class DeleteSchoolClassBranchCommand : IRequest<DeletedSchoolClassBranchResponse>
{
    public int Id { get; set; }

    public class DeleteSchoolClassBranchCommandHandler : IRequestHandler<DeleteSchoolClassBranchCommand, DeletedSchoolClassBranchResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClassBranchRepository _schoolClassBranchRepository;
        private readonly SchoolClassBranchBusinessRules _schoolClassBranchBusinessRules;

        public DeleteSchoolClassBranchCommandHandler(IMapper mapper, ISchoolClassBranchRepository schoolClassBranchRepository,
                                         SchoolClassBranchBusinessRules schoolClassBranchBusinessRules)
        {
            _mapper = mapper;
            _schoolClassBranchRepository = schoolClassBranchRepository;
            _schoolClassBranchBusinessRules = schoolClassBranchBusinessRules;
        }

        public async Task<DeletedSchoolClassBranchResponse> Handle(DeleteSchoolClassBranchCommand request, CancellationToken cancellationToken)
        {
            SchoolClassBranch? schoolClassBranch = await _schoolClassBranchRepository.GetAsync(predicate: scb => scb.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolClassBranchBusinessRules.SchoolClassBranchShouldExistWhenSelected(schoolClassBranch);

            await _schoolClassBranchRepository.DeleteAsync(schoolClassBranch!);

            DeletedSchoolClassBranchResponse response = _mapper.Map<DeletedSchoolClassBranchResponse>(schoolClassBranch);
            return response;
        }
    }
}