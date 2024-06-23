using Application.Features.SchoolClasses.Constants;
using Application.Features.SchoolClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolClasses.Commands.Delete;

public class DeleteSchoolClassCommand : IRequest<DeletedSchoolClassResponse>
{
    public int Id { get; set; }

    public class DeleteSchoolClassCommandHandler : IRequestHandler<DeleteSchoolClassCommand, DeletedSchoolClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClassRepository _schoolClassRepository;
        private readonly SchoolClassBusinessRules _schoolClassBusinessRules;

        public DeleteSchoolClassCommandHandler(IMapper mapper, ISchoolClassRepository schoolClassRepository,
                                         SchoolClassBusinessRules schoolClassBusinessRules)
        {
            _mapper = mapper;
            _schoolClassRepository = schoolClassRepository;
            _schoolClassBusinessRules = schoolClassBusinessRules;
        }

        public async Task<DeletedSchoolClassResponse> Handle(DeleteSchoolClassCommand request, CancellationToken cancellationToken)
        {
            SchoolClass? schoolClass = await _schoolClassRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolClassBusinessRules.SchoolClassShouldExistWhenSelected(schoolClass);

            await _schoolClassRepository.DeleteAsync(schoolClass!);

            DeletedSchoolClassResponse response = _mapper.Map<DeletedSchoolClassResponse>(schoolClass);
            return response;
        }
    }
}