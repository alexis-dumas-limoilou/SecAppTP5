using Newtonsoft.Json;
using Sec.Market.MVC.Interfaces;
using Sec.Market.MVC.Models;
using System.Text;

namespace Sec.Market.MVC.Services
{
    public class ProductServiceProxy : IProductService
    {
        private readonly HttpClient _httpClient;

        private const string _produitApiUrl = "api/products/";

        public ProductServiceProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Ajouter(Product product)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_produitApiUrl, content);

            response.EnsureSuccessStatusCode();
        }

        public Task Modifier(Product product)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Obtenir(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>(_produitApiUrl + id);
        }

        public async Task<List<Product>> ObtenirSelonFiltre(string? filtre)
        {

            return await _httpClient.GetFromJsonAsync<List<Product>>(_produitApiUrl + "?filter=" + filtre);
        }

        public Task Supprimer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
