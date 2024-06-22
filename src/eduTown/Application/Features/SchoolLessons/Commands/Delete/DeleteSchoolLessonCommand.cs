using Application.Features.SchoolLessons.Constants;
using Application.Features.SchoolLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolLessons.Commands.Delete;

public class DeleteSchoolLessonCommand : IRequest<DeletedSchoolLessonResponse>
{
    public int Id { get; set; }

    public class DeleteSchoolLessonCommandHandler : IRequestHandler<DeleteSchoolLessonCommand, DeletedSchoolLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolLessonRepository _schoolLessonRepository;
        private readonly SchoolLessonBusinessRules _schoolLessonBusinessRules;

        public DeleteSchoolLessonCommandHandler(IMapper mapper, ISchoolLessonRepository schoolLessonRepository,
                                         SchoolLessonBusinessRules schoolLessonBusinessRules)
        {
            _mapper = mapper;
            _schoolLessonRepository = schoolLessonRepository;
            _schoolLessonBusinessRules = schoolLessonBusinessRules;
        }

        public async Task<DeletedSchoolLessonResponse> Handle(DeleteSchoolLessonCommand request, CancellationToken cancellationToken)
        {
            SchoolLesson? schoolLesson = await _schoolLessonRepository.GetAsync(predicate: sl => sl.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolLessonBusinessRules.SchoolLessonShouldExistWhenSelected(schoolLesson);

            await _schoolLessonRepository.DeleteAsync(schoolLesson!);

            DeletedSchoolLessonResponse response = _mapper.Map<DeletedSchoolLessonResponse>(schoolLesson);
            return response;
        }
    }
}