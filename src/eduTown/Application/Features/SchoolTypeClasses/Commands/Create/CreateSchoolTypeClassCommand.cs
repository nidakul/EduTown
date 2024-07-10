using Application.Features.SchoolTypeClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolTypeClasses.Commands.Create;

public class CreateSchoolTypeClassCommand : IRequest<CreatedSchoolTypeClassResponse>
{
    public required int SchoolTypeId { get; set; }
    public required int ClassroomId { get; set; }

    public class CreateSchoolTypeClassCommandHandler : IRequestHandler<CreateSchoolTypeClassCommand, CreatedSchoolTypeClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolTypeClassRepository _schoolTypeClassRepository;
        private readonly SchoolTypeClassBusinessRules _schoolTypeClassBusinessRules;

        public CreateSchoolTypeClassCommandHandler(IMapper mapper, ISchoolTypeClassRepository schoolTypeClassRepository,
                                         SchoolTypeClassBusinessRules schoolTypeClassBusinessRules)
        {
            _mapper = mapper;
            _schoolTypeClassRepository = schoolTypeClassRepository;
            _schoolTypeClassBusinessRules = schoolTypeClassBusinessRules;
        }

        public async Task<CreatedSchoolTypeClassResponse> Handle(CreateSchoolTypeClassCommand request, CancellationToken cancellationToken)
        {
            SchoolTypeClass schoolTypeClass = _mapper.Map<SchoolTypeClass>(request);

            await _schoolTypeClassRepository.AddAsync(schoolTypeClass);

            CreatedSchoolTypeClassResponse response = _mapper.Map<CreatedSchoolTypeClassResponse>(schoolTypeClass);
            return response;
        }
    }
}