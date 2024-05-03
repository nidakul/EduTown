using Application.Features.SchoolClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolClassrooms.Commands.Create;

public class CreateSchoolClassroomCommand : IRequest<CreatedSchoolClassroomResponse>
{
    public required int SchoolId { get; set; }
    public required int ClassroomId { get; set; }

    public class CreateSchoolClassroomCommandHandler : IRequestHandler<CreateSchoolClassroomCommand, CreatedSchoolClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClassroomRepository _schoolClassroomRepository;
        private readonly SchoolClassroomBusinessRules _schoolClassroomBusinessRules;

        public CreateSchoolClassroomCommandHandler(IMapper mapper, ISchoolClassroomRepository schoolClassroomRepository,
                                         SchoolClassroomBusinessRules schoolClassroomBusinessRules)
        {
            _mapper = mapper;
            _schoolClassroomRepository = schoolClassroomRepository;
            _schoolClassroomBusinessRules = schoolClassroomBusinessRules;
        }

        public async Task<CreatedSchoolClassroomResponse> Handle(CreateSchoolClassroomCommand request, CancellationToken cancellationToken)
        {
            SchoolClassroom schoolClassroom = _mapper.Map<SchoolClassroom>(request);

            await _schoolClassroomRepository.AddAsync(schoolClassroom);

            CreatedSchoolClassroomResponse response = _mapper.Map<CreatedSchoolClassroomResponse>(schoolClassroom);
            return response;
        }
    }
}