using Application.Features.UserCertificates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserCertificates.Queries.GetById;

public class GetByIdUserCertificateQuery : IRequest<GetByIdUserCertificateResponse>
{
    public int Id { get; set; }

    public class GetByIdUserCertificateQueryHandler : IRequestHandler<GetByIdUserCertificateQuery, GetByIdUserCertificateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserCertificateRepository _userCertificateRepository;
        private readonly UserCertificateBusinessRules _userCertificateBusinessRules;

        public GetByIdUserCertificateQueryHandler(IMapper mapper, IUserCertificateRepository userCertificateRepository, UserCertificateBusinessRules userCertificateBusinessRules)
        {
            _mapper = mapper;
            _userCertificateRepository = userCertificateRepository;
            _userCertificateBusinessRules = userCertificateBusinessRules;
        }

        public async Task<GetByIdUserCertificateResponse> Handle(GetByIdUserCertificateQuery request, CancellationToken cancellationToken)
        {
            UserCertificate? userCertificate = await _userCertificateRepository.GetAsync(predicate: uc => uc.Id == request.Id, cancellationToken: cancellationToken);
            await _userCertificateBusinessRules.UserCertificateShouldExistWhenSelected(userCertificate);

            GetByIdUserCertificateResponse response = _mapper.Map<GetByIdUserCertificateResponse>(userCertificate);
            return response;
        }
    }
}