using Application.Features.InstructorDepartments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.InstructorDepartments.Commands.Update;

public class UpdateInstructorDepartmentCommand : IRequest<UpdatedInstructorDepartmentResponse>
{
    public int Id { get; set; }
    public required int InstructorId { get; set; }
    public required int DepartmentId { get; set; }

    public class UpdateInstructorDepartmentCommandHandler : IRequestHandler<UpdateInstructorDepartmentCommand, UpdatedInstructorDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorDepartmentRepository _instructorDepartmentRepository;
        private readonly InstructorDepartmentBusinessRules _instructorDepartmentBusinessRules;

        public UpdateInstructorDepartmentCommandHandler(IMapper mapper, IInstructorDepartmentRepository instructorDepartmentRepository,
                                         InstructorDepartmentBusinessRules instructorDepartmentBusinessRules)
        {
            _mapper = mapper;
            _instructorDepartmentRepository = instructorDepartmentRepository;
            _instructorDepartmentBusinessRules = instructorDepartmentBusinessRules;
        }

        public async Task<UpdatedInstructorDepartmentResponse> Handle(UpdateInstructorDepartmentCommand request, CancellationToken cancellationToken)
        {
            InstructorDepartment? instructorDepartment = await _instructorDepartmentRepository.GetAsync(predicate: id => id.Id == request.Id, cancellationToken: cancellationToken);
            await _instructorDepartmentBusinessRules.InstructorDepartmentShouldExistWhenSelected(instructorDepartment);
            instructorDepartment = _mapper.Map(request, instructorDepartment);

            await _instructorDepartmentRepository.UpdateAsync(instructorDepartment!);

            UpdatedInstructorDepartmentResponse response = _mapper.Map<UpdatedInstructorDepartmentResponse>(instructorDepartment);
            return response;
        }
    }
}