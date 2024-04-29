using Application.Features.StudentGradeLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentGradeLessons.Queries.GetById;

public class GetByIdStudentGradeLessonQuery : IRequest<GetByIdStudentGradeLessonResponse>
{
    public int Id { get; set; }

    public class GetByIdStudentGradeLessonQueryHandler : IRequestHandler<GetByIdStudentGradeLessonQuery, GetByIdStudentGradeLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentGradeLessonRepository _studentGradeLessonRepository;
        private readonly StudentGradeLessonBusinessRules _studentGradeLessonBusinessRules;

        public GetByIdStudentGradeLessonQueryHandler(IMapper mapper, IStudentGradeLessonRepository studentGradeLessonRepository, StudentGradeLessonBusinessRules studentGradeLessonBusinessRules)
        {
            _mapper = mapper;
            _studentGradeLessonRepository = studentGradeLessonRepository;
            _studentGradeLessonBusinessRules = studentGradeLessonBusinessRules;
        }

        public async Task<GetByIdStudentGradeLessonResponse> Handle(GetByIdStudentGradeLessonQuery request, CancellationToken cancellationToken)
        {
            StudentGradeLesson? studentGradeLesson = await _studentGradeLessonRepository.GetAsync(predicate: sgl => sgl.Id == request.Id, cancellationToken: cancellationToken);
            await _studentGradeLessonBusinessRules.StudentGradeLessonShouldExistWhenSelected(studentGradeLesson);

            GetByIdStudentGradeLessonResponse response = _mapper.Map<GetByIdStudentGradeLessonResponse>(studentGradeLesson);
            return response;
        }
    }
}