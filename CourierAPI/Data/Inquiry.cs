using CourierAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace CourierAPI.Data
{
    public record Inquiry
    {
        public double DimX { get; init; }
        public double DimY { get; init; }
        public double DimZ { get; init; }
        public double Weight { get; init; }
        public DateTime DeliveryDate { get; init; }
        public string Name { get; init; } = "";
        public virtual Location? StartLocation { get; init; } = new();
        public virtual Location? EndLocation { get; init; } = new();
        public bool HightPriority { get; init; }
        public bool WeekendDelivery { get; init; }
        public int Id { get; init; }
    }

    //public class Inquiry
    //{
    //    public Inquiry()
    //    {
    //        StartLocation = new Location();
    //        EndLocation = new Location();
    //    }
    //    public Inquiry(
    //        double dimX, double dimY, double dimZ, double weight,
    //        DateOnly deliveryDate, string name,
    //        Location startLocation, Location endLocation,
    //        bool hightPriority, bool weekendDelivery,
    //        int id = -1
    //        )
    //    {
    //        DimX = dimX; DimY = dimY; DimZ = dimZ;
    //        Weight = weight;
    //        DeliveryDate = deliveryDate;
    //        StartLocation = startLocation;
    //        EndLocation = endLocation;
    //        HightPriority = hightPriority;
    //        WeekendDelivery = weekendDelivery;
    //        Name = name;
    //        if (id != -1)
    //            Id = id;
    //    }

    //    [Required]
    //    public double DimX { get; set; }
    //    [Required]
    //    public double DimY { get; set; }
    //    [Required]
    //    public double DimZ { get; set; }
    //    [Required]
    //    public double Weight { get; set; }
    //    [Required]
    //    public DateOnly DeliveryDate { get; set; }
    //    [Required]
    //    public string Name { get; set; } = "";
    //    [Required]
    //    public Location StartLocation { get; set; }
    //    [Required]
    //    public Location EndLocation { get; set; }
    //    [Required]
    //    public bool HightPriority { get; set; }
    //    [Required]
    //    public bool WeekendDelivery { get; set; }
    //    [Key]
    //    public int Id { get; set; }
    //}
}
