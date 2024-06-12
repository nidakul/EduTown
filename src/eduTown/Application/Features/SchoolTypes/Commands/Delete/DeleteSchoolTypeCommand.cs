using Application.Features.SchoolTypes.Constants;
using Application.Features.SchoolTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolTypes.Commands.Delete;

public class DeleteSchoolTypeCommand : IRequest<DeletedSchoolTypeResponse>
{
    public int Id { get; set; }

    public class DeleteSchoolTypeCommandHandler : IRequestHandler<DeleteSchoolTypeCommand, DeletedSchoolTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolTypeRepository _schoolTypeRepository;
        private readonly SchoolTypeBusinessRules _schoolTypeBusinessRules;

        public DeleteSchoolTypeCommandHandler(IMapper mapper, ISchoolTypeRepository schoolTypeRepository,
                                         SchoolTypeBusinessRules schoolTypeBusinessRules)
        {
            _mapper = mapper;
            _schoolTypeRepository = schoolTypeRepository;
            _schoolTypeBusinessRules = schoolTypeBusinessRules;
        }

        public async Task<DeletedSchoolTypeResponse> Handle(DeleteSchoolTypeCommand request, CancellationToken cancellationToken)
        {
            SchoolType? schoolType = await _schoolTypeRepository.GetAsync(predicate: st => st.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolTypeBusinessRules.SchoolTypeShouldExistWhenSelected(schoolType);

            await _schoolTypeRepository.DeleteAsync(schoolType!);

            DeletedSchoolTypeResponse response = _mapper.Map<DeletedSchoolTypeResponse>(schoolType);
            return response;
        }
    }
}