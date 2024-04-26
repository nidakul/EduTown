using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.UserCertificates.Queries.GetList;

public class GetListUserCertificateQuery : IRequest<GetListResponse<GetListUserCertificateListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListUserCertificateQueryHandler : IRequestHandler<GetListUserCertificateQuery, GetListResponse<GetListUserCertificateListItemDto>>
    {
        private readonly IUserCertificateRepository _userCertificateRepository;
        private readonly IMapper _mapper;

        public GetListUserCertificateQueryHandler(IUserCertificateRepository userCertificateRepository, IMapper mapper)
        {
            _userCertificateRepository = userCertificateRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListUserCertificateListItemDto>> Handle(GetListUserCertificateQuery request, CancellationToken cancellationToken)
        {
            IPaginate<UserCertificate> userCertificates = await _userCertificateRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListUserCertificateListItemDto> response = _mapper.Map<GetListResponse<GetListUserCertificateListItemDto>>(userCertificates);
            return response;
        }
    }
}