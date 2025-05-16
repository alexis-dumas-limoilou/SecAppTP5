using Sec.Market.API.Entites;

namespace Sec.Market.API.Interfaces
{
    public interface IProductRepository 
    {

        public Task<List<Product>> GetProducts();

        public Task<List<Product>> SearchProducts(string filter);

        public ValueTask<Product?> GetProductById(int productId);

        public Task InsertProduct(Product product);
        public Task DeleteProduct(Product product);
        public Task UpdateProduct(Product product);
        
    }
}
