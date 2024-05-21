using Application.Features.Auth.Commands.Register;
using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;
using NArchitecture.Core.Security.Hashing;

namespace Application.Services.Repositories;

public interface IUserRepository : IAsyncRepository<User, Guid>, IRepository<User, Guid>
{

    Task<User> CreateUserAsync(UserForRegisterCommand userForRegisterCommand);

    
}
