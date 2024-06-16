using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.ExamDates.Queries.GetList;

public class GetListExamDateQuery : IRequest<GetListResponse<GetListExamDateListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListExamDateQueryHandler : IRequestHandler<GetListExamDateQuery, GetListResponse<GetListExamDateListItemDto>>
    {
        private readonly IExamDateRepository _examDateRepository;
        private readonly IMapper _mapper;

        public GetListExamDateQueryHandler(IExamDateRepository examDateRepository, IMapper mapper)
        {
            _examDateRepository = examDateRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListExamDateListItemDto>> Handle(GetListExamDateQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ExamDate> examDates = await _examDateRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListExamDateListItemDto> response = _mapper.Map<GetListResponse<GetListExamDateListItemDto>>(examDates);
            return response;
        }
    }
}