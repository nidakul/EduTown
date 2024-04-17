using NArchitecture.Core.Application.Dtos;
using System;
namespace Application.Features.Auth.Commands.Login
{
    public class UserForLoginCommand : IDto
    {
        public string NationalIdentity { get; set; }
        public string Password { get; set; }
        public string? AuthenticatorCode { get; set; }

        public UserForLoginCommand()
        {
            NationalIdentity = string.Empty;
            Password = string.Empty;
        }

        public UserForLoginCommand(string nationalIdentity, string password)
        {
            NationalIdentity = nationalIdentity;
            Password = password;
        }
    }
}

