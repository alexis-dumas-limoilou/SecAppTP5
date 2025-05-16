using Sec.Market.MVC.Models;

namespace Sec.Market.MVC.Interfaces
{
    public interface ICustomerReviewService
    {
        Task<List<CustomerReview>> ObtenirSelonProduit(int productId);

        Task<CustomerReview> Obtenir(int id);

        Task Ajouter(CustomerReview customerReview);
    }
}
