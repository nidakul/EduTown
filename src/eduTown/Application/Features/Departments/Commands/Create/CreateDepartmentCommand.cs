using Application.Features.Departments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Commands.Create;

public class CreateDepartmentCommand : IRequest<CreatedDepartmentResponse>
{
    public required string Name { get; set; }

    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, CreatedDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly DepartmentBusinessRules _departmentBusinessRules;

        public CreateDepartmentCommandHandler(IMapper mapper, IDepartmentRepository departmentRepository,
                                         DepartmentBusinessRules departmentBusinessRules)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
            _departmentBusinessRules = departmentBusinessRules;
        }

        public async Task<CreatedDepartmentResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department department = _mapper.Map<Department>(request);

            await _departmentRepository.AddAsync(department);

            CreatedDepartmentResponse response = _mapper.Map<CreatedDepartmentResponse>(department);
            return response;
        }
    }
}