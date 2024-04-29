using Application.Features.GradeTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GradeTypes.Commands.Create;

public class CreateGradeTypeCommand : IRequest<CreatedGradeTypeResponse>
{
    public required string Name { get; set; }

    public class CreateGradeTypeCommandHandler : IRequestHandler<CreateGradeTypeCommand, CreatedGradeTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGradeTypeRepository _gradeTypeRepository;
        private readonly GradeTypeBusinessRules _gradeTypeBusinessRules;

        public CreateGradeTypeCommandHandler(IMapper mapper, IGradeTypeRepository gradeTypeRepository,
                                         GradeTypeBusinessRules gradeTypeBusinessRules)
        {
            _mapper = mapper;
            _gradeTypeRepository = gradeTypeRepository;
            _gradeTypeBusinessRules = gradeTypeBusinessRules;
        }

        public async Task<CreatedGradeTypeResponse> Handle(CreateGradeTypeCommand request, CancellationToken cancellationToken)
        {
            GradeType gradeType = _mapper.Map<GradeType>(request);

            await _gradeTypeRepository.AddAsync(gradeType);

            CreatedGradeTypeResponse response = _mapper.Map<CreatedGradeTypeResponse>(gradeType);
            return response;
        }
    }
}