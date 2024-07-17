using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SchoolClassBranches.Queries.GetList;

public class GetListSchoolClassBranchQuery : IRequest<GetListResponse<GetListSchoolClassBranchListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSchoolClassBranchQueryHandler : IRequestHandler<GetListSchoolClassBranchQuery, GetListResponse<GetListSchoolClassBranchListItemDto>>
    {
        private readonly ISchoolClassBranchRepository _schoolClassBranchRepository;
        private readonly IMapper _mapper;

        public GetListSchoolClassBranchQueryHandler(ISchoolClassBranchRepository schoolClassBranchRepository, IMapper mapper)
        {
            _schoolClassBranchRepository = schoolClassBranchRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSchoolClassBranchListItemDto>> Handle(GetListSchoolClassBranchQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SchoolClassBranch> schoolClassBranches = await _schoolClassBranchRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSchoolClassBranchListItemDto> response = _mapper.Map<GetListResponse<GetListSchoolClassBranchListItemDto>>(schoolClassBranches);
            return response;
        }
    }
}