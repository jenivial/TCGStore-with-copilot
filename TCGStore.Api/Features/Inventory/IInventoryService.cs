namespace TCGStore.Api.Features.Inventory;

public interface IInventoryService
{
    Task<IEnumerable<InventoryItem>> GetAllInventoryAsync();
    Task<InventoryItem?> GetInventoryByCardIdAsync(int cardId);
    Task<InventoryItem> AddInventoryAsync(AddInventoryRequest request);
    Task<bool> UpdateQuantityAsync(int id, int quantity);
}
