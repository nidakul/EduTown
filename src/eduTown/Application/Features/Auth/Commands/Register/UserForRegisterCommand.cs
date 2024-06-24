using Domain.Entities;
using NArchitecture.Core.Application.Dtos;
using System;
namespace Application.Features.Auth.Commands.Register
{
    public class UserForRegisterCommand : IDto
    {
        public int SchoolId { get; set; }
        public string NationalIdentity { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string? ImageUrl { get; set; }


        public UserForRegisterCommand()
        {
            NationalIdentity = string.Empty;
            Password = string.Empty; 
        }

        public UserForRegisterCommand(int schoolId, string nationalIdentity, string password, string firstName, string lastName, string email, string gender, string? imageUrl): this()
        {
            SchoolId = schoolId;
            NationalIdentity = nationalIdentity;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Gender = gender;
            ImageUrl = imageUrl;
        }
    }
}


