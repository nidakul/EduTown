using Application.Features.Branches.Rules;
using Application.Features.Classrooms.Rules;
using Application.Features.Posts.Rules;
using Application.Features.Schools.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NArchitecture.Core.Persistence.Paging;
using System;
namespace Application.Features.Students.Queries.GetListStudentsSchoolIdClassIdBranchId
{
    public class GetListStudentsSchoolIdClassIdBranchIdQuery : IRequest<GetListStudentsSchoolIdClassIdBranchIdResponse>
    {
        public int SchoolId { get; set; }
        public int ClassroomId { get; set; }
        public int BranchId { get; set; }

        public class GetListStudentsSchoolIdClassIdBranchIdQueryHandler : IRequestHandler<GetListStudentsSchoolIdClassIdBranchIdQuery, GetListStudentsSchoolIdClassIdBranchIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly IStudentRepository _studentRepository;
            private readonly SchoolBusinessRules _schoolBusinessRules;
            private readonly ClassroomBusinessRules _classroomBusinessRules;
            private readonly BranchBusinessRules _branchBusinessRules;

            public GetListStudentsSchoolIdClassIdBranchIdQueryHandler(IMapper mapper, IStudentRepository studentRepository, PostBusinessRules postBusinessRules, SchoolBusinessRules schoolBusinessRules, ClassroomBusinessRules classroomBusinessRules, BranchBusinessRules branchBusinessRules)
            {
                _mapper = mapper;
                _studentRepository = studentRepository;
                _schoolBusinessRules = schoolBusinessRules;
                _classroomBusinessRules = classroomBusinessRules;
                _branchBusinessRules = branchBusinessRules;
            }
            public async Task<GetListStudentsSchoolIdClassIdBranchIdResponse> Handle(GetListStudentsSchoolIdClassIdBranchIdQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Student>? student = await _studentRepository.GetListAsync(predicate: s => s.User.School.Id.Equals(request.SchoolId) && s.ClassroomId.Equals(request.ClassroomId) && s.BranchId.Equals(request.BranchId),
                    include: p => p.Include(s => s.User.School)
                    .Include(s => s.User),
                enableTracking: false, cancellationToken: cancellationToken,
                index: 0,
                size: int.MaxValue);
                await _schoolBusinessRules.SchoolIdShouldExistWhenSelected(request.SchoolId, cancellationToken);
                await _classroomBusinessRules.ClassroomIdShouldExistWhenSelected(request.ClassroomId, cancellationToken);
                await _branchBusinessRules.BranchIdShouldExistWhenSelected(request.BranchId, cancellationToken);

                GetListStudentsSchoolIdClassIdBranchIdResponse response = _mapper.Map<GetListStudentsSchoolIdClassIdBranchIdResponse>(student);
                return response;
            }
        }
    }
}

