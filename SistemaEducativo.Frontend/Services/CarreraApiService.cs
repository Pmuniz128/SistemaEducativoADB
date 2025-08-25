using SistemaEducativo.Frontend.Models;
using System.Net.Http;
using System.Net.Http.Json;


namespace SistemaEducativo.Frontend.Services
{
    public class CarreraApiService : ICarreraApiService
    {
        private readonly HttpClient _httpClient;

        public CarreraApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CarreraViewModel>> GetCarrerasAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<CarreraViewModel>>("api/carreras");
            return result ?? new List<CarreraViewModel>();
        }
    }
}
