using Application.Features.Departments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Commands.Update;

public class UpdateDepartmentCommand : IRequest<UpdatedDepartmentResponse>
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, UpdatedDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly DepartmentBusinessRules _departmentBusinessRules;

        public UpdateDepartmentCommandHandler(IMapper mapper, IDepartmentRepository departmentRepository,
                                         DepartmentBusinessRules departmentBusinessRules)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
            _departmentBusinessRules = departmentBusinessRules;
        }

        public async Task<UpdatedDepartmentResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department? department = await _departmentRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _departmentBusinessRules.DepartmentShouldExistWhenSelected(department);
            department = _mapper.Map(request, department);

            await _departmentRepository.UpdateAsync(department!);

            UpdatedDepartmentResponse response = _mapper.Map<UpdatedDepartmentResponse>(department);
            return response;
        }
    }
}