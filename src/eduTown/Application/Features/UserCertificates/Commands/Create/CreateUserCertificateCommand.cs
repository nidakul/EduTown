using Application.Features.UserCertificates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserCertificates.Commands.Create;

public class CreateUserCertificateCommand : IRequest<CreatedUserCertificateResponse>
{
    public required Guid UserId { get; set; }
    public required int CertificateId { get; set; }
    public required int ClassroomId { get; set; }
    public DateTime Year { get; set; }
    public int Semester { get; set; }

    public class CreateUserCertificateCommandHandler : IRequestHandler<CreateUserCertificateCommand, CreatedUserCertificateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserCertificateRepository _userCertificateRepository;
        private readonly UserCertificateBusinessRules _userCertificateBusinessRules;

        public CreateUserCertificateCommandHandler(IMapper mapper, IUserCertificateRepository userCertificateRepository,
                                         UserCertificateBusinessRules userCertificateBusinessRules)
        {
            _mapper = mapper;
            _userCertificateRepository = userCertificateRepository;
            _userCertificateBusinessRules = userCertificateBusinessRules;
        }

        public async Task<CreatedUserCertificateResponse> Handle(CreateUserCertificateCommand request, CancellationToken cancellationToken)
        {
            UserCertificate userCertificate = _mapper.Map<UserCertificate>(request);

            await _userCertificateRepository.AddAsync(userCertificate);

            CreatedUserCertificateResponse response = _mapper.Map<CreatedUserCertificateResponse>(userCertificate);
            return response;
        }
    }
}