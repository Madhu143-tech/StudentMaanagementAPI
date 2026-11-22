using System.Diagnostics;

namespace StudentManagementAPI.Middleware;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();
        var method = context.Request.Method;
        var path = context.Request.Path;

        _logger.LogInformation("[HTTP INCOMING] Method: {Method} | Path: {Path} | Time: {Time}",
            method, path, DateTime.Now.ToString("HH:mm:ss.fff"));

        await _next(context);

        stopwatch.Stop();

        var statusCode = context.Response.StatusCode;

        _logger.LogInformation("[HTTP COMPLETED] Method: {Method} | Path: {Path} | Status: {Status} | Elapsed: {Elapsed}ms",
            method, path, statusCode, stopwatch.ElapsedMilliseconds);
    }
}
