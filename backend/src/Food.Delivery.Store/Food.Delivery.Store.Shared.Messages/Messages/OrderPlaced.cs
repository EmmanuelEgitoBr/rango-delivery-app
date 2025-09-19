namespace Food.Delivery.Store.Shared.Messages.Messages;

public sealed record OrderPlaced
{
    public required Guid OrderId { get; init; }
    public required Guid CustomerId { get; init; }
    public required DateTime OrderDate { get; init; }
    public required List<OrderItem> Items { get; init; }
}
