using Application.Features.LessonClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.LessonClassrooms.Queries.GetById;

public class GetByIdLessonClassroomQuery : IRequest<GetByIdLessonClassroomResponse>
{
    public int Id { get; set; }

    public class GetByIdLessonClassroomQueryHandler : IRequestHandler<GetByIdLessonClassroomQuery, GetByIdLessonClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILessonClassroomRepository _lessonClassroomRepository;
        private readonly LessonClassroomBusinessRules _lessonClassroomBusinessRules;

        public GetByIdLessonClassroomQueryHandler(IMapper mapper, ILessonClassroomRepository lessonClassroomRepository, LessonClassroomBusinessRules lessonClassroomBusinessRules)
        {
            _mapper = mapper;
            _lessonClassroomRepository = lessonClassroomRepository;
            _lessonClassroomBusinessRules = lessonClassroomBusinessRules;
        }

        public async Task<GetByIdLessonClassroomResponse> Handle(GetByIdLessonClassroomQuery request, CancellationToken cancellationToken)
        {
            LessonClassroom? lessonClassroom = await _lessonClassroomRepository.GetAsync(predicate: lc => lc.Id == request.Id, cancellationToken: cancellationToken);
            await _lessonClassroomBusinessRules.LessonClassroomShouldExistWhenSelected(lessonClassroom);

            GetByIdLessonClassroomResponse response = _mapper.Map<GetByIdLessonClassroomResponse>(lessonClassroom);
            return response;
        }
    }
}