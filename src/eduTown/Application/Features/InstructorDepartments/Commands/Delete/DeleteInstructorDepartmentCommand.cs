using Application.Features.InstructorDepartments.Constants;
using Application.Features.InstructorDepartments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.InstructorDepartments.Commands.Delete;

public class DeleteInstructorDepartmentCommand : IRequest<DeletedInstructorDepartmentResponse>
{
    public int Id { get; set; }

    public class DeleteInstructorDepartmentCommandHandler : IRequestHandler<DeleteInstructorDepartmentCommand, DeletedInstructorDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorDepartmentRepository _instructorDepartmentRepository;
        private readonly InstructorDepartmentBusinessRules _instructorDepartmentBusinessRules;

        public DeleteInstructorDepartmentCommandHandler(IMapper mapper, IInstructorDepartmentRepository instructorDepartmentRepository,
                                         InstructorDepartmentBusinessRules instructorDepartmentBusinessRules)
        {
            _mapper = mapper;
            _instructorDepartmentRepository = instructorDepartmentRepository;
            _instructorDepartmentBusinessRules = instructorDepartmentBusinessRules;
        }

        public async Task<DeletedInstructorDepartmentResponse> Handle(DeleteInstructorDepartmentCommand request, CancellationToken cancellationToken)
        {
            InstructorDepartment? instructorDepartment = await _instructorDepartmentRepository.GetAsync(predicate: id => id.Id == request.Id, cancellationToken: cancellationToken);
            await _instructorDepartmentBusinessRules.InstructorDepartmentShouldExistWhenSelected(instructorDepartment);

            await _instructorDepartmentRepository.DeleteAsync(instructorDepartment!);

            DeletedInstructorDepartmentResponse response = _mapper.Map<DeletedInstructorDepartmentResponse>(instructorDepartment);
            return response;
        }
    }
}