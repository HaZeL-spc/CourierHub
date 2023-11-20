using CourierAPI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CourierAPI.Data;

public record Delivery
{

    public int Id { get; set; }

    public DeliveryStatus Status { get; set; }

    public string Name { get; set; }
    public int ClientId { get; set; }
    public virtual Client Client { get; init; }
    public int StartLocationId { get; set; }
    public virtual Location? StartLocation { get; set; } // workaround because "Foreign key constraint may cause cycles or multiple cascade paths?"
    public int EndLocationId { get; set; } 
    public virtual Location? EndLocation { get; set; } // workaround because "Foreign key constraint may cause cycles or multiple cascade paths?"
    public DateTime PickedUpTime { get; set; }
    public DateTime FinishedDeliveryTime { get; set; }
}

