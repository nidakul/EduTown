using Application.Features.SchoolClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolClasses.Commands.Update;

public class UpdateSchoolClassCommand : IRequest<UpdatedSchoolClassResponse>
{
    public int Id { get; set; }
    public required int SchoolId { get; set; }
    public required int ClassroomId { get; set; }

    public class UpdateSchoolClassCommandHandler : IRequestHandler<UpdateSchoolClassCommand, UpdatedSchoolClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClassRepository _schoolClassRepository;
        private readonly SchoolClassBusinessRules _schoolClassBusinessRules;

        public UpdateSchoolClassCommandHandler(IMapper mapper, ISchoolClassRepository schoolClassRepository,
                                         SchoolClassBusinessRules schoolClassBusinessRules)
        {
            _mapper = mapper;
            _schoolClassRepository = schoolClassRepository;
            _schoolClassBusinessRules = schoolClassBusinessRules;
        }

        public async Task<UpdatedSchoolClassResponse> Handle(UpdateSchoolClassCommand request, CancellationToken cancellationToken)
        {
            SchoolClass? schoolClass = await _schoolClassRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolClassBusinessRules.SchoolClassShouldExistWhenSelected(schoolClass);
            schoolClass = _mapper.Map(request, schoolClass);

            await _schoolClassRepository.UpdateAsync(schoolClass!);

            UpdatedSchoolClassResponse response = _mapper.Map<UpdatedSchoolClassResponse>(schoolClass);
            return response;
        }
    }
}