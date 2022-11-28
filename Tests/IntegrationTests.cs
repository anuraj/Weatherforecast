using Microsoft.AspNetCore.Mvc.Testing;

namespace WeatherForecast.Tests;

public class IntegrationTests: IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;
    private readonly HttpClient _httpClient;
    public IntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _httpClient = factory.CreateClient();
    }
    /*
     * This test will fail is we remove the call to app.UseRouting(); in Program.cs
     */
    [Fact]
    public async Task FetchWeatherforecastWithRateLimit()
    {
        for (int i = 0; i < 5; i++)
        {
            var response = await _httpClient.GetAsync("/weatherforecast");
            response.EnsureSuccessStatusCode();
        }
    }
}