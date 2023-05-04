using Phoenix.Auth.Business;
using Phoenix.Modules.Docs.Business.CounsellingUnit;
using Phoenix.Modules.Docs.Business.Extensions;
using Phoenix.Modules.MentalHealthTools.Business.Extensions;
using Phoenix.Modules.Pharma.Business.Extensions;
using Serilog;

namespace API;

public static class Middleware
{
    public static void ConfigurePipeline(this WebApplication app)
    {
        app.RunAuthStartup();
        app.RunMhToolsStartup();
        app.RunPharmaStartup();
        app.RunDocsStartup();
        
        app.UseSwagger();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zomujo Auth API");
                c.DisplayOperationId();
            });
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Zomujo Auth API");
                c.RoutePrefix = string.Empty;
            });
        }

        app.UseHttpsRedirection();
        app.UseDefaultFiles();
        app.UseStaticFiles();

        app.UseSerilogRequestLogging();
        
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapHub<SessionHub>("/mental-health");
        app.MapControllers();

        app.Run();
    }
}