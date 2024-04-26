using Application.Features.UserCertificates.Constants;
using Application.Features.UserCertificates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserCertificates.Commands.Delete;

public class DeleteUserCertificateCommand : IRequest<DeletedUserCertificateResponse>
{
    public int Id { get; set; }

    public class DeleteUserCertificateCommandHandler : IRequestHandler<DeleteUserCertificateCommand, DeletedUserCertificateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserCertificateRepository _userCertificateRepository;
        private readonly UserCertificateBusinessRules _userCertificateBusinessRules;

        public DeleteUserCertificateCommandHandler(IMapper mapper, IUserCertificateRepository userCertificateRepository,
                                         UserCertificateBusinessRules userCertificateBusinessRules)
        {
            _mapper = mapper;
            _userCertificateRepository = userCertificateRepository;
            _userCertificateBusinessRules = userCertificateBusinessRules;
        }

        public async Task<DeletedUserCertificateResponse> Handle(DeleteUserCertificateCommand request, CancellationToken cancellationToken)
        {
            UserCertificate? userCertificate = await _userCertificateRepository.GetAsync(predicate: uc => uc.Id == request.Id, cancellationToken: cancellationToken);
            await _userCertificateBusinessRules.UserCertificateShouldExistWhenSelected(userCertificate);

            await _userCertificateRepository.DeleteAsync(userCertificate!);

            DeletedUserCertificateResponse response = _mapper.Map<DeletedUserCertificateResponse>(userCertificate);
            return response;
        }
    }
}