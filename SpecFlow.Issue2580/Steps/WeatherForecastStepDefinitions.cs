using Api;
using FluentAssertions;

namespace SpecFlow.Issue2580.Steps;

[Binding]
public sealed class WeatherForecastStepDefinitions
{
    private readonly HttpClient _httpClient;
    private HttpResponseMessage? _response;

    public WeatherForecastStepDefinitions(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [When(@"weather forecasts are requested")]
    public async Task WhenWeatherForecastsAreRequested()
    {
        _response = await _httpClient.GetAsync("/WeatherForecast");
    }

    [Then(@"weather forecasts are returned")]
    public async Task ThenWeatherForecastsAreReturned()
    {
        _response.Should().NotBeNull();
        _response!.EnsureSuccessStatusCode();
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().ContainEquivalentOf("temperatureC");
    }
}