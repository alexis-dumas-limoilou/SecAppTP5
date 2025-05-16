using Sec.Market.API.Entites;

namespace Sec.Market.API.Interfaces
{
    public interface ICustomerReviewRepository
    {
        public Task<List<CustomerReview>> GetCustomerReviews();

        public Task<List<CustomerReview>> GetCustomerReviewsByProduct(int productId);
        public ValueTask<CustomerReview?> GetCustomerReviewById(int customerReviewId);
        public Task InsertCustomerReview(CustomerReview customerReview);

        public Task DeleteCustomerReview(CustomerReview customerReview);
        public Task UpdateCustomerReview(CustomerReview customerReview);
    }
}
