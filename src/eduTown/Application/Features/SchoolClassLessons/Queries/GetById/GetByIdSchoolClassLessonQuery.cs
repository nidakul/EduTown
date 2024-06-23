using Application.Features.SchoolClassLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolClassLessons.Queries.GetById;

public class GetByIdSchoolClassLessonQuery : IRequest<GetByIdSchoolClassLessonResponse>
{
    public int Id { get; set; }

    public class GetByIdSchoolClassLessonQueryHandler : IRequestHandler<GetByIdSchoolClassLessonQuery, GetByIdSchoolClassLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClassLessonRepository _schoolClassLessonRepository;
        private readonly SchoolClassLessonBusinessRules _schoolClassLessonBusinessRules;

        public GetByIdSchoolClassLessonQueryHandler(IMapper mapper, ISchoolClassLessonRepository schoolClassLessonRepository, SchoolClassLessonBusinessRules schoolClassLessonBusinessRules)
        {
            _mapper = mapper;
            _schoolClassLessonRepository = schoolClassLessonRepository;
            _schoolClassLessonBusinessRules = schoolClassLessonBusinessRules;
        }

        public async Task<GetByIdSchoolClassLessonResponse> Handle(GetByIdSchoolClassLessonQuery request, CancellationToken cancellationToken)
        {
            SchoolClassLesson? schoolClassLesson = await _schoolClassLessonRepository.GetAsync(predicate: scl => scl.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolClassLessonBusinessRules.SchoolClassLessonShouldExistWhenSelected(schoolClassLesson);

            GetByIdSchoolClassLessonResponse response = _mapper.Map<GetByIdSchoolClassLessonResponse>(schoolClassLesson);
            return response;
        }
    }
}