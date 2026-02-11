using Amazon.DynamoDBv2.DataModel;

namespace TCGStore.Api.Features.Cards;

[DynamoDBTable("cards")]
public class Card
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
