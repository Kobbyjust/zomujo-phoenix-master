using API;
using Phoenix.Auth.Business;
using Phoenix.Auth.Business.Jobs;
using Phoenix.Modules.Docs.Business;
using Phoenix.Modules.Docs.Business.Jobs;
using Phoenix.Modules.MentalHealthTools.Business;
using Phoenix.Modules.Pharma.Business;
using Phoenix.Shared.Business;
using Phoenix.Shared.Persistence.DependencyInjection;
using Phoenix.Shared.Persistence.Events.Bus;
using Quartz;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Services.AddSharedBusiness(builder.Configuration)
    .AddSharedPersistence()
    .InstallAuthModule(builder.Configuration)
    .InstallDocs(builder.Configuration)
    .InstallPharma(builder.Configuration)
    .InstallMhTools(builder.Configuration);
    
var authKey = new JobKey(nameof(ProcessAuthBoxMessagesJob));
var docsKey = new JobKey(nameof(ProcessDocsBoxMessagesJob));
builder.Services.AddQuartz(configure =>
{
    configure.AddJob<ProcessAuthBoxMessagesJob>(authKey)
        .AddTrigger(trigger => trigger.ForJob(authKey)
            .WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(10)
                .RepeatForever()));
    configure.AddJob<ProcessDocsBoxMessagesJob>(docsKey)
        .AddTrigger(trigger => trigger.ForJob(docsKey)
            .WithSimpleSchedule(schedule => schedule.WithIntervalInSeconds(10)
                .RepeatForever()));
    configure.UseMicrosoftDependencyInjectionJobFactory();
});
builder.Services.AddQuartzHostedService();

builder.Host.UseSerilog(logger);
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

WebApplication app;

try
{
    logger.Information("App starting...");
    app = builder.Build();
    logger.Information("App has started successfully!");
}
catch (Exception e)
{
    logger.Error("{Message}", e.Message);
    throw;
}

app.ConfigurePipeline();