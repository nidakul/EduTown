using Application.Features.SchoolClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SchoolClassrooms.Queries.GetById;

public class GetByIdSchoolClassroomQuery : IRequest<GetByIdSchoolClassroomResponse>
{
    public int Id { get; set; }

    public class GetByIdSchoolClassroomQueryHandler : IRequestHandler<GetByIdSchoolClassroomQuery, GetByIdSchoolClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolClassroomRepository _schoolClassroomRepository;
        private readonly SchoolClassroomBusinessRules _schoolClassroomBusinessRules;

        public GetByIdSchoolClassroomQueryHandler(IMapper mapper, ISchoolClassroomRepository schoolClassroomRepository, SchoolClassroomBusinessRules schoolClassroomBusinessRules)
        {
            _mapper = mapper;
            _schoolClassroomRepository = schoolClassroomRepository;
            _schoolClassroomBusinessRules = schoolClassroomBusinessRules;
        }

        public async Task<GetByIdSchoolClassroomResponse> Handle(GetByIdSchoolClassroomQuery request, CancellationToken cancellationToken)
        {
            SchoolClassroom? schoolClassroom = await _schoolClassroomRepository.GetAsync(predicate: sc => sc.Id == request.Id, cancellationToken: cancellationToken);
            await _schoolClassroomBusinessRules.SchoolClassroomShouldExistWhenSelected(schoolClassroom);

            GetByIdSchoolClassroomResponse response = _mapper.Map<GetByIdSchoolClassroomResponse>(schoolClassroom);
            return response;
        }
    }
}