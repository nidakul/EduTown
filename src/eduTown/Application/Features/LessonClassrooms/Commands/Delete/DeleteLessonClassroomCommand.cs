using Application.Features.LessonClassrooms.Constants;
using Application.Features.LessonClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonClassrooms.Commands.Delete;

public class DeleteLessonClassroomCommand : IRequest<DeletedLessonClassroomResponse>
{
    public int Id { get; set; }

    public class DeleteLessonClassroomCommandHandler : IRequestHandler<DeleteLessonClassroomCommand, DeletedLessonClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonClassroomRepository _lessonClassroomRepository;
        private readonly LessonClassroomBusinessRules _lessonClassroomBusinessRules;

        public DeleteLessonClassroomCommandHandler(IMapper mapper, ILessonClassroomRepository lessonClassroomRepository,
                                         LessonClassroomBusinessRules lessonClassroomBusinessRules)
        {
            _mapper = mapper;
            _lessonClassroomRepository = lessonClassroomRepository;
            _lessonClassroomBusinessRules = lessonClassroomBusinessRules;
        }

        public async Task<DeletedLessonClassroomResponse> Handle(DeleteLessonClassroomCommand request, CancellationToken cancellationToken)
        {
            LessonClassroom? lessonClassroom = await _lessonClassroomRepository.GetAsync(predicate: lc => lc.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonClassroomBusinessRules.LessonClassroomShouldExistWhenSelected(lessonClassroom);

            await _lessonClassroomRepository.DeleteAsync(lessonClassroom!);

            DeletedLessonClassroomResponse response = _mapper.Map<DeletedLessonClassroomResponse>(lessonClassroom);
            return response;
        }
    }
}