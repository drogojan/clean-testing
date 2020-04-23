using WebUI;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using MediatR;

namespace Application.IntegrationTests
{
    public class IntegrationTestFixture
    {
        private static IConfigurationRoot _configuration;
        private static IServiceScopeFactory _scopeFactory;

        public IntegrationTestFixture()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables();

            _configuration = builder.Build();

            var startup = new Startup(_configuration);

            var services = new ServiceCollection();

            // services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
            //     w.EnvironmentName == "Development" &&
            //     w.ApplicationName == "CleanArchitecture.WebUI"));

            // services.AddLogging();

            startup.ConfigureServices(services);

            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();

            // var connString = _configuration.GetConnectionString("DefaultConnectionString");

            // _checkpoint = new Checkpoint
            // {
            //     TablesToIgnore = new[] { "__EFMigrationsHistory" }
            // };

            // EnsureDatabase();
        }

        public static async Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<IMediator>();

            return await mediator.Send(request);
        }
    }
}