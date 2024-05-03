using NArchitecture.Core.Application.Responses;

namespace Application.Features.SchoolClassrooms.Commands.Delete;

public class DeletedSchoolClassroomResponse : IResponse
{
    public int Id { get; set; }
}