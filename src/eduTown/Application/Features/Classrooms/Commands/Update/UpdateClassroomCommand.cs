using Application.Features.Classrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Classrooms.Commands.Update;

public class UpdateClassroomCommand : IRequest<UpdatedClassroomResponse>
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public class UpdateClassroomCommandHandler : IRequestHandler<UpdateClassroomCommand, UpdatedClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassroomRepository _classroomRepository;
        private readonly ClassroomBusinessRules _classroomBusinessRules;

        public UpdateClassroomCommandHandler(IMapper mapper, IClassroomRepository classroomRepository,
                                         ClassroomBusinessRules classroomBusinessRules)
        {
            _mapper = mapper;
            _classroomRepository = classroomRepository;
            _classroomBusinessRules = classroomBusinessRules;
        }

        public async Task<UpdatedClassroomResponse> Handle(UpdateClassroomCommand request, CancellationToken cancellationToken)
        {
            Classroom? classroom = await _classroomRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _classroomBusinessRules.ClassroomShouldExistWhenSelected(classroom);
            classroom = _mapper.Map(request, classroom);

            await _classroomRepository.UpdateAsync(classroom!);

            UpdatedClassroomResponse response = _mapper.Map<UpdatedClassroomResponse>(classroom);
            return response;
        }
    }
}