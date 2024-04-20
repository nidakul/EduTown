using Application.Features.Classrooms.Constants;
using Application.Features.Classrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Classrooms.Commands.Delete;

public class DeleteClassroomCommand : IRequest<DeletedClassroomResponse>
{
    public int Id { get; set; }

    public class DeleteClassroomCommandHandler : IRequestHandler<DeleteClassroomCommand, DeletedClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IClassroomRepository _classroomRepository;
        private readonly ClassroomBusinessRules _classroomBusinessRules;

        public DeleteClassroomCommandHandler(IMapper mapper, IClassroomRepository classroomRepository,
                                         ClassroomBusinessRules classroomBusinessRules)
        {
            _mapper = mapper;
            _classroomRepository = classroomRepository;
            _classroomBusinessRules = classroomBusinessRules;
        }

        public async Task<DeletedClassroomResponse> Handle(DeleteClassroomCommand request, CancellationToken cancellationToken)
        {
            Classroom? classroom = await _classroomRepository.GetAsync(predicate: c => c.Id == request.Id, cancellationToken: cancellationToken);
            await _classroomBusinessRules.ClassroomShouldExistWhenSelected(classroom);

            await _classroomRepository.DeleteAsync(classroom!);

            DeletedClassroomResponse response = _mapper.Map<DeletedClassroomResponse>(classroom);
            return response;
        }
    }
}