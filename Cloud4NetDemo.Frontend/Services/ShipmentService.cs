using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Cloud4NetDemo.Shared;

namespace Cloud4NetDemo.Frontend.Services
{
    public class ShipmentService
    {
        private readonly HttpClient _httpClient;

        public ShipmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ShipmentTrackerDto> ShipPackage(ShipmentRequestDto request)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/ship", request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Error shipping product");
            }
            return await response.Content.ReadFromJsonAsync<ShipmentTrackerDto>();
        }
    }
}