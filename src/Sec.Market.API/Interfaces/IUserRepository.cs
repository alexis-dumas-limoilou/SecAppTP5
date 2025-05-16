using Sec.Market.API.Entites;

namespace Sec.Market.API.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUsers();

        public Task<User?> GetUserById(int userId);
        public Task<User?> GetUserByEmailAndPwd(string email, string pwd);
        public Task InsertUser(User user);
        public Task UpdateUser(User user);
        public Task DeleteUser(User user);
        
        
    }
}
