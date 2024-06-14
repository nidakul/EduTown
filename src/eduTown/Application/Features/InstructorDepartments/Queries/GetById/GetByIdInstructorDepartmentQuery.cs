using Application.Features.InstructorDepartments.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.InstructorDepartments.Queries.GetById;

public class GetByIdInstructorDepartmentQuery : IRequest<GetByIdInstructorDepartmentResponse>
{
    public int Id { get; set; }

    public class GetByIdInstructorDepartmentQueryHandler : IRequestHandler<GetByIdInstructorDepartmentQuery, GetByIdInstructorDepartmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IInstructorDepartmentRepository _instructorDepartmentRepository;
        private readonly InstructorDepartmentBusinessRules _instructorDepartmentBusinessRules;

        public GetByIdInstructorDepartmentQueryHandler(IMapper mapper, IInstructorDepartmentRepository instructorDepartmentRepository, InstructorDepartmentBusinessRules instructorDepartmentBusinessRules)
        {
            _mapper = mapper;
            _instructorDepartmentRepository = instructorDepartmentRepository;
            _instructorDepartmentBusinessRules = instructorDepartmentBusinessRules;
        }

        public async Task<GetByIdInstructorDepartmentResponse> Handle(GetByIdInstructorDepartmentQuery request, CancellationToken cancellationToken)
        {
            InstructorDepartment? instructorDepartment = await _instructorDepartmentRepository.GetAsync(predicate: id => id.Id == request.Id, cancellationToken: cancellationToken);
            await _instructorDepartmentBusinessRules.InstructorDepartmentShouldExistWhenSelected(instructorDepartment);

            GetByIdInstructorDepartmentResponse response = _mapper.Map<GetByIdInstructorDepartmentResponse>(instructorDepartment);
            return response;
        }
    }
}