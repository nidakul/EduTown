using Application.Features.SchoolClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolClasses.Commands.Create;

public class CreateSchoolClassCommand : IRequest<CreatedSchoolClassResponse>
{
    public required int SchoolId { get; set; }
    public required int ClassroomId { get; set; }

    public class CreateSchoolClassCommandHandler : IRequestHandler<CreateSchoolClassCommand, CreatedSchoolClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClassRepository _schoolClassRepository;
        private readonly SchoolClassBusinessRules _schoolClassBusinessRules;

        public CreateSchoolClassCommandHandler(IMapper mapper, ISchoolClassRepository schoolClassRepository,
                                         SchoolClassBusinessRules schoolClassBusinessRules)
        {
            _mapper = mapper;
            _schoolClassRepository = schoolClassRepository;
            _schoolClassBusinessRules = schoolClassBusinessRules;
        }

        public async Task<CreatedSchoolClassResponse> Handle(CreateSchoolClassCommand request, CancellationToken cancellationToken)
        {
            SchoolClass schoolClass = _mapper.Map<SchoolClass>(request);

            await _schoolClassRepository.AddAsync(schoolClass);

            CreatedSchoolClassResponse response = _mapper.Map<CreatedSchoolClassResponse>(schoolClass);
            return response;
        }
    }
}