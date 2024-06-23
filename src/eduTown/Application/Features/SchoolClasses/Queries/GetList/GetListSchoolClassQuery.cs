using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SchoolClasses.Queries.GetList;

public class GetListSchoolClassQuery : IRequest<GetListResponse<GetListSchoolClassListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSchoolClassQueryHandler : IRequestHandler<GetListSchoolClassQuery, GetListResponse<GetListSchoolClassListItemDto>>
    {
        private readonly ISchoolClassRepository _schoolClassRepository;
        private readonly IMapper _mapper;

        public GetListSchoolClassQueryHandler(ISchoolClassRepository schoolClassRepository, IMapper mapper)
        {
            _schoolClassRepository = schoolClassRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSchoolClassListItemDto>> Handle(GetListSchoolClassQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SchoolClass> schoolClasses = await _schoolClassRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSchoolClassListItemDto> response = _mapper.Map<GetListResponse<GetListSchoolClassListItemDto>>(schoolClasses);
            return response;
        }
    }
}