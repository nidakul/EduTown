using Application.Features.GradeTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GradeTypes.Queries.GetById;

public class GetByIdGradeTypeQuery : IRequest<GetByIdGradeTypeResponse>
{
    public int Id { get; set; }

    public class GetByIdGradeTypeQueryHandler : IRequestHandler<GetByIdGradeTypeQuery, GetByIdGradeTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGradeTypeRepository _gradeTypeRepository;
        private readonly GradeTypeBusinessRules _gradeTypeBusinessRules;

        public GetByIdGradeTypeQueryHandler(IMapper mapper, IGradeTypeRepository gradeTypeRepository, GradeTypeBusinessRules gradeTypeBusinessRules)
        {
            _mapper = mapper;
            _gradeTypeRepository = gradeTypeRepository;
            _gradeTypeBusinessRules = gradeTypeBusinessRules;
        }

        public async Task<GetByIdGradeTypeResponse> Handle(GetByIdGradeTypeQuery request, CancellationToken cancellationToken)
        {
            GradeType? gradeType = await _gradeTypeRepository.GetAsync(predicate: gt => gt.Id == request.Id, cancellationToken: cancellationToken);
            await _gradeTypeBusinessRules.GradeTypeShouldExistWhenSelected(gradeType);

            GetByIdGradeTypeResponse response = _mapper.Map<GetByIdGradeTypeResponse>(gradeType);
            return response;
        }
    }
}