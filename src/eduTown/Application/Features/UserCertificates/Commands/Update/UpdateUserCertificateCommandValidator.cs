using FluentValidation;

namespace Application.Features.UserCertificates.Commands.Update;

public class UpdateUserCertificateCommandValidator : AbstractValidator<UpdateUserCertificateCommand>
{
    public UpdateUserCertificateCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.CertificateId).NotEmpty();
        RuleFor(c => c.ClassroomId).NotEmpty();
    }
}