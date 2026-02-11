using TCGStore.Api.Features.Cards;
using TCGStore.Api.Features.Orders;
using TCGStore.Api.Features.Users;
using TCGStore.Api.Features.Inventory;
using TCGStore.Api.Features.Cards.Persistence;
using TCGStore.Api.Shared.Infrastructure.Data;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.Options;

namespace TCGStore.Api.Common.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Configure DynamoDB options from appsettings and user secrets
        services.Configure<DynamoDbOptions>(configuration.GetSection("AWS:DynamoDB"));

        // Register DynamoDB client
        // Uses AWS SDK's default credential chain (environment variables, profiles, IAM roles, etc.)
        services.AddSingleton<IAmazonDynamoDB>(sp => 
        {
            var options = sp.GetRequiredService<IOptions<DynamoDbOptions>>();
            var config = new AmazonDynamoDBConfig 
            { 
                RegionEndpoint = Amazon.RegionEndpoint.GetBySystemName(options.Value.Region)
            };
            return new AmazonDynamoDBClient(config);
        });
        services.AddSingleton<IDynamoDBContext, DynamoDBContext>();

        // Register DynamoDB initializer
        services.AddScoped<DynamoDbInitializer>();

        // Register data repositories
        services.AddScoped<ICardCatalogRepository, DynamoCardRepository>();

        // Register feature services
        services.AddScoped<ICardsService, CardsService>();
        services.AddScoped<IOrdersService, OrdersService>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IInventoryService, InventoryService>();

        return services;
    }
}

