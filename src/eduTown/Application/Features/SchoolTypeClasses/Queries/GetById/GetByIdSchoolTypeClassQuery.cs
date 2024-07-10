using Application.Features.SchoolTypeClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolTypeClasses.Queries.GetById;

public class GetByIdSchoolTypeClassQuery : IRequest<GetByIdSchoolTypeClassResponse>
{
    public int Id { get; set; }

    public class GetByIdSchoolTypeClassQueryHandler : IRequestHandler<GetByIdSchoolTypeClassQuery, GetByIdSchoolTypeClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolTypeClassRepository _schoolTypeClassRepository;
        private readonly SchoolTypeClassBusinessRules _schoolTypeClassBusinessRules;

        public GetByIdSchoolTypeClassQueryHandler(IMapper mapper, ISchoolTypeClassRepository schoolTypeClassRepository, SchoolTypeClassBusinessRules schoolTypeClassBusinessRules)
        {
            _mapper = mapper;
            _schoolTypeClassRepository = schoolTypeClassRepository;
            _schoolTypeClassBusinessRules = schoolTypeClassBusinessRules;
        }

        public async Task<GetByIdSchoolTypeClassResponse> Handle(GetByIdSchoolTypeClassQuery request, CancellationToken cancellationToken)
        {
            SchoolTypeClass? schoolTypeClass = await _schoolTypeClassRepository.GetAsync(predicate: stc => stc.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolTypeClassBusinessRules.SchoolTypeClassShouldExistWhenSelected(schoolTypeClass);

            GetByIdSchoolTypeClassResponse response = _mapper.Map<GetByIdSchoolTypeClassResponse>(schoolTypeClass);
            return response;
        }
    }
}