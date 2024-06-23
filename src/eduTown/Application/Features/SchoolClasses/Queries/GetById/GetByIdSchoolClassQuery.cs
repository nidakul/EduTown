using Application.Features.SchoolClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolClasses.Queries.GetById;

public class GetByIdSchoolClassQuery : IRequest<GetByIdSchoolClassResponse>
{
    public int Id { get; set; }

    public class GetByIdSchoolClassQueryHandler : IRequestHandler<GetByIdSchoolClassQuery, GetByIdSchoolClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClassRepository _schoolClassRepository;
        private readonly SchoolClassBusinessRules _schoolClassBusinessRules;

        public GetByIdSchoolClassQueryHandler(IMapper mapper, ISchoolClassRepository schoolClassRepository, SchoolClassBusinessRules schoolClassBusinessRules)
        {
            _mapper = mapper;
            _schoolClassRepository = schoolClassRepository;
            _schoolClassBusinessRules = schoolClassBusinessRules;
        }

        public async Task<GetByIdSchoolClassResponse> Handle(GetByIdSchoolClassQuery request, CancellationToken cancellationToken)
        {
            SchoolClass? schoolClass = await _schoolClassRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolClassBusinessRules.SchoolClassShouldExistWhenSelected(schoolClass);

            GetByIdSchoolClassResponse response = _mapper.Map<GetByIdSchoolClassResponse>(schoolClass);
            return response;
        }
    }
}