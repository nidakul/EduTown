using Application.Features.LessonClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonClassrooms.Commands.Update;

public class UpdateLessonClassroomCommand : IRequest<UpdatedLessonClassroomResponse>
{
    public int Id { get; set; }
    public required int LessonId { get; set; }
    public required int ClassroomId { get; set; }

    public class UpdateLessonClassroomCommandHandler : IRequestHandler<UpdateLessonClassroomCommand, UpdatedLessonClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonClassroomRepository _lessonClassroomRepository;
        private readonly LessonClassroomBusinessRules _lessonClassroomBusinessRules;

        public UpdateLessonClassroomCommandHandler(IMapper mapper, ILessonClassroomRepository lessonClassroomRepository,
                                         LessonClassroomBusinessRules lessonClassroomBusinessRules)
        {
            _mapper = mapper;
            _lessonClassroomRepository = lessonClassroomRepository;
            _lessonClassroomBusinessRules = lessonClassroomBusinessRules;
        }

        public async Task<UpdatedLessonClassroomResponse> Handle(UpdateLessonClassroomCommand request, CancellationToken cancellationToken)
        {
            LessonClassroom? lessonClassroom = await _lessonClassroomRepository.GetAsync(predicate: lc => lc.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonClassroomBusinessRules.LessonClassroomShouldExistWhenSelected(lessonClassroom);
            lessonClassroom = _mapper.Map(request, lessonClassroom);

            await _lessonClassroomRepository.UpdateAsync(lessonClassroom!);

            UpdatedLessonClassroomResponse response = _mapper.Map<UpdatedLessonClassroomResponse>(lessonClassroom);
            return response;
        }
    }
}