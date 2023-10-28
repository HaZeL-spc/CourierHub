using CourierAPI.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CourierAPI.Data;

public class Delivery
{
    public Delivery()
    {
        Name = "";
        Status = DeliveryStatus.NotPickedUp;
        StartLocation = new();
        EndLocation = new();
    }

    public Delivery(int id , string name, Location startLocation, Location endLocation)
    {
        Id = id;
        Name = name;
        Status = DeliveryStatus.NotPickedUp;
        StartLocation = startLocation;
        EndLocation = endLocation;
    }
    public Delivery(string name, Location startLocation, Location endLocation)
    {
        Name = name;
        Status = DeliveryStatus.NotPickedUp;
        StartLocation = startLocation;
        EndLocation = endLocation;
    }

    [Key]
    public int Id { get; set; }
    [RequiredEnum]
    public DeliveryStatus Status { get; set; }
    [Required]
    public string Name { get; set; }
    public Location? StartLocation { get; set; } // workaround because "Foreign key constraint may cause cycles or multiple cascade paths?"
    public Location? EndLocation { get; set; } // workaround because "Foreign key constraint may cause cycles or multiple cascade paths?"
    public DateTime PickedUpTime { get; set; }
    public DateTime FinishedDeliveryTime { get; set; }
}

