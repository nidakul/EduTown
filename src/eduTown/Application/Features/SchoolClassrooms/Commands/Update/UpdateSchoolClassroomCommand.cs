using Application.Features.SchoolClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolClassrooms.Commands.Update;

public class UpdateSchoolClassroomCommand : IRequest<UpdatedSchoolClassroomResponse>
{
    public int Id { get; set; }
    public required int SchoolId { get; set; }
    public required int ClassroomId { get; set; }

    public class UpdateSchoolClassroomCommandHandler : IRequestHandler<UpdateSchoolClassroomCommand, UpdatedSchoolClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClassroomRepository _schoolClassroomRepository;
        private readonly SchoolClassroomBusinessRules _schoolClassroomBusinessRules;

        public UpdateSchoolClassroomCommandHandler(IMapper mapper, ISchoolClassroomRepository schoolClassroomRepository,
                                         SchoolClassroomBusinessRules schoolClassroomBusinessRules)
        {
            _mapper = mapper;
            _schoolClassroomRepository = schoolClassroomRepository;
            _schoolClassroomBusinessRules = schoolClassroomBusinessRules;
        }

        public async Task<UpdatedSchoolClassroomResponse> Handle(UpdateSchoolClassroomCommand request, CancellationToken cancellationToken)
        {
            SchoolClassroom? schoolClassroom = await _schoolClassroomRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolClassroomBusinessRules.SchoolClassroomShouldExistWhenSelected(schoolClassroom);
            schoolClassroom = _mapper.Map(request, schoolClassroom);

            await _schoolClassroomRepository.UpdateAsync(schoolClassroom!);

            UpdatedSchoolClassroomResponse response = _mapper.Map<UpdatedSchoolClassroomResponse>(schoolClassroom);
            return response;
        }
    }
}