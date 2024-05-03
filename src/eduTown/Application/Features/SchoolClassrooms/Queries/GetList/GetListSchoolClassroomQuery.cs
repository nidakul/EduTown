using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SchoolClassrooms.Queries.GetList;

public class GetListSchoolClassroomQuery : IRequest<GetListResponse<GetListSchoolClassroomListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSchoolClassroomQueryHandler : IRequestHandler<GetListSchoolClassroomQuery, GetListResponse<GetListSchoolClassroomListItemDto>>
    {
        private readonly ISchoolClassroomRepository _schoolClassroomRepository;
        private readonly IMapper _mapper;

        public GetListSchoolClassroomQueryHandler(ISchoolClassroomRepository schoolClassroomRepository, IMapper mapper)
        {
            _schoolClassroomRepository = schoolClassroomRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSchoolClassroomListItemDto>> Handle(GetListSchoolClassroomQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SchoolClassroom> schoolClassrooms = await _schoolClassroomRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSchoolClassroomListItemDto> response = _mapper.Map<GetListResponse<GetListSchoolClassroomListItemDto>>(schoolClassrooms);
            return response;
        }
    }
}