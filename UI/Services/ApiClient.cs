using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using SharedKernel.ApiModels;

namespace UI.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AnnualTaxDTO> PostTaxCalculationAsync(RequestAnnualTaxDTO requestAnnualTaxDTO)
        {
            var response = await _httpClient.PostAsJsonAsync($"/api/tax", requestAnnualTaxDTO);

            if (response.StatusCode == HttpStatusCode.NotFound || response.StatusCode == HttpStatusCode.BadRequest)
            {
                return null;
            }

            response.EnsureSuccessStatusCode();

            
            return await response.Content.ReadAsAsync<AnnualTaxDTO>();
        }
    }
}
