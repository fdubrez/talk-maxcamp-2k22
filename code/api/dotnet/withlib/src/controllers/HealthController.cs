using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace peachme_api.controllers;

[ApiController]
[Route("health")]
public class HealthController : ControllerBase
{

    public enum HealthStatus
    {
        Healthy,
        Unhealthy
    }
    public class HealthResponse
    {
        public string Status {get; } = "ok";

        public string Name { get; } = Assembly.GetEntryAssembly()?.GetName().Name;
        public string Version { get; } = Assembly.GetEntryAssembly().GetName().Version.ToString();
    } 

    [HttpGet]
    public Task<HealthResponse> Index()
    {
        return Task.FromResult(new HealthResponse());
    }
}