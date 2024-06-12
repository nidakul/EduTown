using Application.Features.SchoolTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolTypes.Queries.GetById;

public class GetByIdSchoolTypeQuery : IRequest<GetByIdSchoolTypeResponse>
{
    public int Id { get; set; }

    public class GetByIdSchoolTypeQueryHandler : IRequestHandler<GetByIdSchoolTypeQuery, GetByIdSchoolTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolTypeRepository _schoolTypeRepository;
        private readonly SchoolTypeBusinessRules _schoolTypeBusinessRules;

        public GetByIdSchoolTypeQueryHandler(IMapper mapper, ISchoolTypeRepository schoolTypeRepository, SchoolTypeBusinessRules schoolTypeBusinessRules)
        {
            _mapper = mapper;
            _schoolTypeRepository = schoolTypeRepository;
            _schoolTypeBusinessRules = schoolTypeBusinessRules;
        }

        public async Task<GetByIdSchoolTypeResponse> Handle(GetByIdSchoolTypeQuery request, CancellationToken cancellationToken)
        {
            SchoolType? schoolType = await _schoolTypeRepository.GetAsync(predicate: st => st.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolTypeBusinessRules.SchoolTypeShouldExistWhenSelected(schoolType);

            GetByIdSchoolTypeResponse response = _mapper.Map<GetByIdSchoolTypeResponse>(schoolType);
            return response;
        }
    }
}