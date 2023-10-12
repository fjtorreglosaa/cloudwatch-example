using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace UdemyToolkit
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var startup = new Startup(builder.Configuration);

            startup.ConfigureServices(builder.Services);

            var serviceProvider = builder.Services.BuildServiceProvider();

            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();

            var app = builder.Build();

            startup.Configure(app, app.Environment);

            app.Run();
        }
    }
}