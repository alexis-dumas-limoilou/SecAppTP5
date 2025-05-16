using Newtonsoft.Json;
using Sec.Market.MVC.Interfaces;
using Sec.Market.MVC.Models;
using System.Text;

namespace Sec.Market.MVC.Services
{
    public class UserServiceProxy : IUserService
    {
        private readonly HttpClient _httpClient;

        private const string _userApiUrl = "api/users/";

        public UserServiceProxy(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task Ajouter(User user)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_userApiUrl, content);

            response.EnsureSuccessStatusCode();
        }

        public Task<User> Obtenir(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> Obtenir(string email, string pwd)
        {
            var queryParameters = new Dictionary<string, string>
                  {
                    { "email", email },
                    { "pwd", pwd}
                };
            var dictFormUrlEncoded = new FormUrlEncodedContent(queryParameters);

            var queryString = await dictFormUrlEncoded.ReadAsStringAsync();

            var response = await _httpClient.GetAsync(_userApiUrl + "GetUser?" + queryString);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<User>();
              else
                  return null;
        }

        public async Task<List<User>> ObtenirTout()
        {
            return await _httpClient.GetFromJsonAsync<List<User>>(_userApiUrl);
        }
    }
}
