using CourierAPI.Helpers;

namespace CourierAPI.Models;

public record DeliveryDto(
    int Id, 
    DeliveryStatus Status, 
    string Name, 
    LocationDTO StartLocation,
    LocationDTO EndLocation, 
    DateTime PickedUptime, 
    DateTime FinishedDeliveryTime, 
    int ClientId)
{
    public DeliveryDto() : this(0, 0, "", new LocationDTO(), new LocationDTO(), DateTime.Now, 
        DateTime.Now, 0)
    { }
}
