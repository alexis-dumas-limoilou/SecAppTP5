using Newtonsoft.Json;
using Sec.Market.MVC.Interfaces;
using Sec.Market.MVC.Models;
using System.Text;

namespace Sec.Market.MVC.Services
{
    public class CustomerReviewServiceProxy : ICustomerReviewService
    {
        private readonly HttpClient _httpClient;

        private const string _customerReviewApiUrl = "api/customerreviews/";

        public CustomerReviewServiceProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Ajouter(CustomerReview customerReview)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(customerReview), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_customerReviewApiUrl, content);

            response.EnsureSuccessStatusCode();
        }

        public Task<CustomerReview> Obtenir(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CustomerReview>> ObtenirSelonProduit(int productId)
        {

           return await _httpClient.GetFromJsonAsync<List<CustomerReview>>(_customerReviewApiUrl + "?productId=" + productId);
          
        }
    }
}
