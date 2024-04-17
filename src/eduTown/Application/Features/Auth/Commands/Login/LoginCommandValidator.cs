using FluentValidation;

namespace Application.Features.Auth.Commands.Login;

public class LoginCommandValidator : AbstractValidator<LoginCommand>
{
    public LoginCommandValidator()
    {
        RuleFor(c => c.UserForLoginCommand.NationalIdentity).NotEmpty();
        RuleFor(c => c.UserForLoginCommand.Password).NotEmpty().MinimumLength(4);
    }
}
