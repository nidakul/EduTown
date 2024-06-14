using Application.Features.InstructorDepartments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.InstructorDepartments.Commands.Create;

public class CreateInstructorDepartmentCommand : IRequest<CreatedInstructorDepartmentResponse>
{
    public required int InstructorId { get; set; }
    public required int DepartmentId { get; set; }

    public class CreateInstructorDepartmentCommandHandler : IRequestHandler<CreateInstructorDepartmentCommand, CreatedInstructorDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorDepartmentRepository _instructorDepartmentRepository;
        private readonly InstructorDepartmentBusinessRules _instructorDepartmentBusinessRules;

        public CreateInstructorDepartmentCommandHandler(IMapper mapper, IInstructorDepartmentRepository instructorDepartmentRepository,
                                         InstructorDepartmentBusinessRules instructorDepartmentBusinessRules)
        {
            _mapper = mapper;
            _instructorDepartmentRepository = instructorDepartmentRepository;
            _instructorDepartmentBusinessRules = instructorDepartmentBusinessRules;
        }

        public async Task<CreatedInstructorDepartmentResponse> Handle(CreateInstructorDepartmentCommand request, CancellationToken cancellationToken)
        {
            InstructorDepartment instructorDepartment = _mapper.Map<InstructorDepartment>(request);

            await _instructorDepartmentRepository.AddAsync(instructorDepartment);

            CreatedInstructorDepartmentResponse response = _mapper.Map<CreatedInstructorDepartmentResponse>(instructorDepartment);
            return response;
        }
    }
}