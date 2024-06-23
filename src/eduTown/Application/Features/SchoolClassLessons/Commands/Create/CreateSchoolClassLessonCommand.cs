using Application.Features.SchoolClassLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolClassLessons.Commands.Create;

public class CreateSchoolClassLessonCommand : IRequest<CreatedSchoolClassLessonResponse>
{
    public required int SchoolClassId { get; set; }
    public required int LessonId { get; set; }

    public class CreateSchoolClassLessonCommandHandler : IRequestHandler<CreateSchoolClassLessonCommand, CreatedSchoolClassLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClassLessonRepository _schoolClassLessonRepository;
        private readonly SchoolClassLessonBusinessRules _schoolClassLessonBusinessRules;

        public CreateSchoolClassLessonCommandHandler(IMapper mapper, ISchoolClassLessonRepository schoolClassLessonRepository,
                                         SchoolClassLessonBusinessRules schoolClassLessonBusinessRules)
        {
            _mapper = mapper;
            _schoolClassLessonRepository = schoolClassLessonRepository;
            _schoolClassLessonBusinessRules = schoolClassLessonBusinessRules;
        }

        public async Task<CreatedSchoolClassLessonResponse> Handle(CreateSchoolClassLessonCommand request, CancellationToken cancellationToken)
        {
            SchoolClassLesson schoolClassLesson = _mapper.Map<SchoolClassLesson>(request);

            await _schoolClassLessonRepository.AddAsync(schoolClassLesson);

            CreatedSchoolClassLessonResponse response = _mapper.Map<CreatedSchoolClassLessonResponse>(schoolClassLesson);
            return response;
        }
    }
}