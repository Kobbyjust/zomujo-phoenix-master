﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;

namespace Phoenix.Modules.Docs.Business.Extensions;

public class HealthCheck
{
    public string Status { get; set; }
    public string? Component { get; set; }
    public string? Description { get; set; }
}

public class HealthCheckResponse
{
    public string Status { get; set; }
    public IEnumerable<HealthCheck> Checks { get; set; }
    public TimeSpan Duration { get; set; }
}

public static class HealthCheckExtensions
{
    public static async Task BuildHealthCheckResponse(this HttpResponse response, HealthReport report)
    {
        var hcResponse = new HealthCheckResponse
        {
            Status = report.Status.ToString(),
            Checks = report.Entries.Select(x => new HealthCheck
            {
                Component = x.Key,
                Status = x.Value.Status.ToString(),
                Description = x.Value.Description
            }),
            Duration = report.TotalDuration
        };
        await response.WriteAsync(JsonConvert.SerializeObject(hcResponse));
    }
}