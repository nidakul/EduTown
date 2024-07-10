using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolTypeClasses.Commands.Delete;

public class DeletedSchoolTypeClassResponse : IResponse
{
    public int Id { get; set; }
}