using Application.Features.SchoolTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolTypes.Commands.Update;

public class UpdateSchoolTypeCommand : IRequest<UpdatedSchoolTypeResponse>
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public class UpdateSchoolTypeCommandHandler : IRequestHandler<UpdateSchoolTypeCommand, UpdatedSchoolTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolTypeRepository _schoolTypeRepository;
        private readonly SchoolTypeBusinessRules _schoolTypeBusinessRules;

        public UpdateSchoolTypeCommandHandler(IMapper mapper, ISchoolTypeRepository schoolTypeRepository,
                                         SchoolTypeBusinessRules schoolTypeBusinessRules)
        {
            _mapper = mapper;
            _schoolTypeRepository = schoolTypeRepository;
            _schoolTypeBusinessRules = schoolTypeBusinessRules;
        }

        public async Task<UpdatedSchoolTypeResponse> Handle(UpdateSchoolTypeCommand request, CancellationToken cancellationToken)
        {
            SchoolType? schoolType = await _schoolTypeRepository.GetAsync(predicate: st => st.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolTypeBusinessRules.SchoolTypeShouldExistWhenSelected(schoolType);
            schoolType = _mapper.Map(request, schoolType);

            await _schoolTypeRepository.UpdateAsync(schoolType!);

            UpdatedSchoolTypeResponse response = _mapper.Map<UpdatedSchoolTypeResponse>(schoolType);
            return response;
        }
    }
}