using Application.Features.Departments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Departments.Queries.GetById;

public class GetByIdDepartmentQuery : IRequest<GetByIdDepartmentResponse>
{
    public int Id { get; set; }

    public class GetByIdDepartmentQueryHandler : IRequestHandler<GetByIdDepartmentQuery, GetByIdDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentRepository _departmentRepository;
        private readonly DepartmentBusinessRules _departmentBusinessRules;

        public GetByIdDepartmentQueryHandler(IMapper mapper, IDepartmentRepository departmentRepository, DepartmentBusinessRules departmentBusinessRules)
        {
            _mapper = mapper;
            _departmentRepository = departmentRepository;
            _departmentBusinessRules = departmentBusinessRules;
        }

        public async Task<GetByIdDepartmentResponse> Handle(GetByIdDepartmentQuery request, CancellationToken cancellationToken)
        {
            Department? department = await _departmentRepository.GetAsync(predicate: d => d.Id == request.Id, cancellationToken: cancellationToken);
            await _departmentBusinessRules.DepartmentShouldExistWhenSelected(department);

            GetByIdDepartmentResponse response = _mapper.Map<GetByIdDepartmentResponse>(department);
            return response;
        }
    }
}