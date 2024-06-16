using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserLessons.Queries.GetList;

public class GetListUserLessonQuery : IRequest<GetListResponse<GetListUserLessonListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserLessonQueryHandler : IRequestHandler<GetListUserLessonQuery, GetListResponse<GetListUserLessonListItemDto>>
    {
        private readonly IUserLessonRepository _userLessonRepository;
        private readonly IMapper _mapper;

        public GetListUserLessonQueryHandler(IUserLessonRepository userLessonRepository, IMapper mapper)
        {
            _userLessonRepository = userLessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserLessonListItemDto>> Handle(GetListUserLessonQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserLesson> userLessons = await _userLessonRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserLessonListItemDto> response = _mapper.Map<GetListResponse<GetListUserLessonListItemDto>>(userLessons);
            return response;
        }
    }
}