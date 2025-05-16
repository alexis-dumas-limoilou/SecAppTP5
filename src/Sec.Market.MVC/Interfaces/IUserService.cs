using Sec.Market.MVC.Models;

namespace Sec.Market.MVC.Interfaces
{
    public interface IUserService
    {
        Task<List<User?>> ObtenirTout();

        Task<User> Obtenir(int id);

        Task<User> Obtenir(string email, string pwd);

        Task Ajouter(User user);

   
    }
}
