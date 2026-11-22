using StudentManagementAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Student REST API v1");
    c.RoutePrefix = string.Empty;
});

// Register Custom Request Logging Middleware
app.UseMiddleware<RequestLoggingMiddleware>();

app.UseAuthorization();

// Redirect /swagger to root so both http://localhost:5000/ and http://localhost:5000/swagger work
app.MapGet("/swagger", () => Results.Redirect("/"));
app.MapGet("/swagger/{*any}", () => Results.Redirect("/"));

app.MapControllers();

app.Lifetime.ApplicationStarted.Register(() =>
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("==========================================================");
    Console.WriteLine("  Student Management REST API is Running Successfully!");
    Console.WriteLine("  Open your browser to test:");
    Console.WriteLine("  -> Swagger UI:   http://localhost:5000");
    Console.WriteLine("  -> Students API: http://localhost:5000/api/Students");
    Console.WriteLine("==========================================================");
    Console.ResetColor();
    Console.WriteLine();
});

app.Run();
