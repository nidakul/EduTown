using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Rules;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Students.Commands.Create;

public class CreateStudentCommand : IRequest<CreatedStudentResponse>
{
    //public required Guid UserId { get; set; }
    public required string StudentNo { get; set; }
    public required int SchoolId { get; set; }
    public required int ClassroomId { get; set; }
    public required string NationalIdentity { get; set; }
    public required string Password { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required DateTime Birthdate { get; set; }
    public required string Birthplace { get; set; }
    public required string Branch { get; set; } //şube
    public string? ImageUrl { get; set; }



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
            await _authBusinessRules.UserNationalIdentityShouldBeNotExists(request.NationalIdentity);

            UserForRegisterCommand userForRegisterCommand = new UserForRegisterCommand(
           request.SchoolId,
           request.ClassroomId,
           request.NationalIdentity,
           request.Password,
           request.FirstName,
           request.LastName,
           request.Email,
           request.ImageUrl
       );
            User createdUser = await _userRepository.CreateUserAsync(userForRegisterCommand);
            //await _userRepository.AddAsync(createdUser);

            Student student = _mapper.Map<Student>(request);
            student.UserId = createdUser.Id;
            await _studentRepository.AddAsync(student);

            CreatedStudentResponse response = _mapper.Map<CreatedStudentResponse>(student);
            return response;
        }
    }
}
