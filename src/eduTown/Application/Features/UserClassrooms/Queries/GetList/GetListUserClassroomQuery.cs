using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserClassrooms.Queries.GetList;

public class GetListUserClassroomQuery : IRequest<GetListResponse<GetListUserClassroomListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserClassroomQueryHandler : IRequestHandler<GetListUserClassroomQuery, GetListResponse<GetListUserClassroomListItemDto>>
    {
        private readonly IUserClassroomRepository _userClassroomRepository;
        private readonly IMapper _mapper;

        public GetListUserClassroomQueryHandler(IUserClassroomRepository userClassroomRepository, IMapper mapper)
        {
            _userClassroomRepository = userClassroomRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserClassroomListItemDto>> Handle(GetListUserClassroomQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserClassroom> userClassrooms = await _userClassroomRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserClassroomListItemDto> response = _mapper.Map<GetListResponse<GetListUserClassroomListItemDto>>(userClassrooms);
            return response;
        }
    }
}