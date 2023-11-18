namespace CourierAPI.Data;

public record Client
{
    public int Id { get; init; }

    public ICollection<Delivery> Deliveries { get; init; }
}
