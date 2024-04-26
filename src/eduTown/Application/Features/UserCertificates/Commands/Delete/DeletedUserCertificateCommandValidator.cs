using FluentValidation;

namespace Application.Features.UserCertificates.Commands.Delete;

public class DeleteUserCertificateCommandValidator : AbstractValidator<DeleteUserCertificateCommand>
{
    public DeleteUserCertificateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}