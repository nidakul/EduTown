using Application.Features.SchoolLessonClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolLessonClasses.Queries.GetById;

public class GetByIdSchoolLessonClassQuery : IRequest<GetByIdSchoolLessonClassResponse>
{
    public int Id { get; set; }

    public class GetByIdSchoolLessonClassQueryHandler : IRequestHandler<GetByIdSchoolLessonClassQuery, GetByIdSchoolLessonClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolLessonClassRepository _schoolLessonClassRepository;
        private readonly SchoolLessonClassBusinessRules _schoolLessonClassBusinessRules;

        public GetByIdSchoolLessonClassQueryHandler(IMapper mapper, ISchoolLessonClassRepository schoolLessonClassRepository, SchoolLessonClassBusinessRules schoolLessonClassBusinessRules)
        {
            _mapper = mapper;
            _schoolLessonClassRepository = schoolLessonClassRepository;
            _schoolLessonClassBusinessRules = schoolLessonClassBusinessRules;
        }

        public async Task<GetByIdSchoolLessonClassResponse> Handle(GetByIdSchoolLessonClassQuery request, CancellationToken cancellationToken)
        {
            SchoolLessonClass? schoolLessonClass = await _schoolLessonClassRepository.GetAsync(predicate: slc => slc.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolLessonClassBusinessRules.SchoolLessonClassShouldExistWhenSelected(schoolLessonClass);

            GetByIdSchoolLessonClassResponse response = _mapper.Map<GetByIdSchoolLessonClassResponse>(schoolLessonClass);
            return response;
        }
    }
}