using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolClasses.Commands.Delete;

public class DeletedSchoolClassResponse : IResponse
{
    public int Id { get; set; }
}