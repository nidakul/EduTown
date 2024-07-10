using Application.Features.SchoolTypeClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolTypeClasses.Commands.Update;

public class UpdateSchoolTypeClassCommand : IRequest<UpdatedSchoolTypeClassResponse>
{
    public int Id { get; set; }
    public required int SchoolTypeId { get; set; }
    public required int ClassroomId { get; set; }

    public class UpdateSchoolTypeClassCommandHandler : IRequestHandler<UpdateSchoolTypeClassCommand, UpdatedSchoolTypeClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolTypeClassRepository _schoolTypeClassRepository;
        private readonly SchoolTypeClassBusinessRules _schoolTypeClassBusinessRules;

        public UpdateSchoolTypeClassCommandHandler(IMapper mapper, ISchoolTypeClassRepository schoolTypeClassRepository,
                                         SchoolTypeClassBusinessRules schoolTypeClassBusinessRules)
        {
            _mapper = mapper;
            _schoolTypeClassRepository = schoolTypeClassRepository;
            _schoolTypeClassBusinessRules = schoolTypeClassBusinessRules;
        }

        public async Task<UpdatedSchoolTypeClassResponse> Handle(UpdateSchoolTypeClassCommand request, CancellationToken cancellationToken)
        {
            SchoolTypeClass? schoolTypeClass = await _schoolTypeClassRepository.GetAsync(predicate: stc => stc.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolTypeClassBusinessRules.SchoolTypeClassShouldExistWhenSelected(schoolTypeClass);
            schoolTypeClass = _mapper.Map(request, schoolTypeClass);

            await _schoolTypeClassRepository.UpdateAsync(schoolTypeClass!);

            UpdatedSchoolTypeClassResponse response = _mapper.Map<UpdatedSchoolTypeClassResponse>(schoolTypeClass);
            return response;
        }
    }
}