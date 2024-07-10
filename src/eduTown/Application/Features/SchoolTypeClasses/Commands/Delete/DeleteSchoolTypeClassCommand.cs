using Application.Features.SchoolTypeClasses.Constants;
using Application.Features.SchoolTypeClasses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolTypeClasses.Commands.Delete;

public class DeleteSchoolTypeClassCommand : IRequest<DeletedSchoolTypeClassResponse>
{
    public int Id { get; set; }

    public class DeleteSchoolTypeClassCommandHandler : IRequestHandler<DeleteSchoolTypeClassCommand, DeletedSchoolTypeClassResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolTypeClassRepository _schoolTypeClassRepository;
        private readonly SchoolTypeClassBusinessRules _schoolTypeClassBusinessRules;

        public DeleteSchoolTypeClassCommandHandler(IMapper mapper, ISchoolTypeClassRepository schoolTypeClassRepository,
                                         SchoolTypeClassBusinessRules schoolTypeClassBusinessRules)
        {
            _mapper = mapper;
            _schoolTypeClassRepository = schoolTypeClassRepository;
            _schoolTypeClassBusinessRules = schoolTypeClassBusinessRules;
        }

        public async Task<DeletedSchoolTypeClassResponse> Handle(DeleteSchoolTypeClassCommand request, CancellationToken cancellationToken)
        {
            SchoolTypeClass? schoolTypeClass = await _schoolTypeClassRepository.GetAsync(predicate: stc => stc.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolTypeClassBusinessRules.SchoolTypeClassShouldExistWhenSelected(schoolTypeClass);

            await _schoolTypeClassRepository.DeleteAsync(schoolTypeClass!);

            DeletedSchoolTypeClassResponse response = _mapper.Map<DeletedSchoolTypeClassResponse>(schoolTypeClass);
            return response;
        }
    }
}