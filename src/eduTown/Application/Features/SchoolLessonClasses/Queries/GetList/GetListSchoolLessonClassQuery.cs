using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.SchoolLessonClasses.Queries.GetList;

public class GetListSchoolLessonClassQuery : IRequest<GetListResponse<GetListSchoolLessonClassListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListSchoolLessonClassQueryHandler : IRequestHandler<GetListSchoolLessonClassQuery, GetListResponse<GetListSchoolLessonClassListItemDto>>
    {
        private readonly ISchoolLessonClassRepository _schoolLessonClassRepository;
        private readonly IMapper _mapper;

        public GetListSchoolLessonClassQueryHandler(ISchoolLessonClassRepository schoolLessonClassRepository, IMapper mapper)
        {
            _schoolLessonClassRepository = schoolLessonClassRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListSchoolLessonClassListItemDto>> Handle(GetListSchoolLessonClassQuery request, CancellationToken cancellationToken)
        {
            IPaginate<SchoolLessonClass> schoolLessonClasses = await _schoolLessonClassRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListSchoolLessonClassListItemDto> response = _mapper.Map<GetListResponse<GetListSchoolLessonClassListItemDto>>(schoolLessonClasses);
            return response;
        }
    }
}