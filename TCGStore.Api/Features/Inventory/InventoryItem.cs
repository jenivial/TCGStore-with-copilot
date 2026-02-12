namespace TCGStore.Api.Features.Inventory;

public class InventoryItem
{
    public int Id { get; set; }
    public int CardId { get; set; }
    public int Quantity { get; set; }
    public int ReorderLevel { get; set; }
    public string? Location { get; set; }
    public DateTime LastRestocked { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
