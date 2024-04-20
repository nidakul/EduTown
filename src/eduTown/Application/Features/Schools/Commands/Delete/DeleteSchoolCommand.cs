using Application.Features.Schools.Constants;
using Application.Features.Schools.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Schools.Commands.Delete;

public class DeleteSchoolCommand : IRequest<DeletedSchoolResponse>
{
    public int Id { get; set; }

    public class DeleteSchoolCommandHandler : IRequestHandler<DeleteSchoolCommand, DeletedSchoolResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolRepository _schoolRepository;
        private readonly SchoolBusinessRules _schoolBusinessRules;

        public DeleteSchoolCommandHandler(IMapper mapper, ISchoolRepository schoolRepository,
                                         SchoolBusinessRules schoolBusinessRules)
        {
            _mapper = mapper;
            _schoolRepository = schoolRepository;
            _schoolBusinessRules = schoolBusinessRules;
        }

        public async Task<DeletedSchoolResponse> Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
        {
            School? school = await _schoolRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolBusinessRules.SchoolShouldExistWhenSelected(school);

            await _schoolRepository.DeleteAsync(school!);

            DeletedSchoolResponse response = _mapper.Map<DeletedSchoolResponse>(school);
            return response;
        }
    }
}