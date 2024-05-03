using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.LessonClassrooms.Queries.GetList;

public class GetListLessonClassroomQuery : IRequest<GetListResponse<GetListLessonClassroomListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListLessonClassroomQueryHandler : IRequestHandler<GetListLessonClassroomQuery, GetListResponse<GetListLessonClassroomListItemDto>>
    {
        private readonly ILessonClassroomRepository _lessonClassroomRepository;
        private readonly IMapper _mapper;

        public GetListLessonClassroomQueryHandler(ILessonClassroomRepository lessonClassroomRepository, IMapper mapper)
        {
            _lessonClassroomRepository = lessonClassroomRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLessonClassroomListItemDto>> Handle(GetListLessonClassroomQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LessonClassroom> lessonClassrooms = await _lessonClassroomRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLessonClassroomListItemDto> response = _mapper.Map<GetListResponse<GetListLessonClassroomListItemDto>>(lessonClassrooms);
            return response;
        }
    }
}