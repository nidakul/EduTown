using Application.Features.Auth.Commands.Register;
using Application.Features.Auth.Rules;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Students.Commands.Update;

public class UpdateStudentCommand : IRequest<UpdatedStudentResponse>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public int BranchId { get; set; }
    public int ClassroomId { get; set; }
    public string StudentNo { get; set; }
    public DateOnly Birthdate { get; set; }
    public string Birthplace { get; set; }
    public required UserForRegisterCommand UserForRegisterCommand { get; set; }

    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, UpdatedStudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly StudentBusinessRules _studentBusinessRules;
        private readonly IUserRepository _userRepository;

        public UpdateStudentCommandHandler(IMapper mapper, IStudentRepository studentRepository,
                                         StudentBusinessRules studentBusinessRules, IUserRepository userRepository)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _studentBusinessRules = studentBusinessRules;
            _userRepository = userRepository;
        }

        public async Task<UpdatedStudentResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            Student? student = await _studentRepository.GetAsync(predicate: s => s.UserId == request.UserId, cancellationToken: cancellationToken);
            await _studentBusinessRules.StudentShouldExistWhenSelected(student);
            student = _mapper.Map(request, student);

            User updatedUser = await _userRepository.UpdateUserAsync(request.UserId,request.UserForRegisterCommand!);

            await _studentRepository.UpdateAsync(student!);

            UpdatedStudentResponse response = _mapper.Map<UpdatedStudentResponse>(student);
            return response;
        }
    }
}