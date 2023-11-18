using CourierCastingApp.DataTransferObjects;
using CourierCastingApp.Helpers;
using CourierCastingApp.Models;
using System.ComponentModel.DataAnnotations;

namespace CourierCastingApp.ViewModels
{
    public class DeliveryVm
    {
        public DeliveryVm(DeliveryDto delivery)
        {
            Id = delivery.Id;
            Status  = delivery.Status;
            Name = delivery.Name;
            StartLocation = new LocationVm(delivery.StartLocation);
            EndLocation = new LocationVm(delivery.EndLocation);
            PickedUpTime = delivery.PickedUpTime;
            FinishedDeliveryTime = delivery.FinishedDeliveryTime;
            ClientId = delivery.ClientId;
        }

        [Display(Name = "Identyfikator")]
        public int Id { get; set; }

        [Display(Name = "Status dostawy")]
        public DeliveryStatus Status { get; set; }

        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        [StringLength(50, ErrorMessage = "Nazwa nie może być dłuższa niż 50 znaków.")]
        public string Name { get; set; } = "";

        [Display(Name = "Punkt odbioru")]
        public LocationVm StartLocation { get; set; } = new LocationVm();

        [Display(Name = "Adres dostawy")]
        public LocationVm EndLocation { get; set; } = new LocationVm();

        [Display(Name = "Rozpoczęcie dostawy")]
        [DataType(DataType.DateTime)]
        public DateTime? PickedUpTime { get; set; }

        [Display(Name = "Zakończenie dostawy")]
        [DataType(DataType.DateTime)]
        public DateTime? FinishedDeliveryTime { get; set; }

        public bool ShouldDisplayPickedUpTime()
        {
            return Status == DeliveryStatus.PickedUp;
        }
        [Display(Name = "Klient")]
        public int ClientId { get; init; }

        public bool ShouldDisplayFinishedDeliveryTime()
        {
            return Status == DeliveryStatus.Delivered || Status == DeliveryStatus.Cancelled;
        }
    }
}
