using Newtonsoft.Json;
using Sec.Market.MVC.Interfaces;
using Sec.Market.MVC.Models;
using System.Text;

namespace Sec.Market.MVC.Services
{
    public class OrderServiceProxy : IOrderService
    {
        private readonly HttpClient _httpClient;

        private const string _orderApiUrl = "api/orders/";

        public OrderServiceProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task Ajouter(OrderData orderData)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(orderData), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_orderApiUrl, content);

            response.EnsureSuccessStatusCode();
        }

        public Task<Order> Obtenir(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> ObtenirSelonUser(int userId)
        {

            return await _httpClient.GetFromJsonAsync<List<Order>>(_orderApiUrl + "?userId=" + userId);
        }

        public Task Supprimer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
