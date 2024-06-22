using Application.Features.SchoolLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolLessons.Commands.Update;

public class UpdateSchoolLessonCommand : IRequest<UpdatedSchoolLessonResponse>
{
    public int Id { get; set; }
    public required int SchoolId { get; set; }
    public required int LessonId { get; set; }

    public class UpdateSchoolLessonCommandHandler : IRequestHandler<UpdateSchoolLessonCommand, UpdatedSchoolLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolLessonRepository _schoolLessonRepository;
        private readonly SchoolLessonBusinessRules _schoolLessonBusinessRules;

        public UpdateSchoolLessonCommandHandler(IMapper mapper, ISchoolLessonRepository schoolLessonRepository,
                                         SchoolLessonBusinessRules schoolLessonBusinessRules)
        {
            _mapper = mapper;
            _schoolLessonRepository = schoolLessonRepository;
            _schoolLessonBusinessRules = schoolLessonBusinessRules;
        }

        public async Task<UpdatedSchoolLessonResponse> Handle(UpdateSchoolLessonCommand request, CancellationToken cancellationToken)
        {
            SchoolLesson? schoolLesson = await _schoolLessonRepository.GetAsync(predicate: sl => sl.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolLessonBusinessRules.SchoolLessonShouldExistWhenSelected(schoolLesson);
            schoolLesson = _mapper.Map(request, schoolLesson);

            await _schoolLessonRepository.UpdateAsync(schoolLesson!);

            UpdatedSchoolLessonResponse response = _mapper.Map<UpdatedSchoolLessonResponse>(schoolLesson);
            return response;
        }
    }
}