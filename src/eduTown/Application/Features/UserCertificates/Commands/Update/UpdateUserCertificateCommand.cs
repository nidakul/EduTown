using Application.Features.UserCertificates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserCertificates.Commands.Update;

public class UpdateUserCertificateCommand : IRequest<UpdatedUserCertificateResponse>
{
    public int Id { get; set; }
    public required Guid UserId { get; set; }
    public required int CertificateId { get; set; }
    public required int ClassroomId { get; set; }

    public class UpdateUserCertificateCommandHandler : IRequestHandler<UpdateUserCertificateCommand, UpdatedUserCertificateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserCertificateRepository _userCertificateRepository;
        private readonly UserCertificateBusinessRules _userCertificateBusinessRules;

        public UpdateUserCertificateCommandHandler(IMapper mapper, IUserCertificateRepository userCertificateRepository,
                                         UserCertificateBusinessRules userCertificateBusinessRules)
        {
            _mapper = mapper;
            _userCertificateRepository = userCertificateRepository;
            _userCertificateBusinessRules = userCertificateBusinessRules;
        }

        public async Task<UpdatedUserCertificateResponse> Handle(UpdateUserCertificateCommand request, CancellationToken cancellationToken)
        {
            UserCertificate? userCertificate = await _userCertificateRepository.GetAsync(predicate: uc => uc.Id == request.Id, cancellationToken: cancellationToken);
            await _userCertificateBusinessRules.UserCertificateShouldExistWhenSelected(userCertificate);
            userCertificate = _mapper.Map(request, userCertificate);

            await _userCertificateRepository.UpdateAsync(userCertificate!);

            UpdatedUserCertificateResponse response = _mapper.Map<UpdatedUserCertificateResponse>(userCertificate);
            return response;
        }
    }
}