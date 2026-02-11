using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using TCGStore.Api.Features.Cards;
using Microsoft.Extensions.Options;

namespace TCGStore.Api.Shared.Infrastructure.Data;

public class DynamoDbInitializer
{
    private readonly IAmazonDynamoDB _client;
    private readonly ILogger<DynamoDbInitializer> _logger;
    private readonly DynamoDbOptions _dynamoDbOptions;
    private readonly string _tableName;

    public DynamoDbInitializer(IAmazonDynamoDB client, ILogger<DynamoDbInitializer> logger, IOptions<DynamoDbOptions> dynamoDbOptions)
    {
        _client = client;
        _logger = logger;
        _dynamoDbOptions = dynamoDbOptions.Value;
        _tableName = _dynamoDbOptions.TableName;
    }

    public async Task InitializeAsync()
    {
        try
        {
            if (string.IsNullOrEmpty(_tableName))
            {
                _logger.LogError("DynamoDB table name is not configured. Check AWS:DynamoDB:TableName in secrets.");
                throw new InvalidOperationException("DynamoDB table name is not configured");
            }

            _logger.LogInformation("Checking for existing DynamoDB table: {TableName}", _tableName);
            var tables = await _client.ListTablesAsync();
            _logger.LogInformation("Found {Count} existing tables", tables.TableNames.Count);
            
            if (!tables.TableNames.Contains(_tableName))
            {
                _logger.LogWarning("DynamoDB table '{TableName}' not found. This table should have been created by Terraform. Please run the setup script first.", _tableName);
                throw new InvalidOperationException($"DynamoDB table '{_tableName}' not found. Ensure Terraform has been applied successfully.");
            }
            
            _logger.LogInformation("Table {TableName} exists", _tableName);
            
            // Only seed test data in development and if the table is empty
            await SeedTestDataAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error during DynamoDB initialization: {Message}", ex.Message);
            throw;
        }
    }

    private async Task SeedTestDataAsync()
    {
        try
        {
            var scan = await _client.ScanAsync(new ScanRequest { TableName = _tableName, Limit = 1 });
            if (scan.Count > 0)
            {
                _logger.LogInformation("Table {TableName} already contains data, skipping seed", _tableName);
                return;
            }
            
            _logger.LogInformation("Seeding DynamoDB with test cards");
            var testCards = new List<Card>
            {
                new() { Id = Guid.NewGuid().ToString(), Name = "Black Lotus", SetName = "Limited Edition Alpha", SetCode = "LEA", CollectorNumber = 1, Rarity = "Rare", Price = 10000.00m, ImageUrl = "https://example.com/black-lotus.jpg", Description = "Add three mana of any one color to your mana pool.", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new() { Id = Guid.NewGuid().ToString(), Name = "Charizard", SetName = "Base Set", SetCode = "BS", CollectorNumber = 4, Rarity = "Holographic Rare", Price = 5000.00m, ImageUrl = "https://example.com/charizard.jpg", Description = "Fire-breathing dragon Pokémon card.", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            };
            foreach (var card in testCards)
            {
                var item = new Dictionary<string, AttributeValue>
                {
                    ["Id"] = new AttributeValue { S = card.Id },
                    ["Name"] = new AttributeValue { S = card.Name },
                    ["SetName"] = new AttributeValue { S = card.SetName },
                    ["SetCode"] = new AttributeValue { S = card.SetCode },
                    ["CollectorNumber"] = new AttributeValue { N = card.CollectorNumber.ToString() },
                    ["Rarity"] = new AttributeValue { S = card.Rarity },
                    ["Price"] = new AttributeValue { N = card.Price.ToString() },
                    ["ImageUrl"] = new AttributeValue { S = card.ImageUrl },
                    ["Description"] = new AttributeValue { S = card.Description },
                    ["CreatedAt"] = new AttributeValue { S = card.CreatedAt.ToString("o") },
                    ["UpdatedAt"] = new AttributeValue { S = card.UpdatedAt.ToString("o") }
                };
                await _client.PutItemAsync(_tableName, item);
            }
            _logger.LogInformation("Successfully seeded {Count} test cards", testCards.Count);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error seeding test data: {Message}", ex.Message);
            throw;
        }
    }
}
