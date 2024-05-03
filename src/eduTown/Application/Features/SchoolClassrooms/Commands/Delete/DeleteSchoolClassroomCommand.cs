using Application.Features.SchoolClassrooms.Constants;
using Application.Features.SchoolClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolClassrooms.Commands.Delete;

public class DeleteSchoolClassroomCommand : IRequest<DeletedSchoolClassroomResponse>
{
    public int Id { get; set; }

    public class DeleteSchoolClassroomCommandHandler : IRequestHandler<DeleteSchoolClassroomCommand, DeletedSchoolClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClassroomRepository _schoolClassroomRepository;
        private readonly SchoolClassroomBusinessRules _schoolClassroomBusinessRules;

        public DeleteSchoolClassroomCommandHandler(IMapper mapper, ISchoolClassroomRepository schoolClassroomRepository,
                                         SchoolClassroomBusinessRules schoolClassroomBusinessRules)
        {
            _mapper = mapper;
            _schoolClassroomRepository = schoolClassroomRepository;
            _schoolClassroomBusinessRules = schoolClassroomBusinessRules;
        }

        public async Task<DeletedSchoolClassroomResponse> Handle(DeleteSchoolClassroomCommand request, CancellationToken cancellationToken)
        {
            SchoolClassroom? schoolClassroom = await _schoolClassroomRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolClassroomBusinessRules.SchoolClassroomShouldExistWhenSelected(schoolClassroom);

            await _schoolClassroomRepository.DeleteAsync(schoolClassroom!);

            DeletedSchoolClassroomResponse response = _mapper.Map<DeletedSchoolClassroomResponse>(schoolClassroom);
            return response;
        }
    }
}