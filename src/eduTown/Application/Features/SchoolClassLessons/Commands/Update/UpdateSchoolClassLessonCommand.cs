using Application.Features.SchoolClassLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolClassLessons.Commands.Update;

public class UpdateSchoolClassLessonCommand : IRequest<UpdatedSchoolClassLessonResponse>
{
    public int Id { get; set; }
    public required int SchoolClassId { get; set; }
    public required int LessonId { get; set; }

    public class UpdateSchoolClassLessonCommandHandler : IRequestHandler<UpdateSchoolClassLessonCommand, UpdatedSchoolClassLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClassLessonRepository _schoolClassLessonRepository;
        private readonly SchoolClassLessonBusinessRules _schoolClassLessonBusinessRules;

        public UpdateSchoolClassLessonCommandHandler(IMapper mapper, ISchoolClassLessonRepository schoolClassLessonRepository,
                                         SchoolClassLessonBusinessRules schoolClassLessonBusinessRules)
        {
            _mapper = mapper;
            _schoolClassLessonRepository = schoolClassLessonRepository;
            _schoolClassLessonBusinessRules = schoolClassLessonBusinessRules;
        }

        public async Task<UpdatedSchoolClassLessonResponse> Handle(UpdateSchoolClassLessonCommand request, CancellationToken cancellationToken)
        {
            SchoolClassLesson? schoolClassLesson = await _schoolClassLessonRepository.GetAsync(predicate: scl => scl.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolClassLessonBusinessRules.SchoolClassLessonShouldExistWhenSelected(schoolClassLesson);
            schoolClassLesson = _mapper.Map(request, schoolClassLesson);

            await _schoolClassLessonRepository.UpdateAsync(schoolClassLesson!);

            UpdatedSchoolClassLessonResponse response = _mapper.Map<UpdatedSchoolClassLessonResponse>(schoolClassLesson);
            return response;
        }
    }
}