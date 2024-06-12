using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SchoolTypes.Queries.GetList;

public class GetListSchoolTypeQuery : IRequest<GetListResponse<GetListSchoolTypeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSchoolTypeQueryHandler : IRequestHandler<GetListSchoolTypeQuery, GetListResponse<GetListSchoolTypeListItemDto>>
    {
        private readonly ISchoolTypeRepository _schoolTypeRepository;
        private readonly IMapper _mapper;

        public GetListSchoolTypeQueryHandler(ISchoolTypeRepository schoolTypeRepository, IMapper mapper)
        {
            _schoolTypeRepository = schoolTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSchoolTypeListItemDto>> Handle(GetListSchoolTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SchoolType> schoolTypes = await _schoolTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSchoolTypeListItemDto> response = _mapper.Map<GetListResponse<GetListSchoolTypeListItemDto>>(schoolTypes);
            return response;
        }
    }
}