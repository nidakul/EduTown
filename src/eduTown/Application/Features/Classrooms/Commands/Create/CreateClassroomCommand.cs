using Application.Features.Classrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Classrooms.Commands.Create;

public class CreateClassroomCommand : IRequest<CreatedClassroomResponse>
{
    public required int SchoolLessonId { get; set; }
    public required string Name { get; set; }

    public class CreateClassroomCommandHandler : IRequestHandler<CreateClassroomCommand, CreatedClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassroomRepository _classroomRepository;
        private readonly ClassroomBusinessRules _classroomBusinessRules;

        public CreateClassroomCommandHandler(IMapper mapper, IClassroomRepository classroomRepository,
                                         ClassroomBusinessRules classroomBusinessRules)
        {
            _mapper = mapper;
            _classroomRepository = classroomRepository;
            _classroomBusinessRules = classroomBusinessRules;
        }

        public async Task<CreatedClassroomResponse> Handle(CreateClassroomCommand request, CancellationToken cancellationToken)
        {
            Classroom classroom = _mapper.Map<Classroom>(request);

            await _classroomRepository.AddAsync(classroom);

            CreatedClassroomResponse response = _mapper.Map<CreatedClassroomResponse>(classroom);
            return response;
        }
    }
}