using Application.Features.LessonClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonClassrooms.Commands.Create;

public class CreateLessonClassroomCommand : IRequest<CreatedLessonClassroomResponse>
{
    public required int LessonId { get; set; }
    public required int ClassroomId { get; set; }

    public class CreateLessonClassroomCommandHandler : IRequestHandler<CreateLessonClassroomCommand, CreatedLessonClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonClassroomRepository _lessonClassroomRepository;
        private readonly LessonClassroomBusinessRules _lessonClassroomBusinessRules;

        public CreateLessonClassroomCommandHandler(IMapper mapper, ILessonClassroomRepository lessonClassroomRepository,
                                         LessonClassroomBusinessRules lessonClassroomBusinessRules)
        {
            _mapper = mapper;
            _lessonClassroomRepository = lessonClassroomRepository;
            _lessonClassroomBusinessRules = lessonClassroomBusinessRules;
        }

        public async Task<CreatedLessonClassroomResponse> Handle(CreateLessonClassroomCommand request, CancellationToken cancellationToken)
        {
            LessonClassroom lessonClassroom = _mapper.Map<LessonClassroom>(request);

            await _lessonClassroomRepository.AddAsync(lessonClassroom);

            CreatedLessonClassroomResponse response = _mapper.Map<CreatedLessonClassroomResponse>(lessonClassroom);
            return response;
        }
    }
}