using CourierCastingApp.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CourierCastingApp.DataTransferObjects
{
    public record DeliveryDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public DeliveryStatus Status { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public LocationDto StartLocation { get; set; }
        [Required]
        public LocationDto EndLocation { get; set; }

        public DateTime? PickedUpTime { get; set; }

        public DateTime? FinishedDeliveryTime { get; set; }
        [Required]
        public int ClientId { get; init; }

        public DeliveryDto(int id, string name, LocationDto startLocation, LocationDto endLocation)
        {
            Id = id;
            Status = DeliveryStatus.NotPickedUp;
            Name = name;
            StartLocation = startLocation;
            EndLocation = endLocation;
        }

        public DeliveryDto()
        {

        }
    }
}
