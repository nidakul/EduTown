using Application.Features.Schools.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.Schools.Queries.GetClassesBySchoolId
{
    public class GetClassesBySchoolIdQuery : IRequest<GetClassesBySchoolIdResponse>
    {
        public int Id { get; set; }

        public class GetClassesBySchoolIdQueryHandler : IRequestHandler<GetClassesBySchoolIdQuery, GetClassesBySchoolIdResponse>
        {
            private readonly IMapper _mapper;
            private readonly SchoolBusinessRules _schoolBusinessRules;
            private readonly ISchoolRepository _schoolRepository;

            public GetClassesBySchoolIdQueryHandler(IMapper mapper, SchoolBusinessRules schoolBusinessRules, ISchoolRepository schoolRepository)
            {
                _mapper = mapper;
                _schoolBusinessRules = schoolBusinessRules;
                _schoolRepository = schoolRepository;
            }

            public async Task<GetClassesBySchoolIdResponse> Handle(GetClassesBySchoolIdQuery request, CancellationToken cancellationToken)
            {
                School? school = await _schoolRepository.GetAsync(predicate: s => s.Id.Equals(request.Id),
                    include: s => s.Include(s => s.SchoolClasses).ThenInclude(s => s.Classroom),
                    enableTracking: false,
                    cancellationToken: cancellationToken
                    );
                await _schoolBusinessRules.SchoolShouldExistWhenSelected(school);
                GetClassesBySchoolIdResponse response = _mapper.Map<GetClassesBySchoolIdResponse>(school);
                return response;

            }
        }
    }
}

