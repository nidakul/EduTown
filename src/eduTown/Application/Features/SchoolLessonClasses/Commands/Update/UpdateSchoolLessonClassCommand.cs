using Application.Features.SchoolLessonClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolLessonClasses.Commands.Update;

public class UpdateSchoolLessonClassCommand : IRequest<UpdatedSchoolLessonClassResponse>
{
    public int Id { get; set; }

    public class UpdateSchoolLessonClassCommandHandler : IRequestHandler<UpdateSchoolLessonClassCommand, UpdatedSchoolLessonClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolLessonClassRepository _schoolLessonClassRepository;
        private readonly SchoolLessonClassBusinessRules _schoolLessonClassBusinessRules;

        public UpdateSchoolLessonClassCommandHandler(IMapper mapper, ISchoolLessonClassRepository schoolLessonClassRepository,
                                         SchoolLessonClassBusinessRules schoolLessonClassBusinessRules)
        {
            _mapper = mapper;
            _schoolLessonClassRepository = schoolLessonClassRepository;
            _schoolLessonClassBusinessRules = schoolLessonClassBusinessRules;
        }

        public async Task<UpdatedSchoolLessonClassResponse> Handle(UpdateSchoolLessonClassCommand request, CancellationToken cancellationToken)
        {
            SchoolLessonClass? schoolLessonClass = await _schoolLessonClassRepository.GetAsync(predicate: slc => slc.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolLessonClassBusinessRules.SchoolLessonClassShouldExistWhenSelected(schoolLessonClass);
            schoolLessonClass = _mapper.Map(request, schoolLessonClass);

            await _schoolLessonClassRepository.UpdateAsync(schoolLessonClass!);

            UpdatedSchoolLessonClassResponse response = _mapper.Map<UpdatedSchoolLessonClassResponse>(schoolLessonClass);
            return response;
        }
    }
}