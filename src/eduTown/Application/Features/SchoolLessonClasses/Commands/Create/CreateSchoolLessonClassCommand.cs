using Application.Features.SchoolLessonClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolLessonClasses.Commands.Create;

public class CreateSchoolLessonClassCommand : IRequest<CreatedSchoolLessonClassResponse>
{

    public class CreateSchoolLessonClassCommandHandler : IRequestHandler<CreateSchoolLessonClassCommand, CreatedSchoolLessonClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolLessonClassRepository _schoolLessonClassRepository;
        private readonly SchoolLessonClassBusinessRules _schoolLessonClassBusinessRules;

        public CreateSchoolLessonClassCommandHandler(IMapper mapper, ISchoolLessonClassRepository schoolLessonClassRepository,
                                         SchoolLessonClassBusinessRules schoolLessonClassBusinessRules)
        {
            _mapper = mapper;
            _schoolLessonClassRepository = schoolLessonClassRepository;
            _schoolLessonClassBusinessRules = schoolLessonClassBusinessRules;
        }

        public async Task<CreatedSchoolLessonClassResponse> Handle(CreateSchoolLessonClassCommand request, CancellationToken cancellationToken)
        {
            SchoolLessonClass schoolLessonClass = _mapper.Map<SchoolLessonClass>(request);

            await _schoolLessonClassRepository.AddAsync(schoolLessonClass);

            CreatedSchoolLessonClassResponse response = _mapper.Map<CreatedSchoolLessonClassResponse>(schoolLessonClass);
            return response;
        }
    }
}