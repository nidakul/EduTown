using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.StudentGradeLessons.Queries.GetList;

public class GetListStudentGradeLessonQuery : IRequest<GetListResponse<GetListStudentGradeLessonListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListStudentGradeLessonQueryHandler : IRequestHandler<GetListStudentGradeLessonQuery, GetListResponse<GetListStudentGradeLessonListItemDto>>
    {
        private readonly IStudentGradeLessonRepository _studentGradeLessonRepository;
        private readonly IMapper _mapper;

        public GetListStudentGradeLessonQueryHandler(IStudentGradeLessonRepository studentGradeLessonRepository, IMapper mapper)
        {
            _studentGradeLessonRepository = studentGradeLessonRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentGradeLessonListItemDto>> Handle(GetListStudentGradeLessonQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StudentGradeLesson> studentGradeLessons = await _studentGradeLessonRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentGradeLessonListItemDto> response = _mapper.Map<GetListResponse<GetListStudentGradeLessonListItemDto>>(studentGradeLessons);
            return response;
        }
    }
}