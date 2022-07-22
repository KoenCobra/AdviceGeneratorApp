using System.Text.Json;
using AdviceGeneratorApp.Model;
using AdviceGeneratorApp.Sdk.Abstractions;

namespace AdviceGeneratorApp.Sdk
{
    public class AdviceApi : IAdviceApi
    {
        private readonly HttpClient _httpClient;

        public AdviceApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Advice> GetAdvice()
        {
            var response = await _httpClient.GetAsync("https://api.adviceslip.com/advice");

            response.EnsureSuccessStatusCode();

            await using var result = await response.Content.ReadAsStreamAsync();

            var advice = await JsonSerializer.DeserializeAsync<Advice>(result);

            if (advice is null)
            {
                return new Advice();
            }

            return advice;
        }
    }
}
