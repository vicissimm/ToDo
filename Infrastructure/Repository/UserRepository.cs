using Microsoft.EntityFrameworkCore;
using Domain.Interfaces;
using Domain.Entites;
using Infrastructure.DataContext;
using Microsoft.Extensions.Configuration;
using Domain.ValueObjects;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ToDoAppDataContext _context;
        private readonly IPasswordHasher _passwordHasher;
        public UserRepository(ToDoAppDataContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<User?> CheckEmail(string email)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            return entity;
        }

        public async Task CreateUser(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<TokenObject> Login(string email, string password)
        {
            var configurationManager = new ConfigurationManager();
            var auth = new Authorization(configurationManager);

            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            var accessToken = string.Empty;
            var refreshToken = string.Empty;

            auth.Token(user.Id, out accessToken);
            auth.RefreshToken(user.Id, out refreshToken);

            var tokens = new TokenObject
            {
                AccessToken=accessToken,
                RefreshToken=refreshToken,
            };

            return tokens;
        }

        public async Task<int> GetUserIdFromToken(string token)
        {
            var configurationManager = new ConfigurationManager();
            var auth = new Authorization(configurationManager);
            var id = auth.DecodeAccessToken(token);

            return id;
        }

    }
}
