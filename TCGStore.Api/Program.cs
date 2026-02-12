using TCGStore.Api.Common.Extensions;
using TCGStore.Api.Common.Middleware;
using TCGStore.Api.Features.Cards.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Add application services
builder.Services.AddApplicationServices(builder.Configuration);

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Initialize DynamoDB
if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        try
        {
            logger.LogInformation("Starting DynamoDB initialization...");
            var initializer = scope.ServiceProvider.GetRequiredService<CardDynamoDbInitializer>();
            await initializer.InitializeAsync();
            logger.LogInformation("DynamoDB initialization completed successfully.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to initialize DynamoDB: {Message}", ex.Message);
            throw;
        }
    }
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
