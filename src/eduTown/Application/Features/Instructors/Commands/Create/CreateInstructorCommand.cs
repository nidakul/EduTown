using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Rules;
using Application.Features.Instructors.Rules;
using Application.Services.Repositories;
using Application.Services.UsersService;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Security.Hashing;
using System.Security.Cryptography.X509Certificates;

namespace Application.Features.Instructors.Commands.Create;

public class CreateInstructorCommand : IRequest<CreatedInstructorResponse>
{
    public required string Department { get; set; }
    public UserForRegisterCommand UserForRegisterCommand { get; set; }

    public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, CreatedInstructorResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorRepository _instructorRepository;
        private readonly InstructorBusinessRules _instructorBusinessRules;
        private readonly IUserRepository _userRepository;
        private readonly AuthBusinessRules _authBusinessRules;


        public CreateInstructorCommandHandler(IMapper mapper, IInstructorRepository instructorRepository,
                                         InstructorBusinessRules instructorBusinessRules, AuthBusinessRules authBusinessRules,  IUserRepository userRepository)
        {
            _mapper = mapper;
            _instructorRepository = instructorRepository;
            _instructorBusinessRules = instructorBusinessRules;
            _userRepository = userRepository;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<CreatedInstructorResponse> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserNationalIdentityShouldBeNotExists(request.UserForRegisterCommand.NationalIdentity);

            Instructor instructor = _mapper.Map<Instructor>(request);

            User createdUser = await _userRepository.CreateUserAsync(request.UserForRegisterCommand);
            instructor.UserId = createdUser.Id;

            await _instructorRepository.AddAsync(instructor);

            CreatedInstructorResponse response = _mapper.Map<CreatedInstructorResponse>(instructor);
            return response;
        }
    }
}