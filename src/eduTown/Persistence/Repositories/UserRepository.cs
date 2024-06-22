using Application.Features.Auth.Commands.Register;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using NArchitecture.Core.Security.Hashing;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, Guid, BaseDbContext>, IUserRepository
{
    public UserRepository(BaseDbContext context)
        : base(context)
    {


    }

    public async Task<User> CreateUserAsync(UserForRegisterCommand userForRegisterCommand)
    {
        HashingHelper.CreatePasswordHash(
            userForRegisterCommand.Password,
            passwordHash: out byte[] passwordHash,
            passwordSalt: out byte[] passwordSalt
        );

        User newUser = new User
        {
            SchoolId = userForRegisterCommand.SchoolId,
            NationalIdentity = userForRegisterCommand.NationalIdentity,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt,
            FirstName = userForRegisterCommand.FirstName,
            LastName = userForRegisterCommand.LastName,
            Email = userForRegisterCommand.Email,
            ImageUrl = userForRegisterCommand.ImageUrl,
            Gender = userForRegisterCommand.Gender
        };

        return await AddAsync(newUser);
    }

}
