using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.GradeTypes.Queries.GetList;

public class GetListGradeTypeQuery : IRequest<GetListResponse<GetListGradeTypeListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListGradeTypeQueryHandler : IRequestHandler<GetListGradeTypeQuery, GetListResponse<GetListGradeTypeListItemDto>>
    {
        private readonly IGradeTypeRepository _gradeTypeRepository;
        private readonly IMapper _mapper;

        public GetListGradeTypeQueryHandler(IGradeTypeRepository gradeTypeRepository, IMapper mapper)
        {
            _gradeTypeRepository = gradeTypeRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListGradeTypeListItemDto>> Handle(GetListGradeTypeQuery request, CancellationToken cancellationToken)
        {
            IPaginate<GradeType> gradeTypes = await _gradeTypeRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListGradeTypeListItemDto> response = _mapper.Map<GetListResponse<GetListGradeTypeListItemDto>>(gradeTypes);
            return response;
        }
    }
}