using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Responses;
using System;
namespace Application.Features.Users.Queries.GetCertificatesByUserId
{
    public class GetCertificatesByUserIdQuery :IRequest<GetCertificatesByUserIdResponse>
    {
        public Guid Id { get; set; }

        public class GetCertificatesByUserIdQueryHandler : IRequestHandler<GetCertificatesByUserIdQuery, GetCertificatesByUserIdResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public GetCertificatesByUserIdQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<GetCertificatesByUserIdResponse> Handle(GetCertificatesByUserIdQuery request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(predicate: u => u.Id.Equals(request.Id),
                    include: u => u.Include(u => u.UserCertificates).ThenInclude(u => u.Certificate),
                   //.Include(u => u.UserCertificates).ThenInclude(u => u.Classroom),
                    enableTracking: false,
                    cancellationToken: cancellationToken);
                await _userBusinessRules.UserShouldBeExistsWhenSelected(user);

                GetCertificatesByUserIdResponse response = _mapper.Map<GetCertificatesByUserIdResponse>(user);
                return response;

            }
        }
    }
}

