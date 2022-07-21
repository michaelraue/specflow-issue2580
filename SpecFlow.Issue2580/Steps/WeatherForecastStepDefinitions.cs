using Api;
using Api.Services;
using FluentAssertions;
using Moq;

namespace SpecFlow.Issue2580.Steps;

[Binding]
public sealed class WeatherForecastStepDefinitions
{
    private readonly Mock<IWeatherForecastService> _weatherForecastServiceMock;
    private readonly HttpClient _httpClient;
    private HttpResponseMessage? _response;

    public WeatherForecastStepDefinitions(Mock<IWeatherForecastService> weatherForecastServiceMock, HttpClient httpClient)
    {
        _weatherForecastServiceMock = weatherForecastServiceMock;
        _httpClient = httpClient;
    }

    [When(@"weather forecasts are requested")]
    public async Task WhenWeatherForecastsAreRequested()
    {
        _weatherForecastServiceMock.Setup(x => x.Get()).Returns(new[] {
            new WeatherForecast
            {
                Date = DateTime.Now.AddDays(1),
                TemperatureC = 40,
                Summary = "Mild"
            }
        });
        _response = await _httpClient.GetAsync("/WeatherForecast");
    }

    [Then(@"weather forecasts are returned")]
    public async Task ThenWeatherForecastsAreReturned()
    {
        _response.Should().NotBeNull();
        _response!.EnsureSuccessStatusCode();
        var content = await _response.Content.ReadAsStringAsync();
        content.Should().ContainEquivalentOf("mild");
    }
}