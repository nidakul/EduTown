using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.StudentGrades.Queries.GetList;

public class GetListStudentGradeQuery : IRequest<GetListResponse<GetListStudentGradeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListStudentGradeQueryHandler : IRequestHandler<GetListStudentGradeQuery, GetListResponse<GetListStudentGradeListItemDto>>
    {
        private readonly IStudentGradeRepository _studentGradeRepository;
        private readonly IMapper _mapper;

        public GetListStudentGradeQueryHandler(IStudentGradeRepository studentGradeRepository, IMapper mapper)
        {
            _studentGradeRepository = studentGradeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentGradeListItemDto>> Handle(GetListStudentGradeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StudentGrade> studentGrades = await _studentGradeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentGradeListItemDto> response = _mapper.Map<GetListResponse<GetListStudentGradeListItemDto>>(studentGrades);
            return response;
        }
    }
}