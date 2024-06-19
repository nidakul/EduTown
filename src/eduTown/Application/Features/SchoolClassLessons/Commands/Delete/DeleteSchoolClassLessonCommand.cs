using Application.Features.SchoolClassLessons.Constants;
using Application.Features.SchoolClassLessons.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolClassLessons.Commands.Delete;

public class DeleteSchoolClassLessonCommand : IRequest<DeletedSchoolClassLessonResponse>
{
    public int Id { get; set; }

    public class DeleteSchoolClassLessonCommandHandler : IRequestHandler<DeleteSchoolClassLessonCommand, DeletedSchoolClassLessonResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClassLessonRepository _schoolClassLessonRepository;
        private readonly SchoolClassLessonBusinessRules _schoolClassLessonBusinessRules;

        public DeleteSchoolClassLessonCommandHandler(IMapper mapper, ISchoolClassLessonRepository schoolClassLessonRepository,
                                         SchoolClassLessonBusinessRules schoolClassLessonBusinessRules)
        {
            _mapper = mapper;
            _schoolClassLessonRepository = schoolClassLessonRepository;
            _schoolClassLessonBusinessRules = schoolClassLessonBusinessRules;
        }

        public async Task<DeletedSchoolClassLessonResponse> Handle(DeleteSchoolClassLessonCommand request, CancellationToken cancellationToken)
        {
            SchoolClassLesson? schoolClassLesson = await _schoolClassLessonRepository.GetAsync(predicate: scl => scl.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolClassLessonBusinessRules.SchoolClassLessonShouldExistWhenSelected(schoolClassLesson);

            await _schoolClassLessonRepository.DeleteAsync(schoolClassLesson!);

            DeletedSchoolClassLessonResponse response = _mapper.Map<DeletedSchoolClassLessonResponse>(schoolClassLesson);
            return response;
        }
    }
}