using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.WheaterForecasts.Queries.GetWheaterForecasts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebUI.Controllers
{
    public class WeatherForecastController : ApiController
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await Mediator.Send(new GetWheaterForecastsQuery());
        }
    }
}
