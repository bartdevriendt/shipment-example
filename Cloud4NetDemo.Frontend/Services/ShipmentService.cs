using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Cloud4NetDemo.Shared;
using Cloud4NetDemo.Shared.Wrapper;

namespace Cloud4NetDemo.Frontend.Services
{
    public class ShipmentService
    {
        private readonly HttpClient _httpClient;

        public ShipmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Result<ShipmentTrackerDto>> ShipPackage(ShipmentRequestDto request)
        {
            var response = await _httpClient.PostAsJsonAsync(
                "api/ship", request);
            return await response.Content.ReadFromJsonAsync<Result<ShipmentTrackerDto>>();
        }
    }
}