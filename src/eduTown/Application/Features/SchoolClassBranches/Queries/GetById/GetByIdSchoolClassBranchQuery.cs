using Application.Features.SchoolClassBranches.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolClassBranches.Queries.GetById;

public class GetByIdSchoolClassBranchQuery : IRequest<GetByIdSchoolClassBranchResponse>
{
    public int Id { get; set; }

    public class GetByIdSchoolClassBranchQueryHandler : IRequestHandler<GetByIdSchoolClassBranchQuery, GetByIdSchoolClassBranchResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClassBranchRepository _schoolClassBranchRepository;
        private readonly SchoolClassBranchBusinessRules _schoolClassBranchBusinessRules;

        public GetByIdSchoolClassBranchQueryHandler(IMapper mapper, ISchoolClassBranchRepository schoolClassBranchRepository, SchoolClassBranchBusinessRules schoolClassBranchBusinessRules)
        {
            _mapper = mapper;
            _schoolClassBranchRepository = schoolClassBranchRepository;
            _schoolClassBranchBusinessRules = schoolClassBranchBusinessRules;
        }

        public async Task<GetByIdSchoolClassBranchResponse> Handle(GetByIdSchoolClassBranchQuery request, CancellationToken cancellationToken)
        {
            SchoolClassBranch? schoolClassBranch = await _schoolClassBranchRepository.GetAsync(predicate: scb => scb.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolClassBranchBusinessRules.SchoolClassBranchShouldExistWhenSelected(schoolClassBranch);

            GetByIdSchoolClassBranchResponse response = _mapper.Map<GetByIdSchoolClassBranchResponse>(schoolClassBranch);
            return response;
        }
    }
}