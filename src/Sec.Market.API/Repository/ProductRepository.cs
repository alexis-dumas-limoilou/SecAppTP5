
using Microsoft.EntityFrameworkCore;
using Sec.Market.API.Data;
using Sec.Market.API.Entites;
using Sec.Market.API.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Sec.Market.API.Repository
{
    public class ProductRepository: IProductRepository
    {
        public readonly MarketContext _context;

        public ProductRepository(MarketContext context)
        {
            _context = context;
        }


        public ValueTask<Product?> GetProductById(int productId)
        {
            return _context.Products.FindAsync(productId);
        }
        
        public Task<List<Product>> GetProducts()
        {
            return _context.Products.ToListAsync();
        }

        public Task InsertProduct(Product product)
        {
            _context.Products.Add(product);
            return _context.SaveChangesAsync();
        }

        public Task<List<Product>> SearchProducts(string filter)
        {
            
            return _context.Products.FromSqlRaw($"SELECT * FROM Products WHERE Name LIKE '%{filter}%' OR Description LIKE '%{filter}%'")
                .ToListAsync();
        }

        public Task UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }

        public Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            return _context.SaveChangesAsync();
        }
    }
}
