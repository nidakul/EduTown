using Application.Features.GradeTypes.Constants;
using Application.Features.GradeTypes.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.GradeTypes.Commands.Delete;

public class DeleteGradeTypeCommand : IRequest<DeletedGradeTypeResponse>
{
    public int Id { get; set; }

    public class DeleteGradeTypeCommandHandler : IRequestHandler<DeleteGradeTypeCommand, DeletedGradeTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IGradeTypeRepository _gradeTypeRepository;
        private readonly GradeTypeBusinessRules _gradeTypeBusinessRules;

        public DeleteGradeTypeCommandHandler(IMapper mapper, IGradeTypeRepository gradeTypeRepository,
                                         GradeTypeBusinessRules gradeTypeBusinessRules)
        {
            _mapper = mapper;
            _gradeTypeRepository = gradeTypeRepository;
            _gradeTypeBusinessRules = gradeTypeBusinessRules;
        }

        public async Task<DeletedGradeTypeResponse> Handle(DeleteGradeTypeCommand request, CancellationToken cancellationToken)
        {
            GradeType? gradeType = await _gradeTypeRepository.GetAsync(predicate: gt => gt.Id == request.Id, cancellationToken: cancellationToken);
            await _gradeTypeBusinessRules.GradeTypeShouldExistWhenSelected(gradeType);

            await _gradeTypeRepository.DeleteAsync(gradeType!);

            DeletedGradeTypeResponse response = _mapper.Map<DeletedGradeTypeResponse>(gradeType);
            return response;
        }
    }
}