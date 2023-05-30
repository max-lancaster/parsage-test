using parsage_test.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using Microsoft.AspNetCore.Mvc;

namespace parsage_test.WebUI.Controllers;

public class WeatherForecastController : ApiControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}
