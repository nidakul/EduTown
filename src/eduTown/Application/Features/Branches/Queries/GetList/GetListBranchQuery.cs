using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Branches.Queries.GetList;

public class GetListBranchQuery : IRequest<GetListResponse<GetListBranchListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListBranchQueryHandler : IRequestHandler<GetListBranchQuery, GetListResponse<GetListBranchListItemDto>>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public GetListBranchQueryHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListBranchListItemDto>> Handle(GetListBranchQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Branch> branches = await _branchRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListBranchListItemDto> response = _mapper.Map<GetListResponse<GetListBranchListItemDto>>(branches);
            return response;
        }
    }
}