using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.Terms.Queries.GetList;

public class GetListTermQuery : IRequest<GetListResponse<GetListTermListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListTermQueryHandler : IRequestHandler<GetListTermQuery, GetListResponse<GetListTermListItemDto>>
    {
        private readonly ITermRepository _termRepository;
        private readonly IMapper _mapper;

        public GetListTermQueryHandler(ITermRepository termRepository, IMapper mapper)
        {
            _termRepository = termRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTermListItemDto>> Handle(GetListTermQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Term> terms = await _termRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListTermListItemDto> response = _mapper.Map<GetListResponse<GetListTermListItemDto>>(terms);
            return response;
        }
    }
}