using CourierAPI.Helpers;
using CourierAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CourierAPI.Data;

public record Delivery
{

    public Delivery(InquiryDTO i) 
    {
        Status = DeliveryStatus.NotPickedUp;
        Name = i.Name;
        ClientId = 9999; // tmp change if needed
        Client = new Client(); // tmp
        StartLocationId = i.StartLocation.Id;
        StartLocation = new Location(i.StartLocation);
        EndLocationId = i.EndLocation.Id;
        EndLocation = new Location(i.EndLocation);
    }

    public Delivery() { Name = ""; Client = new Client(); }

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

