namespace TCGStore.Api.Features.Inventory;

public record AddInventoryRequest(
    int CardId,
    int Quantity,
    int ReorderLevel,
    string? Location
);

public record UpdateQuantityRequest(
    int Quantity
);
