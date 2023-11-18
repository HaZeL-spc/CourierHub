using CourierCastingApp.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CourierCastingApp.Models
{
    public record DeliveryDto
    {
        [Display(Name = "Identyfikator")]
        public required int Id { get; set; }

        [Display(Name = "Status dostawy")]
        public required DeliveryStatus Status { get; set; }

        [Display(Name = "Nazwa")]
        public required string Name { get; set; }

        [Display(Name = "Punkt odbioru")]
        public required LocationModel StartLocation { get; set; }

        [Display(Name = "Adres dostawy")]
        public required LocationModel EndLocation { get; set; }

        [Display(Name = "Rozpoczęcie dostawy")]
        public DateTime PickedUpTime { get; set; }

        [Display(Name = "Zakończenie dostawy")]
        public DateTime FinishedDeliveryTime { get; set; }

        public int ClientId { get; init; }

        [SetsRequiredMembers]
        public DeliveryDto(int id, string name, LocationModel startLocation, LocationModel endLocation)
        {
            Id = id;
            Status = DeliveryStatus.NotPickedUp;
            Name = name;
            StartLocation = startLocation;
            EndLocation = endLocation;
        }

        public bool ShouldDisplayPickedUpTime()
        {
            return Status == DeliveryStatus.PickedUp; 
        }

        public bool ShouldDisplayFinishedDeliveryTime()
        {
            return Status == DeliveryStatus.Delivered || Status == DeliveryStatus.Cancelled;
        }
    }
}
