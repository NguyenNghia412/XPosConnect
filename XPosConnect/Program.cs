using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using NLog;
using NLog.Web;
using System;
using XPosConnect;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Info("Starting application...");
try
{
    //var builder = Host.CreateApplicationBuilder(args);
    var builder = WebApplication.CreateBuilder(args);

    var allowedOriginsConfig = builder.Configuration["AllowedOrigins"] ?? string.Empty;

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("ConfiguredOrigins", policy =>
        {
            if (allowedOriginsConfig.Trim() == "*")
            {
                policy.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            }
            else
            {
                var origins = allowedOriginsConfig
                    .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

                if (origins.Length > 0)
                {
                    policy.WithOrigins(origins)
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                }
                else
                {
                    // No origins configured = block all
                    policy.WithOrigins(Array.Empty<string>());
                }
            }
        });
    });

    builder.WebHost.ConfigureKestrel((context, options) =>
    {
        options.Configure(context.Configuration.GetSection("Kestrel"));
    });
    builder.Host.UseNLog(); // Add NLog as logging provider
    builder.Services.AddHostedService<Worker>();
    builder.Services.AddWindowsService();

    builder.Services.AddControllers();

    var host = builder.Build();
    host.UseCors("ConfiguredOrigins");
    host.MapControllers();
    host.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    LogManager.Shutdown();
}
