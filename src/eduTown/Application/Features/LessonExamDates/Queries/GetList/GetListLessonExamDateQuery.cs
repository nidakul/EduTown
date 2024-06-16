using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.LessonExamDates.Queries.GetList;

public class GetListLessonExamDateQuery : IRequest<GetListResponse<GetListLessonExamDateListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListLessonExamDateQueryHandler : IRequestHandler<GetListLessonExamDateQuery, GetListResponse<GetListLessonExamDateListItemDto>>
    {
        private readonly ILessonExamDateRepository _lessonExamDateRepository;
        private readonly IMapper _mapper;

        public GetListLessonExamDateQueryHandler(ILessonExamDateRepository lessonExamDateRepository, IMapper mapper)
        {
            _lessonExamDateRepository = lessonExamDateRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListLessonExamDateListItemDto>> Handle(GetListLessonExamDateQuery request, CancellationToken cancellationToken)
        {
            IPaginate<LessonExamDate> lessonExamDates = await _lessonExamDateRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListLessonExamDateListItemDto> response = _mapper.Map<GetListResponse<GetListLessonExamDateListItemDto>>(lessonExamDates);
            return response;
        }
    }
}