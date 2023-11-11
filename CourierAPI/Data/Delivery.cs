using CourierAPI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CourierAPI.Data;

public class Delivery
{
    [Key]
    public int Id { get; set; }
    [RequiredEnum]
    public DeliveryStatus Status { get; set; }
    [Required]
    public string Name { get; set; }
    public virtual Client Client { get; init; }
    public Location? StartLocation { get; set; } // workaround because "Foreign key constraint may cause cycles or multiple cascade paths?"
    public Location? EndLocation { get; set; } // workaround because "Foreign key constraint may cause cycles or multiple cascade paths?"
    public DateTime PickedUpTime { get; set; }
    public DateTime FinishedDeliveryTime { get; set; }
}

