using Application.Features.Auth.Commands.Register;
using Application.Services.Repositories;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using NArchitecture.Core.Security.Entities;
using NArchitecture.Core.Security.Hashing;
using Persistence.Contexts;
using System.Reflection.Metadata.Ecma335;

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

    public async Task<User> UpdateUserAsync(Guid userId, UserForRegisterCommand userForRegisterCommand)
    {
        User updateUser = await GetAsync(predicate: u => u.Id == userId);

        updateUser.SchoolId = userForRegisterCommand.SchoolId;
        updateUser.NationalIdentity = userForRegisterCommand.NationalIdentity;
        updateUser.FirstName = userForRegisterCommand.FirstName;
        updateUser.LastName = userForRegisterCommand.LastName;
        updateUser.Email = userForRegisterCommand.Email;
        updateUser.Gender = userForRegisterCommand.Gender;
        updateUser.ImageUrl = userForRegisterCommand.ImageUrl;

        return await UpdateAsync(updateUser);
    }

}
