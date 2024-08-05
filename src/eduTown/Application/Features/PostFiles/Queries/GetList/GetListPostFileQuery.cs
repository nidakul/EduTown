using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.PostFiles.Queries.GetList;

public class GetListPostFileQuery : IRequest<GetListResponse<GetListPostFileListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListPostFileQueryHandler : IRequestHandler<GetListPostFileQuery, GetListResponse<GetListPostFileListItemDto>>
    {
        private readonly IPostFileRepository _postFileRepository;
        private readonly IMapper _mapper;

        public GetListPostFileQueryHandler(IPostFileRepository postFileRepository, IMapper mapper)
        {
            _postFileRepository = postFileRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListPostFileListItemDto>> Handle(GetListPostFileQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PostFile> postFiles = await _postFileRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListPostFileListItemDto> response = _mapper.Map<GetListResponse<GetListPostFileListItemDto>>(postFiles);
            return response;
        }
    }
}