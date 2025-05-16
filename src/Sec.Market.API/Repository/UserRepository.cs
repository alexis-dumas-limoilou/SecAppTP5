using Microsoft.EntityFrameworkCore;
using Sec.Market.API.Data;
using Sec.Market.API.Entites;
using Sec.Market.API.Interfaces;

namespace Sec.Market.API.Repository
{
    public class UserRepository : IUserRepository
    {
        public readonly MarketContext _context;
        public UserRepository(MarketContext context)
        {
            _context = context;
        }
       
        public Task DeleteUser(User user)
        {
            _context.Users.Remove(user);
            return _context.SaveChangesAsync();
        }

        public Task<User?> GetUserByEmailAndPwd(string email, string pwd)
        {
            return _context.Users.FromSqlRaw("SELECT * FROM Users WHERE Email = '" + email + "' AND Password = '" + pwd + "'")
                .SingleOrDefaultAsync();
        }

        public Task<User?> GetUserById(int userId)
        {
            return _context.Users.FromSqlRaw("SELECT * FROM Users WHERE Id = " + userId)
                .SingleOrDefaultAsync();
        }

        public Task<List<User>> GetUsers()
        {
            return _context.Users.ToListAsync();
        }

        public Task InsertUser(User user)
        {
            _context.Users.Add(user);
            return _context.SaveChangesAsync();
        }

        public Task UpdateUser(User user)
        {
            _context.Users.Update(user);
            return _context.SaveChangesAsync();
        }
    }
}
