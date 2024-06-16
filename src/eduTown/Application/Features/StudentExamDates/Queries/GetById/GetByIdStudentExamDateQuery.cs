using Application.Features.StudentExamDates.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.StudentExamDates.Queries.GetById;

public class GetByIdStudentExamDateQuery : IRequest<GetByIdStudentExamDateResponse>
{
    public int Id { get; set; }

    public class GetByIdStudentExamDateQueryHandler : IRequestHandler<GetByIdStudentExamDateQuery, GetByIdStudentExamDateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IStudentExamDateRepository _studentExamDateRepository;
        private readonly StudentExamDateBusinessRules _studentExamDateBusinessRules;

        public GetByIdStudentExamDateQueryHandler(IMapper mapper, IStudentExamDateRepository studentExamDateRepository, StudentExamDateBusinessRules studentExamDateBusinessRules)
        {
            _mapper = mapper;
            _studentExamDateRepository = studentExamDateRepository;
            _studentExamDateBusinessRules = studentExamDateBusinessRules;
        }

        public async Task<GetByIdStudentExamDateResponse> Handle(GetByIdStudentExamDateQuery request, CancellationToken cancellationToken)
        {
            StudentExamDate? studentExamDate = await _studentExamDateRepository.GetAsync(predicate: sed => sed.Id == request.Id, cancellationToken: cancellationToken);
            await _studentExamDateBusinessRules.StudentExamDateShouldExistWhenSelected(studentExamDate);

            GetByIdStudentExamDateResponse response = _mapper.Map<GetByIdStudentExamDateResponse>(studentExamDate);
            return response;
        }
    }
}