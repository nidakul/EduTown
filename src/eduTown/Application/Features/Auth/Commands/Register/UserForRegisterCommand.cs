using NArchitecture.Core.Application.Dtos;
using System;
namespace Application.Features.Auth.Commands.Register
{
    public class UserForRegisterCommand : IDto
    {
        public string NationalIdentity { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? ImageUrl { get; set; }


        public UserForRegisterCommand()
        {
            NationalIdentity = string.Empty;
            Password = string.Empty; 
        }

        public UserForRegisterCommand(string nationalIdentity, string password, string firstName, string lastName, string email, string? imageUrl):this()
        {
            NationalIdentity = nationalIdentity;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ImageUrl = imageUrl;
        }
    }
}


