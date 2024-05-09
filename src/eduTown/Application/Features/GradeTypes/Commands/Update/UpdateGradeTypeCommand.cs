using Application.Features.GradeTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GradeTypes.Commands.Update;

public class UpdateGradeTypeCommand : IRequest<UpdatedGradeTypeResponse>
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required int GradeCount { get; set; }


    public class UpdateGradeTypeCommandHandler : IRequestHandler<UpdateGradeTypeCommand, UpdatedGradeTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGradeTypeRepository _gradeTypeRepository;
        private readonly GradeTypeBusinessRules _gradeTypeBusinessRules;

        public UpdateGradeTypeCommandHandler(IMapper mapper, IGradeTypeRepository gradeTypeRepository,
                                         GradeTypeBusinessRules gradeTypeBusinessRules)
        {
            _mapper = mapper;
            _gradeTypeRepository = gradeTypeRepository;
            _gradeTypeBusinessRules = gradeTypeBusinessRules;
        }

        public async Task<UpdatedGradeTypeResponse> Handle(UpdateGradeTypeCommand request, CancellationToken cancellationToken)
        {
            GradeType? gradeType = await _gradeTypeRepository.GetAsync(predicate: gt => gt.Id == request.Id, cancellationToken: cancellationToken);
            await _gradeTypeBusinessRules.GradeTypeShouldExistWhenSelected(gradeType);
            gradeType = _mapper.Map(request, gradeType);

            await _gradeTypeRepository.UpdateAsync(gradeType!);

            UpdatedGradeTypeResponse response = _mapper.Map<UpdatedGradeTypeResponse>(gradeType);
            return response;
        }
    }
}