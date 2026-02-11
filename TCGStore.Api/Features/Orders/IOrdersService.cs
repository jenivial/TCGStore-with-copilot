namespace TCGStore.Api.Features.Orders;

public interface IOrdersService
{
    Task<IEnumerable<Order>> GetAllOrdersAsync();
    Task<Order?> GetOrderByIdAsync(int id);
    Task<Order> CreateOrderAsync(CreateOrderRequest request);
    Task<bool> UpdateOrderStatusAsync(int id, OrderStatus status);
}
