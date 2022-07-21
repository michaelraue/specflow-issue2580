using Api.Services;
using BoDi;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace SpecFlow.Issue2580.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeTestRun]
        public static void Startup(IObjectContainer objectContainer)
        {
            var weatherForecastServiceMock = new Mock<IWeatherForecastService>();
            var app = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                        services.AddSingleton(weatherForecastServiceMock.Object));
                });
            objectContainer.RegisterInstanceAs(weatherForecastServiceMock);
            objectContainer.RegisterInstanceAs(app.CreateClient());
        }
    }
}