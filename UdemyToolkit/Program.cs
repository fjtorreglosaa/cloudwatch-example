using AWS.Logger.SeriLog;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Compact;

namespace UdemyToolkit
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, longingConfiguration) =>
            {
                longingConfiguration.ReadFrom.Configuration(context.Configuration)
                    .WriteTo.AWSSeriLog(configuration: context.Configuration, textFormatter: new RenderedCompactJsonFormatter());
            });

            //builder.Logging.AddAWSProvider();

            var startup = new Startup(builder.Configuration);

            startup.ConfigureServices(builder.Services);

            var app = builder.Build();

            startup.Configure(app, app.Environment);

            app.Run();
        }
    }
}