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
namespace Application.Features.Posts.Queries.GetPostsBySchoolIdClassIdBranchId
{
    public class GetPostsBySchoolIdClassIdBranchIdQuery : IRequest<GetPostsBySchoolIdClassIdBranchIdResponse>
    {
        public int SchoolId { get; set; }
        public int ClassroomId { get; set; }
        public int BranchId { get; set; }

        public class GetPostsBySchoolIdClassIdBranchIdQueryHandler : IRequestHandler<GetPostsBySchoolIdClassIdBranchIdQuery, GetPostsBySchoolIdClassIdBranchIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly IPostRepository _postRepository;
            private readonly PostBusinessRules _postBusinessRules;
            private readonly SchoolBusinessRules _schoolBusinessRules;
            private readonly ClassroomBusinessRules _classroomBusinessRules;
            private readonly BranchBusinessRules _branchBusinessRules;

            public GetPostsBySchoolIdClassIdBranchIdQueryHandler(IMapper mapper, IPostRepository postRepository, PostBusinessRules postBusinessRules, SchoolBusinessRules schoolBusinessRules, ClassroomBusinessRules classroomBusinessRules, BranchBusinessRules branchBusinessRules)
            {
                _mapper = mapper;
                _postRepository = postRepository;
                _postBusinessRules = postBusinessRules;
                _schoolBusinessRules = schoolBusinessRules;
                _classroomBusinessRules = classroomBusinessRules;
                _branchBusinessRules = branchBusinessRules;
            }

            public async Task<GetPostsBySchoolIdClassIdBranchIdResponse> Handle(GetPostsBySchoolIdClassIdBranchIdQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Post>? post = await _postRepository.GetListAsync(predicate: p => p.SchoolId.Equals(request.SchoolId) && p.ClassroomId.Equals(request.ClassroomId) && p.BranchId.Equals(request.BranchId),
                include: p => p.Include(p => p.User.School)
                .Include(p => p.User.Student.Classroom)
                .Include(p => p.User.Student.Branch)
                .Include(p => p.User),
                enableTracking: false, cancellationToken: cancellationToken,
                index: 0,
                size: int.MaxValue);

                await _schoolBusinessRules.SchoolIdShouldExistWhenSelected(request.SchoolId, cancellationToken);
                await _classroomBusinessRules.ClassroomIdShouldExistWhenSelected(request.ClassroomId, cancellationToken);
                await _branchBusinessRules.BranchIdShouldExistWhenSelected(request.BranchId, cancellationToken);

                GetPostsBySchoolIdClassIdBranchIdResponse response = _mapper.Map<GetPostsBySchoolIdClassIdBranchIdResponse>(post);
                return response;

            }

        }

    }
}

