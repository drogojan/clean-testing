using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Application.WheaterForecasts.Queries.GetWheaterForecasts
{
    public class GetWheaterForecastsQuery : IRequest<IEnumerable<WeatherForecast>>
    {
    }

    public class GetWheaterForecastsQueryHandler : IRequestHandler<GetWheaterForecastsQuery, IEnumerable<WeatherForecast>>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        public Task<IEnumerable<WeatherForecast>> Handle(GetWheaterForecastsQuery request, CancellationToken cancellationToken)
        {
            var rng = new Random();
            var vm = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });

            return Task.FromResult(vm);
        }
    }
}