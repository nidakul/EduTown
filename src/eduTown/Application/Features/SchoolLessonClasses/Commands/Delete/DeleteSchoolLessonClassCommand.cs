using Application.Features.SchoolLessonClasses.Constants;
using Application.Features.SchoolLessonClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolLessonClasses.Commands.Delete;

public class DeleteSchoolLessonClassCommand : IRequest<DeletedSchoolLessonClassResponse>
{
    public int Id { get; set; }

    public class DeleteSchoolLessonClassCommandHandler : IRequestHandler<DeleteSchoolLessonClassCommand, DeletedSchoolLessonClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolLessonClassRepository _schoolLessonClassRepository;
        private readonly SchoolLessonClassBusinessRules _schoolLessonClassBusinessRules;

        public DeleteSchoolLessonClassCommandHandler(IMapper mapper, ISchoolLessonClassRepository schoolLessonClassRepository,
                                         SchoolLessonClassBusinessRules schoolLessonClassBusinessRules)
        {
            _mapper = mapper;
            _schoolLessonClassRepository = schoolLessonClassRepository;
            _schoolLessonClassBusinessRules = schoolLessonClassBusinessRules;
        }

        public async Task<DeletedSchoolLessonClassResponse> Handle(DeleteSchoolLessonClassCommand request, CancellationToken cancellationToken)
        {
            SchoolLessonClass? schoolLessonClass = await _schoolLessonClassRepository.GetAsync(predicate: slc => slc.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolLessonClassBusinessRules.SchoolLessonClassShouldExistWhenSelected(schoolLessonClass);

            await _schoolLessonClassRepository.DeleteAsync(schoolLessonClass!);

            DeletedSchoolLessonClassResponse response = _mapper.Map<DeletedSchoolLessonClassResponse>(schoolLessonClass);
            return response;
        }
    }
}