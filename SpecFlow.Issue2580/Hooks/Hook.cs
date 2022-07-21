using BoDi;
using Microsoft.AspNetCore.Mvc.Testing;

namespace SpecFlow.Issue2580.Hooks
{
    [Binding]
    public class Hooks
    {
        [BeforeTestRun]
        public static void Startup(IObjectContainer objectContainer)
        {
            var app = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                });
            objectContainer.RegisterInstanceAs(app.CreateClient());
        }
    }
}