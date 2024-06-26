using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Lessons.Queries.GetList;

public class GetListLessonQuery : IRequest<GetListResponse<GetListLessonListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListLessonQueryHandler : IRequestHandler<GetListLessonQuery, GetListResponse<GetListLessonListItemDto>>
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public GetListLessonQueryHandler(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLessonListItemDto>> Handle(GetListLessonQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Lesson> lessons = await _lessonRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLessonListItemDto> response = _mapper.Map<GetListResponse<GetListLessonListItemDto>>(lessons);
            return response;
        }
    }
}