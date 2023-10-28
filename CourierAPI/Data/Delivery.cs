using CourierAPI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CourierAPI.Data;

public class Delivery
{
    [Key]
    public int Id { get; set; }
    [RequiredEnum]
    public DeliveryStatus Status { get; set; }
    public required string Name { get; set; }
    public required Location StartLocation { get; set; }
    public required Location EndLocation { get; set; }
    public DateTime PickedUpTime;
    public DateTime FinishedDeliveryTime;
}

