using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Schools.Queries.GetList;

public class GetListSchoolQuery : IRequest<GetListResponse<GetListSchoolListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSchoolQueryHandler : IRequestHandler<GetListSchoolQuery, GetListResponse<GetListSchoolListItemDto>>
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly IMapper _mapper;

        public GetListSchoolQueryHandler(ISchoolRepository schoolRepository, IMapper mapper)
        {
            _schoolRepository = schoolRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSchoolListItemDto>> Handle(GetListSchoolQuery request, CancellationToken cancellationToken)
        {
            IPaginate<School> schools = await _schoolRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSchoolListItemDto> response = _mapper.Map<GetListResponse<GetListSchoolListItemDto>>(schools);
            return response;
        }
    }
}