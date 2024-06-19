using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SchoolClassLessons.Queries.GetList;

public class GetListSchoolClassLessonQuery : IRequest<GetListResponse<GetListSchoolClassLessonListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSchoolClassLessonQueryHandler : IRequestHandler<GetListSchoolClassLessonQuery, GetListResponse<GetListSchoolClassLessonListItemDto>>
    {
        private readonly ISchoolClassLessonRepository _schoolClassLessonRepository;
        private readonly IMapper _mapper;

        public GetListSchoolClassLessonQueryHandler(ISchoolClassLessonRepository schoolClassLessonRepository, IMapper mapper)
        {
            _schoolClassLessonRepository = schoolClassLessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSchoolClassLessonListItemDto>> Handle(GetListSchoolClassLessonQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SchoolClassLesson> schoolClassLessons = await _schoolClassLessonRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSchoolClassLessonListItemDto> response = _mapper.Map<GetListResponse<GetListSchoolClassLessonListItemDto>>(schoolClassLessons);
            return response;
        }
    }
}