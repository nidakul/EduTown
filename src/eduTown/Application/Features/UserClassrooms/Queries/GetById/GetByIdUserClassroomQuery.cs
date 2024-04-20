using Application.Features.UserClassrooms.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.UserClassrooms.Queries.GetById;

public class GetByIdUserClassroomQuery : IRequest<GetByIdUserClassroomResponse>
{
    public int Id { get; set; }

    public class GetByIdUserClassroomQueryHandler : IRequestHandler<GetByIdUserClassroomQuery, GetByIdUserClassroomResponse>
    {
        private readonly IMapper _mapper;
        private readonly IUserClassroomRepository _userClassroomRepository;
        private readonly UserClassroomBusinessRules _userClassroomBusinessRules;

        public GetByIdUserClassroomQueryHandler(IMapper mapper, IUserClassroomRepository userClassroomRepository, UserClassroomBusinessRules userClassroomBusinessRules)
        {
            _mapper = mapper;
            _userClassroomRepository = userClassroomRepository;
            _userClassroomBusinessRules = userClassroomBusinessRules;
        }

        public async Task<GetByIdUserClassroomResponse> Handle(GetByIdUserClassroomQuery request, CancellationToken cancellationToken)
        {
            UserClassroom? userClassroom = await _userClassroomRepository.GetAsync(predicate: uc => uc.Id == request.Id, cancellationToken: cancellationToken);
            await _userClassroomBusinessRules.UserClassroomShouldExistWhenSelected(userClassroom);

            GetByIdUserClassroomResponse response = _mapper.Map<GetByIdUserClassroomResponse>(userClassroom);
            return response;
        }
    }
}