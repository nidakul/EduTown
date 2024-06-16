using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.StudentExamDates.Queries.GetList;

public class GetListStudentExamDateQuery : IRequest<GetListResponse<GetListStudentExamDateListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListStudentExamDateQueryHandler : IRequestHandler<GetListStudentExamDateQuery, GetListResponse<GetListStudentExamDateListItemDto>>
    {
        private readonly IStudentExamDateRepository _studentExamDateRepository;
        private readonly IMapper _mapper;

        public GetListStudentExamDateQueryHandler(IStudentExamDateRepository studentExamDateRepository, IMapper mapper)
        {
            _studentExamDateRepository = studentExamDateRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListStudentExamDateListItemDto>> Handle(GetListStudentExamDateQuery request, CancellationToken cancellationToken)
        {
            IPaginate<StudentExamDate> studentExamDates = await _studentExamDateRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListStudentExamDateListItemDto> response = _mapper.Map<GetListResponse<GetListStudentExamDateListItemDto>>(studentExamDates);
            return response;
        }
    }
}