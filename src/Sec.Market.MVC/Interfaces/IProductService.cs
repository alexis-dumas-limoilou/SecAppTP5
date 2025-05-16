using Sec.Market.MVC.Models;

namespace Sec.Market.MVC.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> ObtenirSelonFiltre(string? filtre);

        Task<Product> Obtenir(int id);

        Task Ajouter(Product product);

        Task Supprimer(int id);

        Task Modifier(Product product);
    }
}
