using Application.Features.SchoolLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolLessons.Queries.GetById;

public class GetByIdSchoolLessonQuery : IRequest<GetByIdSchoolLessonResponse>
{
    public int Id { get; set; }

    public class GetByIdSchoolLessonQueryHandler : IRequestHandler<GetByIdSchoolLessonQuery, GetByIdSchoolLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolLessonRepository _schoolLessonRepository;
        private readonly SchoolLessonBusinessRules _schoolLessonBusinessRules;

        public GetByIdSchoolLessonQueryHandler(IMapper mapper, ISchoolLessonRepository schoolLessonRepository, SchoolLessonBusinessRules schoolLessonBusinessRules)
        {
            _mapper = mapper;
            _schoolLessonRepository = schoolLessonRepository;
            _schoolLessonBusinessRules = schoolLessonBusinessRules;
        }

        public async Task<GetByIdSchoolLessonResponse> Handle(GetByIdSchoolLessonQuery request, CancellationToken cancellationToken)
        {
            SchoolLesson? schoolLesson = await _schoolLessonRepository.GetAsync(predicate: sl => sl.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolLessonBusinessRules.SchoolLessonShouldExistWhenSelected(schoolLesson);

            GetByIdSchoolLessonResponse response = _mapper.Map<GetByIdSchoolLessonResponse>(schoolLesson);
            return response;
        }
    }
}