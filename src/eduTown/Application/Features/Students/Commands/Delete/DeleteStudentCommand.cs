using Application.Features.Students.Constants;
using Application.Features.Students.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Students.Commands.Delete;

public class DeleteStudentCommand : IRequest<DeletedStudentResponse>
{
    public Guid Id { get; set; }

    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, DeletedStudentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;
        private readonly StudentBusinessRules _studentBusinessRules;

        public DeleteStudentCommandHandler(IMapper mapper, IStudentRepository studentRepository,
                                         StudentBusinessRules studentBusinessRules)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
            _studentBusinessRules = studentBusinessRules;
        }

        public async Task<DeletedStudentResponse> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            Student? student = await _studentRepository.GetAsync(predicate: s => s.Id == request.Id, cancellationToken: cancellationToken);
            await _studentBusinessRules.StudentShouldExistWhenSelected(student);

            await _studentRepository.DeleteAsync(student!);

            DeletedStudentResponse response = _mapper.Map<DeletedStudentResponse>(student);
            return response;
        }
    }
}