using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using MediatR;

namespace Application.Features.InstructorDepartments.Queries.GetList;

public class GetListInstructorDepartmentQuery : IRequest<GetListResponse<GetListInstructorDepartmentListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListInstructorDepartmentQueryHandler : IRequestHandler<GetListInstructorDepartmentQuery, GetListResponse<GetListInstructorDepartmentListItemDto>>
    {
        private readonly IInstructorDepartmentRepository _instructorDepartmentRepository;
        private readonly IMapper _mapper;

        public GetListInstructorDepartmentQueryHandler(IInstructorDepartmentRepository instructorDepartmentRepository, IMapper mapper)
        {
            _instructorDepartmentRepository = instructorDepartmentRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListInstructorDepartmentListItemDto>> Handle(GetListInstructorDepartmentQuery request, CancellationToken cancellationToken)
        {
            IPaginate<InstructorDepartment> instructorDepartments = await _instructorDepartmentRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize, 
                cancellationToken: cancellationToken
            );

            GetListResponse<GetListInstructorDepartmentListItemDto> response = _mapper.Map<GetListResponse<GetListInstructorDepartmentListItemDto>>(instructorDepartments);
            return response;
        }
    }
}