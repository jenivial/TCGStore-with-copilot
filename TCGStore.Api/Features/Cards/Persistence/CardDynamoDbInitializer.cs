using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Microsoft.Extensions.Options;

namespace TCGStore.Api.Features.Cards.Persistence;

public class CardDynamoDbInitializer(IDynamoDBContext context, ILogger<CardDynamoDbInitializer> logger)
{
    private readonly string _tableName = DynamoCardRepository.TableName;

    public async Task InitializeAsync()
    {
        try
        {
            // Only seed test data in development and if the table is empty
            await SeedTestDataAsync();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error during DynamoDB initialization: {Message}", ex.Message);
            throw;
        }
    }

    private async Task SeedTestDataAsync()
    {
        try
        {
            var seededCard = await context.LoadAsync<DynamoCard>("0DB433FE-C7CC-46A1-B813-95D9BCC94A91");
            if (seededCard is not null)
            {
                logger.LogInformation("Table {TableName} already contains data, skipping seed", _tableName);
                return;
            }

            logger.LogInformation("Seeding DynamoDB with test cards");
            var testCards = new List<DynamoCard>
            {
                new() { Id = "0DB433FE-C7CC-46A1-B813-95D9BCC94A91", Name = "Black Lotus", SetName = "Limited Edition Alpha", SetCode = "LEA", CollectorNumber = 1, Rarity = "Rare", Price = 10000.00m, ImageUrl = "https://example.com/black-lotus.jpg", Description = "Add three mana of any one color to your mana pool.", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new() { Id = "D24504F5-0C20-4477-85A9-5BE691CD7525", Name = "Charizard", SetName = "Base Set", SetCode = "BS", CollectorNumber = 4, Rarity = "Holographic Rare", Price = 5000.00m, ImageUrl = "https://example.com/charizard.jpg", Description = "Fire-breathing dragon Pokémon card.", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new() { Id = "A1B2C3D4-E5F6-47G8-H9I0-J1K2L3M4N5O6", Name = "Blue Eyes White Dragon", SetName = "Legend of Blue Eyes White Dragon", SetCode = "LOB", CollectorNumber = 1, Rarity = "Ultra Rare", Price = 3500.00m, ImageUrl = "https://example.com/blue-eyes.jpg", Description = "This legendary dragon is shrouded in mystery.", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new() { Id = "P7Q8R9S0-T1U2-43V4-W5X6-Y7Z8A9B0C1D2", Name = "Pikachu", SetName = "Base Set", SetCode = "BS", CollectorNumber = 25, Rarity = "Rare", Price = 2000.00m, ImageUrl = "https://example.com/pikachu.jpg", Description = "Electric-type Pokémon known for its lightning attacks.", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new() { Id = "E3F4G5H6-I7J8-49K0-L1M2-N3O4P5Q6R7S8", Name = "Twin Peaks", SetName = "Dual Masters", SetCode = "DM", CollectorNumber = 42, Rarity = "Super Rare", Price = 750.00m, ImageUrl = "https://example.com/twin-peaks.jpg", Description = "Powerful nature spell that doubles your mana reserves.", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
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
                await context.SaveAsync(card);
            }
            logger.LogInformation("Successfully seeded {Count} test cards", testCards.Count);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error seeding test data: {Message}", ex.Message);
            throw;
        }
    }
}
