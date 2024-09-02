using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Rules;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Logging;

namespace Application.Features.Students.Commands.Create;

public class CreateStudentCommand : IRequest<CreatedStudentResponse>
{
    public int BranchId { get; set; }
    public int ClassroomId { get; set; }
    public string StudentNo { get; set; }
    public DateOnly Birthdate { get; set; }
    public string Birthplace { get; set; }
    public required UserForRegisterCommand UserForRegisterCommand { get; set; }


    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, CreatedStudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly StudentBusinessRules _studentBusinessRules;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IUserRepository _userRepository;

        public CreateStudentCommandHandler(IMapper mapper, IStudentRepository studentRepository,
                                         StudentBusinessRules studentBusinessRules, AuthBusinessRules authBusinessRules, IUserRepository userRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _studentBusinessRules = studentBusinessRules;
            _authBusinessRules = authBusinessRules;
            _userRepository = userRepository;
        }

        public async Task<CreatedStudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserNationalIdentityShouldBeNotExists(request.UserForRegisterCommand.NationalIdentity);

            Student student = _mapper.Map<Student>(request);
            
            User createdUser = await _userRepository.CreateUserAsync(request.UserForRegisterCommand);
            student.UserId = createdUser.Id;

            await _studentRepository.AddAsync(student);

            CreatedStudentResponse response = _mapper.Map<CreatedStudentResponse>(student);
            return response;
        }
    }
}
