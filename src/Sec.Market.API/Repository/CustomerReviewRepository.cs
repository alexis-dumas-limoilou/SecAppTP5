using Microsoft.EntityFrameworkCore;
using Sec.Market.API.Data;
using Sec.Market.API.Entites;
using Sec.Market.API.Interfaces;

namespace Sec.Market.API.Repository
{
    public class CustomerReviewRepository : ICustomerReviewRepository
    {
        public readonly MarketContext _context;

        public CustomerReviewRepository(MarketContext context)
        {
            _context = context;
        }

        public Task DeleteCustomerReview(CustomerReview customerReview)
        {
            _context.CustomerReviews.Remove(customerReview);
            return _context.SaveChangesAsync();
        }

        public ValueTask<CustomerReview?> GetCustomerReviewById(int customerReviewId)
        {
            return _context.CustomerReviews.FindAsync(customerReviewId);
        }

        public Task<List<CustomerReview>> GetCustomerReviews()
        {
            return _context.CustomerReviews.ToListAsync();
        }

        public Task<List<CustomerReview>> GetCustomerReviewsByProduct(int productId)
        {
            return _context.CustomerReviews.Where(c => c.ProductId == productId).ToListAsync();
        }

        public Task InsertCustomerReview(CustomerReview customerReview)
        {
            _context.CustomerReviews.Add(customerReview);
            return _context.SaveChangesAsync();
        }

        public Task UpdateCustomerReview(CustomerReview customerReview)
        {
            _context.Entry(customerReview).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
