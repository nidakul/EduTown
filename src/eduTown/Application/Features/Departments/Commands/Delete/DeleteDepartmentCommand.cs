using Application.Features.Departments.Constants;
using Application.Features.Departments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Commands.Delete;

public class DeleteDepartmentCommand : IRequest<DeletedDepartmentResponse>
{
    public int Id { get; set; }

    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, DeletedDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly DepartmentBusinessRules _departmentBusinessRules;

        public DeleteDepartmentCommandHandler(IMapper mapper, IDepartmentRepository departmentRepository,
                                         DepartmentBusinessRules departmentBusinessRules)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
            _departmentBusinessRules = departmentBusinessRules;
        }

        public async Task<DeletedDepartmentResponse> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            Department? department = await _departmentRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _departmentBusinessRules.DepartmentShouldExistWhenSelected(department);

            await _departmentRepository.DeleteAsync(department!);

            DeletedDepartmentResponse response = _mapper.Map<DeletedDepartmentResponse>(department);
            return response;
        }
    }
}