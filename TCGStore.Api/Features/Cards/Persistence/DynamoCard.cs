using Amazon.DynamoDBv2.DataModel;

namespace TCGStore.Api.Features.Cards.Persistence;

[DynamoDBTable("cards")]
public class DynamoCard
{
    [DynamoDBHashKey]
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string SetName { get; set; }
    public string? SetCode { get; set; }
    public int CollectorNumber { get; set; }
    public required string Rarity { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}

public static class DynamoCardExtensions
{
    public static DynamoCard ToDynamoCard(this Card card)
    {
        return new DynamoCard
        {
            Id = card.Id,
            Name = card.Name,
            SetName = card.SetName,
            SetCode = card.SetCode,
            CollectorNumber = card.CollectorNumber,
            Rarity = card.Rarity,
            Price = card.Price,
            ImageUrl = card.ImageUrl,
            Description = card.Description,
            CreatedAt = card.CreatedAt,
            UpdatedAt = card.UpdatedAt
        };
    }

    public static Card ToCard(this DynamoCard dynamoCard)
    {
        return new Card
        {
            Id = dynamoCard.Id,
            Name = dynamoCard.Name,
            SetName = dynamoCard.SetName,
            SetCode = dynamoCard.SetCode,
            CollectorNumber = dynamoCard.CollectorNumber,
            Rarity = dynamoCard.Rarity,
            Price = dynamoCard.Price,
            ImageUrl = dynamoCard.ImageUrl,
            Description = dynamoCard.Description,
            CreatedAt = dynamoCard.CreatedAt,
            UpdatedAt = dynamoCard.UpdatedAt
        };
    }
}

