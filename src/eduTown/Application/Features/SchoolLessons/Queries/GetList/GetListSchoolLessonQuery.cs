using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SchoolLessons.Queries.GetList;

public class GetListSchoolLessonQuery : IRequest<GetListResponse<GetListSchoolLessonListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSchoolLessonQueryHandler : IRequestHandler<GetListSchoolLessonQuery, GetListResponse<GetListSchoolLessonListItemDto>>
    {
        private readonly ISchoolLessonRepository _schoolLessonRepository;
        private readonly IMapper _mapper;

        public GetListSchoolLessonQueryHandler(ISchoolLessonRepository schoolLessonRepository, IMapper mapper)
        {
            _schoolLessonRepository = schoolLessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSchoolLessonListItemDto>> Handle(GetListSchoolLessonQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SchoolLesson> schoolLessons = await _schoolLessonRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSchoolLessonListItemDto> response = _mapper.Map<GetListResponse<GetListSchoolLessonListItemDto>>(schoolLessons);
            return response;
        }
    }
}