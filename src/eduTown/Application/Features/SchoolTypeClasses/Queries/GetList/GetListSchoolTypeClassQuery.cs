using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SchoolTypeClasses.Queries.GetList;

public class GetListSchoolTypeClassQuery : IRequest<GetListResponse<GetListSchoolTypeClassListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSchoolTypeClassQueryHandler : IRequestHandler<GetListSchoolTypeClassQuery, GetListResponse<GetListSchoolTypeClassListItemDto>>
    {
        private readonly ISchoolTypeClassRepository _schoolTypeClassRepository;
        private readonly IMapper _mapper;

        public GetListSchoolTypeClassQueryHandler(ISchoolTypeClassRepository schoolTypeClassRepository, IMapper mapper)
        {
            _schoolTypeClassRepository = schoolTypeClassRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSchoolTypeClassListItemDto>> Handle(GetListSchoolTypeClassQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SchoolTypeClass> schoolTypeClasses = await _schoolTypeClassRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSchoolTypeClassListItemDto> response = _mapper.Map<GetListResponse<GetListSchoolTypeClassListItemDto>>(schoolTypeClasses);
            return response;
        }
    }
}