using Application.Features.SchoolTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
namespace Application.Features.SchoolTypes.Queries.GetClassesBySchoolTypeId
{
    public class GetClassesBySchoolTypeIdQuery : IRequest<GetClassesBySchoolTypeIdResponse>
    {
                public int Id { get; set; }

    public class GetClassesBySchoolTypeIdQueryHandler : IRequestHandler<GetClassesBySchoolTypeIdQuery, GetClassesBySchoolTypeIdResponse>
    {
        private readonly ISchoolTypeRepository _schoolTypeRepository;
        private readonly IMapper _mapper;
        private readonly SchoolTypeBusinessRules _schoolTypeBusinessRules;

        public GetClassesBySchoolTypeIdQueryHandler(ISchoolTypeRepository schoolTypeRepository, IMapper mapper, SchoolTypeBusinessRules schoolTypeBusinessRules)
        {
            _schoolTypeRepository = schoolTypeRepository;
            _mapper = mapper;
            _schoolTypeBusinessRules = schoolTypeBusinessRules;
        }

        public async Task<GetClassesBySchoolTypeIdResponse> Handle(GetClassesBySchoolTypeIdQuery request, CancellationToken cancellationToken)
        {
            SchoolType schoolType = await _schoolTypeRepository.GetAsync(predicate: st => st.Id.Equals(request.Id),
                include: st => st.Include(st => st.SchoolTypeClasses).ThenInclude(st => st.Classroom),
                enableTracking: false,
                cancellationToken: cancellationToken);
            await _schoolTypeBusinessRules.SchoolTypeShouldExistWhenSelected(schoolType);

            GetClassesBySchoolTypeIdResponse response = _mapper.Map<GetClassesBySchoolTypeIdResponse>(schoolType);
            return response;
        }
    }

}
}

