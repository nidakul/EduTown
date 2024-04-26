using FluentValidation;

namespace Application.Features.UserCertificates.Commands.Create;

public class CreateUserCertificateCommandValidator : AbstractValidator<CreateUserCertificateCommand>
{
    public CreateUserCertificateCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.CertificateId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
    }
}