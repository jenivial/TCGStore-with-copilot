namespace TCGStore.Api.Features.Orders;

public record CreateOrderRequest(
    int UserId,
    List<OrderItemRequest> Items
);

public record OrderItemRequest(
    int CardId,
    int Quantity
);

public record UpdateOrderStatusRequest(
    OrderStatus Status
);
