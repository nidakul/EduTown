using Application.Features.SchoolTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolTypes.Commands.Create;

public class CreateSchoolTypeCommand : IRequest<CreatedSchoolTypeResponse>
{
    public required string Name { get; set; }

    public class CreateSchoolTypeCommandHandler : IRequestHandler<CreateSchoolTypeCommand, CreatedSchoolTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolTypeRepository _schoolTypeRepository;
        private readonly SchoolTypeBusinessRules _schoolTypeBusinessRules;

        public CreateSchoolTypeCommandHandler(IMapper mapper, ISchoolTypeRepository schoolTypeRepository,
                                         SchoolTypeBusinessRules schoolTypeBusinessRules)
        {
            _mapper = mapper;
            _schoolTypeRepository = schoolTypeRepository;
            _schoolTypeBusinessRules = schoolTypeBusinessRules;
        }

        public async Task<CreatedSchoolTypeResponse> Handle(CreateSchoolTypeCommand request, CancellationToken cancellationToken)
        {
            SchoolType schoolType = _mapper.Map<SchoolType>(request);

            await _schoolTypeRepository.AddAsync(schoolType);

            CreatedSchoolTypeResponse response = _mapper.Map<CreatedSchoolTypeResponse>(schoolType);
            return response;
        }
    }
}