namespace Api.Services;

public interface IWeatherForecastService
{
    IEnumerable<WeatherForecast> Get();
}