using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;
using System;
namespace Application.Features.Students.Queries.GetStudentDetail
{
    public class GetListStudentDetailQuery : IRequest<GetListResponse<GetListStudentDetailResponse>>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListStudentDetailQueryHandler : IRequestHandler<GetListStudentDetailQuery, GetListResponse<GetListStudentDetailResponse>>
        {
            private readonly IStudentRepository _studentRepository;
            private readonly IMapper _mapper;

            public GetListStudentDetailQueryHandler(IStudentRepository studentRepository, IMapper mapper)
            {
                _studentRepository = studentRepository;
                _mapper = mapper;
            }

            public async Task<GetListResponse<GetListStudentDetailResponse>> Handle(GetListStudentDetailQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Student> students = await _studentRepository.GetListAsync(
                    include: s => s.Include(s=> s.User)
                    .Include(s => s.User).ThenInclude(s=> s.School)
                    .Include(s => s.Classroom)
                    .Include(s => s.Branch),
                    index: request.PageRequest.PageIndex,
                    size: request.PageRequest.PageSize,
                    cancellationToken: cancellationToken
                    );
                GetListResponse<GetListStudentDetailResponse> response = _mapper.Map<GetListResponse<GetListStudentDetailResponse>>(students);
                return response; 
            }
        }
        
    }
}

